using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace format.Model
{
    public class Login
    {
        [Key]
        public int f_sno { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string f_UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string f_Pwd { get; set; }
    }
}
