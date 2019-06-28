using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ZeyrekAsistan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            // Application is running
     

            var parameter = "100";
            if(e.Args.Length>0)
            {
                parameter = e.Args[0];
            }
            //MessageBoxResult result = MessageBox.Show(parameter);
           MainWindow mainWindow = new MainWindow(parameter);
            
            mainWindow.Show();
        }

    }
}
