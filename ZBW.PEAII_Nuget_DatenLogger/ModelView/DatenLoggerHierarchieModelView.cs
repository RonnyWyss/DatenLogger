using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace ZBW.PEAII_Nuget_DatenLogger.ModelView
{
    internal class DatenLoggerHierarchieModelView :BindableBase
    {
        public DatenLoggerHierarchieModelView()
        {
            CmdCancel = new DelegateCommand(OnCmdCancel);

        }


        public DelegateCommand CmdCancel { get; }

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
