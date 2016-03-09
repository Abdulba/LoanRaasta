using LoanBazaar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Text;

namespace LoanBazaar.Controllers.Api
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]CustomerDetails customerDetails)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "loanraasta.com";
                //client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("test@loanraasta.com", "fidcASele@@#342");

                MailMessage mm = new MailMessage("test@loanraasta.com", "leadersfinancialservices@outlook.com");
                mm.CC.Add("abdulbasid@gmail.com");
                mm.CC.Add("sarathirangaraju@gmail.com");
                mm.BodyEncoding = UTF8Encoding.UTF8;

                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine("Customer Name : ").AppendLine(customerDetails.Name);
                strBuilder.AppendLine("Contact Number : ").AppendLine(customerDetails.Mobile);
                strBuilder.AppendLine("Email : ").AppendLine(customerDetails.Email);
                strBuilder.AppendLine("Product : ").AppendLine(customerDetails.LoanType);
                strBuilder.AppendLine("Loan Amount : ").AppendLine(customerDetails.LoanAmount);
                strBuilder.AppendLine("Income : ").AppendLine(customerDetails.Income);
                strBuilder.AppendLine("Employment Type : ").AppendLine(customerDetails.EmploymentType);
                strBuilder.AppendLine("Organization : ").AppendLine(customerDetails.Organization);
                strBuilder.AppendLine("BalanceTransferAndTopup : ").AppendLine(customerDetails.BalanceTransferAndTopup);
                strBuilder.AppendLine("Outstanding : ").AppendLine(customerDetails.Outstanding);
                strBuilder.AppendLine("EMILong : ").AppendLine(customerDetails.EMILong);
                strBuilder.AppendLine("EMIAmount : ").AppendLine(customerDetails.EMIAmount);
                strBuilder.AppendLine("AnyBounces : ").AppendLine(customerDetails.AnyBounces);
                strBuilder.AppendLine("TopupAmount : ").AppendLine(customerDetails.TopupAmount);

                mm.Body = strBuilder.ToString();
                mm.Subject = "Loan Application";
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                return;
            }
            catch(Exception ex)
            {
                return;
            }
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
