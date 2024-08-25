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
    public class Edit_PolicyModel : PageModel
    {
        private readonly IPolicyOpsRepository policyOpsRepository;



        [BindProperty]
        public InsurancePlans insurance { get; set; }

        [BindProperty]
        public AddPolicyData FeaturedImage { get; set; }


        public Edit_PolicyModel(IPolicyOpsRepository policyOpsRepository)
        {
            this.policyOpsRepository = policyOpsRepository;
        }       
        public async void OnGet(Guid id)
        {
            insurance = await policyOpsRepository.GetAsync(id);
        }

        public async Task<IActionResult> OnPostUpdate(Guid id)

        {
            try
            {
                insurance.Id = id;
                policyOpsRepository.UpdateAsync(insurance);

           
                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Record updated successfully!"
                };

            }
            catch (Exception ex)
            {

                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Something went wrong!"
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteRecord(Guid id)

        {
          
            var deleted = await policyOpsRepository.DeleteAsync(id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Policy Info deleted successfully!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/Admin/Data/List_Policy");
            }
            else
                return Page();
        }

        public async Task<IActionResult> OnPostBackToList()
        {
            return RedirectToPage("/Admin/Data/List_Policy");
        }
    }
}
