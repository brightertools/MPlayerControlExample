using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayerTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.Run(new Form1());

            System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
            frm.Height = 600;
            frm.Width = 800;

            LibMPlayerWinform.WinFormMPlayerControl playerControl = new LibMPlayerWinform.WinFormMPlayerControl();
            var player = LibMPlayerCommon.PlayerFactory.Get(playerControl.Handle, GetMediaPlayerPath());
            playerControl.SetPlayer(player);
            playerControl.Dock = DockStyle.Fill;
            playerControl.MPlayerPath = GetMediaPlayerPath();
            playerControl.VideoPath = GetMediaPath();
            frm.Controls.Add(playerControl);

            Application.Run(frm);
        }

        private static string GetMediaPlayerPath()
        {
            return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "MediaPlayer.exe");
        }

        private static string GetMediaPath()
        {
            return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "ScreenSoda1.mp4");
        }
    }
}
