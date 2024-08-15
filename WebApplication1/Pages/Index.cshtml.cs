using Azure;
using InsuraNex.Models.Domain;
using InsuraNex.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IPolicyOpsRepository policyRepository;
        // private readonly ITagRepository tagRepository;

        public List<InsurancePlans> InsurancePlans { get; set; }
        //   public List<Tag> Tags { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
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
