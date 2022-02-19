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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel = new HoroscopeViewModel(dpBirthday.SelectedDate.Value);
        }

        private void UpdateWindow(object sender, RoutedEventArgs e)
        {
            _viewModel.refresh(dpBirthday.SelectedDate.Value);
            tbAge.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
            tbWesternZodiac.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
            tbChineseZodiac.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
            tbGreeting.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }
    }
}
