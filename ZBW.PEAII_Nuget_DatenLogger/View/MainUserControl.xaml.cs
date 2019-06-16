using System.Windows.Controls;
using ZBW.PEAII_Nuget_DatenLogger.ModelView;

namespace ZBW.PEAII_Nuget_DatenLogger.View
{
    /// <summary>
    ///     Interaction logic for MainUserCotrol.xaml
    /// </summary>
    public partial class MainUserControl : UserControl
    {
        public MainUserControl()
        {
            InitializeComponent();
            DataContext = MainUserControlModelView.GetInstance();
        }
    }
}