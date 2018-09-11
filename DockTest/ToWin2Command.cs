using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTest.Base;

namespace DockTest
{
    public class ToWin2Command:ParameterlessCommandBase
    {
        private readonly MainWindowViewModel mainWindowViewModel;
        public ToWin2Command(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute()
        {
            mainWindowViewModel.CurrentViewModel = mainWindowViewModel.Win2ViewModel;
            
        }
    }
}
