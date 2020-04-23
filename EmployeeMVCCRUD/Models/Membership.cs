using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeMVCCRUD.Models
{
    public class Membership
    {
        
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}