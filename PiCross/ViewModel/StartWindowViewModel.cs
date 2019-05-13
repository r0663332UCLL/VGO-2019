using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static ViewModel.PlayWindowViewModel;

namespace ViewModel
{
    public class StartWindowViewModel
    {
        private MainWindowViewModel VM;
        public StartWindowViewModel(MainWindowViewModel Mainvm)
        {
            this.VM = Mainvm;
            this.Start = new StartCommand(VM);
            this.Select = new SelectCommand(VM);
            this.Exit = new ExitCommand(VM);
        }

        public ICommand Select { get; }
        public ICommand Start { get; }
        public ICommand Exit { get; }

        private class StartCommand : ICommand
        {
            private MainWindowViewModel VM;
            public StartCommand(MainWindowViewModel Mainvm)
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
                VM.startGame();
            }
        }

        private class SelectCommand : ICommand
        {
            private MainWindowViewModel VM;
            public SelectCommand(MainWindowViewModel Mainvm)
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
                this.VM.levelSelector();
            }
        }
    }
}
