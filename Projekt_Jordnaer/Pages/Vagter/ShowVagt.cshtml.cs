using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt_Jordnaer.Pages.Vagter
{
    public class ShowVagtModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostCancel()
        {
            return RedirectToPage("AddVagt");
        }
    }
}
