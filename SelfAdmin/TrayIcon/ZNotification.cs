using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrayIcon
{
    class ZNotification
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RepeatPeriod { get; set; }
        public string GroupOrUser { get; set; }

        public string Notification { get; set; }
    }
}
