using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using System.Drawing;

namespace Projekt_Jordnaer.Pages.Medlemmer
{
    public class CreateMemberModel : PageModel
    {
        [BindProperty]
        
        public Medlem Medlem { get; set; }

        private IMedlemService mservice;

        public CreateMemberModel(IMedlemService medlemService)
        {
            mservice = medlemService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await mservice.CreateMemberAsync(Medlem);
            return RedirectToPage("GetAllMembers");
        }
    }
}
