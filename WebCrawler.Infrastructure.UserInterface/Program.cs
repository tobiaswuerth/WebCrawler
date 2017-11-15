using System;
using System.Windows.Forms;
using ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Controller;

namespace ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormSplashscreen formSplashscreen = new FormSplashscreen();
            formSplashscreen.Show();
            Application.DoEvents();

            FormWebCrawlerController formWebCrawlerController = new FormWebCrawlerController();
            FormWebCrawler formWebCrawler = new FormWebCrawler(formWebCrawlerController);
            formWebCrawler.Show();

            formSplashscreen.Close();
            Application.Run(formWebCrawler);
        }
    }
}