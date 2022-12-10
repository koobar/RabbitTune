using Microsoft.VisualBasic.ApplicationServices;
using System.Linq;

namespace RabbitTune
{
    internal class App : WindowsFormsApplicationBase
    {
        // コンストラクタ
        public App()
        {
            this.IsSingleInstance = !ApplicationOptions.AllowMultiInstance;
            this.MainForm = new MainForm();
            this.StartupNextInstance += new StartupNextInstanceEventHandler(App_StartupNextInstance);
        }

        /// <summary>
        /// アプリケーションのメインフォームを取得する。
        /// </summary>
        /// <returns></returns>
        public MainForm GetMainForm()
        {
            return (MainForm)this.MainForm;
        }

        /// <summary>
        /// アプリケーションの実行を開始する。
        /// </summary>
        /// <param name="args"></param>
        public new void Run(string[] args)
        {
            var form = GetMainForm();
            form.SetCommandLineArguments(args);

            base.Run(args);
        }

        private void App_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            var form = GetMainForm();

            form.SetCommandLineArguments(e.CommandLine.ToArray());
            form.ProcessCommandLineArguments();
        }
    }
}
