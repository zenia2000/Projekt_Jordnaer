using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using Projekt_Jordnaer.Services;

namespace Projekt_Jordnaer.Pages.Vagter
{
    public class ShowVagtModel : PageModel
    {
        public List<Vagt> Vagts { get; set; }
        private IVagtService _vService;
        public ShowVagtModel(IVagtService vService)
        {
            _vService = vService;
        }

        public async Task OnGet()
        {
            Vagts = await _vService.GetAllVagtAsync(); 
        }
        public async Task<IActionResult> OnPostOpret()
        {
            return RedirectToPage("AddVagt");
        }
    }
}
