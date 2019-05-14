using System;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Model;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class DatenLoggerViewModel : BindableBase
    {
        private string _Servername;
        private string _Database;
        private string _Username;
        private string _Passwort;
        private DatenLoggerControl DLC = new DatenLoggerControl();

        public DatenLoggerViewModel()
        {
            CmdLoad = new DelegateCommand(OnCmdLoad);
            CmdConfirm = new DelegateCommand(OnCmdConfirm);
            CmdAddLog = new DelegateCommand(OnCmdAddLog);
        }

        public string Servername
        {
            get => _Servername;

            set => SetProperty(ref _Servername, value);
        }
        public string Database
        {
            get => _Database;

            set => SetProperty(ref _Database, value);
        }
        public string Username
        {
            get => _Username;

            set => SetProperty(ref _Username, value);
        }
        public string Passwort
        {
            get => _Passwort;

            set => SetProperty(ref _Passwort, value);
        }


        public DelegateCommand CmdLoad { get; }
        public DelegateCommand CmdConfirm { get; }
        public DelegateCommand CmdAddLog { get; }

        private void OnCmdLoad()
        {
            if (_Servername == null)
            {
                MessageBox.Show("Geben Sie den Servername ein (Default: 'localhost')");
            }
            else if (_Database == null)
            {
                MessageBox.Show("Geben Sie den Datenbankname ein (Default: 'sqltechdb')");
            }
            else if (_Username == null)
            {
                MessageBox.Show("Geben Sie einen Benutzername ein (Default: 'root')");
            }
            else
            {
               DLC.ConnectionState(_Servername,_Database,_Username,_Passwort);
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