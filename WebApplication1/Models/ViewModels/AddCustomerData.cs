using System.ComponentModel.DataAnnotations;

namespace InsuraNex.Models.ViewModels
{
    public class AddCustomerData
    {
        
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
