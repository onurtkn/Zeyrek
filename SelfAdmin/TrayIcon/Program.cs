using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security;

namespace TrayIcon
{
    class Program
    {
        static int workTime = 0;
        static bool birsaat = true;


        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static Thread workTimeThread;
        static Thread workTimeControlThread;
        static Thread readNotificationThread;


        public static ContextMenuStrip menu;

        public static ToolStripItem executeInstaller;
        public static ToolStripItem Worktime;
        public static ToolStripItem MenuExit;
        public static ToolStripLabel serialNoLabel;
        public static ToolStripLabel userNameLabel;
        

        public static ToolTipIcon workicon;

        public static string userName = "";


        public static NotifyIcon notificationIcon;
        static void Main(string[] args)
        {
            /*
            Console ekranı ayarı
            */

            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);

            /*
            Ana notification icon
            */

            Thread notifyThread = new Thread(
            delegate ()
            {
                menu = new ContextMenuStrip();
                userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                MenuExit = new ToolStripMenuItem();
                MenuExit.Image = System.Drawing.Image.FromFile(@"Resources\Icons\exit.png");
                MenuExit.Click += Exit_Click;
                MenuExit.Text = "Çıkış";

                Worktime = new ToolStripMenuItem();
                Worktime.Image = System.Drawing.Image.FromFile(@"Resources\Icons\work.png");
                Worktime.Click += Worktime_Click;
                Worktime.Text = "Çalışma Zamanı";

                executeInstaller = new ToolStripMenuItem();
                executeInstaller.Image = System.Drawing.Image.FromFile(@"Resources\Icons\run.png");
                executeInstaller.Click += ExecuteInstaller_Click; ;
                executeInstaller.Text = "Zeyrek Asistan";

                serialNoLabel = new ToolStripLabel();
                serialNoLabel.Image = System.Drawing.Image.FromFile(@"Resources\Icons\barcode.png");
                //executeInstaller.Click += ExecuteInstaller_Click; ;
                serialNoLabel.Text = Helper.GetBIOSserNo();

                userNameLabel = new ToolStripLabel();
                userNameLabel.Image = System.Drawing.Image.FromFile(@"Resources\Icons\user.png");
                //executeInstaller.Click += ExecuteInstaller_Click; ;
                userNameLabel.Text = userName;

               

               
                menu.Items.Add(userNameLabel);
                menu.Items.Add(serialNoLabel);
                menu.Items.Add(MenuExit);
                menu.Items.Add(Worktime); 
                menu.Items.Add(executeInstaller);
                notificationIcon = new NotifyIcon()
                {
                    Icon = new System.Drawing.Icon(@"Resources\Icons\try.ico"), // Properties.Resources.Services,
                    ContextMenuStrip = menu,
                    Text = "Zeyrek"
                };


                Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);
                




                notificationIcon.Visible = true;
                Application.Run();

                
            }
        );

            notifyThread.Start();

            /*
            Bilgisayar seri numarası kayıt
            */

            ZWebServiceSerial.InsertSerial insserial = new ZWebServiceSerial.InsertSerial();
            insserial.SetSerial(userName, Helper.GetBIOSserNo());

            workTimeControlThread = new Thread(
                   delegate ()
                   {
                       while (true)
                       {
                           if ((workTime / 60) == 1 && birsaat)
                           {
                               notificationIcon.ShowBalloonTip(5000, "Sağlığınız İçin!", (workTime / 60) + "Dakikadır çalışıyorsunuz. Ara vermek ister misiniz?", ToolTipIcon.Warning);
                               birsaat = false;
                               break;
                           }
                           Thread.Sleep(1000);
                       }
                       
                   }
               );

            workTimeControlThread.Start();

            ////////////////////////

            
            /*
             Notification okuma
             */
            

            readNotificationThread = new Thread(
               
            delegate ()
                   {
                       
                       while (true)
                       {
                           try
                           {
                               ZWebService.ReadNotifications rn = new ZWebService.ReadNotifications();
                               string tmp = userName.Substring(userName.IndexOf(@"\"), (userName.Length - userName.IndexOf(@"\")));
                               ZWebService.ZNotification[] notifyArray = rn.ZReadNotification(DateTime.Now, tmp);
                               foreach (var item in notifyArray)
                               {
                                   DateTime dt = DateTime.Now;
                                   if (dt.Month == item.ShowDate.Month && dt.Day == item.ShowDate.Day && dt.Year == item.ShowDate.Year && dt.Hour == item.ShowDate.Hour && dt.Minute == item.ShowDate.Minute)
                                   {
                                       notificationIcon.ShowBalloonTip(5000, item.Title, item.Comment, ToolTipIcon.Info);
                                       break;
                                   }
                               }
                           }
                           catch (Exception)
                           {

                               
                           }
                                            
                               
                           
                           Thread.Sleep(30000);
                       }

                   }
               );

            readNotificationThread.Start();


            ///////////////////////////






            

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            //Console.ReadLine();
        }


        /*
            kontrol ekranı aç
            */
        private static void ExecuteInstaller_Click(object sender, EventArgs e)
        {
            //var proc = new ProcessStartInfo();
            //proc.UseShellExecute = false;            
            ////proc.WorkingDirectory = @"\\10.150.0.15\programs\7zip";
            //proc.FileName = @"\\10.150.0.15\programs\FileZilla\FileZilla_3.34.0_win64-setup_bundled.exe";
            ////proc.Domain = "hvlnet";
            ////proc.Verb = "runas";
            ////proc.LoadUserProfile = true;
            //proc.UserName = "Hvladmin";
            //proc.Password = Helper.ConvertToSecureString("H@v!CaN.");
            //Process.Start(proc);

            var proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            //proc.WorkingDirectory = @"\\10.150.0.15\programs\7zip";
            proc.FileName = @"ZeyrekAsistan.exe";
            proc.Arguments = (workTime / 60)+"";
            //proc.Domain = "hvlnet";
            //proc.Verb = "runas";
            //proc.LoadUserProfile = true;
            //proc.UserName = "Hvladmin";
            //proc.Password = SS.ConvertToSecureString("H@v!CaN.");
            Process.Start(proc);

        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            
        }

        private static void Worktime_Click(object sender, EventArgs e)
        {
            notificationIcon.ShowBalloonTip(5000, "Çalışma Süreniz", (workTime/60)+" Dakika", ToolTipIcon.Warning);
        }

        private static void Exit_Click(object sender, EventArgs e)
        {
            notificationIcon.Dispose();
            Environment.Exit(0);
        }
        static void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                //I left my desk
                //Console.WriteLine("I left my desk");
                notificationIcon.ShowBalloonTip(5000, "Sağlığınız İçin!", "Bu gün kaç bardak su içtiniz?", ToolTipIcon.Warning);
                workTime = 0;
                if (workTimeThread!=null)
                {
                    if (workTimeThread.IsAlive)
                    {
                        workTimeThread.Abort();
                    }
                }
               
               
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                //I returned to my desk
                //Console.WriteLine("I returned to my desk");
                //notificationIcon.ShowBalloonTip(5000, "Çalışma Zamanınız", "I returned to my desk", ToolTipIcon.Warning);

                workTimeThread = new Thread(
                    delegate ()
                    {
                        while (true)
                        {
                            workTime++;
                            Thread.Sleep(1000);
                        }
                    }
                );

                workTimeThread.Start();

            }
        }

    }
}
