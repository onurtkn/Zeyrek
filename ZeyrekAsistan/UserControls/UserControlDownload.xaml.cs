using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZeyrekAsistan.Models;

namespace ZeyrekAsistan.UserControls
{
    /// <summary>
    /// Kullanıcı tarafından seçilecek uygulamaları ekrana yansıtmak için oluşturuldu.
    /// </summary>
    public partial class UserControlDownload : UserControl
    {
        public UserControlDownload()
        {
            InitializeComponent();
            FillApps();
        }
        private void FillApps()
        {

            var products = GetAllApplications();
            if (products.Count > 0)
                ListViewProducts.ItemsSource = products;
        }
        private List<ApplicationsForDownload> GetAllApplications()
        {
            return new List<ApplicationsForDownload>()
          {
            new ApplicationsForDownload("7-Zip", "/Assets/7zip.png","7z1900-x64.exe"),
            new ApplicationsForDownload("Java", "/Assets/java.png",""),
            new ApplicationsForDownload(".Net Framework", "/Assets/Microsoft.png",""),
            new ApplicationsForDownload("Visual Studio", "/Assets/VS.png",""),
            new ApplicationsForDownload("Adobe Reader", "/Assets/Adobe.png",""),
            new ApplicationsForDownload("Firefox", "/Assets/Firefox.png",""),
            new ApplicationsForDownload("Opera", "/Assets/opera.png",""),
            new ApplicationsForDownload("Google Chrome", "/Assets/chrome.png","")
          };
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            try
            {
                var obj = ((ApplicationsForDownload)((System.Windows.FrameworkElement)sender).DataContext);
                if (obj != null)
                {

                    MessageBoxResult result = MessageBox.Show(string.Format("{0} isimli uygulamayı bilgisayarınıza kurmak istediğinize emin misiniz?", obj.Name), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Helper.ApplicationHelper.InstallApplication(obj.ApplicationPath);
                    }   
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
