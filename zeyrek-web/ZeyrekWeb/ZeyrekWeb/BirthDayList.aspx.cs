using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZeyrekWeb
{
    public partial class BirthDayList : System.Web.UI.Page
    {
        BirthDayWebReference.ReadBirthDays ws = new BirthDayWebReference.ReadBirthDays();
        protected void Page_Load(object sender, EventArgs e)
        {
            //BirthDay Web Service Read
            BirthDayWebReference.ZBirthD[] arr = ws.getBirthdayList();
            foreach (var item in arr)
            {
                //Html Writing
                BildirimLt.Text += "<tr><td>" + item.AdSoyad + "</td><td><a href='#' class='btn btn-info btn-icon-split'><span class='icon text-white-50'><i class='fas fa-info-circle'></i></span><span class='text'>Doğum Günü Kutla</span></a></td></tr>";
            }
        }
    }
}