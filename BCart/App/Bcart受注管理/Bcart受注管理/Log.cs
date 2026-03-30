using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcart受注管理
{
    internal static class Log
    {
        public enum Level
        { Info, Warning, Error }

        public static void ErrWrite(string msg, Exception? ex = null)
        {
            Write(msg, Level.Error, ex);
        }

        public static void Write(string msg, Level lv = Level.Info, Exception? ex = null)
        {
            string fName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + string.Format("_{0:yyyyMMdd}.log", DateTime.Now);
            string p = Settings.Default.LogPath;
            if(string.IsNullOrEmpty(p) )
                p = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Logs");
            if(!Path.Exists(p) )
                Directory.CreateDirectory(p);

            string logPath = Path.Combine(p, fName);
            string currentExecutable = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true, Encoding.UTF8))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(DateTime.Now.ToLongTimeString());
                    sb.Append(" ");
                    sb.Append(currentExecutable);
                    sb.Append("[");
                    switch (lv)
                    {
                        case Level.Info:
                            sb.Append("INF");
                            break;
                        case Level.Warning:
                            sb.Append("WAR");
                            break;
                        case Level.Error:
                            sb.Append("ERR");
                            break;
                    }
                    sb.Append("]");
                    sb.Append(msg);
                    if (ex != null)
                    {
                        sb.Append("\n");
                        sb.Append(ex.ToString());
                    }

                    sw.WriteLine(sb.ToString());
                    sw.Flush();
                    sw.Close();
                }

            }
            catch { }

        }
    }
}
