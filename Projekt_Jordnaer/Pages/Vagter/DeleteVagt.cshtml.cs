using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;

namespace Projekt_Jordnaer.Pages.Vagter
{
    public class DeleteVagtModel : PageModel
    {
        [BindProperty]
        public Vagt Vagt { get; set; }
        private IVagtService vService;
        public DeleteVagtModel(IVagtService vagtService)
        {
            vService = vagtService;
        }
        public async Task OnGetAsync(int vagtId)
        {
            Vagt = await vService.GetVagtFromIdAsync(vagtId);
        }
        public async Task<IActionResult> OnPostAsync(int vagtId)
        {
            await vService.DeleteVagtAsync(vagtId);
            return RedirectToPage("ShowVagt");
        }
        public async Task<IActionResult> OnPostCancel()
        {
            return RedirectToPage("ShowVagt");
        }
    }

}
