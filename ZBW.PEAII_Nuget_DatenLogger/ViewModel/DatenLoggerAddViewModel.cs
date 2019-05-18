using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class DatenLoggerAddViewModel : BindableBase
    {
        private string _hostname;
        private int _id;
        private string _location;
        private string _message;
        private string _pod;
        private string _selectedHostnameItem;
        private string _selectedLocationItem;
        private string _selectedDeviceIdItem;
        private int _selectedServerityItem;
        private List<string> _serverityItems;
        private DateTime _timestamp;



        public DatenLoggerAddViewModel()
        {
            CmdSave = new DelegateCommand(OnCmdSave);
            CmdCancel = new DelegateCommand(OnCmdCancel);
            SeverityItems = SeverityLevelComboBoxItems.SeverityLevel;
        }

        public DelegateCommand CmdSave { get; }

        public DelegateCommand CmdCancel { get; }

        public string Hostname
        {
            get => _hostname;
            set => SetProperty(ref _hostname, value);
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

        public List<string> SeverityItems
        {
            get => _serverityItems;
            set => SetProperty(ref _serverityItems, value);
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

        private void OnCmdSave()
        {
        
        }

        private void OnCmdCancel()
        {
        }
    }
}