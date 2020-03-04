using Naive_bayes.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Naive_bayes.Views
{
    /// <summary>
    /// Interaction logic for RegisterDataView.xaml
    /// </summary>
    public partial class RegisterDataView : Window
    {
        public delegate void AddedDataPoint();
        public AddedDataPoint addedDataPoint;

        public RegisterDataView()
        {
            DataContext = new RegisterDataViewModel();
            InitializeComponent();
        }

        public void added()
        {
            addedDataPoint?.Invoke();
        }
        private void Add_Click(object sender, RoutedEventArgs e) => (DataContext as RegisterDataViewModel).AddData_Clicked();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as RegisterDataViewModel).dataPointAdd += added;
        }
    }
}
