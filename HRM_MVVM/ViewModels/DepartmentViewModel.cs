using System.Data.Entity;
using System.Linq;
using HRM_MVVM.Model;
namespace HRM_MVVM.ViewModels
{
    public class DepartmentViewModel
    {
        public readonly HRM_DB _context;

        public DepartmentViewModel(HRM_DB context)
        {
            _context = context;
        }
        public async void AddDepartment(int managerId, string departmentName)
        {
            Department department = new Department()
            {
                DepartmentName = departmentName
            };
            var manager = await _context.Employees.FirstOrDefaultAsync(p => p.Id == managerId);
            department.Managers.Add(manager);
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }
        public async void RemoveDepartment(int departmentId)
        {
            // #1 employees that are assigned to this department, they should assigned to unassigned
            // unassigned_department is just an easy way of representing unemployed, and to-be
            // employed workers at x company
           
            var departmentEmployees = await _context.Employees.Where(emp => emp.Department.DepartmentId == departmentId).ToListAsync();
            for (int i = 0; i < departmentEmployees.Count(); i++)
            {
                // where 0 = null, 
                departmentEmployees[i].Department.DepartmentId = 0;
            }
            // #2 remove this department
            var department = await _context.Departments.FirstOrDefaultAsync(p=> p.DepartmentId == departmentId);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }

        }
        public async void AddDepartmentManager(int departmentId, int managerId)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(p => p.DepartmentId == departmentId);
            var manager = await  _context.Employees.FirstOrDefaultAsync(p => p.Id == managerId);
            if (departmentId != null && manager != null)
            {
                department.Managers.Add(manager);
                await _context.SaveChangesAsync();
            }
        }
        public async void AssignEmployee(int employeeId, int departmentId)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(p=>p.Id== employeeId);
            var department = await _context.Departments.FirstOrDefaultAsync(p => p.DepartmentId == departmentId);
            if (emp != null & department != null)
            {
                department.Employees.Add(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
