using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_MVVM.Model
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DepartmentId { get; set; }
        public virtual ICollection<Employee> Managers { get; set; }
        public  virtual  ICollection<Employee> Employees { get; set;}
        [Required]
        public string DepartmentName{ get; set; }

    }
}
