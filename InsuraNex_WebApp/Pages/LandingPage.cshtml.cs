using InsuraNex.Models.Domain;
using InsuraNex.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Pages;

namespace Insuranex.Pages
{
    public class LandingPageModel : PageModel
    {
        private readonly ILogger<LandingPageModel> _logger;

        private readonly IPolicyOpsRepository policyRepository;
        // private readonly ITagRepository tagRepository;

        public List<InsurancePlans> InsurancePlans { get; set; }
        //   public List<Tag> Tags { get; set; }

        public LandingPageModel(ILogger<LandingPageModel> logger,
        IPolicyOpsRepository policyRepository)
        //    ,ITagRepository tagRepository)
        {
            _logger = logger;
            this.policyRepository = policyRepository;
            //  this.tagRepository = tagRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            InsurancePlans = (await policyRepository.GetAllAsync()).ToList();
            //Tags = (await tagRepository.GetAllAsync()).ToList();

            return Page();

        }
    }
}
