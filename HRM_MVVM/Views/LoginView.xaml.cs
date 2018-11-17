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
            this.Username.Text = "dmcness1@shareasale.com";
            this.Password.Text = "1ey0lFoMgg";
            var state =  _vm.Login(Username.Text, Password.Text);
            if (state == true)
            {
                var currentUser = _vm._context.Logins.First(p => p.Email == Username.Text);
                var employeeView = new EmployeeView(new ViewModels.EmployeeViewModel(_vm._context), currentUser);
                employeeView.Show();
            }
            else if (state == false)
            {
                MessageBox.Show("The account has been deactivated");
            }
            else
            {
                MessageBox.Show("no such user");
            }

        }
    }
}
