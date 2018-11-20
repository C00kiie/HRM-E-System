using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_MVVM.Model
{
    public class EmployeeInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [ForeignKey("Employee")]
        public int  EmployeeInfoId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public Employee.Experience_ Experience { get; set; }
        [Required]
        public DateTime JoinedSince { get; set; }
        // not required since it'd be nullable {if not included}
        [Required] public virtual Employee Employee { get; set; }
    }
}
