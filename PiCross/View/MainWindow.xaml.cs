using DataStructures;
using ViewModel;
using PiCross;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Grid = DataStructures.Grid;
using Size = DataStructures.Size;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.viewmodel = new MainWindowViewModel();
            this.DataContext = viewmodel;
            picrossControl.Grid = viewmodel.DemoPlayablePluzzle.Grid;
            picrossControl.RowConstraints = viewmodel.DemoPlayablePluzzle.RowConstraints;
            picrossControl.ColumnConstraints = viewmodel.DemoPlayablePluzzle.ColumnConstraints;
        }
        private MainWindowViewModel viewmodel;
    }
    public class SquareConverter : IValueConverter
    {
        public object Filled { get; set; }

        public object Empty { get; set; }

        public object Unknown { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var square = (Square)value;
            if (square == Square.EMPTY)
            {
                return Empty;
            }
            else if (square == Square.FILLED)
            {
                return Filled;
            }
            else
            {
                return Unknown;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
