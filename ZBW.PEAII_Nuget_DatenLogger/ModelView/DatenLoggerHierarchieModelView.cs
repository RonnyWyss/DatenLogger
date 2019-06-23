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
        // ILocationRepository locationRepository
        public DatenLoggerHierarchieModelView()
        {
            _locationlist = new List<ILocation>();
            CmdCancel = new DelegateCommand(OnCmdCancel);
           // LocationRepository = locationRepository;
        }


        public DelegateCommand CmdCancel { get; }

        public ILocationRepository LocationRepository { get; }

        public List<ILocation> Locations
        {
            get => _locationlist;
            set => SetProperty(ref _locationlist, value);
        }

        private static DatenLoggerHierarchieModelView Instance { get; set; }

        public static DatenLoggerHierarchieModelView GetInstance()
        {
            if (Instance == null)
            {
                ILocationRepository locationRepository = new LocationRepository();
                //Instance = new DatenLoggerHierarchieModelView(locationRepository);
            }

            return Instance;
        }

        public void LoadLocationTree()
        {
            // Locations = LocationRepository.GetLocationsHierarchie();
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