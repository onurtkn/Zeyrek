using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZeyrekWeb
{
    public partial class Default : System.Web.UI.Page
    {
        string UserName;
        string UpdateUserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Get windows user name 
                UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                UpdateUserName = UserName.Substring(UserName.IndexOf(@"\"), UserName.Length - UserName.IndexOf(@"\"));
                UpdateUserName = UpdateUserName.Replace(@"\", "");

                //User name session writing
                Session["username"] = UpdateUserName;
            }

            GetNotification(); //Notification Call
            GetTask(); //Task Call
        }

        private void GetTask()
        {
            int gorevsay = 0;
            int onaysay = 0;

            //Task Web Service Read
            TaskWebReference.ReadTask tws = new TaskWebReference.ReadTask();
            TaskWebReference.ZTask[] taskarr = tws.ZReadTask("ecosar");

            foreach (var item in taskarr)
            {
                if (item.Type == "Task")
                {
                    //Task Html Writing
                    GorevLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td><td>" + item.EndDate.ToShortDateString() + "</td></tr>";
                    gorevsay++;
                }

                if (item.Type == "Approval")
                {
                    //Task Html Writing
                    GorevLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td><td>" + item.EndDate.ToShortDateString() + "</td></tr>";
                    onaysay++;
                }

            }

            //Task and Approve Count Writing
            GorevLb.Text = gorevsay.ToString();
            OnayLb.Text = onaysay.ToString();
        }

        private void GetNotification()
        {
            int bildirimsay = 0;

            //Notification Web Service Read
            NotificationWebReference.ReadNotifications ws = new NotificationWebReference.ReadNotifications();
            NotificationWebReference.ZNotification[] arr = ws.ZReadNotification(DateTime.Now, "ecosar");

            foreach (var item in arr)
            {
                //Notification Html Writing
                BildirimLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td></tr>";
                bildirimsay++;
            }
            
            BildirimLb.Text = bildirimsay.ToString(); //Notification Count Writing
        }
    }
}