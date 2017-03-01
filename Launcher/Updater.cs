using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public static class Updater
    {
        static readonly string version = "1.0";

        public static void CheckUpdates()
        {
            var t = new Task(new Action(CompareWithGitHub));
            t.Start();
        }

        private static void CompareWithGitHub()
        {
            using (var client = new WebClient())
            {
                var data = client.DownloadString("https://raw.githubusercontent.com/lyftzeigen/SnakeBattle/master/README.md");
                var v = data.Split('\n')[1].Split(' ')[1];

                if (version != v)
                {
                    MessageBox.Show("Update available!\n" +
                        "Please check new version: https://github.com/lyftzeigen/SnakeBattle", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}