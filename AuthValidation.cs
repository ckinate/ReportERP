using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ReportERP
{
    public class AuthValidation
    {
        private string appHostUrl = ConfigurationManager.AppSettings["appUrl"];


        public AuthValidation()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public bool IsValid(string token)
        {
            var ValidationResult = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.appHostUrl + "api/services/app/User/");
                client.DefaultRequestHeaders.Add("Abp.TenantId", "2");

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                //HTTP GET
                var responseTask = client.GetAsync("GetUsers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ValidationResult = true;

                }

            }
            return ValidationResult;
        }

    }
}