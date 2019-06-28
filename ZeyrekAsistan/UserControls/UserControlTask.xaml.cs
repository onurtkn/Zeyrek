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
using ZeyrekAsistan.ReadTasks;
using ZeyrekAsistan.Helper;


namespace ZeyrekAsistan.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlTask.xaml
    /// </summary>
    public partial class UserControlTask : UserControl
    {
  
        public UserControlTask()
        {
            InitializeComponent();
            var userName = Helper.UserHelper.GetUserName();
            ListViewTasks.ItemsSource  = Helper.TaskHelper.GetTaskList(userName, "Task");
        }
        

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
