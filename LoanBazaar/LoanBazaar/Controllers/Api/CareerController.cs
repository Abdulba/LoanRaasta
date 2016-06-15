using LoanBazaar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Http;

namespace LoanBazaar.Controllers.Api
{
    public class CareerController : ApiController
    {
        // GET: api/Career
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Career/5
        public string Get(int id)
        {
            return "value";
        }
                
        // POST: api/Career
        public async void Post([FromBody]CareerDetails value)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "loanraasta.com";
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("test@loanraasta.com", "fidcASele@@#342");

                MailMessage mm = new MailMessage("test@loanraasta.com", "leadersfinancialservices@outlook.com");
                mm.CC.Add("abdulbasid@gmail.com");
                mm.CC.Add("sarathirangaraju@gmail.com");
                mm.BodyEncoding = UTF8Encoding.UTF8;

                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine("Candidate Name : ").AppendLine(value.Name);
                strBuilder.AppendLine("Contact Number : ").AppendLine(value.Mobile);
                strBuilder.AppendLine("Email : ").AppendLine(value.Email);
                strBuilder.AppendLine("Company : ").AppendLine(value.Company);
                strBuilder.AppendLine("Experience : ").AppendLine(value.Experience);
                              

                mm.Body = strBuilder.ToString();
                mm.Subject = "Job Application";

                //string sPath = "";
                //sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/locker/");
                //if (File.Exists(sPath + Path.GetFileName(value.File)))
                //{
                //    mm.Attachments.Add(new Attachment(sPath + Path.GetFileName(value.File)));
                //}
                
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                return;
            }
            catch(Exception ex)
            {
                return;
            }
            
        }

        // PUT: api/Career/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Career/5
        public void Delete(int id)
        {
        }
    }
}
