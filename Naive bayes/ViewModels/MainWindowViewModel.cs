using Naive_bayes.Common.Models;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
            LoadPenetrations();
        }

        public async void LoadPenetrations()
        {
            Penetrations = new ObservableCollection<PenetrationDataPointDto>();

            var penetrationDataPointRepository = new PenetrationDataPointRepository(new PenetrationDataContext());
            var databasePenetrations = await penetrationDataPointRepository.GetAsync();
            foreach(var penetration in databasePenetrations)
            {
                Penetrations.Add(penetration);
            }
        }
    }
}
