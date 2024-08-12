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
    public class EditModel : PageModel
    {
        private readonly ICustomerOpsRepository customerOpsRepository;

        [BindProperty]
        public Customer? Customers { get; set; }

        public EditModel(ICustomerOpsRepository customerOpsRepository)
        {
            this.customerOpsRepository = customerOpsRepository;
        }
        public async void OnGet(Guid id)
        {
            Customers = await customerOpsRepository.GetAsync(id);
        }

        public async Task<IActionResult> OnPostUpdate(Guid id)

        {
            try
            {
                Customers.Id = id;
            customerOpsRepository.UpdateAsync(Customers);

           
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
          
            var deleted = await customerOpsRepository.DeleteAsync(id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Customer Info deleted successfully!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/Admin/Data/List");
            }
            else
                return Page();
        }

        public async Task<IActionResult> OnPostBackToList()
        {
            return RedirectToPage("/Admin/Data/List");
        }
    }
}
