using PiCross;
using System.ComponentModel;

namespace ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object activeWindow;
        public MainWindowViewModel()
        {
            this.ActiveWindow = new StartWindowViewModel(this);
        }

        public object ActiveWindow
        {
            get
            {
                return activeWindow;
            }
            set
            {
                this.activeWindow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveWindow)));
            }
        }

        public void startGame()
        {
            this.ActiveWindow = new PlayWindowViewModel(this);
        }

        public void levelSelector()
        {
            this.ActiveWindow = new LevelSelectorWindowViewModel(this);
        }

        public void startGame(IPlayablePuzzle puzzle)
        {
            this.ActiveWindow = new PlayWindowViewModel(puzzle);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}