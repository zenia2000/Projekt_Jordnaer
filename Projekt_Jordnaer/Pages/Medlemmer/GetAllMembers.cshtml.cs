using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Projekt_Jordnaer.Pages.Medlemmer
{
    public class GetAllMembersModel : PageModel
    {
            [BindProperty]

            public List<Medlem> Medlemmer { get; set; }

            private IMedlemService mService;

            public GetAllMembersModel(IMedlemService medlemService)
            {
                mService = medlemService;
            }

            public async Task OnGetAsync()
            {
                    Medlemmer = await mService.GetAllMembersAsync();
            }

            public async Task <IActionResult> OnPostOpret()
            {
                return RedirectToPage("CreateMember");
            }
    }
}
