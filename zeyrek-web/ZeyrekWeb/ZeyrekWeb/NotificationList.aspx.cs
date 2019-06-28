using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZeyrekWeb
{
    public partial class NotificationList : System.Web.UI.Page
    {
        //Notification Web Service Read
        NotificationWebReference.ReadNotifications ws = new NotificationWebReference.ReadNotifications();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["GroupId"] == "1")
                GetNotificationEveryone();

            if (Request.QueryString["GroupId"] == "2")
                GetNotificationUser();
        }
        private void GetNotificationEveryone()
        {
            //ZNotification Web Service Read
            NotificationWebReference.ZNotification[] arr = ws.ZReadNotification(DateTime.Now, Session["username"].ToString());
            foreach (var item in arr)
            {
                //Html Writing
                if (item.GroupOrUser == "Everyone")
                    BildirimLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td></tr>";
            }
        }
        private void GetNotificationUser()
        {
            //ZNotification Web Service Read
            NotificationWebReference.ZNotification[] arr = ws.ZReadNotification(DateTime.Now, Session["username"].ToString());
            foreach (var item in arr)
            {
                //Html Writing
                if (item.GroupOrUser == Session["username"].ToString())
                    BildirimLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td></tr>";
            }
        }
    }
}