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
  //  [Authorize(Roles = "Admin")]
    public class List_PolicyModel : PageModel
    {
      
        private readonly IPolicyOpsRepository policyOpsRepository;

        [BindProperty]
        public List<InsurancePlans> InsurancePlans { get; set; }

        public List_PolicyModel(IPolicyOpsRepository policyOpsRepository)
        {
            this.policyOpsRepository = policyOpsRepository;
        }
        public async void OnGet()
        {
            var notificationJson = (string)TempData["Notification"];
            if (notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }
            InsurancePlans = (await policyOpsRepository.GetAllAsync()).ToList();
        }
    }
}