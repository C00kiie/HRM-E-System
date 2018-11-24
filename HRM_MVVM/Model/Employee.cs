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
        public enum MemberType
        {
            Manager,
            Employee
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public EmployeeLogin EmployeeLogin { get; set; }
        public EmployeeInfo EmployeeInfo { get; set; }

        public Department Department { get; set; }
        // not required
        public MemberType type { get; set; }
        public virtual ICollection<HolidayRequests> HolidayRequests { get; set; }
        public virtual ICollection<EmployeeTasks> Tasks { get; set; }
        [Required] public List<Permissions> Permission { get; set; }
    }
}
