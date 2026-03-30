using Bcart受注管理.AppData;
using Bcart受注管理.Forms;
using Bcart受注管理.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;

namespace Bcart受注管理
{
    internal static class Program
    {
        /// <summary>
        /// ロガー
        /// </summary>
        public readonly static NLog.Logger ScLogger = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// ホスト
        /// </summary>
        private static readonly IHost _host;

        /// <summary>
        /// 静的コンストラクタ
        /// 依存関係を挿入したインスタンスを返すホストを生成
        /// </summary>
        static Program()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Services.AddHttpClient(
                Settings.Default.BCartHttpClientName,
                client =>
                {
                    // Set the base address of the named client.
                    client.BaseAddress = new Uri(Settings.Default.BCartApiBaseUrl);
                    // 認可ヘッダー
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Default.BCartApiToken);
                });
            builder.Services.AddTransient<OrderService>();
            builder.Services.AddTransient<OrderProductService>();
            builder.Services.AddTransient<LogisticService>();
            builder.Services.AddTransient<CustomerService>();

            _host = builder.Build();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ScLogger.Info($"{nameof(Main)}を実行します,Version={Settings.Default.Version}");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());


            // アプリケーションの初期化
            PublicData.Init();

            // 補足されなかった例外のイベントハンドラー
            Application.ThreadException += new
                ThreadExceptionEventHandler(Application_ThreadException);
            Thread.GetDomain().UnhandledException += new
                UnhandledExceptionEventHandler(Application_UnhandledException);

            DialogResult retFormResult = DialogResult.OK;

            // 2024/05/17 お客様との打合せで不要と合意
            //// ログイン画面の表示
            //using (frmLogin fLogin = new frmLogin())
            //{
            //    retFormResult = fLogin.ShowDialog();
            //}

            if (retFormResult == DialogResult.OK)
            {
                // メニューの表示
                using (frmMenu frmMenu = new frmMenu())
                {
                    retFormResult = frmMenu.ShowDialog();
                }
            }

            /// アプリケーションの終了
            BeforeExitApp();

            ScLogger.Info($"{nameof(Main)}を終了します");
        }

        /// <summary>
        /// アプリケーションの終了前処理
        /// </summary>
        private static void BeforeExitApp()
        {
            ScLogger.Info($"{nameof(BeforeExitApp)}を実行します");
            _host.Dispose();
            Settings.Default.Save();
        }

        /// <summary>
        /// インスタンスを返す
        /// </summary>
        /// <typeparam name="T">要求するクラス</typeparam>
        /// <returns>要求されたクラスのインスタンス</returns>
        /// <exception cref="NullReferenceException">インスタンスがnullなら例外をスロー</exception>
        public static T GetService<T>()
        {
            var obj = _host.Services.GetService<T>();
            return obj == null ? throw new NullReferenceException($"型:{nameof(T)}の取得に失敗しました") : obj;
        }

        /// <summary>
        /// Windowsフォーム・アプリケーションのメイン・スレッド（＝ApplicationクラスのRunメソッドにより実行されるアプリケーションのコンテキスト）内で発生した未処理の例外をハンドルする
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベントパラメータ</param>
        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("予期しないエラーが発生しました。アプリケーションを終了します。", "受注管理");

            ScLogger.Error($"{nameof(Application_ThreadException)}で例外を補足しました");
            ScLogger.Error($"e={e}");
            ScLogger.Error($"e.Exception={e.Exception}");
            ScLogger.Error($"e.Exception.Message={e.Exception.Message}");
            ScLogger.Error($"e.Exception.StackTrace={e.Exception.StackTrace}");
            ScLogger.Error($"e.Exception.InnerException={e.Exception.InnerException}");
            ScLogger.Error($"e.Exception.Source={e.Exception.Source}");

            /// アプリケーションの終了
            BeforeExitApp();
            Application.Exit();
        }

        /// <summary>
        /// メイン・スレッド以外で発生した未処理の例外をハンドルする
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベントパラメータ</param>
        public static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("予期しないエラーが発生しました。アプリケーションを終了します。", "受注管理");

            ScLogger.Error($"{nameof(Application_UnhandledException)}で例外を補足しました");
            ScLogger.Error($"e={e}");
            ScLogger.Error($"e.ExceptionObject={e.ExceptionObject}");
            if (e.ExceptionObject is Exception exceptionObj)
            {
                ScLogger.Error($"Message={exceptionObj.Message}");
                ScLogger.Error($"StackTrace={exceptionObj.StackTrace}");
                ScLogger.Error($"InnerException={exceptionObj.InnerException}");
                ScLogger.Error($"Source={exceptionObj.Source}");
            }

            /// アプリケーションの終了
            BeforeExitApp();
            Application.Exit();
        }
    }
}