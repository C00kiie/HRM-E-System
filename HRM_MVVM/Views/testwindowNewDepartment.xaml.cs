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

namespace HRM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for testwindowNewDepartment.xaml
    /// </summary>
    public partial class testwindowNewDepartment : Window
    {
        private readonly ViewModels.DepartmentViewModel _vm;
        public testwindowNewDepartment(ViewModels.DepartmentViewModel vm)
        {
            _vm = vm;
            InitializeComponent();
        }

        private void add_department(object sender, RoutedEventArgs e)
        {
            _vm.AddDepartment(box.Text.Trim());
            MessageBox.Show("done");
        }
    }
}
