using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace ReportERP
{
    public class ReportData
    {
        public DataTable LoadTestData()
        {
            DataTable t1 = new DataTable("td");
            t1.Columns.Add("ID");
            t1.Columns.Add("CustomerName");
            t1.Columns.Add("OrderCount");

            t1.Rows.Add("1", "Chika", "20");
            t1.Rows.Add("3", "Rukky", "70");

            return t1;
        }

        public DataTable LoadTestData2()
        {
            DataTable t1 = new DataTable("td");
            t1.Columns.Add("Vendor");


            t1.Rows.Add("Michael");
            t1.Rows.Add("Christian");
            t1.Rows.Add("David");

            return t1;
        }

        public DataTable OpexRequisitionData()
        {
            DataTable table1 = new DataTable("td");

            
            table1.Columns.Add("Currency");
            table1.Columns.Add("RequestNumber");
            table1.Columns.Add("TaxAmount");
            table1.Columns.Add("TransactionTypeid");
            table1.Columns.Add("Amount");
            table1.Columns.Add("PayeeName");
            table1.Columns.Add("Narration");
            table1.Columns.Add("OperationId");
            table1.Columns.Add("description");
            table1.Columns.Add("whtAmount");
            table1.Columns.Add("invoiceNumber");
            table1.Columns.Add("transactionDescription");
            table1.Columns.Add("payeeTypeDescription");
            table1.Columns.Add("invoiceDate");
            table1.Columns.Add("caTransactionType");
            //0 - Normal, 1 - Header, 2 - Footer, 3 - Space

            table1.Rows.Add("NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");

            table1.Rows.Add("NGN", "Fin00002", "Chika", "Chika", "Chika1", "0", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");
            table1.Rows.Add("NGN", "Fin00003", "Chika", "Chika", "Chika2", "20000", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");
            table1.Rows.Add("NGN", "Fin00004", "Chika", "Chika", "Chika1", "20000", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");
            table1.Rows.Add("NGN", "Fin00005", "Chika", "Chika", "Chika1", "40000", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");
            table1.Rows.Add("NGN", "Fin00006", "Chika", "Chika", "Chika", "false", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");


            return table1;

        }

        public DataTable OpexRequisition(string token, string baseUrl, string dataUrl, string valueDate)
        {

            //1. Instantiate a datatable and define the properties
            DataTable table1 = new DataTable("OR");
          
            table1.Columns.Add("Currency");
            table1.Columns.Add("RequestNumber");
            table1.Columns.Add("TaxAmount");
            table1.Columns.Add("TransactionTypeid");
            table1.Columns.Add("Amount");
            table1.Columns.Add("PayeeName");
            table1.Columns.Add("Narration");
            table1.Columns.Add("OperationId");
            table1.Columns.Add("description");
            table1.Columns.Add("whtAmount");
            table1.Columns.Add("invoiceNumber");
            table1.Columns.Add("transactionDescription");
            table1.Columns.Add("payeeTypeDescription");
            table1.Columns.Add("invoiceDate");
            table1.Columns.Add("caTransactionType");

            //2. Get data from your service
            var result = this.GetData(token, baseUrl, dataUrl);
           // var result = this.OpexRequisitionData();


            //4. map your data to your datatable
            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(item["Currency"], item["RequestNumber"], item["TaxAmount"], item["TransactionTypeid"],
                    item["Amount"], item["PayeeName"], item["Narration"], item["OperationId"], item["description"], item["whtAmount"], item["invoiceNumber"],
                    item["transactionDescription"], item["payeeTypeDescription"], item["invoiceDate"], item["caTransactionType"]);

            }

            //return datatable with data
            return table1;
        }
        public DataTable OpexPaymentData()
        {
            DataTable table1 = new DataTable("OP");

            table1.Columns.Add("pVoucherNo");
            table1.Columns.Add("paymentRefNo");
            table1.Columns.Add("PDate");
            table1.Columns.Add("PayeeName");
            table1.Columns.Add("reqRefNo");
            table1.Columns.Add("DebitGL");
            table1.Columns.Add("CreditGL");
            table1.Columns.Add("AmountNowPaid");
            table1.Columns.Add("amount");
            table1.Columns.Add("vatAmount");
            table1.Columns.Add("WHTAmount");
            table1.Columns.Add("PMadeBy");
            table1.Columns.Add("currency");
            table1.Columns.Add("exchangeRate");
            table1.Columns.Add("pmode");
            table1.Columns.Add("whtgl");
            table1.Columns.Add("narration");
            table1.Columns.Add("mis");
            table1.Columns.Add("viewdetail");



            //0 - Normal, 1 - Header, 2 - Footer, 3 - Space

            table1.Rows.Add("1", "Fin00001", "Chika", "test1", "20000", "Chika", "Chika", "1", "Fin00001", "Chika", "test1", "20000", "Chika", "Chika", "20000", "Chika", "Chika");

            table1.Rows.Add("2", "Fin00002", "Chika1", "0", "20000", "Chika", "Chika", "1", "Fin00001", "Chika", "test1", "20000", "Chika", "Chika", "20000", "Chika", "Chika");
            table1.Rows.Add("3", "Fin00003", "Chika2", "20000", "20000", "Chika", "Chika", "1", "Fin00001", "Chika", "test1", "20000", "Chika", "Chika", "20000", "Chika", "Chika");
            table1.Rows.Add("4", "Fin00004", "Chika1", "20000", "20000", "Chika", "Chika", "1", "Fin00001", "Chika", "test1", "20000", "Chika", "Chika", "20000", "Chika", "Chika");
            table1.Rows.Add("5", "Fin00005", "Chika1", "40000", "20000", "Chika", "Chika", "1", "Fin00001", "Chika", "test1", "20000", "Chika", "Chika", "20000", "Chika", "Chika");
            table1.Rows.Add("6", "Fin00006", "Chika", "false", "20000", "Chika", "Chika", "1", "Fin00001", "Chika", "test1", "20000", "Chika", "Chika", "20000", "Chika", "Chika");


            return table1;

        }



        public DataTable CARequisitionData()
        {
            DataTable table1 = new DataTable("td");

            table1.Columns.Add("id");
            table1.Columns.Add("Currency");
            table1.Columns.Add("RequestNumber");
            table1.Columns.Add("TaxAmount");
            table1.Columns.Add("TransactionTypeid");
            table1.Columns.Add("Amount");
            table1.Columns.Add("PayeeName");
            table1.Columns.Add("Narration");
            table1.Columns.Add("OperationId");
            table1.Columns.Add("description");
            table1.Columns.Add("whtAmount");
            table1.Columns.Add("invoiceNumber");
            table1.Columns.Add("transactionDescription");
            table1.Columns.Add("payeeTypeDescription");
            table1.Columns.Add("invoiceDate");
            table1.Columns.Add("caTransactionType");
            //0 - Normal, 1 - Header, 2 - Footer, 3 - Space

            table1.Rows.Add("NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");

            table1.Rows.Add("NGN", "Fin00002", "Chika", "Chika", "Chika1", "0", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");
            table1.Rows.Add("NGN", "Fin00003", "Chika", "Chika", "Chika2", "20000", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");
            table1.Rows.Add("NGN", "Fin00004", "Chika", "Chika", "Chika1", "20000", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");
            table1.Rows.Add("NGN", "Fin00005", "Chika", "Chika", "Chika1", "40000", "Chika", "Chika", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");
            table1.Rows.Add("NGN", "Fin00006", "Chika", "Chika", "Chika", "false", "Chika", "Chika", "NGN", "Fin00006", "Chika", "Chika", "Chika", "false", "Chika", "Chika");

            return table1;

        }
        public DataTable CallOverReport()
        {
            DataTable table1 = new DataTable("td");

            table1.Columns.Add("id");
            table1.Columns.Add("TransactionType");
            table1.Columns.Add("Ref");
            table1.Columns.Add("MainAccountId");
            table1.Columns.Add("AccountId");
            table1.Columns.Add("DebitAmount");
            table1.Columns.Add("CreditAmount");
            table1.Columns.Add("Narration");
            table1.Columns.Add("TransactionDate");
            table1.Columns.Add("ValueDate");
            table1.Columns.Add("TransactionSattusId");
            table1.Columns.Add("BeneficiaryCode");
            table1.Columns.Add("CurrencyId");
            table1.Columns.Add("MadeBy");

            //0 - Normal, 1 - Header, 2 - Footer, 3 - Space

            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "1", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");

            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00002", "Chika", "Chika", "Chika1", "0", "Chika", "Chika");
            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00003", "Chika", "Chika", "Chika2", "20000", "Chika", "Chika");
            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00004", "Chika", "Chika", "Chika1", "20000", "Chika", "Chika");
            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00005", "Chika", "Chika", "Chika1", "40000", "Chika", "Chika");
            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00006", "Chika", "Chika", "Chika", "false", "Chika", "Chika");

            return table1;

        }
        public DataTable OpexPayment()
        {
            //1. Instantiate a datatable and define the properties
            DataTable table1 = new DataTable("OP");

            table1.Columns.Add("pVoucherNo");
            table1.Columns.Add("paymentRefNo");
            table1.Columns.Add("PDate");
            table1.Columns.Add("PayeeName");
            table1.Columns.Add("reqRefNo");
            table1.Columns.Add("DebitGL");
            table1.Columns.Add("CreditGL");
            table1.Columns.Add("AmountNowPaid");
            table1.Columns.Add("amount");
            table1.Columns.Add("vatAmount");
            table1.Columns.Add("WHTAmount");
            table1.Columns.Add("PMadeBy");
            table1.Columns.Add("currency");
            table1.Columns.Add("exchangeRate");
            table1.Columns.Add("pmode");
            table1.Columns.Add("whtgl");
            table1.Columns.Add("narration");
           // table1.Columns.Add("mis");
            //table1.Columns.Add("viewdetail");



            //2. Get data from your service
            //var result = this.GetData(token, baseUrl, dataUrl);
             var result = this.OpexPaymentData();


            //4. map your data to your datatable
            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(item["pVoucherNo"], item["PDate"], item["PayeeName"], item["paymentRefNo"],
                    item["DebitGL"], item["CreditGL"], item["AmountNowPaid"], item["amount"], item["reqRefNo"], item["vatAmount"], item["WHTAmount"], item["PMadeBy"],
                    item["currency"], item["pmode"], item["exchangeRate"], item["whtgl"], item["narration"]);
            }

            //return datatable with data
            return table1;

        }
        public DataTable OpexCallOverReport()
        {
            DataTable table1 = new DataTable("td");

            table1.Columns.Add("id");
            table1.Columns.Add("TransactionType");
            table1.Columns.Add("Ref");
            table1.Columns.Add("MainAccountId");
            table1.Columns.Add("AccountId");
            table1.Columns.Add("DebitAmount");
            table1.Columns.Add("CreditAmount");
            table1.Columns.Add("Narration");
            table1.Columns.Add("TransactionDate");
            table1.Columns.Add("ValueDate");
            table1.Columns.Add("TransactionSattusId");
            table1.Columns.Add("BeneficiaryCode");
            table1.Columns.Add("CurrencyId");
            table1.Columns.Add("MadeBy");

            //0 - Normal, 1 - Header, 2 - Footer, 3 - Space

            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "1", "NGN", "Fin00001", "Chika", "Chika", "Chika", "test1", "Chika", "Chika");

            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00002", "Chika", "Chika", "Chika1", "0", "Chika", "Chika");
            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00003", "Chika", "Chika", "Chika2", "20000", "Chika", "Chika");
            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00004", "Chika", "Chika", "Chika1", "20000", "Chika", "Chika");
            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00005", "Chika", "Chika", "Chika1", "40000", "Chika", "Chika");
            table1.Rows.Add("1", "NGN", "Fin00001", "Chika", "Chika", "NGN", "Fin00006", "Chika", "Chika", "Chika", "false", "Chika", "Chika");

            return table1;

        }

        public DataTable OutstandingCAData()
        {
            DataTable table1 = new DataTable("td");

            table1.Columns.Add("payeeName");
            table1.Columns.Add("RequestNumber");
            table1.Columns.Add("advanceAmount");
            table1.Columns.Add("Date");
            table1.Columns.Add("initiator");
            table1.Columns.Add("cashAdvanceType");
            

           
            //0 - Normal, 1 - Header, 2 - Footer, 3 - Space

            table1.Rows.Add("NGN", "Fin00001", "Chika", "NGN", "Fin00001", "Chika");

            table1.Rows.Add("NGN", "Fin00002", "Chika", "NGN", "Fin00001", "Chika");
            table1.Rows.Add("NGN", "Fin00003", "Chika", "NGN", "Fin00001", "Chika");
            table1.Rows.Add("NGN", "Fin00004", "Chika", "NGN", "Fin00001", "Chika");
            table1.Rows.Add("NGN", "Fin00005", "Chika", "NGN", "Fin00001", "Chika");
            table1.Rows.Add("NGN", "Fin00006", "Chika", "NGN", "Fin00001", "Chika");

            return table1;

        }

        public DataTable OpexPayment(string token, string baseUrl, string dataUrl, string valueDate)
        {
            //1. Instantiate a datatable and define the properties
            DataTable table1 = new DataTable("OP");
        
            table1.Columns.Add("pVoucherNo");
            table1.Columns.Add("paymentRefNo");
            table1.Columns.Add("PDate");
            table1.Columns.Add("PayeeName");
            table1.Columns.Add("reqRefNo");
            table1.Columns.Add("DebitGL");
            table1.Columns.Add("CreditGL");
            table1.Columns.Add("AmountNowPaid");
            table1.Columns.Add("amount");
            table1.Columns.Add("vatAmount");
            table1.Columns.Add("WHTAmount");
            table1.Columns.Add("PMadeBy");
            table1.Columns.Add("currency");
            table1.Columns.Add("exchangeRate");
            table1.Columns.Add("pmode");
            table1.Columns.Add("whtgl");
            table1.Columns.Add("narration");
            table1.Columns.Add("mis");
            table1.Columns.Add("viewdetail");



            //2. Get data from your service
           var result = this.GetData(token, baseUrl, dataUrl);
            //var result = this.OpexPaymentData();


            //4. map your data to your datatable
            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(item["pVoucherNo"], item["PDate"], item["PayeeName"], item["paymentRefNo"],
                    item["DebitGL"], item["CreditGL"], item["AmountNowPaid"], item["amount"], item["reqRefNo"], item["vatAmount"], item["WHTAmount"], item["PMadeBy"],
                    item["currency"], item["pmode"], item["exchangeRate"], item["whtgl"], item["narration"]);
            }

            //return datatable with data
            return table1;

        }
        public DataTable CARequisition(string token, string baseUrl, string dataUrl, string valueDate)
        {


            //1. Instantiate a datatable and define the properties
            DataTable table1 = new DataTable("CAR");
          
            table1.Columns.Add("Currency");
            table1.Columns.Add("RequestNumber");
            table1.Columns.Add("TaxAmount");
            table1.Columns.Add("TransactionTypeid");
            table1.Columns.Add("Amount");
            table1.Columns.Add("PayeeName");
            table1.Columns.Add("Narration");
            table1.Columns.Add("OperationId");
            table1.Columns.Add("madeBy");
            table1.Columns.Add("whtAmount");
            table1.Columns.Add("invoiceNumber");
            table1.Columns.Add("transactionDescription");
            table1.Columns.Add("payeeTypeDescription");
            table1.Columns.Add("requestDate");
            table1.Columns.Add("cashAdvanceType");

            //2. Get data from your service
            var result = this.GetData(token, baseUrl, dataUrl);
          //  var result = this.CARequisitionData();



            //3. map your data to your datatable
            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add( item["Currency"], item["RequestNumber"], item["TaxAmount"], item["TransactionTypeid"],
                    item["Amount"], item["PayeeName"], item["Narration"], item["OperationId"], item["madeBy"], item["whtAmount"], item["invoiceNumber"],
                    item["transactionDescription"], item["payeeTypeDescription"], item["invoiceDate"], item["caTransactionType"]);

            }

            //return datatable with data
            return table1;
        }

        public DataTable OutstandingCA(string token, string baseUrl, string dataUrl, string valueDate)
        {

            //1. Instantiate a datatable and define the properties
            DataTable table1 = new DataTable("OCA");
            table1.Columns.Add("payeeName");
            table1.Columns.Add("RequestNumber");
            table1.Columns.Add("advanceAmount");
            table1.Columns.Add("Date");
            table1.Columns.Add("initiator");
            table1.Columns.Add("cashAdvanceType");



            //2. Get data from your service
            var result = this.GetData(token, baseUrl, dataUrl);
           // var result = OutstandingCAData();


            //4. map your data to your datatable
            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(item["payeeName"], item["RequestNumber"], item["advanceAmount"], item["Date"], item["initiator"], item["cashAdvanceType"]);

            }

            //return datatable with data
            return table1;
        }

        public DataTable OpexCallOverPosting(string token, string baseUrl, string dataUrl, string valueDate)
        {
            //1. Instantiate a datatable and define the properties
            DataTable table1 = new DataTable("td");
            table1.Columns.Add("id");
            table1.Columns.Add("PDate");
            table1.Columns.Add("PaymentDetail");
            table1.Columns.Add("PayeeName");
            table1.Columns.Add("DebitGL");
            table1.Columns.Add("CreditGL");
            table1.Columns.Add("PMadeBy");
            table1.Columns.Add("pVoucherNo");
            table1.Columns.Add("pRefNo");
            table1.Columns.Add("transCode");
            table1.Columns.Add("grossAmt");
            table1.Columns.Add("taxAmount");
            table1.Columns.Add("whtAmount");
            table1.Columns.Add("invoiceNumber");
            table1.Columns.Add("invoiceDate");
            table1.Columns.Add("currency");
            table1.Columns.Add("postingStatus");
            table1.Columns.Add("exchangeRate");
            table1.Columns.Add("operationId");


            //2. Get data from your service
            var result = this.GetData(token, baseUrl, dataUrl);

            //4. map your data to your datatable
            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(item["id"], item["PDate"], item["PaymentDetail"], item["PayeeName"], item["DebitGL"], item["CreditGL"], item["PMadeBy"],
                    item["pVoucherNo"], item["pRefNo"], item["transCode"], item["grossAmt"], item["taxAmount"], item["CreditGL"], item["invoiceNumber"],
                    item["invoiceDate"], item["currency"], item["postingStatus"], item["exchangeRate"], item["operationId"]);
            }

            //return datatable with data
            return table1;

        }
        public DataTable FinReport2()
        {
            DataTable table1 = new DataTable("Bk2");

            table1.Columns.Add("MainID");
            table1.Columns.Add("ID");
            table1.Columns.Add("Caption");
            table1.Columns.Add("Amount");

            var itemList = CustomData2(0);
            foreach (DataRow item in itemList.Rows)
            {
                table1.Rows.Add(item["MainID"], item["ID"], item["Caption"], item["Amount"]);

            }
            return table1;
        }
        public DataTable FinReport()
        {
            DataTable table1 = new DataTable("Bk1");

            table1.Columns.Add("ParentCaption");
            table1.Columns.Add("Caption");
            table1.Columns.Add("Category");
            table1.Columns.Add("Level");

            table1.Columns.Add("Amount");
            table1.Columns.Add("IsTotalLine");
            table1.Columns.Add("Type");
            table1.Columns.Add("Color");
            var itemList = CustomData();
            foreach (DataRow item in itemList.Rows)
            {
                table1.Rows.Add(item["parentcaption"], item["caption"], item["category"], item["level"], item["amount"], item["totalline"], item["type"], item["color"]);

            }
            return table1;
        }

        private DataTable CustomData()
        {
            DataTable table1 = new DataTable("td");

            table1.Columns.Add("parentcaption");
            table1.Columns.Add("caption");
            table1.Columns.Add("category");
            table1.Columns.Add("level");

            table1.Columns.Add("amount");
            table1.Columns.Add("totalline");
            table1.Columns.Add("type");
            table1.Columns.Add("color");
            //0 - Normal, 1 - Header, 2 - Footer, 3 - Space

            table1.Rows.Add("Asset", "Asset", "0", "1", "0", "false", "1", "#CCCC00");

            table1.Rows.Add("Asset", "Current Asset", "1", "1", "0", "false", "1", "#FFFFFF");
            table1.Rows.Add("Current Asset", "Receivables", "2", "2", "20000", "false", "0", "#FFFFFF");
            table1.Rows.Add("Current Asset", "Cash and Cash Equivalent", "2", "1", "20000", "false", "0", "#FFFFFF");
            table1.Rows.Add("Asset", "Total Current Asset", "1", "1", "40000", "true", "2", "#FFFFFF");
            table1.Rows.Add("Asset", "", "1", "1", "0", "false", "3", "#FFFFFF");

            table1.Rows.Add("Asset", "Other Current Asset", "1", "2", "30000", "false", "0", "#FFFFFF");
            table1.Rows.Add("Asset", "PPE", "1", "3", "30000", "false", "0", "#FFFFFF");

            table1.Rows.Add("Asset", "Total Asset", "0", "1", "100000", "true", "2", "#FFFFFF");
            table1.Rows.Add("Asset", "6", "0", "30", "8", "false", "3", "#FFFFFF");

            table1.Rows.Add("Liability and Equity", "Liability and Equity", "0", "2", "0", "false", "1", "#FFFFFF");
            table1.Rows.Add("Liability and Equity", "Current Liability", "1", "1", "30000", "false", "0", "#FFFFFF");
            table1.Rows.Add("Liability and Equity", "Other Current Liability", "1", "2", "30000", "false", "0", "#FFFFFF");
            table1.Rows.Add("Liability and Equity", "Equity", "1", "2", "0", "false", "1", "#FFFFFF");
            table1.Rows.Add("Equity", "Share Capital", "2", "1", "15000", "false", "0", "#FFFFFF");
            table1.Rows.Add("Equity", "Retained Earnings", "2", "2", "10000", "false", "0", "#FFFFFF");
            table1.Rows.Add("Equity", "Accumulated Comprehensive Income/Loss", "2", "3", "5000", "false", "0", "#FFFFFF");
            table1.Rows.Add("Liability and Equity", "Total Equity", "1", "2", "40000", "true", "2", "#FFFFFF");
            table1.Rows.Add("Liability and Equity", "", "1", "2", "0", "false", "3", "#FFFFFF");
            table1.Rows.Add("Liability and Equity", "Total Liability and Equity", "0", "2", "100000", "true", "2", "#FFFFFF");
            table1.Rows.Add("Liability and Equity", "", "0", "2", "0", "false", "3", "#FFFFFF");

            return table1;

        }
        public DataTable IndPaymentD()
        {
            DataTable table1 = new DataTable("IDP");

            table1.Columns.Add("paymentDate");
            table1.Columns.Add("PVoucherNo");
            table1.Columns.Add("Pmode");
            table1.Columns.Add("PaymentRefNo");

            table1.Columns.Add("PayeeName");
            table1.Columns.Add("Narration");
            table1.Columns.Add("Amount");
            table1.Columns.Add("PmadeBy");
            var itemList = IPData();
            foreach (DataRow item in itemList.Rows)
            {
                table1.Rows.Add(item["paymentDate"], item["PVoucherNo"], item["Pmode"], item["PaymentRefNo"], item["PayeeName"], item["Narration"], item["Amount"], item["PmadeBy"]);

            }
            return table1;
        }

        public DataTable Mis()
        {
            DataTable table1 = new DataTable("IDP");

            table1.Columns.Add("Amount");
            table1.Columns.Add("Deparment");
            table1.Columns.Add("PaymentId");
            table1.Columns.Add("RequestDate");

           
            var itemList = MisData();
            foreach (DataRow item in itemList.Rows)
            {
                table1.Rows.Add(item["Amount"], item["Deparment"], item["PaymentId"], item["RequestDate"]);

            }
            return table1;
        }

        private DataTable MisData()
        {
            DataTable table1 = new DataTable("td");

            table1.Columns.Add("Amount");
            table1.Columns.Add("Deparment");
            table1.Columns.Add("PaymentId");
            table1.Columns.Add("RequestDate");

            //0 - Normal, 1 - Header, 2 - Footer, 3 - Space

            table1.Rows.Add( "2333", "Ruky", "all good");

            table1.Rows.Add("434", "Debby", "thanks", "34534");


            return table1;

        }
        private DataTable IPData()
        {
            DataTable table1 = new DataTable("td");

            table1.Columns.Add("paymentDate");
            table1.Columns.Add("PVoucherNo");
            table1.Columns.Add("Pmode");
            table1.Columns.Add("PaymentRefNo");

            table1.Columns.Add("PayeeName");
            table1.Columns.Add("Narration");
            table1.Columns.Add("Amount");
            table1.Columns.Add("PmadeBy");
            //0 - Normal, 1 - Header, 2 - Footer, 3 - Space

            table1.Rows.Add("Jan", "fr23234", "Online", "2333", "Ruky", "all good", "2342");

            table1.Rows.Add("Feb", "re34343", "cash", "434", "Debby", "thanks", "34534", "Dav");
          

            return table1;

        }

        private DataTable CustomData2(int ID)
        {
            DataTable table1 = new DataTable("Bk13");

            table1.Columns.Add("MainID");
            table1.Columns.Add("ID");
            table1.Columns.Add("Caption");
            table1.Columns.Add("Amount");

            table1.Rows.Add("1", "57", "Cash", "8000");
            table1.Rows.Add("1", "58", "Bank", "12000");

            return table1;
        }

        public DataTable BankRecon1Data(string token, string baseUrl, string dataUrl)
        {
            DataTable table1 = new DataTable("Bk1");


            //      "bankGLAccNos": "1224364578",
            //"bankName": null,
            //"glBalance": 2343815220.43,
            //"closingBnkStatementBal": 0,
            //"openingBnkStateMentBal": 0,
            //"reconciliationDate": "0001-01-01T00:00:00",
            //"startdate": "2019-09-01T01:00:00",
            //"enddate": "2019-09-30T23:33:36",
            //"debitBalanceCashBook": 13037740357.29,
            //"creditBalanceCashBook": 8076036519.4,
            //"debitBalanceBankStatement": 7272032767.67,
            //"creditBalanceBankStatement": 13465155678.16




            table1.Columns.Add("BankGLAccNos");
            table1.Columns.Add("BankName");
            table1.Columns.Add("GlBalance");
            table1.Columns.Add("ClosingBnkStatementBal");
            table1.Columns.Add("OpeningBnkStateMentBal");
            table1.Columns.Add("ReconciliationDate");
            table1.Columns.Add("Startdate");
            table1.Columns.Add("Enddate");
            table1.Columns.Add("DebitBalanceCashBook");
            table1.Columns.Add("CreditBalanceCashBook");
            table1.Columns.Add("DebitBalanceBankStatement");
            table1.Columns.Add("CreditBalanceBankStatement");

            var result = this.GetData(token, baseUrl, dataUrl);
            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(
                    item["bankGLAccNos"],
                    item["bankName"],
                    item["glBalance"],
                    item["closingBnkStatementBal"],
                    item["openingBnkStateMentBal"],

                 string.Format("{0:d}", item["reconciliationDate"]),
                 string.Format("{0:d}", item["startdate"]),
                 string.Format("{0:d}", item["enddate"]),
                 string.Format("{0:N}", item["debitBalanceCashBook"]),
                 string.Format("{0:N}", item["creditBalanceCashBook"])
                 , string.Format("{0:N}", item["debitBalanceBankStatement"])
                 , string.Format("{0:N}", item["creditBalanceBankStatement"]));
            }
            return table1;
        }

        public DataTable TrialBalanceData(string token, string baseUrl, string dataUrl, string valueDate)
        {

            //1. Instantiate a datatable and define the properties
            DataTable table1 = new DataTable("TB");
            table1.Columns.Add("AccountCode");

            DataColumn accountName = new DataColumn();
            accountName.ColumnName = "AccountName";
            accountName.Caption = "Account Name";
            accountName.ExtendedProperties.Add("cWidth", 10);
            accountName.ExtendedProperties.Add("rActionLink", "www.google.com");
            table1.Columns.Add(accountName);
            table1.Columns.Add("Debit");
            table1.Columns.Add("Credit");
            decimal totalDebit = 0;
            decimal totalCredit = 0;
            table1.Columns.Add("CompanyName");
            table1.Columns.Add("ValueDate");


            //2. Get data from your service
            var result = this.GetData(token ,baseUrl, dataUrl);



            //4. map your data to your datatable
            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(item["accountCode"], item["accountName"], string.Format("{0:#,0.00}", item["debit"]), string.Format("{0:#,0.00}", item["credit"]), item["companyName"], valueDate);
                totalDebit += Convert.ToDecimal(item["debit"]);
                totalCredit += Convert.ToDecimal(item["credit"]);
            }
            table1.Rows.Add("", "", string.Format("{0:#,0.00}", totalDebit), string.Format("{0:#,0.00}", totalCredit));

            //return datatable with data
            return table1;
        }

        public DataTable GeneralLedgerData(string token, string baseUrl, string dataUrl, string startDate, string endDate)
        {
            DataTable table1 = new DataTable("GL");

            DataColumn nar = new DataColumn();
            nar.ColumnName = "Narration";


            table1.Columns.Add("TransactionDate");

            table1.Columns.Add("Ref");
            table1.Columns.Add(nar);

            DataColumn opBal = new DataColumn();
            opBal.ColumnName = "OpeningBalance";
            opBal.Caption = "Opening Balance";
            table1.Columns.Add(opBal);

            DataColumn debit = new DataColumn();
            debit.ColumnName = "DebitAmount";
            debit.Caption = "Debit Amount";
            table1.Columns.Add(debit);

            table1.Columns.Add("CreditAmount");
            table1.Columns.Add("ClosingBalance");
            table1.Columns.Add("CompanyName");
            table1.Columns.Add("StartDate");
            table1.Columns.Add("EndDate");


            var result = this.GetData(token, baseUrl, dataUrl);
            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(string.Format("{0:d}", item["valueDate"]), item["ref"], item["narration"], string.Format("{0:#,0.00}", item["openingBalance"]), string.Format("{0:#,0.00}", item["debitAmount"]), string.Format("{0:#,0.00}", item["creditAmount"]), string.Format("{0:#,0.00}", item["runningBalance"]), item["companyName"], startDate, endDate);
            }
            return table1;
        }

        public DataTable FinancialReportDetail(string token, string baseUrl, string dataUrl)
        {
            DataTable table1 = new DataTable("Bk222");

            table1.Columns.Add("MainID");
            table1.Columns.Add("ID");
            table1.Columns.Add("Caption");
            table1.Columns.Add("Amount");
            table1.Columns.Add("MainCaption");


            var result = this.GetData(token, baseUrl, dataUrl);

            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(item["id"], item["id"], item["caption"], item["amount"], item["parentCaption"]);

            }
            return table1;
        }
        public DataTable FinancialReportSub(string token, string baseUrl, string dataUrl)
        {
            DataTable table1 = new DataTable("Bk13");

            table1.Columns.Add("MainID");
            table1.Columns.Add("ID");
            table1.Columns.Add("Caption");
            table1.Columns.Add("Amount");
            table1.Columns.Add("MainCaption");


            var result = this.GetData(token, baseUrl, dataUrl);

            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(item["id"], item["id"], item["caption"], item["amount"], item["parentCaption"]);

            }
            return table1;
        }

        public DataTable FinancialReport(string token, string baseUrl, string dataUrl, string title, string valueDate)
        {
            DataTable table1 = new DataTable("Bk1");
            table1.Columns.Add("Id");
            table1.Columns.Add("ParentCaption");
            table1.Columns.Add("Caption");
            table1.Columns.Add("Category");
            table1.Columns.Add("Level");

            table1.Columns.Add("Amount");
            table1.Columns.Add("IsTotalLine");
            table1.Columns.Add("Type");
            table1.Columns.Add("Color");
            table1.Columns.Add("CompanyName");
            table1.Columns.Add("Title");
            table1.Columns.Add("Period");
            var result = this.GetData(token ,baseUrl, dataUrl);

            foreach (DataRow item in result.Rows)
            {
                table1.Rows.Add(item["id"], item["parentCaption"], item["caption"], item["categoryId"], item["level"], item["amount"], item["isTotalLine"], item["captionType"], item["color"], item["companyName"], title, valueDate);

            }
            return table1;


        }

        public DataTable GetData(string token,string baseUrl, string dataUrl)
        {
            DataTable dataResult = new DataTable();
            using (var client = new HttpClient())
            {
                //
                //
                client.BaseAddress = new Uri(baseUrl);
                 client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //HTTP GET

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                var responseTask = client.GetAsync(dataUrl);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var dataset = readTask.Result;
                    JObject originalObject = JObject.Parse(dataset);
                    var analogInputTrueValues = originalObject.Descendants()
                                                              .OfType<JProperty>()
                                                              .Where(p => p.Name == "result")
                                                              .Select(x => x.Value.ToString()).ToList();
                    dataResult = JsonConvert.DeserializeObject<DataTable>(analogInputTrueValues.FirstOrDefault());

                }

            }
            return dataResult;

        }

    }
}