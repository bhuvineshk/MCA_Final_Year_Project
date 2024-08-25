using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InsuraNex.Data;
using InsuraNex.Models.Domain;
using InsuraNex.Repositories;
using Microsoft.AspNetCore.Authorization;
using InsuraNex.Models.ViewModels;

namespace InsuraNex.Pages.Admin.Data
{
    [Authorize(Roles = "Admin")]
    public class View_PolicyModel : PageModel
    {
        private readonly IPolicyOpsRepository policyOpsRepository;



        [BindProperty]
        public InsurancePlans insurance { get; set; }

        [BindProperty]
        public AddPolicyData FeaturedImage { get; set; }

        public View_PolicyModel(IPolicyOpsRepository policyOpsRepository)
        {
            this.policyOpsRepository = policyOpsRepository;
        }
        public async void OnGet(Guid id)
        {

            insurance = await policyOpsRepository.GetAsync(id);

        }

        public IActionResult OnPostBackToList()

        {
            return RedirectToPage("/Admin/Data/List_Policy");
        }

        public IActionResult OnPostEditCustomer(Guid id)

        {
            if (insurance != null)
            {
                return RedirectToPage("/Admin/Data/Edit_Policy", new { id });
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }



    }
}
