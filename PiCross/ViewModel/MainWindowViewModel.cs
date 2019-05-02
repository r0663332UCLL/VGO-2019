using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class MainWindowViewModel
    {
        private IPlayablePuzzle DemoPlayablePluzzle;

        public MainWindowViewModel()
        {
           var DemoPuzzle = Puzzle.FromRowStrings(
                            "x.xxx",
                            "x.x..",
                            "xxxxx",
                            "..x.x",
                            "xxx.x"
           );
            var Facade = new PiCrossFacade();
            this.DemoPlayablePluzzle = Facade.CreatePlayablePuzzle(DemoPuzzle);
            this.MarkCommand = new Mark();
        }

        public ICommand MarkCommand { get; }
        public IGrid<object> Grid
        {
            get
            {
                return DemoPlayablePluzzle.Grid;
            }
        }
    }
    public class Mark : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var rectangle = parameter as IPlayablePuzzleSquare;

            if (rectangle.Contents.Value == Square.UNKNOWN)
            {
                rectangle.Contents.Value = Square.FILLED;
            }
            else if (rectangle.Contents.Value == Square.FILLED)
            {
                rectangle.Contents.Value = Square.EMPTY;
            }
            else if (rectangle.Contents.Value == Square.EMPTY)
            {
                rectangle.Contents.Value = Square.UNKNOWN;
            }
        }
    }
}
