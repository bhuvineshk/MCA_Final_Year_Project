using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InsuraNex.Data;
using InsuraNex.Models.Domain;
using InsuraNex.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace InsuraNex.Pages.Admin.Data
{
    [Authorize(Roles = "Admin")]
    public class ViewModel : PageModel
    {
        private readonly ICustomerOpsRepository customerOpsRepository;

        [BindProperty]
        public Customer? Customers { get; set; }

        public ViewModel(ICustomerOpsRepository customerOpsRepository)
        {
            this.customerOpsRepository = customerOpsRepository;
        }
        public async void OnGet(Guid id)
        {

            Customers = await customerOpsRepository.GetAsync(id);

        }

        public IActionResult OnPostBackToList()

        {
            return RedirectToPage("/Admin/Data/List");
        }

        public IActionResult OnPostEditCustomer(Guid id)

        {
            if (Customers != null)
            {
                return RedirectToPage("/Admin/Data/Edit", new { id });
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }



    }
}
