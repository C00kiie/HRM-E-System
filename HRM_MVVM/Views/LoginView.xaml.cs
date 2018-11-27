using System.Windows;
using HRM_MVVM.Model;
using HRM_MVVM.ViewModels;

namespace HRM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private LoginViewModel _vm;
        public LoginView(LoginViewModel vm)
        {
            _vm = vm;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Username.Text = "testAccount@testAccount.com";
            //this.Password.Text = "testAccount";
            var state =  _vm.Login(Username.Text, Password.Text);
            if (state  == LoginViewModel.LoginCodes.SuccessfulAndActivated)
            {
                this.Hide();
                Employee emp = _vm.LoadEmployee(this.Username.Text);
                var view = new EmployeeView(emp,new EmployeeViewModel(_vm._context));
                view.Show();
            }
            else if (state == LoginViewModel.LoginCodes.SuccessfulAndNotActivated)
            {
                MessageBox.Show("The account has been deactivated");
            }
            else if (state == LoginViewModel.LoginCodes.WrongPasswordOrUsername)
            {
                MessageBox.Show("wrong password or username");
            } else if(state == LoginViewModel.LoginCodes.NotFound)
            {
                MessageBox.Show("no such user");
            }

        }
    }
}
