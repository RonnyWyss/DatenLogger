using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using DuplicateCheckerLib;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Properties;
using IEntity = ZBW.PEAII_Nuget_DatenLogger.Model.IEntity;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class DatenLoggerViewModel : BindableBase
    {
        private UserControl _content;
        private string _servername = Settings.Default.default_servername;
        private string _database = Settings.Default.default_datenbasename;
        private string _username = Settings.Default.default_user;
        private List<IEntity> _logEntries;
        private string _passwort ;
        private IEntity _selectedEntity;
        private IEntity _selectedEntities;
        private int _selectedIndex;

        public DatenLoggerViewModel()
        {
            LogEntries = new List<IEntity>();
            CmdLoad = new DelegateCommand(OnCmdLoad);
            CmdConfirm = new DelegateCommand(OnCmdConfirm);
            CmdAddLog = new DelegateCommand(OnCmdAddLog);
            CmdDublicateCheck = new DelegateCommand(OnCmdDublicateCheck);
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
        public DelegateCommand CmdDublicateCheck { get; }
        private DatenLoggerRepository DatenLoggerRepository { get; set; }

        public List<IEntity> LogEntries
        {
            get => _logEntries;
            set => SetProperty(ref _logEntries, value);
        }

        public IEntity SelectedEntity
        {
     
            get => _selectedEntity;
            set => SetProperty(ref _selectedEntity, value);
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
                DatenLoggerRepository = new DatenLoggerRepository();
                LogEntries = DatenLoggerRepository.GetAllLogEntries();
                DatenLoggerAddViewModel.GetAddLogEntryViewModel.FillComboboxen();
                RefreshDatenLogEntries();
            }
        }

        private void OnCmdConfirm()
        {
            DatenLoggerRepository.ClearLogEntry(SelectedEntity);
            RefreshDatenLogEntries();
        }

        private void OnCmdAddLog()
        {
            NavigateToLogAddView();
        }

        public void NavigateToLogAddView()
        {
            var mainUserControlVM = MainUserControlViewModel.GetInstance();
            mainUserControlVM.DatenloggerAddVisibility = Visibility.Visible;
            mainUserControlVM.DatenloggerVisibility = Visibility.Collapsed;
 
        }

        private void OnCmdDublicateCheck()
        {
           var dupChecker = new DuplicateChecker();
            var dupList = dupChecker.FindDuplicates(LogEntries);
            List<IEntity> temp = new List<IEntity>();
          
            foreach (var entity in dupList)
            {
                temp.Add(entity as IEntity);
            }
            LogEntries.Clear();
            LogEntries = temp;
        }

        public void RefreshDatenLogEntries()
        {
            LogEntries = DatenLoggerRepository.GetAllLogEntries();
        }
    }
}