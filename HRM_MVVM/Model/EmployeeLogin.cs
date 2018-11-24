using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_MVVM.Model
{
    public class EmployeeLogin
    {
        [Key]
        [ForeignKey("Employee")]
        public int LoginId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int IsActivated { get; set; }
        public Employee Employee { get; set; }
        
    }
}
