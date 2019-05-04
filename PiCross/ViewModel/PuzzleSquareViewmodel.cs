using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    class PuzzleSquareViewModel
    {
        private IPlayablePuzzleSquare playablePuzzleSquare;
        public PuzzleSquareViewModel(IPlayablePuzzleSquare square)
        {
            this.playablePuzzleSquare = square;
            Mark = new ClickCommand(this);
        }
        public ICommand Mark {get;}
        public Cell<Square> Contents
        {
            get
            {
                return this.playablePuzzleSquare.Contents;
            }
        }
        private class ClickCommand : ICommand
        {
            private PuzzleSquareViewModel ViewModel;

            public ClickCommand(PuzzleSquareViewModel vm)
            {
                this.ViewModel = vm;
            }
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if (ViewModel.Contents.Value == Square.UNKNOWN)
                {
                    ViewModel.Contents.Value = Square.FILLED;
                }
                else if (ViewModel.Contents.Value == Square.FILLED)
                {
                    ViewModel.Contents.Value = Square.EMPTY;
                }
                else if (ViewModel.Contents.Value == Square.EMPTY)
                {
                    ViewModel.Contents.Value = Square.UNKNOWN;
                }
            }
        }

    }
}
