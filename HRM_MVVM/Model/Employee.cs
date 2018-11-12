using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_MVVM.Model
{
    public class Employee
    {
        public enum Permission_
        {
            Admin,
            HR,
            Employee
        }

        public enum Experience_
        {
            Junior, 
            Senior, 
            Trainee, 
            Intern
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public DateTime JoinedSince { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password{ get; set; }
        [Required]
        public Experience_ Experience{ get; set; }
        // not required
        public int DepartmentId { get; set; }
        [Required]
        public int IsActivated { get; set; }
        [Required]
        public Permission_ Permission { get; set; }
    }
}
