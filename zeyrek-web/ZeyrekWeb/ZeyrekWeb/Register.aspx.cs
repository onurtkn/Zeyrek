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
    public partial class Register : System.Web.UI.Page
    {
        string UserName;
        string UpdateUserName;

        string UserQuestion1 = "", UserQuestion2 = "", UserQuestion3 = "";
        string UserAnswer1 = "", UserAnswer2 = "", UserAnswer3 = "";
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
            if (UpdateUserName == UserNameTxt.Text)
            {
                if (GuvSorTxt1.Text != "" && GuvCevTxt1.Text != "" && GuvSorTxt2.Text != "" && GuvCevTxt2.Text != "" && GuvSorTxt3.Text != "" && GuvCevTxt3.Text != "")
                {
                    //Questions and Answers encryption for security 
                    UserQuestion1 = CreatCrypto(GuvSorTxt1.Text);
                    UserQuestion2 = CreatCrypto(GuvSorTxt2.Text);
                    UserQuestion3 = CreatCrypto(GuvSorTxt3.Text);

                    //Questions and Answers encryption for security 
                    UserAnswer1 = CreatCrypto(GuvCevTxt1.Text);
                    UserAnswer2 = CreatCrypto(GuvCevTxt2.Text);
                    UserAnswer3 = CreatCrypto(GuvCevTxt3.Text);

                    //Password Web Service Read
                    PasswordWebReference.PasswordOperations ws = new PasswordWebReference.PasswordOperations();
                    ws.setPasswordQ(UpdateUserName, UserQuestion1, UserQuestion2, UserQuestion3, UserAnswer1, UserAnswer2, UserAnswer3);

                    GuvSorTxt1.Text = ""; GuvSorTxt2.Text = ""; GuvSorTxt3.Text = "";
                    GuvCevTxt1.Text = ""; GuvCevTxt2.Text = ""; GuvCevTxt3.Text = "";

                    HataLb.Text = "Güvenlik sorularınız başarılı bir şekilde değiştirilmiştir.";
                }

                else
                {
                    HataLb.Text = "Lüfren tüm alanları doldurunuz.";
                }
            }
            else
            {
                HataLb.Text = "Bu işlemi yanlızca kendi bilgisayarınızdan yapabilirsiniz.";
            }

        }
    }
}