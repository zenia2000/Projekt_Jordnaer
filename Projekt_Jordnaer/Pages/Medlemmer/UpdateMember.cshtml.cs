using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Projekt_Jordnaer.Interfaces;
using Projekt_Jordnaer.Models;
using System.Drawing;

namespace Projekt_Jordnaer.Pages.Medlemmer
{
    public class UpdateMemberModel : PageModel
    {
        [BindProperty]

        public Medlem MemberToUpdate { get; set; }

        private IMedlemService _mService;

        public UpdateMemberModel(IMedlemService mService)
        {
            _mService = mService;
        }

        public async Task OnGet(int memberID)
        {
            MemberToUpdate = await _mService.GetMemberFromIDAsync(memberID);
        }

        public async Task<IActionResult> OnPost()
        {
            bool ok = await _mService.UpdateMemberAsync(MemberToUpdate, MemberToUpdate.MemberID);
            if (ok == true)
            {
                return RedirectToPage("GetAllMembers");
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostCancel()
        {
            return RedirectToPage("GetAllMembers");
        }
    }
}
