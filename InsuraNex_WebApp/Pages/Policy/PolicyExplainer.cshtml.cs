using InsuraNex.Models.Domain;
using InsuraNex.Models.ViewModels;
using InsuraNex.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Insuranex.Pages.Policy
{
    public class PolicyExplainerModel : PageModel
    {
        private readonly IPolicyOpsRepository policyOpsRepository;

        [BindProperty]
        public List<InsurancePlans> InsurancePlans { get; set; }

        public PolicyExplainerModel(IPolicyOpsRepository policyOpsRepository)
        {
            this.policyOpsRepository = policyOpsRepository;
        }

        public async void  OnGet()
        {
            InsurancePlans = (await policyOpsRepository.GetAllAsync()).ToList();

        }
    }
}
