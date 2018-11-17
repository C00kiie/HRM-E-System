using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class HolidayRequestsViewModel
    {
        private readonly HRM_DB _context;

        public HolidayRequestsViewModel(HRM_DB context)
        {
            _context = context; 
        }
        public async void RequestHoliday(Employee employee, List<DateTime> offDays)
        {
            HolidayRequests request = new HolidayRequests()
            {
                EmployeeId = employee.Id,
                RequestedDays =  offDays,
                // by default this value is 0 aka rejected
                HStatus_ =  HolidayRequests.HStatus.UnHandled,
                HolidayPermissionLevel = employee.Permission
            };
            _context.HolidayRequests.Add(request);
            await _context.SaveChangesAsync();
        }
        public async void RequestHandling(int requestId, HolidayRequests.HStatus status)
        {
            var request = await _context.HolidayRequests.FirstOrDefaultAsync(p => p.RequestId == requestId);
            if (request != null)
            {
                request.HStatus_ = status;
                await _context.SaveChangesAsync();
            }
        }
    }
}
