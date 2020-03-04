using Naive_bayes.Common.Models;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Naive_bayes.ViewModels
{
	public class RegisterDataViewModel : BaseViewModel
	{
		public delegate void AddDataPoint();
		public AddDataPoint dataPointAdd;

		private PenetrationDataPointDto _dataPoint;

		public PenetrationDataPointDto DataPoint
		{
			get => _dataPoint;
			set 
			{
				_dataPoint = value;
				OnPropertyChanged();
			}
		}

		#region Data Point Available Variables
		private ObservableCollection<AngleDto> _angle;

		public ObservableCollection<AngleDto> Angle
		{
			get { return _angle; }
			set 
			{ 
				_angle = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<ArmorDto> _armor;

		public ObservableCollection<ArmorDto> Armor
		{
			get { return _armor; }
			set 
			{ 
				_armor = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<PenetrationDto> _penetration;

		public ObservableCollection<PenetrationDto> Penetration
		{
			get { return _penetration; }
			set 
			{ 
				_penetration = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<ShellSizeDto> _shellSize;

		public ObservableCollection<ShellSizeDto> ShellSize
		{
			get { return _shellSize; }
			set 
			{ 
				_shellSize = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<ShellTypeDto> _shellType;

		public ObservableCollection<ShellTypeDto> ShellType
		{
			get { return _shellType; }
			set 
			{ 
				_shellType = value;
				OnPropertyChanged();
			}
		}

		#endregion

		public RegisterDataViewModel()
		{
			Load();
			PrepareDataPoint();
		}

		public async void Load()
		{
			ResetData();
			var context = new PenetrationDataContext();

			var angles = await new AngleRepository(context).GetAsync();
			foreach (var angle in angles)
				Angle.Add(angle);

			var armors = await new ArmorRepository(context).GetAsync();
			foreach (var armor in armors)
				Armor.Add(armor);

			var penetrations = await new PenetrationRepository(context).GetAsync();
			foreach (var pen in penetrations)
				Penetration.Add(pen);

			var shellSizes = await new ShellSizeRepository(context).GetAsync();
			foreach (var shellSize in shellSizes)
				ShellSize.Add(shellSize);

			var shellTypes = await new ShellTypeRepository(context).GetAsync();
			foreach (var type in shellTypes)
				ShellType.Add(type);
		}

		private void PrepareDataPoint()
		{
			DataPoint = new PenetrationDataPointDto()
			{
				Angle = this.Angle[0],
				Armor = this.Armor[0],
				ShellType = this.ShellType[0],
				ShellSize = this.ShellSize[0],
				Penetration = this.Penetration[0]
			};
		}

		private void ResetData()
		{
			Angle = new ObservableCollection<AngleDto>();
			Armor = new ObservableCollection<ArmorDto>();
			Penetration = new ObservableCollection<PenetrationDto>();
			ShellSize = new ObservableCollection<ShellSizeDto>();
			ShellType = new ObservableCollection<ShellTypeDto>();
		}

		public async void AddData_Clicked()
		{
			var repository = new PenetrationDataPointRepository(new PenetrationDataContext());
			await repository.CreateNewDataPoint(DataPoint);
			Load();
			System.Windows.MessageBox.Show("Added data");

			dataPointAdd?.Invoke();

		}

		
	}
}
