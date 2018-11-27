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
    /// Interaction logic for AttendenceView.xaml
    /// </summary>
    public partial class AttendenceView : Window
    {
        private readonly AttendanceViewModel _vm;
        private readonly Employee _employee;
        private int runMode;
        public AttendenceView(Employee employee, AttendanceViewModel vm, int runmode = 0)
        {
            runMode = runmode;
            _vm = vm;
            _employee = employee;
            InitializeComponent();
        }

        private void loadDays(object sender, RoutedEventArgs e)
        {
            var attendanceHistory = _vm.GetAttendanceHistoryByThisMonth(_employee, DateTime.Now);
            foreach (var day in attendanceHistory)
            {
                Days.Items.Add(day.Day.ToLongDateString());
            }
        }

        private void LoadHolidays(object sender, RoutedEventArgs e)
        {
            Days.Items.Clear();
            var holidays = _vm.GetHolidaysByThisMonth(_employee, DateTime.Now);
            foreach (var day in holidays)
            {
                Days.Items.Add(day.RequestedDay.ToLongDateString());
            }
        }

        private void LoadDays(object sender, RoutedEventArgs e)
        {
            Days.Items.Clear();
            var attendanceHistory = _vm.GetAttendanceHistoryByThisMonth(_employee, DateTime.Now);
            foreach (var day in attendanceHistory)
            {
                Days.Items.Add(day.Day.ToLongDateString());
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            if (this.runMode == 0)
            {
                this.Hide();
                var view = new EmployeeView(_employee,new EmployeeViewModel(_vm._context));
                view.Show();
            }
            else
            {
                this.Hide();
            }
        }
    }
}
