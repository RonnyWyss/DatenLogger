using System.Windows.Controls;
using ZBW.PEAII_Nuget_DatenLogger.ViewModel;

namespace ZBW.PEAII_Nuget_DatenLogger.View
{
    /// <summary>
    ///     Interaction logic for DatenLoggerView.xaml
    /// </summary>
    public partial class DatenLoggerView : UserControl
    {
        public DatenLoggerView()
        {
            InitializeComponent();
            DataContext = new DatenLoggerViewModel();
        }
    }
}