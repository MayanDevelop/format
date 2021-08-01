using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace format.Model
{
    public class Employee
    {
        [Key]
        public int f_Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string f_Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not valid")]
        public string f_Email { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile")]
        public string f_Mobile { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public string f_Designation { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string f_Gender { get; set; }
        [Required]
        [Display(Name = "Course")]
        public string f_Course { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string f_Image { get; set; }
        [Required]
        public  DateTime f_Createdate { get; set; }
    }
}
