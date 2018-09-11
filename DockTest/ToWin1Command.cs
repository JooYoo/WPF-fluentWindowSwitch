using System;
using DockTest.Base;

namespace DockTest
{
    public class ToWin1Command:ParameterlessCommandBase
    {
        private readonly MainWindowViewModel mainWindowViewModel;
        public ToWin1Command(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }


        public override void Execute()
        {
            mainWindowViewModel.CurrentViewModel = mainWindowViewModel.Win1ViewModel;
        }
    }
}
