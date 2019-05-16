using System;
using System.Windows;
using Google.Protobuf;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class DatenLoggerViewModel : BindableBase
    {
        private string _servername;
        private string _database;
        private string _username;
        private string _passwort;
        private DatenLoggerControl DLC = new DatenLoggerControl();

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
                DLC.ConnectionState(_servername,_database,_username,_passwort);
            }

        }

        private void OnCmdConfirm()
        {

        }

        private void OnCmdAddLog()
        {

        }
    }
}