using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using format.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace format.Pages.EmployeeList
{
    public class empListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public empListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Employee> Employees { get; set; }

        public async Task OnGet()
        {
            Employees = await _db.Employee.ToListAsync();
        }
    }
}
