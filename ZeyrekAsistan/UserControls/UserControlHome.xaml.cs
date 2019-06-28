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
using ZeyrekAsistan.Helper;

namespace ZeyrekAsistan.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlHome.xaml
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        private int OptimizedTime = 50;
        public string Parameter { get; set; }
        public int RemainingTime { get; set; }
        public UserControlHome(string parameter)
        {
            Parameter = parameter;
            InitializeComponent();
            InitCustom();
            
        }

        private void InitCustom()
        {
            var userName = UserHelper.GetUserName();
            FillNumberData(userName);

            Consumo consumo = new Consumo(Parameter, OptimizedTime);
            DataContext = new ConsumoViewModel(consumo);

            txtMola.Text=OptimizedTime - Int32.Parse(Parameter)>0? (OptimizedTime - Int32.Parse(Parameter)).ToString()+" dakika sonra mola verin" : "Hemen mola verin";
        }

        private void FillNumberData(string userName)
        {
            var approval = Helper.TaskHelper.GetTaskList(userName, "Approval");
            if (approval != null)
            {
                txtApprovalCount.Text = approval.Count.ToString();
            }

            var tasks = Helper.TaskHelper.GetTaskList(userName, "Task");
            if (tasks != null)
            {
                txtTaskCount.Text = tasks.Count.ToString();
            }

            var notifications = Helper.NotificationHelper.GetNotificationsByNumber(userName, 0, 2);
            if (notifications.Count > 0)
            {
                txtNdateFirst.Text = notifications[0].ShowDate.ToShortDateString();
                txtNhourFirst.Text = notifications[0].ShowDate.ToShortTimeString();
                txtNTitleFirst.Text = notifications[0].Title;

                txtNdateSecond.Text = notifications[1].ShowDate.ToShortDateString();
                txtNhourSecond.Text = notifications[1].ShowDate.ToShortTimeString();
                txtNTitleSecond.Text = notifications[1].Title;
            }
            


        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
            
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    internal class ConsumoViewModel
    {
        public List<Consumo> Consumo { get; private set; }

        public ConsumoViewModel(Consumo consumo)
        {
            Consumo = new List<Consumo>();
            Consumo.Add(consumo);
        }
    }

    internal class Consumo
    {
     
        public string Titulo { get; private set; }
        public int Porcentagem { get; private set; }

        public Consumo(string parameter,int optimizeTime)
        {
            
            var duration = Int32.Parse(parameter);
            var remainingTime = optimizeTime - duration;
            Titulo = "Mola vermeden geçen süre " + duration +" dakika" ;


            Porcentagem = 100;
            if (remainingTime > 0)
            {
                double yuzde = (double)duration/(double)optimizeTime;
                Porcentagem = (int)Math.Floor(yuzde*100);
            }
            
           
        }

       
    }
}
