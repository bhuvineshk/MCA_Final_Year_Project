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
    [Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {
        private readonly ICustomerOpsRepository customerOpsRepository;

        [BindProperty]
        public List<Customer> Customers { get; set; }

        public ListModel(ICustomerOpsRepository customerOpsRepository)
        {
            this.customerOpsRepository = customerOpsRepository;
        }
        public async void OnGet()
        {
            var notificationJson = (string)TempData["Notification"];
            if (notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }
            Customers = (await customerOpsRepository.GetAllAsync()).ToList();
        }
    }
}
