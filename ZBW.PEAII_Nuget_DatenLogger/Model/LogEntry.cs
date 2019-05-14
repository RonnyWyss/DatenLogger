using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ZBW.PEAII_Nuget_DatenLogger.Model
{
    class LogEntry :BindableBase
    {
        private int _id;
        private string _pod;
        private string _location;
        private string _hostname;
        private int _serverity;
        private DateTime _timestamp;
        private string _message;

        public int Id
        {
            get => _id;

            set => SetProperty(ref _id, value);
        }
        public string Pod
        {
            get => _pod;

            set => SetProperty(ref _pod, value);
        }
        public string Location
        {
            get => _location;

            set => SetProperty(ref _location, value);
        }
        public string Hostname
        {
            get => _hostname;

            set => SetProperty(ref _hostname, value);
        }
        public int Serverity
        {
            get => _serverity;

            set => SetProperty(ref _serverity, value);
        }
        public DateTime Timestamp
        {
            get => _timestamp;

            set => SetProperty(ref _timestamp, value);
        }
        public string Message
        {
            get => _message;

            set => SetProperty(ref _message, value);
        }
    }
}
