using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBulkActivator
{
    public class Log
    {
        public static Queue<string> tuPush = new Queue<string>();

        public static void Push(string msg) =>
            tuPush.Enqueue($"[{DateTime.Now.ToString("HH:mm")}]: {msg}");
    }
}
