using System;
using System.Collections.Generic;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.Table;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.View;

namespace ZBW.PEAII_Nuget_DatenLogger.ModelView
{
    internal class DatenLoggerAddModelView : BindableBase
    {
        private string _deviceId;
        private List<int> _deviceIdItems;
        private List<int> _deviceIds;
        private string _hostname;
        private List<string> _hostnameItems;
        private int _id;
        private string _location;
        private List<ILocation> _locationItems;
        private string _message;
        private string _pod;
        private string _selectedDeviceIdItem;
        private string _selectedHostnameItem;
        private string _selectedLocationItem;
        private int _selectedServerityItem;
        private List<int> _severityItems;
        private DateTime _timestamp;


        public DatenLoggerAddModelView()
        {
            GetAddLogEntryModelView = this;
            CmdSave = new DelegateCommand(OnCmdSave);
            CmdCancel = new DelegateCommand(OnCmdCancel);
            //LogEntryView = new LogEntryView();
            DeviceRepository = new DeviceRepository();
            LoggingRepository = new LoggingRepository();
            LocationRepository = new LocationRepository();
            Entity = new LogEntry();
        }

        public DelegateCommand CmdSave { get; }

        public DelegateCommand CmdCancel { get; }


        private IDeviceRepository DeviceRepository { get; }
        private ILocationRepository LocationRepository { get; }
        private ILogEntryView LogEntryView { get; }
        private IEntity Entity { get; }
        private ILoggingRepository LoggingRepository { get; }
        public static DatenLoggerAddModelView GetAddLogEntryModelView { get; private set; }

        public List<int> DeviceIdItems
        {
            get => _deviceIdItems;
            set => SetProperty(ref _deviceIdItems, value);
        }

        public List<string> HostnameItems
        {
            get => _hostnameItems;
            set => SetProperty(ref _hostnameItems, value);
        }

        public List<ILocation> LocationItems
        {
            get => _locationItems;
            set => SetProperty(ref _locationItems, value);
        }

        public List<int> SeverityItems
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

        public List<int> DeviceIds
        {
            get
            {
                _deviceIds?.Sort();

                return _deviceIds;
            }
            set => SetProperty(ref _deviceIds, value);
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
            //  var datenloggerRepositoring = new DatenLoggerRepository(Settings.Default.Connectionstring);
            //   DatenLoggerRepository = datenloggerRepositoring;
        }

        public void FillComboboxen()
        {
            SetDatenLoggerRepository();
            //DeviceIdItems = DatenLoggerRepository.GetAllDeviceIds();
            //HostnameItems = DatenLoggerRepository.GetAllHostname();
            //LocationItems = DatenLoggerRepository.GetAllLocation();
            //SeverityItems = DatenLoggerRepository.GetAllSeverity();
            DeviceIdItems = DeviceRepository.GetDeviceIds();
            HostnameItems = DeviceRepository.GetDeviceHostname();
            LocationItems = LocationRepository.GetAllLocation();
        }

        private void OnCmdSave()
        {
            if (SelectedHostnameItem == null)
            {
                MessageBox.Show("Wählen Sie einen Hostnamen");
            }
            else if (Message == null)
            {
                MessageBox.Show("Schreiben Sie eine Nachricht");
            }
            //else if (SelectedSeverityItem == 0)
            //{
            //    MessageBox.Show("Wählen Sie eine Dringlichkeitsstufe");
            //}
            else if (SelectedLocationItem == null)
            {
                MessageBox.Show("Wählen Sie den Ort aus");
            }
            else if (SelectedDeviceIdItem == null)
            {
                MessageBox.Show("Wählen Sie eine PoD");
            }
            else
            {
                IEntity entity = new LogEntry(SelectedHostnameItem, Message, SelectedSeverityItem);
                entity.DeviceId = SelectedDeviceIdItem;
                LoggingRepository.AddLogEntry(entity);
                NavigateToDatenloggerView();
            }
        }

        private void OnCmdCancel()
        {
            NavigateToDatenloggerView();
        }

        public void NavigateToDatenloggerView()
        {
            var mainUserControlVM = MainUserControlModelView.GetInstance();
            mainUserControlVM.DatenloggerAddVisibility = Visibility.Collapsed;
            mainUserControlVM.DatenloggerVisibility = Visibility.Visible;
            mainUserControlVM.DatenloggerHierarchieVisibility = Visibility.Collapsed;
        }
    }
}