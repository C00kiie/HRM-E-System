using System.Windows;
using HRM_MVVM.Model;
using HRM_MVVM.ViewModels;

namespace HRM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : Window
    {

        private readonly Employee _employee;
        private readonly EmployeeViewModel _vm;
        public ProfileView(Employee employee, EmployeeViewModel vm)
        {
            _employee = employee;
            _vm = vm;
            InitializeComponent();
        }

        private void UpdateEmployeeCredentials(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(email.Text) && !string.IsNullOrWhiteSpace(password_Copy.Text))
            {
                string message = _vm.UpdateEmployeeCredentials(email.Text.Trim(), password.Text.Trim(), password_Copy.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Please enter the email/password combo");
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Close();
            var view = new EmployeeView(_employee, new EmployeeViewModel(_vm._context));
            view.Show();
        }

        private void UpdateEmployeeInfo(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) && birthdate.SelectedDate.Value != null)
            {
            _vm.UpdateEmployee(_employee.Id, Name.Text.Trim(), birthdate.SelectedDate.Value);
                MessageBox.Show("Done!");
            }
        }
    }
}
