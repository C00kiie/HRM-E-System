using System;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime StartingPoint { get; set; }
        [Required]
        public DateTime EndPoint { get; set; }
        [Required]
        public string details { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public Priority Priority_ { get; set; }
    }
}
