using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_MVVM.Model
{

    public class Tasks
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
        public int TaskId { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime StartingPoint { get; set; }
        [Required]
        public DateTime EndPoint { get; set; }
        [Required]
        public string details { get; set; }
        [Required]
        public  Status status_ { get; set; }
        [Required]
        public Priority Priority_ { get; set; }
    }
}
