using System.Windows.Input;
using DockTest.Base;

namespace DockTest
{
    public class MainWindowViewModel : ViewModelBase
    {
        public Win1ViewModel Win1ViewModel { get; set; }
        public Win2ViewModel Win2ViewModel { get; set; }

        public ICommand ToWin1 { get; set; }
        public ICommand ToWin2 { get; set; }

        public MainWindowViewModel()
        {
            //viewModel
            Win1ViewModel = new Win1ViewModel();
            Win2ViewModel = new Win2ViewModel();

            //btns
            ToWin1 = new ToWin1Command(this);
            ToWin2 = new ToWin2Command(this);

            //set mainWindow
            CurrentViewModel = Win1ViewModel;

        }

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}
