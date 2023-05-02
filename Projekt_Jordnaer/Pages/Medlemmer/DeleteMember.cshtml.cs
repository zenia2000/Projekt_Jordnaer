using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using System.Drawing;

namespace Projekt_Jordnaer.Pages.Medlemmer
{
    public class DeleteMemberModel : PageModel
    {
        [BindProperty]

        public Medlem MemberToDelete { get; set; }

        private IMedlemService _mService { get; set; }

        public DeleteMemberModel(IMedlemService mService)
        {
                _mService = mService;
        }

        public async Task OnGetAsync(int memberID)
        { 
            MemberToDelete = await _mService.DeleteMemberAsync(memberID);
        }

        public async Task<IActionResult> OnPostAsync(int memberID)
        {
            //await _mService.UpdateMemberAsync(memberID);
            return RedirectToPage("GetAllMembers");
        }

        public async Task<IActionResult> OnPostCancel(int memberID)
        {
              return RedirectToPage("GetAllMembers");
        }
    }
}
