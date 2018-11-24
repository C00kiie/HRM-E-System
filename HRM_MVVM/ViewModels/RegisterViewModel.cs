using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Navigation;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class RegisterViewModel
    {
        public readonly HRM_DB _context;

        public RegisterViewModel(HRM_DB context)
        {
            _context = context;
        }

        public bool emailExists(string email)
        {
            var check = _context.Employees.FirstOrDefault(p => p.EmployeeLogin.Email == email);
            return check != null;
        }
        public  string AddEmployee(
            string name,
            DateTime birthDateTime,
            DateTime joinedSinceDateTime,
            string password,
            string email,
            Employee.Experience_ experience,
            List<Employee.Permissions> perms,
            int isActivated,
            int departmentId = 0
        )

        {
            var department = _context.Departments.Find(departmentId+1);
            var empInfo = new EmployeeInfo()
            {
                JoinedSince = joinedSinceDateTime,
                Birthdate = birthDateTime,
                Experience = experience,
                Name = name,
            };
            var empLogin = new EmployeeLogin()
            {
                Email = email,
                IsActivated = isActivated,
                Password = password
                
            };
            var emp = new Employee()
            {
                EmployeeInfo = empInfo,
                EmployeeLogin = empLogin,
                Permission = perms,
                Department = department
            };

            // saving changes, but before that checking the email existence
            if (!emailExists(email))
            {
                _context.Employees.Add(emp);
                _context.EmployeeInfos.Add(empInfo);
                _context.Logins.Add(empLogin);
                _context.SaveChanges();
                return "Done";
            }
            else
            {
                return "this email exists";
            }
        }

        public  List<Department> LoadDepartments()
        {
            return  _context.Departments.ToList();
        }
    }
     


}
