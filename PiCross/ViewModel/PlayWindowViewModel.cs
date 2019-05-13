using Cells;
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
    public class PlayWindowViewModel
    {
        private IPlayablePuzzle DemoPlayablePluzzle;
        private MainWindowViewModel VM;
        public PlayWindowViewModel(MainWindowViewModel Mainvm)
        {
            this.VM = Mainvm;
            var DemoPuzzle = Puzzle.FromRowStrings(
                             ".xxx.",
                             "x.x.x",
                             "xxxxx",
                             "x.x.x",
                             ".xxx."
            );
            var Facade = new PiCrossFacade();
            this.DemoPlayablePluzzle = Facade.CreatePlayablePuzzle(DemoPuzzle);
            this.Grid = DemoPlayablePluzzle.Grid.Map(square => new PuzzleSquareViewModel(square)).Copy();
            this.ColumnConstraints = DemoPlayablePluzzle.ColumnConstraints.Map(constraint => new PuzzleConstraintsViewModel(constraint)).Copy();
            this.RowConstraints = DemoPlayablePluzzle.RowConstraints.Map(constraint => new PuzzleConstraintsViewModel(constraint)).Copy();
            this.Retry = new RetryCommand(this.VM);
            this.Exit = new ExitCommand(this.VM);
        }

        public PlayWindowViewModel(IPlayablePuzzle puzzle)
        {
            this.DemoPlayablePluzzle = puzzle;
            this.Grid = DemoPlayablePluzzle.Grid.Map(square => new PuzzleSquareViewModel(square)).Copy();
            this.ColumnConstraints = DemoPlayablePluzzle.ColumnConstraints.Map(constraint => new PuzzleConstraintsViewModel(constraint)).Copy();
            this.RowConstraints = DemoPlayablePluzzle.RowConstraints.Map(constraint => new PuzzleConstraintsViewModel(constraint)).Copy();
            this.Retry = new RetryCommand(this.VM);
            this.Exit = new ExitCommand(this.VM);
        }

        public IGrid<object> Grid { get; }
        public ISequence<object> ColumnConstraints { get; }
        public ISequence<object> RowConstraints { get; }
        public ICommand Retry { get; }
        public ICommand Exit { get; }
        public Cell<bool> IsSolved
        {
            get
            {
                return DemoPlayablePluzzle.IsSolved;
            }
        }

        private class RetryCommand : ICommand
        {
            private MainWindowViewModel VM;
            public RetryCommand(MainWindowViewModel Mainvm)
            {
                this.VM = Mainvm;
            }
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                this.VM.Retry();
            }
        }

        public class ExitCommand : ICommand
        {
            private MainWindowViewModel VM;
            public ExitCommand(MainWindowViewModel Mainvm)
            {
                this.VM = Mainvm;
            }
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                this.VM.Exit();
            }
        }
    }
}
