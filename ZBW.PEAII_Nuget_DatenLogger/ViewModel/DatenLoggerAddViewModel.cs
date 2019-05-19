using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class DatenLoggerAddViewModel : BindableBase
    {
        private string _deviceId;
        private ObservableCollection<int> _deviceIdItems;
        private string _hostname;
        private ObservableCollection<string> _hostnameItems;
        private int _id;
        private string _location;
        private ObservableCollection<string> _locationItems;
        private string _message;
        private string _pod;
        private string _selectedDeviceIdItem;
        private string _selectedHostnameItem;
        private string _selectedLocationItem;
        private int _selectedServerityItem;

        private ObservableCollection<string> _severityItems;

        // private List<string> _serverityItems;
        private DateTime _timestamp;


        public DatenLoggerAddViewModel()
        {
            GetAddLogEntryViewModel = this;
            CmdSave = new DelegateCommand(OnCmdSave);
            CmdCancel = new DelegateCommand(OnCmdCancel);
            // SeverityItems = SeverityLevelComboBoxItems.SeverityLevel;
        }

        public DelegateCommand CmdSave { get; }

        public DelegateCommand CmdCancel { get; }

        public DatenLoggerRepository DatenLoggerRepository { get; set; }


        public static DatenLoggerAddViewModel GetAddLogEntryViewModel { get; private set; }

        public ObservableCollection<int> DeviceIdItems
        {
            get => _deviceIdItems;
            set => SetProperty(ref _deviceIdItems, value);
        }

        public ObservableCollection<string> HostnameItems
        {
            get => _hostnameItems;
            set => SetProperty(ref _hostnameItems, value);
        }

        public ObservableCollection<string> LocationItems
        {
            get => _locationItems;
            set => SetProperty(ref _locationItems, value);
        }

        public ObservableCollection<string> SeverityItems
        {
            get => _severityItems;
            set => SetProperty(ref _severityItems, value);
        }

        public string Hostname
        {
            get => _hostname;
            set => SetProperty(ref _hostname, value);
        }

        public string DeviceId
        {
            get => _deviceId;
            set => SetProperty(ref _deviceId, value);
        }

        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        public string Pod
        {
            get => _pod;
            set => SetProperty(ref _pod, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string SelectedDeviceIdItem
        {
            get => _selectedDeviceIdItem;
            set => SetProperty(ref _selectedDeviceIdItem, value);
        }

        public string SelectedHostnameItem
        {
            get => _selectedHostnameItem;
            set => SetProperty(ref _selectedHostnameItem, value);
        }

        public string SelectedLocationItem
        {
            get => _selectedLocationItem;
            set => SetProperty(ref _selectedLocationItem, value);
        }

        /*  public List<string> ServerityItems
        {
            get => _serverityItems;
            set => SetProperty(ref _serverityItems, value);
        }*/

        public int SelectedSeverityItem
        {
            get => _selectedServerityItem;
            set => SetProperty(ref _selectedServerityItem, value);
        }

        public DateTime Timestamp
        {
            get => _timestamp;
            set => SetProperty(ref _timestamp, value);
        }

        private void SetDatenLoggerRepository()
        {
            var datenloggerRepositoring = new DatenLoggerRepository(Settings.Default.Connectionstring);
            DatenLoggerRepository = datenloggerRepositoring;
        }

        public void FillComboboxen()
        {
            // MainUserControlViewModel = MainUserControlViewModel.GetMainUserControlViewModel;
            SetDatenLoggerRepository();
            DeviceIdItems = DatenLoggerRepository.GetAllDeviceIds();
            HostnameItems = DatenLoggerRepository.GetAllHostname();
            LocationItems = DatenLoggerRepository.GetAllLocation();
            SeverityItems = DatenLoggerRepository.GetAllSeverity();
        }

        private void OnCmdSave()
        {
            ILogEntry logEntry = new LogEntry(SelectedHostnameItem, Message, SelectedSeverityItem, SelectedLocationItem);
            logEntry.DeviceId = SelectedDeviceIdItem;
            DatenLoggerRepository.AddLogEntry(logEntry);
        }

        private void OnCmdCancel()
        {
        }
    }
}