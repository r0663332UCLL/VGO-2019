using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;
using DataStructures;
using PiCross;

namespace ViewModel
{
    class PuzzleConstraintsViewModel
    {
        private IPlayablePuzzleConstraints playablePuzzleConstraints;
        public PuzzleConstraintsViewModel(IPlayablePuzzleConstraints constraints)
        {
            this.playablePuzzleConstraints = constraints;
            this.Values = this.playablePuzzleConstraints.Values.Map(value => new PuzzleConstraintsValueViewModel(value)).Copy();
        }
        public ISequence<PuzzleConstraintsValueViewModel> Values { get; }

        public Cell<bool> IsSatisfied {
            get
            {
                return this.playablePuzzleConstraints.IsSatisfied;
            }
        }
    }
}
