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
        public async Task OnGetAsync(int vagtId)
        {
            Vagt = await vService.GetVagtFromIdAsync(vagtId);
        }
        public async Task<IActionResult> OnPostAsync(Vagt vagt, int vagtId)
        {       
            bool ok = await vService.UpdateVagtAsync(vagt, vagtId);
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
