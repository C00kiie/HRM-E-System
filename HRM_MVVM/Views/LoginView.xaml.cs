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
            var state = _vm.Login(Username.Text, Password.Text);
            if (state.Result == true)
            {
                MessageBox.Show("Existent");
            }
            else if (state.Result == false)
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
