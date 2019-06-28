using System;
using System.Collections.Generic;
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
using ZeyrekAsistan.UserControls;
using ZeyrekAsistan.Helper;

namespace ZeyrekAsistan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Parameter { get; set; }
        public MainWindow(string parameter)
        {
            Parameter = parameter;
            InitializeComponent();
            InitCustom();
        }
        private void InitCustom()
        {
            var usc = new UserControlHome(Parameter); //sayfa ilk açıldığında anasayfa için oluşturulan usercontrol açılıyor
            GridMain.Children.Add(usc);

            txtUserName.Text = UserHelper.GetUserName();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
      

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlHome(Parameter);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemNotification":
                    usc = new UserControlNotificationList();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemDownload":
                    usc = new UserControlDownload();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemApproval":
                    usc = new UserControlApproval();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemTask":
                    usc = new UserControlTask();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
