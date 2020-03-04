using Naive_bayes.Common.Models;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
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

        private ObservableCollection<PenetrationDataPointDto> _penetrationsNulled;

        public ObservableCollection<PenetrationDataPointDto> PenetrationsNulled
        {
            get { return _penetrationsNulled; }
            set
            {
                _penetrationsNulled = value;
                OnPropertyChanged("PenetrationsNulled");
            }
        }

        public MainWindowViewModel()
        {
            LoadPenetrations();
        }

        public async void LoadPenetrations()
        {
            Penetrations = new ObservableCollection<PenetrationDataPointDto>();
            PenetrationsNulled = new ObservableCollection<PenetrationDataPointDto>();

            var penetrationDataPointRepository = new PenetrationDataPointRepository(new PenetrationDataContext());
            var databasePenetrations = await penetrationDataPointRepository.GetAsync();
            foreach (var penetration in databasePenetrations.Where(x => x.WillPen != null).OrderByDescending(x =>x.Id))
            {
                Penetrations.Add(penetration);
            }

            foreach (var penetration in databasePenetrations.Where(x => x.WillPen == null))
            {
                PenetrationsNulled.Add(penetration);
            }
        }

        public void ClassifyItem(PenetrationDataPointDto dto)
        {
            var a = NaiveBayes.CanPenetrate(Penetrations, dto);

            PenetrationDataPointRepository penetrationDataPointRepository = new PenetrationDataPointRepository(new PenetrationDataContext());
            
        }
    }
}
