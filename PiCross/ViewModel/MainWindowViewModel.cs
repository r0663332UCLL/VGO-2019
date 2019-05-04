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
            this.Grid = DemoPlayablePluzzle.Grid.Map(square => new PuzzleSquareViewModel(square)).Copy();
            this.ColumnConstraints = DemoPlayablePluzzle.ColumnConstraints.Map(constraint => new PuzzleConstraintsViewModel(constraint)).Copy();
            this.RowConstraints = DemoPlayablePluzzle.RowConstraints.Map(constraint => new PuzzleConstraintsViewModel(constraint)).Copy();
        }

        public IGrid<object> Grid{ get; }
        public ISequence<object> ColumnConstraints { get; }
        public ISequence<object> RowConstraints { get; }
    }
}
