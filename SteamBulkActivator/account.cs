using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model.RequestParams;
using VkNet.Model;
using System.IO;
using System.Windows.Forms;
using VkNet.Enums.Filters;

namespace SteamBulkActivator
{
    public class Account
    {
        public VkApi _api = new VkApi();
        public void Auth()
        {
            if (!_api.IsAuthorized)
            {
                var data = File.ReadAllLines("setting/account.txt");
                foreach (var acc in data)
                {
                    _api.Authorize(new ApiAuthParams()
                    {
                        Login = acc.Split(':')[0],
                        Password = acc.Split(':')[1],
                        ApplicationId = 7202880,
                        Settings = Settings.All
                    });
                }
            }
        }
    }
}
