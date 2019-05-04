using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class PuzzleConstraintsValueViewModel
    {
        private IPlayablePuzzleConstraintsValue playablePuzzleConstraintsValue;
        public PuzzleConstraintsValueViewModel(IPlayablePuzzleConstraintsValue value)
        {
            this.playablePuzzleConstraintsValue = value;
        }
        public int Value {
            get
            {
                return this.playablePuzzleConstraintsValue.Value;
            }
        }
        public Cell<bool> IsSatisfied {
            get
            {
                return this.playablePuzzleConstraintsValue.IsSatisfied;
            }
        }

    }
}
