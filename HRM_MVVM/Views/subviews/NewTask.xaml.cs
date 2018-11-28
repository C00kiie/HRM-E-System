using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using HRM_MVVM.Model;
using HRM_MVVM.ViewModels;

namespace HRM_MVVM.Views.subviews
{
    /// <summary>
    /// Interaction logic for NewTask.xaml
    /// </summary>
    public partial class NewTask : Window
    {
        private readonly Employee _employee;
        private readonly TasksViewModel _vm;
        private Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        public NewTask(Employee employee, TasksViewModel vm)
        {
            _employee = employee;
            _vm = vm;
            InitializeComponent();
        }

        private void Sumbit(object sender, RoutedEventArgs e)
        {
            // dates
            var from = From.SelectedDate.Value;
            var to = To.SelectedDate.Value;
            //priority
            var priorityString = this.priority.SelectedItem.ToString();
            // casting string to enum type
            EmployeeTasks.Priority prioEnumType =
                (EmployeeTasks.Priority) 
                Enum.Parse(typeof(EmployeeTasks.Priority), priorityString);
            // details
            string detailstext = new TextRange(details.Document.ContentStart, details.Document.ContentEnd).Text;

            // employee id
            var selected_employee_index = employeesDropList.SelectedIndex;
            var emp = employees[selected_employee_index];

            try
            {
                if (!string.IsNullOrWhiteSpace(detailstext) && from != null && to != null && !string.IsNullOrWhiteSpace(priorityString))
                {
                    _vm.AddTask(emp.Id, prioEnumType, from, to, EmployeeTasks.Status.NotDone, detailstext);
                    MessageBox.Show("Done");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("all fields are required");
            }
        }


        private void Priority_loaded(object sender, RoutedEventArgs e)
        {
            var experienceList = Enum
                .GetValues(typeof(EmployeeTasks.Priority))
                .Cast<EmployeeTasks.Priority>();
            foreach (var item in experienceList)
            {
                priority.Items.Add(item);
            }
        }

        private void EmployeesDropList_OnLoaded(object sender, RoutedEventArgs e)
        {
            var employees = _vm.GetEmployeesByDepartment(_employee.Department.DepartmentId);
            employees.Remove(_employee);
            int i = 0;
            foreach (var employee in employees)
            {
                this.employees[i] = employee;
                employeesDropList.Items.Add(employee.EmployeeInfo.Name);
                i++;

            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
