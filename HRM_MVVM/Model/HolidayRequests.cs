using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_MVVM.Model
{
    public class HolidayRequests
    {
        public enum HStatus
        {
            Accepted,
            Rejected,
            UnHandled
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RequestId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        // requested day or days
        public List<DateTime> RequestedDays { get; set; }
        [Required]
        // 
        public HStatus HStatus_ { get; set; }
        [Required]
        // an employee has a request level of 1  which can be managed by managers/admins
        // A manager has a request level of 2 which can be managed by admins
        // an admin can request holidays and accept it by himself
        // {considering that he is an eligible member that could be trusted} 
        public Employee.Permission_ HolidayPermissionLevel { get; set; }

    }
}
