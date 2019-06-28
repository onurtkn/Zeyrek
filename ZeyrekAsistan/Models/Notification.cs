using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeyrekAsistan.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime ShowDate { get; set; }
        public string NotificationCategory { get; set; }
        public string GroupOrUser { get; set; }
        public Notification(string title, string comment, DateTime showdate,string notificationcategory,string grouporuser)
        {
            Title = title;
            Comment = comment;
            ShowDate = showdate;
            NotificationCategory = notificationcategory;
            GroupOrUser = grouporuser;
        }
    }
}
