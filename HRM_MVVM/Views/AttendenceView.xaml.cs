using System;
using System.Windows;
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
                var element = day.RequestedDay.ToLongDateString() + " | request status=> " + day.ReqStatus.ToString();

                Days.Items.Add(element);
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
                this.Close();
                var view = new EmployeeView(_employee,new EmployeeViewModel(_vm._context));
                view.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void RequestHoliday(object sender, RoutedEventArgs e)
        {
            if (this.requested_holiday.SelectedDate != null)
            {
                _vm.RequestHoliday(_employee,this.requested_holiday.SelectedDate.Value);
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Not done :<");
            }
        }
    }
}
