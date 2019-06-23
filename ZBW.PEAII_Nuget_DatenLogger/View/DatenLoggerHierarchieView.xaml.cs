using System.Windows.Controls;
using ZBW.PEAII_Nuget_DatenLogger.ModelView;

namespace ZBW.PEAII_Nuget_DatenLogger.View
{
    /// <summary>
    ///     Interaction logic for DatenLoggerHierarchieView.xaml
    /// </summary>
    public partial class DatenLoggerHierarchieView : UserControl
    {
        public DatenLoggerHierarchieView()
        {
            InitializeComponent();
            DataContext = new DatenLoggerHierarchieModelView();
        }
    }
}