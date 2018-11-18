using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_MVVM.Model
{
    public class Employee
    {
        public  enum Permission_
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

        [Required] public virtual login Login { get; set; }
        [Required] public virtual EmployeeInfo EmployeeInfo { get; set; }
        [Required] public Employee.Permission_ Permission { get; set; }
    }
}
