using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
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
            HR,
            Employee,

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] public virtual EmployeeLogin EmployeeLogin { get; set; }
        [Required] public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Required] public virtual Department Department { get; set; }
        // not required
        [Required] public MemberType type { get; set; }
        public virtual ICollection<HolidayRequests> HolidayRequests { get; set; }
        public virtual ICollection<EmployeeTasks> Tasks { get; set; }

        // this field is deprecated due to the fact that it'd be later on used for a more advanced usage i.e adding more perms
        // for now MemberType could sustain us
        // refrain from using it 
        //[Required] public virtual List<Permissions> Permission { get; set; }
    }
}
