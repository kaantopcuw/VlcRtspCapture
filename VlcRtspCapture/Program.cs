using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VlcRtspCapture
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            string vlcSource = @"C:\PROGRA~1\VideoLAN\VLC\vlc.exe";
            string rtpsUrl = "URL";
            string fileName = now.ToString("yyyy-MM-ddTHH-mm-ss") + ".mp4";

            string cmdString = $@"{vlcSource} -vvv {rtpsUrl} --run-time 11 --stop-time 11  --sout ""#transcode{{acodec=none}}:file{{dst=C:\Users\Ali\Desktop\{fileName},no-overwrite}}"" vlc://quit";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(cmdString);
            cmd.StandardInput.Flush();
            System.Threading.Thread.Sleep(2000);
            cmd.Kill();

        }
    }
}
