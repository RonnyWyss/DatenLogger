using System;
using Prism.Commands;
using Prism.Mvvm;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class DatenLoggerAddViewModel : BindableBase
    {
        private string _hostname;
        private int _id;
        private string _location;
        private string _message;
        private string _pod;
        private int _serverity;
        private DateTime _timestamp;


        public DatenLoggerAddViewModel()
        {
            CmdSave = new DelegateCommand(OnCmdSave);
            CmdCancel = new DelegateCommand(OnCmdCancel);
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

        public int Severity
        {
            get => _serverity;
            set => SetProperty(ref _serverity, value);
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