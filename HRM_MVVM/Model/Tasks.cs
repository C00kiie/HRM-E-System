using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace HRM_MVVM.Model
{

    public class EmployeeTasks 
    {
        public enum Priority
        {
            Low, 
            Normal, 
            Important, 
            Critical, 
            Crucial
        }

        public enum Status
        {
            Done, 
            Not_Done, 
            UnderProgress
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TaskId { get; set; }
        [Required]
        public DateTime StartingPoint { get; set; }
        [Required]
        public DateTime EndPoint { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public  Status Status_ { get; set; }
        [Required]
        public Priority Priority_ { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; internal set; }
        public  virtual  Employee Employee { get; set; }
    }
}
