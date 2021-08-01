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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public Employee Employee { get; set; }

        public List<string> f_Course { get; set; }

        public async Task OnGet(int id)
        {
            Employee = await _db.Employee.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var emp = await _db.Employee.FindAsync(Employee.f_Id);

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
            emp.f_Name = Employee.f_Name;
            emp.f_Mobile = Employee.f_Mobile;
            emp.f_Image = @"/images/" + num + extension;
            emp.f_Gender = Employee.f_Gender;
            emp.f_Email = Employee.f_Email;
            emp.f_Designation = Employee.f_Designation;
            emp.f_Createdate = Employee.f_Createdate;
            emp.f_Course = Employee.f_Course;

          
            await _db.SaveChangesAsync();
            return RedirectToPage("empList");

        }
    }
}
