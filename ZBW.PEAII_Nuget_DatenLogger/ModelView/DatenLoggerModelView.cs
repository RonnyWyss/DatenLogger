using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DuplicateCheckerLib;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Properties;
using ZBW.PEAII_Nuget_DatenLogger.Repositories;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.Table;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.View;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.View.Impl;
using IEntity = ZBW.PEAII_Nuget_DatenLogger.Model.IEntity;

namespace ZBW.PEAII_Nuget_DatenLogger.ModelView
{
    internal class DatenLoggerModelView : BindableBase
    {
        private UserControl _content;
        private string _database = Settings.Default.default_datenbasename;
        private List<IEntity> _logEntries;
        private string _passwort;
        private IEntity _selectedEntities;
        private IEntity _selectedEntity;
        private int _selectedIndex;
        private string _servername = Settings.Default.default_servername;
        private string _username = Settings.Default.default_user;
        private string _connString;

        public DatenLoggerModelView()
        {
            LogEntries = new List<IEntity>();
            CmdLoad = new DelegateCommand(OnCmdLoad);
            CmdConfirm = new DelegateCommand(OnCmdConfirm);
            CmdAddLog = new DelegateCommand(OnCmdAddLog);
            CmdDublicateCheck = new DelegateCommand(OnCmdDublicateCheck);
            CmdHierarchie = new DelegateCommand(OnCmdHierarchie);
            LogEntryView = new LogEntryView();
            LoggingRepository = new LoggingRepository();

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
        public DelegateCommand CmdHierarchie { get; }
        private DatenLoggerRepository DatenLoggerRepository { get; set; }
        private ILogEntryView LogEntryView { get; }
        private ILoggingRepository LoggingRepository { get; }
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
               // DatenLoggerRepository = new DatenLoggerRepository();
            //    LogEntries = DatenLoggerRepository.GetAllLogEntries();
            //    DatenLoggerAddModelView.GetAddLogEntryModelView.FillComboboxen();
              //  RefreshDatenLogEntries();

              LogEntries = LogEntryView.GetAllLogEntries();

            }
        }

        private void OnCmdConfirm()
        {
            //    DatenLoggerRepository.ClearLogEntry(SelectedEntity);
            LoggingRepository.ClearLogEntry(SelectedEntity);
            RefreshDatenLogEntries();
        }

        private void OnCmdAddLog()
        {
            NavigateToLogAddView();
        }

        private void OnCmdHierarchie()
        {
            NavigateToHierarchieView();
        }

        public void NavigateToLogAddView()
        {
            var mainUserControlVM = MainUserControlModelView.GetInstance();
            mainUserControlVM.DatenloggerAddVisibility = Visibility.Visible;
            mainUserControlVM.DatenloggerVisibility = Visibility.Collapsed;
            mainUserControlVM.DatenloggerHierarchieVisibility = Visibility.Collapsed;
        }

        public void NavigateToHierarchieView()
        {
            var mainUserControlVM = MainUserControlModelView.GetInstance();
            mainUserControlVM.DatenloggerAddVisibility = Visibility.Collapsed;
            mainUserControlVM.DatenloggerVisibility = Visibility.Collapsed;
            mainUserControlVM.DatenloggerHierarchieVisibility = Visibility.Visible;
        }

        private void OnCmdDublicateCheck()
        {
            var dupChecker = new DuplicateChecker();
            var dupList = dupChecker.FindDuplicates(LogEntries);
            var temp = new List<IEntity>();

            foreach (var entity in dupList) temp.Add(entity as IEntity);
            LogEntries = temp;
        }


        public void RefreshDatenLogEntries()
        {
         //   LogEntries = DatenLoggerRepository.GetAllLogEntries();
        }
    }
}