using System.Collections.Generic;
using System.Windows;
using HRM_MVVM.Model;
using HRM_MVVM.ViewModels;

namespace HRM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for ManageAttendence.xaml
    /// </summary>
    
    public partial class ManageAttendence : Window
    {
        private readonly Employee _employee;
        private readonly  Dictionary<int, HolidayRequests> _holidayDict = new Dictionary<int, HolidayRequests>();
        private readonly HolidayRequestsViewModel _vm;
        public ManageAttendence(Employee employee ,HolidayRequestsViewModel vm)
        {
            _employee = employee;
            _vm = vm;
            InitializeComponent();
        }


        private void requests_loaded(object sender, RoutedEventArgs e)
        {
            var requests = _vm.getAllRequests();
            int i = 0;
            foreach (var request in requests)
            {
                _holidayDict[i] = request;
                var element = request.Employee.EmployeeInfo.Name + " : " +
                              request.RequestedDay.ToLongDateString() + " | " +
                              "request_status => " + request.ReqStatus.ToString();
                requests_list_ui.Items.Add(element);
                i++;
            }

        }

        private void back(object sender, RoutedEventArgs e)
        {

            this.Close();
            var view = new EmployeeView(_employee,new EmployeeViewModel(_vm._context));
            view.Show();
        }

        private void Refersh(object sender, RoutedEventArgs e)
        {
            var requests = _vm.getAllRequests();
            _holidayDict.Clear();
            requests_list_ui.Items.Clear();
            int i = 0;
            foreach (var request in requests)
            {
                _holidayDict[i] = request;
                var element = request.Employee.EmployeeInfo.Name + " : " +
                              request.RequestedDay.ToLongDateString() + " | " +
                              "request_status => " + request.ReqStatus.ToString();
                requests_list_ui.Items.Add(element);
                i++;
            }
        }

        private void reload()
        {
            var requests = _vm.getAllRequests();
            _holidayDict.Clear();
            requests_list_ui.Items.Clear();
            int i = 0;
            foreach (var request in requests)
            {
                _holidayDict[i] = request;
                var element = request.Employee.EmployeeInfo.Name + " : " +
                              request.RequestedDay.ToLongDateString() + " | " +
                              "request_status => " + request.ReqStatus.ToString();
                requests_list_ui.Items.Add(element);
                i++;
            }
        }
        private void approve(object sender, RoutedEventArgs e)
        {
            var index = requests_list_ui.SelectedIndex;
            if (index != -1)
            {
             var requestId = _holidayDict[index].RequestId;
             _vm.RequestHandling(requestId, HolidayRequests.RequestStatus.Accepted);
             reload();
            }

        }

        private void disapprove(object sender, RoutedEventArgs e)
        {
            var index = requests_list_ui.SelectedIndex;
            if (index != -1)
            {
                var requestId = _holidayDict[index].RequestId;
                _vm.RequestHandling(requestId, HolidayRequests.RequestStatus.Rejected);
            }
            reload();
        }
    }
}
