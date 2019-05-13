using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class PlayablePuzzleViewModel
    {
        private IPlayablePuzzle puzzle;
        private MainWindowViewModel VM;
        
        public PlayablePuzzleViewModel(MainWindowViewModel Mainvm, IPlayablePuzzle puzzle, String title)
        {
            this.VM = Mainvm;
            this.puzzle = puzzle;
            this.Title = title;
            this.SelectPuzzle = new Select(this.VM, this.puzzle);
        }
        public String Title { get; }
        public ICommand SelectPuzzle { get;  }

        private class Select : ICommand
        {
            private MainWindowViewModel VM;
            private IPlayablePuzzle puzzle;
            public Select(MainWindowViewModel Mainvm, IPlayablePuzzle puzzle)
            {
                this.VM = Mainvm;
                this.puzzle = puzzle;
            }
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                this.VM.startGame(puzzle);
            }
        }
    }
}
