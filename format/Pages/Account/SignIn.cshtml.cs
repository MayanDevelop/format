using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using format.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace format.Pages.Account
{
    [BindProperties]
    public class SignInModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SignInModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Login Login { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Login.f_UserName == "admin" && Login.f_Pwd == "Pass")
            {
                var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@admin.com")
                };
                var identity = new ClaimsIdentity(Claims, "CookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

               await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

                return RedirectToPage("/EmployeeList/empList");
            }

            return Page();
        }
    }
}
