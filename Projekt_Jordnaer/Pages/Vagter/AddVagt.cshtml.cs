using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using Projekt_Jordnaer.Services;

namespace Projekt_Jordnaer.Pages.Vagter
{
    public class AddVagtModel : PageModel
    {
        public Vagt Vagt { get; set; }
        private IVagtService vService;
        public AddVagtModel(IVagtService vagtService)
        {
            vService = vagtService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await vService.CreateVagtAsync(Vagt);
            return RedirectToPage("Index");
        }
    }
}
