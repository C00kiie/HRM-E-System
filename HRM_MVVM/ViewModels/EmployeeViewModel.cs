using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class EmployeeViewModel
    {
        public readonly HRM_DB _context;

        public EmployeeViewModel(HRM_DB context)
        {
            _context = context;
        }
        public  void UpdateEmployee(int employeeId,
            string name,
            DateTime birthDateTime
        )
        {
            var emp =  _context.EmployeeInfos.FirstOrDefault(p => p.EmployeeInfoId == employeeId);
            if (emp != null)
            {
                // updating all fields 
                emp.Name = name;
                emp.Birthdate = birthDateTime;
                // save changes
                 _context.SaveChangesAsync();
            }

        }
        public bool emailExists(string email)
        {
            var check = _context.Employees.FirstOrDefault(p => p.EmployeeLogin.Email == email);
            return check != null;
        }
        public  string UpdateEmployeeCredentials(string email, string password, string newPassword)
        {
            var emp = _context.Logins.FirstOrDefault(p => p.Email == email);
            if (emp != null)
            {
                    if (emp.Password == Functions.Password.ComputeSha256Hash(password))
                    {
                        emp.Email = email;
                        emp.Password = Functions.Password.ComputeSha256Hash(newPassword);
                        _context.SaveChanges();
                        return "Done";
                    }
                    else
                    {
                        return "Wrong password";
                    }
            }

            return "Null exception occured in the database; report the bug";
        }

    }
}
