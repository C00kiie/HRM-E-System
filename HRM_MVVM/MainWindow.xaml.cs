using System.Windows;
using HRM_MVVM.Model;
using HRM_MVVM.ViewModels;
using HRM_MVVM.Views;

namespace HRM_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HRM_DB _context;
        public MainWindow()
        {
            var context = new HRM_DB();
            _context = context;
            InitializeComponent();
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new Views.LoginView(new LoginViewModel(_context));
            view.Show();
        }
        private void register_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new Views.RegisterView(new RegisterViewModel(_context));
            view.Show();
        }


    }
}
