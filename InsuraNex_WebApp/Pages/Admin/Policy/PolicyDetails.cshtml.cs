using InsuraNex.Models.Domain;
using InsuraNex.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Insuranex.Pages.Admin.Policy
{
    public class PolicyDetailsModel : PageModel
    {
        private readonly IPolicyOpsRepository policyOpsRepository;

      
        public InsurancePlans InsurancePlan { get; set; }

        public PolicyDetailsModel(IPolicyOpsRepository policyOpsRepository)
        {
            this.policyOpsRepository = policyOpsRepository;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            InsurancePlan = await policyOpsRepository.GetAsync(urlHandle);
            return Page();
        }
    }
}
