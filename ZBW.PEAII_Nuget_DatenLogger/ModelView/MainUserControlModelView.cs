using System.Windows;
using Prism.Mvvm;

namespace ZBW.PEAII_Nuget_DatenLogger.ModelView
{
    internal class MainUserControlModelView : BindableBase
    {
        //Singleton
        private static MainUserControlModelView instance;
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

        public static MainUserControlModelView GetInstance()
        {
            if (instance == null) instance = new MainUserControlModelView();

            return instance;
        }
    }
}