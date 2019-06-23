using System.Collections.Generic;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.Table;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.ModelView
{
    public class DatenLoggerHierarchieModelView : BindableBase
    {
        private List<ILocation> _locationlist;

        public DatenLoggerHierarchieModelView()
        {
            _locationlist = new List<ILocation>();
            CmdCancel = new DelegateCommand(OnCmdCancel);
            CmdLocation = new DelegateCommand(OnCmdLocation);
            LocationRepository = new LocationRepository();
        }


        public DelegateCommand CmdCancel { get; }
        public DelegateCommand CmdLocation { get; }

        public ILocationRepository LocationRepository { get; }

        public List<ILocation> Locations
        {
            get => _locationlist;
            set => SetProperty(ref _locationlist, value);
        }

        private static DatenLoggerHierarchieModelView Instance { get; set; }

        public static DatenLoggerHierarchieModelView GetInstance()
        {
            if (Instance == null) Instance = new DatenLoggerHierarchieModelView();

            return Instance;
        }

        public void LoadLocationTree()
        {
            Locations = LocationRepository.GetLocationsHierarchie();
        }

        private void OnCmdLocation()
        {
            LoadLocationTree();
        }

        private void OnCmdCancel()
        {
            NavigateToDatenLoggerView();
        }

        public void NavigateToDatenLoggerView()
        {
            var mainUserControlVM = MainUserControlModelView.GetInstance();
            mainUserControlVM.DatenloggerAddVisibility = Visibility.Collapsed;
            mainUserControlVM.DatenloggerVisibility = Visibility.Visible;
            mainUserControlVM.DatenloggerHierarchieVisibility = Visibility.Collapsed;
        }
    }
}