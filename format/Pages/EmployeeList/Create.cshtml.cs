using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using format.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace format.Pages.EmployeeList
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public Employee Employee { get; set; }

        public List<string> f_Course { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var user = _db.Employee.FirstOrDefault(m=>m.f_Email==Employee.f_Email);
            if (user == null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                Random rnd = new Random();
                int num = rnd.Next(52);

                using (var fileStream = new FileStream(Path.Combine(uploads, num + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                Employee.f_Image = @"/images/" + num + extension;
                var Courses = "";
                foreach (var item in f_Course)
                {
                    Courses = item + ","+ Courses;
                }
                Employee.f_Course = Courses;
                await _db.Employee.AddAsync(Employee);
                await _db.SaveChangesAsync();
                return RedirectToPage("empList");
            }
            else
            {
                ViewData["message"] = "Email already exists!";
                return Page();
            }

        }
    }
}
