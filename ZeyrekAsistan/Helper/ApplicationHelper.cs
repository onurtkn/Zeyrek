using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeyrekAsistan.Helper
{
    public static class ApplicationHelper
    {
        /// <summary>
        /// local bilgisayarda bulunan bir uygulamayı kurmak için
        /// </summary>
        /// <param name="applicationPath">program exe dosyasının dosya yolu</param>
        public static void InstallApplication(string applicationPath)
        {
            var proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.FileName = applicationPath;
            proc.LoadUserProfile = true;
            Process.Start(proc);
        }

        /// <summary>
        /// Domain üzerinden kurulum yapmak için
        /// </summary>
        /// <param name="applicationPath"></param>
        /// <param name="workingDirectory"></param>
        public static void InstallApplication(string applicationPath,string workingDirectory,string domain, string verb, string adminUserName, string adminPassword)
        {
            var proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = workingDirectory;
            proc.FileName = applicationPath; //domainden kurulurken kullanılacak kod
            proc.Domain = "hvlnet"; //domainden kurulurken kullanılacak kod
            proc.Verb = "runas"; 
            proc.LoadUserProfile = true;
            proc.UserName = adminUserName; //domainden kurulurken kullanılacak kod
            //proc.Password = Helper.ConvertToSecureString(adminPassword); //domainden kurulurken kullanılacak kod
            Process.Start(proc);
        }
    }
}
