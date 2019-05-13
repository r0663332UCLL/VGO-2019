using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class LevelSelectorWindowViewModel
    {
        private MainWindowViewModel VM;
        public LevelSelectorWindowViewModel(MainWindowViewModel Mainvm)
        {
            this.VM = Mainvm;
            var Facade = new PiCrossFacade();

            var Puzzle1 = Puzzle.FromRowStrings(
                             ".xxx.",
                             "x.x.x",
                             "xxxxx",
                             "x.x.x",
                             ".xxx."
            );

            var Puzzle2 = Puzzle.FromRowStrings(
                             "x...x",
                             ".x.x.",
                             "..x..",
                             ".x.x.",
                             "x...x"
            );

            this.Puzzles = new PlayablePuzzleViewModel[2];
            this.Puzzles[0] = new PlayablePuzzleViewModel(VM, Facade.CreatePlayablePuzzle(Puzzle1), "Puzzel 1");
            this.Puzzles[1] = new PlayablePuzzleViewModel(VM, Facade.CreatePlayablePuzzle(Puzzle2), "Puzzel 2");
        }
        public PlayablePuzzleViewModel[] Puzzles { get; }
    }
}
