using System.Windows.Controls;
using ZBW.PEAII_Nuget_DatenLogger.ViewModel;

namespace ZBW.PEAII_Nuget_DatenLogger.View
{
    /// <summary>
    ///     Interaction logic for MainUserCotrol.xaml
    /// </summary>
    public partial class MainUserControl : UserControl
    {
        private readonly UserControl datenloggerview = new DatenLoggerView();
        private readonly UserControl datenloggeraddview = new DatenLoggerAddView();

        public MainUserControl()
        {
            InitializeComponent();
            ContentMain.Content = datenloggerview;
            DataContext = new DatenLoggerViewModel();
        }
    }
}