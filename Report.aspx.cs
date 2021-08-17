using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ReportERP
{
    public partial class Report : System.Web.UI.Page
    {
        private string appHostUrl = ConfigurationManager.AppSettings["appUrl"];

        private string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        private string dataUrl = ConfigurationManager.AppSettings["expenseReportUrl"]; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string searchText = string.Empty;

                if (Request.QueryString["searchText"] != null)
                {
                    searchText = Request.QueryString["searchText"].ToString();
                }


                try
                {

               

                if (Request.QueryString["TypeId"] != null)
                {
                    switch (Request["TypeId"])
                    {
                        case  "1":
                            OpexRequisition("");
                            break;

                        case "2":
                            CARequisition("");
                            break;
                        case "3":
                            OpexPayment("");
                            break;
                        case "4":
                            OutstandingCA("");
                            break;
                        case "5":
                            IndPaymentD();
                            break;
                        case "6":
                            Mis();
                            break;
                        default:
                            break;
                    }
                }

                }
                catch (Exception)
                {

                
                }

                // IndPaymentD();
                // OpexPayment("");
                // CARequisition("");
                //CACallOverPostD();
                //OpexCallOverPostD();

                // OutstandingCA("");
                //   this.ReportBind();
            }

            ReportViewer1.Drillthrough += new DrillthroughEventHandler(ReportViewer1_MIS);
            ReportViewer1.Drillthrough += new DrillthroughEventHandler(ReportViewer1_IndPayD);

            ReportViewer1.Drillthrough += new DrillthroughEventHandler(ReportViewer1_Drillthrough);

        }

        private void OutstandingCA2()
        {
            //Dataset. Load data into the dataset
            var dt = new ReportData();
            var table1 = dt.OutstandingCAData();
            DataSet ds = new DataSet();
            ds.Tables.Add(table1);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/OutstandingCA.rdlc");
            ReportDataSource datasource = new ReportDataSource("OutstandingCA", ds.Tables[0]);
            ReportViewer1.Width = 1000;
            ReportViewer1.Height = 700;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

        }
        private void OpexRequisition(string token)
        {
            //Dataset. Load data into the dataset

            //1. instantiate the parameters
            var sdate = Request["SDate"];
            var edate = Request["EDate"];
            var user = Request["user"];
            var expenseReqUrl = ConfigurationManager.AppSettings["expenseReportUrl"];
            this.dataUrl = expenseReqUrl + "?sDate=" + sdate + "&eDate=" + edate + "&user=" + user;

            var dt = new ReportData();
            var table1 = dt.OpexRequisition("", this.baseUrl, this.dataUrl, "");
            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            //2. declare/define the url endpoint that will fetch data
         //   this.dataUrl = "ExpenseReportService/GetListOpexRequistion";// + date + "&TenantId=" + TId;

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/OpexRequisition.rdlc");
            ReportDataSource datasource = new ReportDataSource("OpexRequisition", ds.Tables[0]);
            ReportViewer1.Width = 1000;
            ReportViewer1.Height = 700;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.AsyncRendering = false;
            ReportViewer1.KeepSessionAlive = true;

        }

        private void OpexPayment(string token)
        {
            //Dataset. Load data into the dataset



            ////1. instantiate the parameters          
            var sdate = Request["SDate"];
            var edate = Request["EDate"];

            var expenseurl = ConfigurationManager.AppSettings["paymentReportUrl"];
            this.dataUrl = expenseurl + "?sDate=" + sdate + "&eDate=" + edate;


            var dt = new ReportData();
            var table1 = dt.OpexPayment("", this.baseUrl, this.dataUrl, "");
            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            //2. declare/define the url endpoint that will fetch data
         
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/OpexPayment.rdlc");
            ReportDataSource datasource = new ReportDataSource("OPEXPAYMENT", ds.Tables[0]);
            ReportViewer1.Width = 1000;
            ReportViewer1.Height = 700;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

        }
        //private void OpexPayment()
        //{
        //    //Dataset. Load data into the dataset

        //    //1. instantiate the parameters
        //    //var TId = Request["TId"];
        //    //var date = Request["date"];
        //    //var dTime = Request["gDate"];

        //    var dt = new ReportData();
        //    var table1 = dt.OpexPayment();
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(table1);

        //    //2. declare/define the url endpoint that will fetch data
        //   // this.dataUrl = "ExpenseReportService/GetListOpexPayment";// + date + "&TenantId=" + TId;

        //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/OpexPayment.rdlc");
        //    ReportDataSource datasource = new ReportDataSource("OPEXPAYMENT", ds.Tables[0]);
        //    ReportViewer1.Width = 1000;
        //    ReportViewer1.Height = 700;
        //    ReportViewer1.LocalReport.DataSources.Clear();
        //    ReportViewer1.LocalReport.DataSources.Add(datasource);

        //}

        private void IndPaymentD()
        {
            //Dataset. Load data into the dataset

            //1. instantiate the parameters          
            var dt = new ReportData();
            var table1 = dt.IndPaymentD();
            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            //2. declare/define the url endpoint that will fetch data
            // this.dataUrl = "ExpenseReportService/GetListOpexPayment";// + date + "&TenantId=" + TId;

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/IndPayD.rdlc");
            ReportDataSource datasource = new ReportDataSource("indPay", ds.Tables[0]);
            ReportViewer1.Width = 1000;
            ReportViewer1.Height = 700;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

        }

        private void Mis()
        {

            var dt = new ReportData();
            var table1 = dt.Mis();
            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            //2. declare/define the url endpoint that will fetch data
            // this.dataUrl = "ExpenseReportService/GetListOpexPayment";// + date + "&TenantId=" + TId;

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/MIS.rdlc");
            ReportDataSource datasource = new ReportDataSource("MIS", ds.Tables[0]);
            ReportViewer1.Width = 1000;
            ReportViewer1.Height = 700;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

        }

        private void CARequisition(string token)
        {
            //Dataset. Load data into the dataset

            //1. instantiate the parameters  
            var sdate = Request["sdate"];
            var edate = Request["edate"];
            var user = Request["user"];
            //2. declare/define the url endpoint that will fetch data
            var expenseurl = ConfigurationManager.AppSettings["CaReqReportUrl"];
            this.dataUrl = expenseurl + "?sDate=" + sdate + "&eDate=" + edate + "&user=" + user;

            var dt = new ReportData();
            var table1 = dt.CARequisition("", this.baseUrl, this.dataUrl, "");
            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/CARequisition.rdlc");
            ReportDataSource datasource = new ReportDataSource("CARequisition", ds.Tables[0]);
            ReportViewer1.Width = 1000;
            ReportViewer1.Height = 700;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

        }
        private void OutstandingCA(string token)
        {
            //Dataset. Load data into the dataset

            ////1. instantiate the parameters
            var sdate = Request["sdate"];
            var edate = Request["edate"];


            //2. declare/define the url endpoint that will fetch data           
            var expenseurl = ConfigurationManager.AppSettings["outstReportUrl"];
            this.dataUrl = expenseurl + "?sDate=" + sdate + "&eDate=" + edate ;

            var dt = new ReportData();
            var table1 = dt.OutstandingCA("", this.baseUrl, this.dataUrl, "");
            DataSet ds = new DataSet();
            ds.Tables.Add(table1);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/OutstandingCA.rdlc");
            ReportDataSource datasource = new ReportDataSource("OutstandingCA", ds.Tables[0]);
            ReportViewer1.Height = 700;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

        }

        protected void ReportViewer1_MIS(object sender, DrillthroughEventArgs e)
        {


          
            var parentId = "0";
            var MIS = "";

            ReportParameterInfoCollection itemList = e.Report.GetParameters();

            foreach (var d in itemList)
            {
                parentId = d.Values[0].ToString().Trim();

             

            }
          //  this.dataUrl = "FinanceReportService/GetReportByTypeDetails?Id=" + parentId + "&sPeriod=" ;

            var dt = new ReportData();
            var table1 = dt.Mis();
            DataSet ds = new DataSet();
            ds.Tables.Add(table1);
            LocalReport localreport = (LocalReport)e.Report;
            localreport.DataSources.Add(new ReportDataSource("MIS", ds.Tables[0]));
        }
        protected void ReportViewer1_IndPayD(object sender, DrillthroughEventArgs e)
        {



            var parentId = "0";
            var MIS = "";

            ReportParameterInfoCollection itemList = e.Report.GetParameters();

            foreach (var d in itemList)
            {
                // parentId = d.Values[0].ToString().Trim();

                if (d.Name == "Id")
                {
                    parentId = d.Values[0].ToString().Trim();
                }
                if (d.Name == "MIS")
                {
                    MIS = d.Values[0].ToString().Trim();
                }

            }
            //  this.dataUrl = "FinanceReportService/GetReportByTypeDetails?Id=" + parentId + "&sPeriod=" ;

            var dt = new ReportData();
            var table1 = dt.IndPaymentD();
            DataSet ds = new DataSet();
            ds.Tables.Add(table1);
            LocalReport localreport = (LocalReport)e.Report;
            localreport.DataSources.Add(new ReportDataSource("indPay", ds.Tables[0]));
        }
        protected void ReportViewer1_Drillthrough(object sender, DrillthroughEventArgs e)
        {

            var sId = "0";

            ReportParameterInfoCollection itemList = e.Report.GetParameters();

            foreach (var d in itemList)
            {
                sId = d.Values[0].ToString().Trim();
            }

            LocalReport localreport = (LocalReport)e.Report;


            DataSet Level1DataSet = new DataSet();
            var dt = new ReportData();
            var table1 = dt.OpexPayment();



            Level1DataSet.Tables.Add(table1);

            localreport.DataSources.Add(new ReportDataSource("OPEXPAYMENT", dt.OpexPayment()));
         
        }
    }
}