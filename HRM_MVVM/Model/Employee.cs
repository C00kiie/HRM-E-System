using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_MVVM.Model
{
    public class Employee
    {
        public  enum Permissions
        {
            Admin,
            HR,
            Employee
        }

        public  enum Experience_
        {
            Junior, 
            Senior, 
            Trainee, 
            Intern
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] public virtual EmployeeLogin EmployeeLogin { get; set; }
        [Required] public virtual EmployeeInfo EmployeeInfo { get; set; }
        // not required
        [Required] public virtual ICollection<HolidayRequests> HolidayRequests { get; set; }
        public  Department Department { get; set; }
        [Required] public virtual ICollection<EmployeeTasks> Tasks { get; set; }
        [Required] public List<Permissions> Permission { get; set; }
    }
}
