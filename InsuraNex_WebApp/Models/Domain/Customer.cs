
using System.Numerics;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InsuraNex.Models.Domain
{
    public class Customer
    {
    
        public Guid Id { get; set; } 

        public Guid Policy_id { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public DateTime DOC { get; set; }

        public string Plan { get; set; }

        public DateTime Plan_Exp_Date { get; set; }

        public string Occupation { get; set; }

        public int Income { get; set; }

        public string City { get; set; }

        public string Contact_No { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; } 


    }
}
