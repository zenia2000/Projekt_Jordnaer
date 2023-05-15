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
            [BindProperty(SupportsGet = true)]

            public string FilterCriteria { get; set; }

            public List<Medlem> Medlemmer { get; set; }

            private IMedlemService mService;

            public GetAllMembersModel(IMedlemService medlemService)
            {
                mService = medlemService;
            }

            public async Task OnGetAsync()
            {
                if (!FilterCriteria.IsNullOrEmpty())
                {
                    Medlemmer = await mService.GetMemberByNameAsync(FilterCriteria);
                }
                else
                {
                    Medlemmer = await mService.GetAllMembersAsync();
                }

            }
    }
}
