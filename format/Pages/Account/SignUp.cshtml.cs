using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using format.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace format.Pages.Account
{
    public class SignUpModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SignUpModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Login Login { get; set; }

        public void OnGet()
        {
        }


    }
}
