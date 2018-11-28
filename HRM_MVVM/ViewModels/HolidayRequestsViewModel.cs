using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class HolidayRequestsViewModel
    {
        public readonly HRM_DB _context;

        public HolidayRequestsViewModel(HRM_DB context)
        {
            _context = context; 
        }

        public List<HolidayRequests> GetUnhandledRequests()
        {
            var UnhandledRequests = from temp in _context.HolidayRequests
                where temp.ReqStatus == HolidayRequests.RequestStatus.UnHandled
                select temp;
            List<HolidayRequests> requests = UnhandledRequests.ToList();
            return requests;
        }
        public List<HolidayRequests> getAllRequests()
        {
            var allRequests =  _context.HolidayRequests.ToList();
            return allRequests;
        }
        public List<HolidayRequests> GetHandledRequestes()
        {
            var UnhandledRequests = from temp in _context.HolidayRequests
                where temp.ReqStatus != HolidayRequests.RequestStatus.UnHandled
                select temp;
            List<HolidayRequests> requests = UnhandledRequests.ToList();
            return requests;
        }
        public async void RequestHoliday(Employee employee, DateTime offDays)
        {
           
            HolidayRequests request = new HolidayRequests()
            {
                EmployeeId = employee.Id,
                RequestedDay =  offDays,
                // by default this value is unhandled
                ReqStatus =  HolidayRequests.RequestStatus.UnHandled,
                
                // this param is gonna be available once we add permissions like
                // CanTakeHoliday perm and CanApproveHoliday perm.
               //HolidayPermissionsLevel= employee.Permission.
            };
            _context.HolidayRequests.Add(request);
            await _context.SaveChangesAsync();
        }
        public  void RequestHandling(int requestId, HolidayRequests.RequestStatus status)
        {
            var request =  _context.HolidayRequests.FirstOrDefault(p => p.RequestId == requestId);
            if (request != null)
            {
                var attendance =
                    _context.Attendances
                        .FirstOrDefault(p => p.Day == request.RequestedDay);
                if (attendance != null)
                {
                    _context.Attendances.Remove(attendance);
                }
                request.ReqStatus = status;
                _context.SaveChanges();
            }
        }
    }
}
