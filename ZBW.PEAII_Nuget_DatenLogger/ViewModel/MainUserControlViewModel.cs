using System.Windows;
using Prism.Mvvm;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class MainUserControlViewModel : BindableBase
    {
        //Singleton
        private static MainUserControlViewModel instance;
        private Visibility _datenloggeraddView = Visibility.Collapsed;
        private Visibility _datenloggerView = Visibility.Visible;

        public Visibility DatenloggerAddVisibility
        {
            get => _datenloggeraddView;
            set => SetProperty(ref _datenloggeraddView, value);
        }

        public Visibility DatenloggerVisibility
        {
            get => _datenloggerView;
            set => SetProperty(ref _datenloggerView, value);
        }

        public static MainUserControlViewModel GetInstance()
        {
            if (instance == null) instance = new MainUserControlViewModel();

            return instance;
        }
    }
}