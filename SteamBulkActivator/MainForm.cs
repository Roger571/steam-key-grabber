using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Steam4NET;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Management;
using System.Security.Cryptography;
using System.Drawing.Imaging;

namespace SteamBulkActivator
{
    public partial class MainForm : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=setting/groups.mdb;";

        private OleDbConnection myConnection;

        Account account = new Account();


        private const int HT_CAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int _eM_SETCUEBANNER = 0x1501;

        private int _user, _pipe;
        private int _registerDelay;
        private bool _waitingForActivationResp = false;
        private bool _txtKeysCleared = false;

        private ISteam006 _steam006;
        private IClientUser _clientUser;
        private IClientEngine _clientEngine;
        private IClientBilling _clientBilling;
        private ISteamClient012 _steamClient012;

        private ResultForm _result;
        private List<string> _cdKeyList;
        private BackgroundWorker _callbackBwg;
        private BackgroundWorker _purchaseBwg;

        private Color _buttonBackgroundNormal = Color.FromArgb(36, 41, 45);
        private Color _buttonBackgroundHover = Color.FromArgb(15, 174, 220);

        private BrowserForm _browserForm;

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }
        public void MainForm_Shown(object sender, EventArgs e)
        {
            CreateFileTxt("setting/account.txt");
        }
        public void CreateFileTxt(string files)
        {
            if (!File.Exists(files))
                File.Create(files).Close();
        }

        //private static string GetHWID()
        //{
        //    var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
        //    ManagementObjectCollection mbsList = mbs.Get();
        //    string id = "";
        //    foreach (ManagementObject mo in mbsList)
        //    {
        //        id = mo["ProcessorId"].ToString();
        //        break;
        //    }

        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(id));
        //    string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);

        //    return result;
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            //string site = "https://dark-game-tested.000webhostapp.com/hwid.txt";

            //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            //using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            //{
            //    // MessageBox.Show(stream.ReadToEnd());
            //    Clipboard.SetText(GetHWID());

            //    if (!Regex.IsMatch(stream.ReadToEnd(), GetHWID()))
            //    {
            //        MessageBox.Show("Забыл купить программу? Солнышко, я напомнил.");
            //        Close();
            //    }
            //}
            CreateFileTxt("setting/account.txt");
          
            if (connectToSteam())
            {
                while (!_clientUser.BLoggedOn())
                {
                    var diagRes = MessageBox.Show("Вы не вошли в Steam-аккаунт", "DLC for Steam", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (diagRes == DialogResult.Cancel)
                    {
                        Environment.Exit(1);
                    }
                    else
                    {
                        if (!connectToSteam())
                        {
                            MessageBox.Show("Отсутствует подключение к Steam.", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Environment.Exit(1);
                        }
                    }
                }

                panelMain.Visible = true;
                panelLoading.Visible = false;

                _cdKeyList = new List<string>();
                ActiveControl = lbl_KeyCount;
                txtKeys.Text = $"Enter your keys here\n\n{Utils.GetRandomCDKey()}\n{Utils.GetRandomCDKey()}\n{Utils.GetRandomCDKey()}\n{Utils.GetRandomCDKey()}";

                _callbackBwg = new BackgroundWorker() { WorkerSupportsCancellation = true };
                _callbackBwg.DoWork += _callbacks_DoWork;
                _callbackBwg.RunWorkerCompleted += _callbacks_RunWorkerCompleted;

                _purchaseBwg = new BackgroundWorker() { WorkerSupportsCancellation = true };
                _purchaseBwg.DoWork += _purchaseBwg_DoWork;
            }
        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void topSpacer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pic_MoveForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btn_Github_Click(object sender, EventArgs e)
        {
            Process.Start("https://vk.com/aim_100");
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Scrape_Click(object sender, EventArgs e)
        {
            if (_browserForm == null)
                _browserForm = new BrowserForm();

            _browserForm.ShowDialog();
        }
        bool start_search = false;
        int all_keys = 0;

        void btn_Register_Click(object sender, EventArgs e)
        {
            account.Auth();

            btn_Register.Text = "VkAuth OK | Сканирование базы..";
            btn_Register.Enabled = false;

            string query = "SELECT group_id, pin FROM group_info ORDER BY ID";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string response = account._api.Invoke(@"wall.get", new Dictionary<string, string>()
                {
                    ["owner_id"] = reader[0].ToString(),
                    ["count"] = reader[1].ToString(),
                    ["access_token"] = account._api.Token,
                    ["v"] = "5.53"
                });

                JObject parse_wall_get = JObject.Parse(response);

                foreach (var a in parse_wall_get["response"]["items"])
                {
                    string query_update = $"UPDATE group_info SET prev_wall_id ={a["id"]},wall_date ={a["date"]} WHERE group_id ='{reader[0]}'";

                    OleDbCommand update_command = new OleDbCommand(query_update, myConnection);
                    update_command.ExecuteNonQuery();
                }
            }

            
            //Bitmap bmp = new Bitmap("image4.png");
            //List<Color> lst = new List<Color>();
            //Color c;
            //for (int x = 2; x < bmp.Width; x++)
            //{
            //    c = bmp.GetPixel(x, 2);
            //    if (!lst.Contains(c))
            //        lst.Add(c);
            //    c = bmp.GetPixel(x, bmp.Height - 3);
            //    if (!lst.Contains(c))
            //        lst.Add(c);
            //}
            //for (int y = 0; y < bmp.Height; y++)
            //{
            //    c = bmp.GetPixel(2, y);
            //    if (!lst.Contains(c))
            //        lst.Add(c);
            //    c = bmp.GetPixel(31, y);
            //    if (!lst.Contains(c))
            //        lst.Add(c);
            //    c = bmp.GetPixel(90, y);
            //    if (!lst.Contains(c))
            //        lst.Add(c);
            //    c = bmp.GetPixel(bmp.Width - 3, y);
            //    if (!lst.Contains(c))
            //        lst.Add(c);
            //}
            //for (int x = 0; x < bmp.Width; x++)
            //{
            //    for (int y = 0; y < bmp.Height; y++)
            //    {
            //        c = bmp.GetPixel(x, y);
            //        if (lst.Contains(c))
            //        {
            //            if (c != Color.White)
            //                FloodFill(bmp, x, y, Color.White);
            //        }
            //    }
            //}

            //Ocr ocr = new Ocr();

            ////Input
            //tessnet2.Tesseract tessocr = new tessnet2.Tesseract();
            //tessocr.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-");
            //tessocr.Init(null, "eng", false);
            //List<tessnet2.Word> text = ocr.DoOCRNormal((Bitmap)bmp, "eng");
            //MessageBox.Show(text[0].Text);

            ////Filled
            //tessocr = new tessnet2.Tesseract();
            //tessocr.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-");
            //tessocr.Init(null, "eng", false);
            //text = ocr.DoOCRNormal((Bitmap)bmp, "eng");
            //MessageBox.Show(text[0].Text);

            // Включаем даем true для проверки которая находиться в таймере, чтобы программа начала делать свое.
            btn_Register.Text = "VkAuth OK | Поиск ключей..";
            start_search = true;
        }

       

        //void FloodFill(Bitmap bitmap, int x, int y, Color color)
        //{
        //    BitmapData data = bitmap.LockBits(
        //        new Rectangle(0, 0, bitmap.Width, bitmap.Height),
        //        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        //    int[] bits = new int[data.Stride / 4 * data.Height];
        //    Marshal.Copy(data.Scan0, bits, 0, bits.Length);

        //    LinkedList<Point> check = new LinkedList<Point>();
        //    int floodTo = color.ToArgb();
        //    int floodFrom = bits[x + y * data.Stride / 4];
        //    bits[x + y * data.Stride / 4] = floodTo;

        //    if (floodFrom != floodTo)
        //    {
        //        check.AddLast(new Point(x, y));
        //        while (check.Count > 0)
        //        {
        //            Point cur = check.First.Value;
        //            check.RemoveFirst();

        //            foreach (Point off in new Point[] {
        //    new Point(0, -1), new Point(0, 1),
        //    new Point(-1, 0), new Point(1, 0)})
        //            {
        //                Point next = new Point(cur.X + off.X, cur.Y + off.Y);
        //                if (next.X >= 0 && next.Y >= 0 &&
        //                    next.X < data.Width &&
        //                    next.Y < data.Height)
        //                {
        //                    if (bits[next.X + next.Y * data.Stride / 4] == floodFrom)
        //                    {
        //                        check.AddLast(next);
        //                        bits[next.X + next.Y * data.Stride / 4] = floodTo;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    Marshal.Copy(bits, 0, data.Scan0, bits.Length);
        //    bitmap.UnlockBits(data);
        //}

        //public class Ocr
        //{
        //    public List<tessnet2.Word> DoOCRNormal(Bitmap image, string lang)
        //    {
        //        tessnet2.Tesseract ocr = new tessnet2.Tesseract();
        //        ocr.Init(null, lang, false);
        //        List<tessnet2.Word> result = ocr.DoOCR(image, Rectangle.Empty);
        //        return result;
        //    }
        //}



        void tmr_Update_Tick(object sender, EventArgs e)
        {
            if (start_search == true)
            {
                string query = "SELECT group_id, wall_date, total_minutes FROM group_info ORDER BY ID";

                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                    int startTimestamp = Convert.ToInt32(reader[1]);

                    var start = unixEpoch.AddSeconds(startTimestamp);
                    var end = DateTime.UtcNow;

                    var duration = end - start;

                    int minute = Convert.ToInt32(reader[2]);
                    
                    if (duration.TotalMinutes >= minute)
                    {
                        next_key(reader[0].ToString());
                    }
                }
                reader.Close();
            }
        }

        void next_key(string owner_id)
        {
            int post_id = 0;
            int post_count = 1;
            int prev_post_id = 0;
            int wall_date = 0;

            string post_text = "";
            string query = $"SELECT prev_wall_id, pin FROM group_info WHERE group_id ='{owner_id}'";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                prev_post_id = Convert.ToInt32(reader[0]);
                post_count = Convert.ToInt32(reader[1]);
            }

            string response = account._api.Invoke(@"wall.get", new Dictionary<string, string>()
            {
                ["owner_id"] = owner_id,
                ["count"] = post_count.ToString(),
                ["access_token"] = account._api.Token,
                ["v"] = "5.53"
            });

            JObject parse_wall_get = JObject.Parse(response);

            foreach (var a in parse_wall_get["response"]["items"])
            {
                post_text = a["text"].ToString();
                wall_date = Convert.ToInt32(a["date"]);
                post_id = Convert.ToInt32(a["id"]);
            }

            if (post_id != prev_post_id)
            {
                List<string> patterns = new List<string> { @"\w{5}-\w{5}-\w{5}", @"\w{5}-\w{5}-\w{5}-\w{5}-\w{5}", @"\w{15} \w{2}" };

                foreach (var pattern in patterns)
                {
                    if (Regex.IsMatch(post_text, pattern))
                    {
                        string query_update = $"UPDATE group_info SET prev_wall_id ={post_id},wall_date ={wall_date} WHERE group_id ='{owner_id}'";

                        OleDbCommand update_command = new OleDbCommand(query_update, myConnection);
                        update_command.ExecuteNonQuery();

                        var matches = Regex.Matches(post_text, String.Format(@"(?<![\w-]){0}(?![\w-]{0})(?![\w-]{0})", pattern));
                        txtKeys.Items.Add(String.Join(", ", matches.Cast<Match>().Select(m => m.Value)));

                        all_keys++;
                        var tempList = new List<string>();
                        tempList.Add(String.Join(", ", matches.Cast<Match>().Select(m => m.Value)));
                        _cdKeyList = tempList;
                        lbl_KeyCount.Text = $"Всего ключей: {all_keys}";

                        PlaySound(@"C:\WINDOWS\Media\town.wav", UIntPtr.Zero, 0);

                        registerKeys();
                    }
                }
            }
        }

        

        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);
        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }
        private void txtKeys_Enter(object sender, EventArgs e)
        {
            if (!_txtKeysCleared)
            {
                _txtKeysCleared = true;
                txtKeys.Text = string.Empty;
                txtKeys.ForeColor = Color.FromArgb(223, 233, 233);
            }
        }

        private void txtKeys_TextChanged(object sender, EventArgs e)
        {
            addKeysToList();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            txtKeys.Text = txtKeys.Text.Trim();
            txtKeys.Text += "\n";
            //txtKeys.DeselectAll();
            //txtKeys.SelectionStart = txtKeys.Text.Length;

            ActiveControl = panelHeader;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (_txtKeysCleared)
            {
                ActiveControl = txtKeys;
            }
        }

        private void btn_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_Close.Image = Properties.Resources.close_bg_hover;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_Close.Image = Properties.Resources.close_bg;
        }

        private void btn_Min_MouseEnter(object sender, EventArgs e)
        {
            btn_Min.Image = Properties.Resources.min_bg_hover;
        }

        private void btn_Min_MouseLeave(object sender, EventArgs e)
        {
            btn_Min.Image = Properties.Resources.min_bg;
        }

        private void btn_Github_MouseEnter(object sender, EventArgs e)
        {
            btn_Github.BackColor = _buttonBackgroundHover;
        }

        private void btn_Github_MouseLeave(object sender, EventArgs e)
        {
            btn_Github.BackColor = _buttonBackgroundNormal;
        }

        private void btn_Donate_MouseEnter(object sender, EventArgs e)
        {
            btn_Donate.BackColor = _buttonBackgroundHover;
            panelDonate.Visible = true;
        }

        private void btn_Donate_MouseLeave(object sender, EventArgs e)
        {
            btn_Donate.BackColor = _buttonBackgroundNormal;

            if (!panelContainsMouse(panelDonate))
                panelDonate.Visible = false;
        }

        private void panelDonate_MouseLeave(object sender, EventArgs e)
        {
            panelDonate.Visible = false;
        }

        private void btn_Paypal_MouseEnter(object sender, EventArgs e)
        {
            btn_Paypal.BackColor = _buttonBackgroundHover;
        }

        private void btn_Paypal_MouseLeave(object sender, EventArgs e)
        {
            btn_Paypal.BackColor = _buttonBackgroundNormal;

            if (!panelContainsMouse(panelDonate))
                panelDonate.Visible = false;
        }

        private void btn_Bitcoin_MouseEnter(object sender, EventArgs e)
        {
            btn_Bitcoin.BackColor = _buttonBackgroundHover;
        }

        private void btn_Bitcoin_MouseLeave(object sender, EventArgs e)
        {
            btn_Bitcoin.BackColor = _buttonBackgroundNormal;

            if (!panelContainsMouse(panelDonate))
                panelDonate.Visible = false;
        }

        private void panelDonateBottomSpacer_MouseLeave(object sender, EventArgs e)
        {
            if (!panelContainsMouse(panelDonate))
                panelDonate.Visible = false;
        }

        private void panelDonateTopSpacer_MouseLeave(object sender, EventArgs e)
        {
            if (!panelContainsMouse(panelDonate))
                panelDonate.Visible = false;
        }

        private void _purchaseBwg_DoWork(object sender, DoWorkEventArgs e)
        {
            while (_result != null && !_result.Visible)
                Thread.Sleep(100);

            var cdkeys = (List<string>)e.Argument;
            for (int i = 0; i < cdkeys.Count; i++)
            {
                if (_purchaseBwg.CancellationPending)
                    break;

                _waitingForActivationResp = true;
                string pchActivationCode = cdkeys[i];
                _clientBilling.PurchaseWithActivationCode(pchActivationCode);

                if (i + 1 < cdkeys.Count)
                {
                    if (_registerDelay != 0)
                        Thread.Sleep(_registerDelay);
                }

                while (_waitingForActivationResp)
                    Thread.Sleep(50);
            }

            completedRegistration();
        }

        private void _callbacks_DoWork(object sender, DoWorkEventArgs e)
        {
            CallbackMsg_t callbackMsg = new CallbackMsg_t();
            while (!_callbackBwg.CancellationPending)
            {
                while (Steamworks.GetCallback(_pipe, ref callbackMsg) && !_callbackBwg.CancellationPending)
                {
                    switch (callbackMsg.m_iCallback)
                    {
                        case PurchaseResponse_t.k_iCallback:
                            onPurchaseResponse((PurchaseResponse_t)Marshal.PtrToStructure(callbackMsg.m_pubParam, typeof(PurchaseResponse_t)));
                            break;
                    }

                    Steamworks.FreeLastCallback(_pipe);
                }

                Thread.Sleep(100);
            }
        }

        private void _callbacks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (e.Error != null)
                MessageBox.Show($"Uhhh...\n\n{e.Error}", "Callback error");
        }

        private void onPurchaseResponse(PurchaseResponse_t callback)
        {
            EPurchaseResultDetail result = (EPurchaseResultDetail)callback.m_EPurchaseResultDetail;
            switch (result)
            {
                case EPurchaseResultDetail.k_EPurchaseResultTooManyActivationAttempts:
                    _purchaseBwg.CancelAsync();
                    completedRegistration();
                    break;
            }

            //_result.AddResult(Utils.GetFriendlyEPurchaseResultDetailMsg(result)); // тут баг краш при валидном ключе
            _waitingForActivationResp = false;
        }

        private void registerKeys()
        {
            _registerDelay = (int)num_RegDelay.Value;

            _purchaseBwg.RunWorkerAsync(_cdKeyList);
            _callbackBwg.RunWorkerAsync();

            _result = new ResultForm(_cdKeyList, _registerDelay);
            //_result.ShowDialog();
            txtKeys.Text = string.Empty;
        }

        private void completedRegistration()
        {

            _callbackBwg.CancelAsync();
            _result.Completed = true;
        }

        private void addKeysToList(bool regexCheck = true)
        {
            if (!_txtKeysCleared)
                return;

            var tempList = new List<string>();

            string cdKeyPattern = @"([A-Za-z0-9]+)(-([A-Za-z0-9]+)){2,}";
            foreach (Match m in Regex.Matches(txtKeys.Text, cdKeyPattern))
            {
                if (tempList.Contains(m.Value))
                    continue;

                tempList.Add(m.Value);
            }
            _cdKeyList = tempList;
            lbl_KeyCount.Text = $"Всего ключей: {_cdKeyList.Count}";
        }

        private bool panelContainsMouse(Panel panel)
        {
            return panelDonate.ClientRectangle.Contains(panelDonate.PointToClient(Cursor.Position));
        }

        private void btn_Paypal_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.paypal.me/");
            panelDonate.Visible = false;
            ShowLoveGif();
        }

        private void ShowLoveGif()
        {
            pic_MoveForm.Image = Properties.Resources.heart_animation_ps;
            tmr_LoveAnimation.Stop();
            tmr_LoveAnimation.Start();
        }

        private void tmr_LoveAnimation_Tick(object sender, EventArgs e)
        {
            tmr_LoveAnimation.Stop();
            pic_MoveForm.Image = null;
        }

        private void btn_Bitcoin_Click(object sender, EventArgs e)
        {
            panelBitcoin.Visible = true;
            panelDonate.Visible = false;

            txt_BitcoinAddress.SelectAll();
            txt_BitcoinAddress.Focus();
            ShowLoveGif();
        }

        private void panelBitcoin_MouseLeave(object sender, EventArgs e)
        {
            if (!panelBitcoin.ClientRectangle.Contains(panelBitcoin.PointToClient(Cursor.Position)))
                panelBitcoin.Visible = false;
        }

        private void panelBitcoinBottomSpacer_MouseLeave(object sender, EventArgs e)
        {
            panelBitcoin.Visible = false;
        }

        private void btn_Donate_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private bool connectToSteam()
        {
            var steamError = new TSteamError();

            if (!Steamworks.Load(true))
            {
                lblError.Text = "Steamworks failed to load.";
                return false;
            }

            _steam006 = Steamworks.CreateSteamInterface<ISteam006>();
            if (_steam006.Startup(0, ref steamError) == 0)
            {
                lblError.Text = "Пожалуйста, включите программу Steam.";
                return false;
            }

            _steamClient012 = Steamworks.CreateInterface<ISteamClient012>();
            _clientEngine = Steamworks.CreateInterface<IClientEngine>();

            _pipe = _steamClient012.CreateSteamPipe();
            if (_pipe == 0)
            {
                lblError.Text = "Failed to create user pipe.";
                return false;
            }

            _user = _steamClient012.ConnectToGlobalUser(_pipe);
            if (_user == 0 || _user == -1)
            {
                lblError.Text = "Failed to connect to global user.";
                return false;
            }
            
            _clientBilling = _clientEngine.GetIClientBilling<IClientBilling>(_user, _pipe);
            _clientUser = _clientEngine.GetIClientUser<IClientUser>(_user, _pipe);
            return true;
        }
    }

    public static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}

