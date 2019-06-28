using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyrekAsistan.ReadNotifications;

namespace ZeyrekAsistan.Helper
{
    public static class NotificationHelper
    {

        /// <summary>
        /// Web servisten bildirim litesini çekiyor
        /// </summary>
        /// <param name="userName">Bilgisayarı açan kullanıcı</param>
        /// <returns></returns>
        public static List<ZNotification> GetAllNotification(string userName)
        {
            ReadNotifications.ReadNotifications rd = new ReadNotifications.ReadNotifications();
            var notification = rd.ZReadNotification(DateTime.Now, userName);

            return notification.ToList();
        }

        public static List<ZNotification> GetNotificationsByNumber(string userName,int startIndex, int endIndex)
        {
            ReadNotifications.ReadNotifications rd = new ReadNotifications.ReadNotifications();
            var notification = rd.ZReadNotification(DateTime.Now, userName).OrderBy(s=>s.ShowDate);

            return notification.Take(endIndex-startIndex).ToList();
        }

    }
}
