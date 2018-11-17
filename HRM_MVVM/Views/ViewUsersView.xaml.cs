using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using HRM_MVVM.Model;
using HRM_MVVM.ViewModels;

namespace HRM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for ViewUsersView.xaml
    /// </summary>
    public partial class ViewUsersView : Window
    {
        private readonly List<EmployeeInfo> users;
        private readonly ViewModels.ViewEmployeesViewModel _vm;
        public ViewUsersView(ViewEmployeesViewModel vm)
        {
            _vm = vm;
            users =  _vm.GetUsersInfo();
            InitializeComponent();
        }

        
    }
}
