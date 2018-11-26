using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Navigation;

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

        [Required] public virtual EmployeeLogin EmployeeLogin { get; set; }
        [Required] public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Required] public virtual Department Department { get; set; }
        // not required
        public MemberType type { get; set; }
        public virtual ICollection<HolidayRequests> HolidayRequests { get; set; }
        public virtual ICollection<EmployeeTasks> Tasks { get; set; }

        // depreicated as of now;  -> we're using MemberType field to fix perm issues
        [Required] public virtual List<Permissions> Permission { get; set; }
    }
}
