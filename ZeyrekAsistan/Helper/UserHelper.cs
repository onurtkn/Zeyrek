using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeyrekAsistan.Helper
{
    static class UserHelper
    {
        /// <summary>
        /// Bilgisayara giriş yapmış kullanıcının adını getiriyor
        /// </summary>
        /// <returns>Bilgisayar kullanıcı adı</returns>
        public static string GetUserName()
        {
            var userName = string.Empty;
            var current = System.Security.Principal.WindowsIdentity.GetCurrent();
            if (current != null)
            {
                userName = current.Name;
                userName = userName.Split(new[] { "\\" }, StringSplitOptions.None)[1]; //kullanıcı adı desktop-12\\havelsan şeklinde geldiği için split ediliyor
            }
          
            return userName;
        }
    }
}
