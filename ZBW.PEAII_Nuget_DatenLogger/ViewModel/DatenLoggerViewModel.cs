using System.Windows;
using System.Windows.Controls;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Properties;
using ZBW.PEAII_Nuget_DatenLogger.View;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class DatenLoggerViewModel : BindableBase
    {
        private UserControl _content;
        private string _database;
        private string _passwort;
        private string _servername;
        private string _username;
        private readonly DatenLoggerControl DLC = new DatenLoggerControl();

        public DatenLoggerViewModel()
        {
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


        public DelegateCommand CmdLoad { get; }
        public DelegateCommand CmdConfirm { get; }
        public DelegateCommand CmdAddLog { get; }

        public UserControl ContentMain
        {
            get => _content;
            set => SetProperty(ref _content, value);
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
                DLC.ConnectionState();
            }
        }

        private void OnCmdConfirm()
        {
        }

        private void OnCmdAddLog()
        {
            NavigateToLogAddView();
        }

        public void NavigateToLogAddView()
        {
            ContentMain = new DatenLoggerAddView();
        }
    }
}