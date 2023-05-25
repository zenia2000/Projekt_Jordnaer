using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;

namespace Projekt_Jordnaer.Pages.Vagter
{
    public class UpdateVagtModel : PageModel
    {
        [BindProperty]
        public Vagt Vagt { get; set; }
        private IVagtService vService;
        
        public UpdateVagtModel(IVagtService vagtService)
        {
            vService = vagtService;
        }
        
        public async Task OnGetAsync(int VagtId)
        {
            Vagt = await vService.GetVagtFromIdAsync(VagtId);
        }
        public async Task<IActionResult> OnPostAsync(Vagt vagt, int VagtId)
        {       
            bool ok = await vService.UpdateVagtAsync(vagt, VagtId);
                if (ok == true)
                    return RedirectToPage("ShowVagt");
                else
                    return Page();
        }
        public async Task<IActionResult> OnPostCancel()
        {
            return RedirectToPage("ShowVagt");
        }
        
    }
}
