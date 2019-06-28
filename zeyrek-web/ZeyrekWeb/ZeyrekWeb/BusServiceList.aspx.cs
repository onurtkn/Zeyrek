using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZeyrekWeb
{
    public partial class BusServiceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //BusService Web Service Read
            BusServiceWebReference.GetBusService ws = new BusServiceWebReference.GetBusService();
            BusServiceWebReference.ZBusSrv[] arr = ws.getBusServiceList();
            foreach (var item in arr)
            {
                //Html Writing
                BildirimLt.Text += "<tr><td>" + item.ServisGuzergahi + "</td><td>" + item.Plaka + "</td><td>" + item.SurucuAd + "</td><td>" + item.SurucuTel + "</td></tr>";
            }
        }
    }
}