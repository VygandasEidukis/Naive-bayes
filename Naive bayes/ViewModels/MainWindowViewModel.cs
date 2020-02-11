using Naive_bayes.Data_Access.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            PenetrationDataContext penetrationDataContext = new PenetrationDataContext();
        }
    }
}
