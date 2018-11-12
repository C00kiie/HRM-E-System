using System;
using System.ComponentModel.DataAnnotations;

namespace HRM_MVVM.Model
{
    public class HolidayRequests
    {
        public enum HStatus
        {
            Accepted,
            Rejected
        }
        // user id
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime RequestedDay { get; set; }
        [Required]
        // 
        public HStatus HStatus_ { get; set; }
        [Required]
        // an employee has a request level of 1  which can be managed by managers/admins
        // A manager has a request level of 2 which can be managed by admins
        // an admin can request holidays and accept it by himself
        // {considering that he is an eligible member that could be trusted} 
        public int HolidayPermissionLevel { get; set; }

    }
}
