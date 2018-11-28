using System.Windows;
using System.Windows.Input;
using HRM_MVVM.Model;
using HRM_MVVM.ViewModels;
using HRM_MVVM.Views.subviews;
using System.Collections.Generic;

namespace HRM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for ManageTasks.xaml
    /// </summary>
    public partial class ManageTasks : Window
    {
        private readonly Employee _employee;
        private readonly TasksViewModel _vm;
        private Dictionary<int, EmployeeTasks> tasksDict = new Dictionary<int, EmployeeTasks>();
        public ManageTasks(Employee employee, TasksViewModel vm)
        {
            _employee = employee;
            _vm = vm;
            InitializeComponent();
        }

        private void newTask(object sender, RoutedEventArgs e)
        {
            var view = new subviews.NewTask(_employee,_vm);
            view.Show();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Close();
            var view = new EmployeeView(_employee,new EmployeeViewModel(_vm._context));
            view.Show();
        }

        private void TasksLoaded(object sender, RoutedEventArgs e)
        {
            var tasks = _vm.GetDepartmentEmployeesTasks(_employee.Department.DepartmentId);
            int i = 0;
            foreach (var task in tasks)
            {
                tasksDict[i] = task;
                string taskString = task.Employee.EmployeeInfo.Name + " : " + task.Priority_.ToString() + ": " + task.Details.ToString();
                TasksList.Items.Add(taskString);
                i++;
            }
        }

        private void RefershTasks(object sender, RoutedEventArgs e)
        {
            TasksList.Items.Clear();
            tasksDict.Clear();
            var tasks = _vm.GetDepartmentEmployeesTasks(_employee.Department.DepartmentId);
            int i = 0;
            foreach (var task in tasks)
            {
                tasksDict[i] = task;
                string taskString =  task.Employee.EmployeeInfo.Name+ " : "+ task.Priority_.ToString() + ": " + task.Details.ToString();
                TasksList.Items.Add(taskString);
                i++;
            }
        }
        private void TasksList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected_index = TasksList.SelectedIndex;
            var view = new TaskDetails(tasksDict[selected_index],_vm);
            view.Show();
        }
    }
}
