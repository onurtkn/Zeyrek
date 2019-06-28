using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZeyrekWeb
{
    public partial class ForgotPass : System.Web.UI.Page
    {
        string UserName;
        string UpdateUserName;

        string SoruTxt = "", CevapTxt = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static string CreatCrypto(string sifrelenecekMetin)
        {
            //Questions and Answers encryption for security 
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();

            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

        protected void KaydetBtn_Click(object sender, EventArgs e)
        {
            if (SifreTxt.Text != "" && SifreTekrarTxt.Text != "")
            {
                if (SifreTxt.Text == SifreTekrarTxt.Text)
                {
                    //Active directory connect
                }
                else
                {
                    HataLb.Text = "Girdiğiniz şifreler uyuşmamaktadır.";
                }
            }
            else
            {
                HataLb.Text = "Lütfen tüm alanları doldurunuz.";
            }
            SifrePnl.Visible = false;
        }

        protected void SifirlaBtn_Click(object sender, EventArgs e)
        {
            //Password Web Service Read
            PasswordWebReference.PasswordOperations ws = new PasswordWebReference.PasswordOperations();
            PasswordWebReference.ZPassword arr = ws.getPasswordQ(UpdateUserName);

            //Questions and Answers encryption for security 
            SoruTxt = CreatCrypto(GuvSorTxt.Text);
            CevapTxt = CreatCrypto(GuvCevTxt.Text);
            
            if (SoruTxt == arr.Question1 || SoruTxt == arr.Question2 || SoruTxt == arr.Question3)
            {
                if (CevapTxt == arr.Answer1 || CevapTxt == arr.Answer2 || CevapTxt == arr.Answer3)
                {
                    SifrePnl.Visible = true;
                }
                else
                {
                    //Cevap Hatalı
                }
            }
            else
            {
                //Soru Hatalı
            }
        }
    }
}