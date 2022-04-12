using Lab01.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Lab01.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HoroscopeViewModel _viewModel;
        DateTime defaultDate = new DateTime(2000, 1, 1);
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel = new HoroscopeViewModel(defaultDate);
        }
    }
}
