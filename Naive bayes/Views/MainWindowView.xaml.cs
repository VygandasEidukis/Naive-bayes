using System;
using System.Collections.Generic;
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

namespace Naive_bayes.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public static RegisterDataView registerData { get; } = new RegisterDataView();

        public MainWindowView()
        {
            InitializeComponent();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(()=>registerData.Show());
                registerData.Closed += (a, b) => this.Close();
            });
            DataContext = new ViewModels.MainWindowViewModel();
        }

        protected override void OnClosed(EventArgs e)
        {
            registerData.Close();
            base.OnClosed(e);
        }
    }
}
