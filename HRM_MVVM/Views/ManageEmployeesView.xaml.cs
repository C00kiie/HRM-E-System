using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using HRM_MVVM.Model;
using HRM_MVVM.ViewModels;

namespace HRM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for ManageEmployeesView.xaml
    /// </summary>
    public partial class ManageEmployeesView : Window
    {
        private readonly Employee _employee;
        private readonly ViewEmployeesViewModel _vm;
        private Dictionary<int, Employee> _EmployeeDict = new Dictionary<int, Employee>();
        private Dictionary<int, Department> _departmentsDict = new Dictionary<int, Department>();
        private Dictionary<int, Employee.MemberType> _roles = new Dictionary<int, Employee.MemberType>();
        // runmode = 0 => def => go back to employee view,
        // runmode = any other value = > terminate/hide
        private int runmode;
        public ManageEmployeesView(Employee employee, ViewEmployeesViewModel vm, int runmode = 0)
        {
            this.runmode = runmode;
            _employee = employee;
            _vm = vm;
            InitializeComponent();
        }


        private void form_loaded(object sender, RoutedEventArgs e)
        {
            var Employees = _vm.GetEmployees();
            Employees.Remove(_employee);
            int i = 0;
            foreach (var employee in Employees)
            {
                _EmployeeDict[i] = Employees.ElementAt(i);
                var element = employee.EmployeeInfo.Name + "| Department => " + employee.Department.DepartmentName
                    + "| role => " + employee.type.ToString();
                EmployeesList.Items.Add(element);
                i++;
            }
        }

        private void Refersh(object sender, RoutedEventArgs e)
        {
            EmployeesList.Items.Clear();
            var Employees = _vm.GetEmployees();
            Employees.Remove(_employee);
            int i = 0;
            foreach (var employee in Employees)
            {
                _EmployeeDict[i] = Employees.ElementAt(i);
                EmployeesList.Items.Add(employee.EmployeeInfo.Name);
                i++;
            }

        }

        private void back(object sender, RoutedEventArgs e)
        {
            if (this.runmode == 0)
            {
                this.Hide();
                var view = new EmployeeView(_employee, new EmployeeViewModel(_vm._context));
                view.Show();
            }
            else
            {
                this.Hide();
            }
        }

        private void DeactivateEmployee(object sender, RoutedEventArgs e)
        {
            var index = EmployeesList.SelectedIndex;
            if (index != -1)
            {
                var employee = _EmployeeDict[index];
                _vm.DeactivateUser(employee);
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Select an Employee");
            }
        }

        private void ActivateEmployee(object sender, RoutedEventArgs e)
        {
            var index = EmployeesList.SelectedIndex;
            if (index != -1)
            {
                var employee = _EmployeeDict[index];
                _vm.ActivateUser(employee.Id);
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Select an Employee");
            }
        }

        private void AddEmployeeView(object sender, RoutedEventArgs e)
        {
            var view = new RegisterView(new RegisterViewModel(_vm._context),1);
            view.Show();
        }

        private void RemoveEmployee(object sender, RoutedEventArgs e)
        {
            var index = EmployeesList.SelectedIndex;
            if (index != -1)
            {
                var employee = _EmployeeDict[index];
                _vm.RemoveEmployee(employee);
                EmployeesList.Items.RemoveAt(index);
                MessageBox.Show("removed");
            }
            else
            {
                MessageBox.Show("Select an Employee");
            }
        }

      

        private void ViewTasks(object sender, RoutedEventArgs e)
        {
            var index = EmployeesList.SelectedIndex;
            if (index != -1)
            {
                var employee = _EmployeeDict[index];
                var view = new TasksView(employee,new TasksViewModel(_vm._context), 1);
                view.Show();
            }
            else
            {
                MessageBox.Show("Select an Employee");
            }
        }

        private void ViewAttendance(object sender, RoutedEventArgs e)
        {
            var index = EmployeesList.SelectedIndex;
            if (index != -1)
            {
                var employee = _EmployeeDict[index];
                var view = new AttendenceView(employee,new AttendanceViewModel(_vm._context),1);
                view.Show();
            }
            else
            {
                MessageBox.Show("Select an Employee");
            }
        }

        private void Departments_list_ui_OnLoaded(object sender, RoutedEventArgs e)
        {
            var departments = _vm.GetDepartments();
            int i = 0;
            foreach (var department in departments)
            {
                _departmentsDict[i] = department;
                departments_list_ui.Items.Add(department.DepartmentName);
                i++;
            }
        }

        private void ReLoad()
        {
            EmployeesList.Items.Clear();
            var Employees = _vm.GetEmployees();
            Employees.Remove(_employee);
            int i = 0;
            foreach (var employee in Employees)
            {
                _EmployeeDict[i] = Employees.ElementAt(i);
                var element = employee.EmployeeInfo.Name + "| Department => " + employee.Department.DepartmentName
                              + "| role => " + employee.type.ToString();
                EmployeesList.Items.Add(element);
                i++;
            }
        }
        private void ChangeDepartment_OnClick(object sender, RoutedEventArgs e)
        {
            var index = departments_list_ui.SelectedIndex;
            var indexOfEmployee = EmployeesList.SelectedIndex;
            if (index != -1 && indexOfEmployee != -1)
            {
                Department department = _departmentsDict[index];
                Employee employee = _EmployeeDict[indexOfEmployee];
                _vm.AssignEmployee(employee, department.DepartmentId);
                ReLoad();
                MessageBox.Show("Done");
            }
        }

        private void ChangeRole_OnClick(object sender, RoutedEventArgs e)
        {
            var index = EmployeesList.SelectedIndex;
            var indexOfRole = RolesList.SelectedIndex;
            if (index != -1)
            {
                Employee employee = _EmployeeDict[index];
                var role = _roles[indexOfRole];
                _vm.ChangeRole(employee,role);
                ReLoad();
                MessageBox.Show("Done");
            }
        }

        private void RolesLoaded(object sender, RoutedEventArgs e)
        {
            var memberTypes = Enum
                .GetValues(typeof(Employee.MemberType))
                .Cast<Employee.MemberType>();
            int i = 0;
            foreach (var item in memberTypes)
            {
                _roles[i] = item;
                RolesList.Items.Add(item);
                i++;
            }
        }
    }

}

