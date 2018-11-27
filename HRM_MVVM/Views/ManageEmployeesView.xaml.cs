using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
        public ManageEmployeesView(Employee employee, ViewEmployeesViewModel vm)
        {
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
                EmployeesList.Items.Add(employee.EmployeeInfo.Name);
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
            this.Hide();
            var view = new EmployeeView(_employee,new EmployeeViewModel(_vm._context));
            view.Show();
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
                MessageBox.Show("Selected an Employee");
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
    }
}
