using System.Windows.Controls;
using ZBW.PEAII_Nuget_DatenLogger.ModelView;

namespace ZBW.PEAII_Nuget_DatenLogger.View
{
    /// <summary>
    ///     Interaction logic for DatenLoggerAdd.xaml
    /// </summary>
    public partial class DatenLoggerAddView : UserControl
    {
        public DatenLoggerAddView()
        {
            InitializeComponent();
            DataContext = new DatenLoggerAddModelView();
        }
    }
}