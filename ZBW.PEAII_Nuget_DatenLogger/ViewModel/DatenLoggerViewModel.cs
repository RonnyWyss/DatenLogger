using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class DatenLoggerViewModel : BindableBase
    {
        private readonly DatenLoggerControl DLC = new DatenLoggerControl();
        private UserControl _content;
        private string _database;
        private ObservableCollection<ILogEntry> _logEntries;
        private string _passwort;
        private ILogEntry _selectedLogEntry;
        private string _servername;
        private string _username;

        public DatenLoggerViewModel()
        {
            LogEntries = new ObservableCollection<ILogEntry>();
            CmdLoad = new DelegateCommand(OnCmdLoad);
            CmdConfirm = new DelegateCommand(OnCmdConfirm);
            CmdAddLog = new DelegateCommand(OnCmdAddLog);
        }

        public string Servername
        {
            get => _servername;

            set => SetProperty(ref _servername, value);
        }

        public string Database
        {
            get => _database;

            set => SetProperty(ref _database, value);
        }

        public string Username
        {
            get => _username;

            set => SetProperty(ref _username, value);
        }

        public string Passwort
        {
            get => _passwort;

            set => SetProperty(ref _passwort, value);
        }


        //__________________________________________
        public DelegateCommand CmdLoad { get; }
        public DelegateCommand CmdConfirm { get; }
        public DelegateCommand CmdAddLog { get; }
        private DatenLoggerRepository DatenLoggerRepository { get; set; }

        public ObservableCollection<ILogEntry> LogEntries
        {
            get => _logEntries;
            set => SetProperty(ref _logEntries, value);
        }

        public UserControl ContentMain
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public ILogEntry SelectedLogEntry
        {
            get => _selectedLogEntry;
            set => SetProperty(ref _selectedLogEntry, value);
        }

        private void OnCmdLoad()
        {
            if (_servername == null)
            {
                MessageBox.Show("Geben Sie den Servername ein (Default: 'localhost')");
            }
            else if (_database == null)
            {
                MessageBox.Show("Geben Sie den Datenbankname ein (Default: 'sqltechdb')");
            }
            else if (_username == null)
            {
                MessageBox.Show("Geben Sie einen Benutzername ein (Default: 'root')");
            }
            else
            {
                Settings.Default.Connectionstring = "Server=" + _servername + ";Database=" + _database + ";Uid=" + _username + ";Pwd=" + _passwort;
                //  DLC.ConnectionState();
                DatenLoggerRepository = new DatenLoggerRepository();
                LogEntries = DatenLoggerRepository.GetAllLogEntries();
            }
        }

        private void OnCmdConfirm()
        {
            DatenLoggerRepository.ClearLogEntry(SelectedLogEntry);
            RefreshDatenLogEntries();
        }

        private void OnCmdAddLog()
        {
            NavigateToLogAddView();
        }

        public void NavigateToLogAddView()
        {
            DatenLoggerAddViewModel.GetAddLogEntryViewModel.FillComboboxen();
            RefreshDatenLogEntries();
        }

        private void RefreshDatenLogEntries()
        {
            LogEntries = DatenLoggerRepository.GetAllLogEntries();
        }
    }
}