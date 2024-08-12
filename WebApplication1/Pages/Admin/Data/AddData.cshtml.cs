using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using InsuraNex.Data;
using InsuraNex.Models.Domain;
using InsuraNex.Models.ViewModels;
using InsuraNex.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace InsuraNex.Pages.Admin.Data
{
    [Authorize(Roles ="Admin")]
    public class AddDataModel : PageModel
    {
        private readonly ICustomerOpsRepository customerOpsRepository;

        [BindProperty]
        public AddCustomerData AddCustomerDataReq { get; set; }

        public AddDataModel(ICustomerOpsRepository customerOpsRepository)
        {
            this.customerOpsRepository = customerOpsRepository;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            var customer = new Customer()
            {
                Name = AddCustomerDataReq.Name,
                DOB = AddCustomerDataReq.DOB,
                DOC = AddCustomerDataReq.DOC,
                Plan = AddCustomerDataReq.Plan,
                Plan_Exp_Date = AddCustomerDataReq.Plan_Exp_Date,
                Occupation = AddCustomerDataReq.Occupation,
                Income = AddCustomerDataReq.Income,
                City = AddCustomerDataReq.City,
                Contact_No = AddCustomerDataReq.Contact_No

            };

           await customerOpsRepository.AddAsync(customer);

            var notification = new Notification
            {
                Type = Enums.NotificationType.Success,
                Message = "New Customer Info Added!"
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Data/List");
        }
        
    }
}
