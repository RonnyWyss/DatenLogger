using System.Windows;
using Prism.Mvvm;

namespace ZBW.PEAII_Nuget_DatenLogger.ViewModel
{
    internal class MainUserControlViewModel : BindableBase
    {
        private Visibility _datenloggerView = Visibility.Visible;
        private Visibility _datenloggeraddView = Visibility.Collapsed;

        public MainUserControlViewModel()
        {
           
        }

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

    //Singleton
        private static MainUserControlViewModel instance;
        public static MainUserControlViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainUserControlViewModel();
            }

            return instance;
        }
    }
}