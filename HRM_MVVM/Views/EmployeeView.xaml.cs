using System.Windows;
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
                manageDepartments.Visibility = Visibility.Visible;
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

        private void ManageDepartments_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new ManageDepartments(_employee,new DepartmentViewModel(_vm._context));
            view.Show();
        }
    }
}
