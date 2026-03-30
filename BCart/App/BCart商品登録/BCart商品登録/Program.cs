using BCart商品登録;
using BCart商品登録.Forms;
using System.Configuration;
using System.IO;

namespace BCart商品登録
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new frmMenu());

            try
            {
                if(!Path.Exists(ConfigurationManager.AppSettings["LogPath"]))
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["LogPath"]);
                }
            }
            catch { }

            BCartApi.Log.Write(string.Format("起動 {0}", Settings.Default.Version));


            frmMenu f = new frmMenu();
            f.ShowDialog();

            BCartApi.Log.Write(string.Format("終了 {0}", Settings.Default.Version));

        }
    }
}