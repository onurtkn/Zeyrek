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
using ZeyrekAsistan.Models;
using ZeyrekAsistan.ReadNotifications;
using ZeyrekAsistan.Helper;

namespace ZeyrekAsistan.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlNotificationList.xaml
    /// </summary>
    /// 
   
    public partial class UserControlNotificationList : UserControl
    {
      
        public IList<ZNotification> NotificationList { get; }

        public UserControlNotificationList()
        {
            var userName = UserHelper.GetUserName();
            NotificationList =NotificationHelper.GetAllNotification(userName);
            InitializeComponent();
        }
       
    }

   
}
