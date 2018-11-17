using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var emp = await _context.EmployeeInfos.FindAsync(userId);
            // updating all fields belonging 
            emp.Name = name;
            emp.Birthdate = birthDateTime;
            // save changes
            await _context.SaveChangesAsync();

        }


        public async Task<EmployeeInfo> Employee_info(int userId)
        {
            return await _context.EmployeeInfos.FirstOrDefaultAsync(p => p.Id == userId);
        }


    }


   
}
