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
        
        public MainWindow()
        {
            this.Visibility = Visibility.Hidden;
            var context = new HRM_DB();
            var view = new LoginView(new ViewModels.LoginViewModel(context));
            view.Show();

            InitializeComponent();
        }
    }
}
