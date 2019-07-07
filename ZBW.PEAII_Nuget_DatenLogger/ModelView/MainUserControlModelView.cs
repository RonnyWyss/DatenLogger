using System.Windows;
using Prism.Mvvm;

namespace ZBW.PEAII_Nuget_DatenLogger.ModelView
{
    internal class MainUserControlModelView : BindableBase
    {
        private Visibility _datenloggeraddView = Visibility.Collapsed;
        private Visibility _datenloggerhierarchieView = Visibility.Collapsed;

        private Visibility _datenloggerView = Visibility.Visible;

        //Singleton
        private static MainUserControlModelView Instance { get; set; }

        public Visibility DatenloggerAddVisibility
        {
            get => _datenloggeraddView;
            set => SetProperty(ref _datenloggeraddView, value);
        }

        public Visibility DatenloggerHierarchieVisibility
        {
            get => _datenloggerhierarchieView;
            set => SetProperty(ref _datenloggerhierarchieView, value);
        }

        public Visibility DatenloggerVisibility
        {
            get => _datenloggerView;
            set => SetProperty(ref _datenloggerView, value);
        }

        public static MainUserControlModelView GetInstance()
        {
            if (Instance == null) Instance = new MainUserControlModelView();

            return Instance;
        }
    }
}