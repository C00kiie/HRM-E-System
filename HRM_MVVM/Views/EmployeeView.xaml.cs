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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        private  readonly  Employee _employee;
        private readonly EmployeeViewModel _vm;
        public EmployeeView(Employee employee, EmployeeViewModel vm)
        {
            _employee = employee;
            _vm = vm;
            InitializeComponent();
        }

        private void TasksView(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new TasksView(_employee,new TasksViewModel(_vm._context));
            view.Show();
        }

        private void TaskManagement(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new ManageTasks(_employee, new TasksViewModel(_vm._context));
            view.Show();
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new MainWindow();
            view.Show();
        }

        private void MyProfileView(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new ProfileView(_employee,new EmployeeViewModel(_vm._context));
            view.Show();
        }

        private void EmployeeView_OnLoaded(object sender, RoutedEventArgs e)
        {
            var permrole = _employee.type;
            //var fakeflag = 0;
            if (permrole == Employee.MemberType.Manager)
            {
                TasksManagement.Visibility = Visibility.Visible;
                manageAttendence.Visibility = Visibility.Visible;
                ManageEmployees.Visibility = Visibility.Visible;
            }else if (permrole == Employee.MemberType.HR)
            {
                manageAttendence.Visibility = Visibility.Visible;
                ManageEmployees.Visibility = Visibility.Visible;
            }
        }

        private void RegisterAttendanceOnThisDay(object sender, RoutedEventArgs e)
        {
            string registerAttendance = _vm.RegisterAttendance(_employee);
            MessageBox.Show(registerAttendance);
        }

        private void AttendanceView(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new AttendenceView(_employee, new AttendanceViewModel(_vm._context));
            view.Show();
        }

        private void ManageEmployees_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new ManageEmployeesView(_employee,new ViewEmployeesViewModel(_vm._context));
            view.Show();
        }
    }
}
