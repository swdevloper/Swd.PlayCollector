using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using log4net;
using System.Reflection;
using Swd.PlayCollector.GuiWpf.View;

namespace Swd.PlayCollector.GuiWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(App));



        private void Application_Startup(object sender, StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            Log.Debug(string.Format("{0} Application starting", MethodBase.GetCurrentMethod().Name));
            

            fMain w = new fMain();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Width = 1024;
            w.Height = 600;
            w.Title = "PlayCollector";
            w.Show();


        }


    }
}
