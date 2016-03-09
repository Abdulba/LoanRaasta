using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanBazaar.Models
{
    public class CustomerDetails
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string LoanType { get; set; }
        public string LoanAmount { get; set; }
        public string EmploymentType { get; set; }
        public string Organization { get; set; }
        public string Income { get; set; }
        public string BalanceTransferAndTopup { get; set; }
        public string Outstanding { get; set; }
        public string EMILong { get; set; }
        public string EMIAmount { get; set; }
        public string AnyBounces { get; set; }
        public string TopupAmount { get; set; }
    }
}