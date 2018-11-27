using System;
using System.Data.Entity;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class EmployeeInfoViewModel
    {
        public readonly HRM_DB _context;

        public EmployeeInfoViewModel(HRM_DB context)
        {
            _context = context;
        }
        public async void UpdateEmployee(int userId,
            string name,
            DateTime birthDateTime
            )
        {
            var emp = await _context.EmployeeInfos.FirstOrDefaultAsync(p => p.EmployeeInfoId == userId);
            if (emp != null)
            {
                // updating all fields 
                emp.Name = name;
                emp.Birthdate = birthDateTime;
                // save changes
                await _context.SaveChangesAsync();
            }

        }

        public async void UpdateEmployeeCreditentials(string email, string password)
        {
            
        }




    }


   
}
