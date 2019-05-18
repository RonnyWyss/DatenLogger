using System;
using Prism.Commands;
using Prism.Mvvm;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class DatenLoggerAddViewModel : BindableBase
    {
        private int _id;
        private int _serverity;
        private string _hostname;
        private string _location;
        private string _message;
        private string _pod;
        private DateTime _timestamp;


        public DatenLoggerAddViewModel()
        {
            CmdSave = new DelegateCommand(OnCmdSave);
            CmdCancel = new DelegateCommand(OnCmdCancel);
        }

        public DelegateCommand CmdSave { get; }

        public DelegateCommand CmdCancel { get; }

        private void OnCmdSave()
        {
        }

        private void OnCmdCancel()
        {
        }

        public string Hostname
        {
            get { return _hostname; }
            set { SetProperty(ref _hostname, value); }
        }
        public string Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }
        public string Pod
        {
            get { return _pod; }
            set { SetProperty(ref _pod, value); }
        }
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        public int Severity
        {
            get { return _serverity; }
            set { SetProperty(ref _serverity, value); }
        }

        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { SetProperty(ref _timestamp, value); }
        }
    }
}