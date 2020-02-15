using Naive_bayes.Common.Models;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Naive_bayes.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<PenetrationDataPointDto> _penetrations;

        public ObservableCollection<PenetrationDataPointDto> Penetrations
        {
            get { return _penetrations; }
            set 
            { 
                _penetrations = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Penetrations = new ObservableCollection<PenetrationDataPointDto>();
        }

        public async void LoadPenetrations()
        {
            var penetrationDataPointRepository = new PenetrationDataPointRepository(new PenetrationDataContext());
            foreach(var penetration in await penetrationDataPointRepository.GetAsync())
            {
                Penetrations.Add(penetration);
            }
        }
    }
}
