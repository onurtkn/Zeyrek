using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZeyrekWeb
{
    public partial class TaskList : System.Web.UI.Page
    {
        TaskWebReference.ReadTask tws = new TaskWebReference.ReadTask();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["GroupId"] == "1")
                GetTaskEvraka();
            if (Request.QueryString["GroupId"] == "2")
                GetTaskSap();
            if (Request.QueryString["GroupId"] == "3")
                GetTaskSharePoint();
            if (Request.QueryString["GroupId"] == "4")
                GetTaskKyokm();
            if (Request.QueryString["GroupId"] == "5")
                GetTaskJira();
            if (Request.QueryString["GroupId"] == "6")
                GetTaskTfs();
        }
        private void GetTaskEvraka()
        {
            //ZTask Web Service Read
            TaskWebReference.ZTask[] taskarr = tws.ZReadTask(Session["username"].ToString());
            TitleLb.Text = "EVRAKA Bekleyen İşlemler";
            foreach (var item in taskarr)
            {
                if (item.Source == "EVRAKA")
                {
                    //Html Writing
                    GorevLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td><td>" + item.EndDate.ToShortDateString() + "</td><td>" + item.Type + "</td></tr>";
                }
            }
        }

        private void GetTaskSap()
        {
            //ZTask Web Service Read
            TaskWebReference.ZTask[] taskarr = tws.ZReadTask(Session["username"].ToString());
            TitleLb.Text = "SAP Bekleyen İşlemler";
            foreach (var item in taskarr)
            {
                if (item.Source == "SAP")
                {
                    //Html Writing
                    GorevLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td><td>" + item.EndDate.ToShortDateString() + "</td><td>" + item.Type + "</td></tr>";
                }
            }
        }

        private void GetTaskSharePoint()
        {
            //ZTask Web Service Read
            TaskWebReference.ZTask[] taskarr = tws.ZReadTask(Session["username"].ToString());
            TitleLb.Text = "SHAREPOINT Bekleyen İşlemler";
            foreach (var item in taskarr)
            {
                if (item.Source == "SHAREPOINT")
                {
                    //Html Writing
                    GorevLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td><td>" + item.EndDate.ToShortDateString() + "</td><td>" + item.Type + "</td></tr>";
                }
            }
        }

        private void GetTaskKyokm()
        {
            //ZTask Web Service Read
            TaskWebReference.ZTask[] taskarr = tws.ZReadTask(Session["username"].ToString());
            TitleLb.Text = "KYOKM Bekleyen İşlemler";
            foreach (var item in taskarr)
            {
                if (item.Source == "KYOKM")
                {
                    //Html Writing
                    GorevLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td><td>" + item.EndDate.ToShortDateString() + "</td><td>" + item.Type + "</td></tr>";
                }
            }
        }
        private void GetTaskJira()
        {
            //ZTask Web Service Read
            TaskWebReference.ZTask[] taskarr = tws.ZReadTask(Session["username"].ToString());
            TitleLb.Text = "JIRA Bekleyen İşlemler";
            foreach (var item in taskarr)
            {
                if (item.Source == "JIRA")
                {
                    GorevLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td><td>" + item.EndDate.ToShortDateString() + "</td><td>" + item.Type + "</td></tr>";
                }
            }
        }
        private void GetTaskTfs()
        {
            //ZTask Web Service Read
            TaskWebReference.ZTask[] taskarr = tws.ZReadTask(Session["username"].ToString());
            TitleLb.Text = "TFS Bekleyen İşlemler";
            foreach (var item in taskarr)
            {
                if (item.Source == "TFS")
                {
                    //Html Writing
                    GorevLt.Text += "<tr><td>" + item.Title + "</td><td>" + item.Comment + "</td><td>" + item.EndDate.ToShortDateString() + "</td><td>" + item.Type + "</td></tr>";
                }
            }
        }
    }
}