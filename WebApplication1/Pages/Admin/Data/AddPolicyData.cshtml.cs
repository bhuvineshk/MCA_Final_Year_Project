using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using InsuraNex.Models.Domain;
using InsuraNex.Models.ViewModels;
using InsuraNex.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace InsuraNex.Pages.Admin.Data
{
    [Authorize(Roles = "Admin")]
    public class AddPolicyDataModel : PageModel
    {
        private readonly IPolicyOpsRepository policyOpsRepository;

        [BindProperty]
        public AddPolicyData AddPolicyDataReq { get; set; }
        
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        public AddPolicyDataModel(IPolicyOpsRepository policyOpsRepository)
        {
            this.policyOpsRepository = policyOpsRepository;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var insurance = new InsurancePlans()
            {
                PolicyName = AddPolicyDataReq.PolicyName,
                PolicyStatus = AddPolicyDataReq.PolicyStatus,
                SumAssured = AddPolicyDataReq.SumAssured,
                PlanType = AddPolicyDataReq.PlanType,
                EffectiveDate = AddPolicyDataReq.EffectiveDate,
                Features = AddPolicyDataReq.Features,
                Frequency = AddPolicyDataReq.Frequency,
                KeyBenefits = AddPolicyDataReq.KeyBenefits,
                ProductSummary = AddPolicyDataReq.ProductSummary,
                MaxAge = AddPolicyDataReq.MaxAge,
                MinAge = AddPolicyDataReq.MinAge,
                FeaturedImageUrl = AddPolicyDataReq.FeaturedImageUrl,
                UrlHandle = AddPolicyDataReq.UrlHandle,
                Term = AddPolicyDataReq.Term
            };

            await policyOpsRepository.AddAsync(insurance);

            var notification = new Notification
            {
                Type = Enums.NotificationType.Success,
                Message = "New Policy Info Added!"
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Data/List_Policy");
        }

    }
}
