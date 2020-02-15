using Naive_bayes.Common.Models;
using Naive_bayes.Data_Access.Contexts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Naive_bayes.ViewModels
{
	public class RegisterDataViewModel : BaseViewModel
	{
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
		}

		public void Load()
		{
			ResetData();
			var context = new PenetrationDataContext();

		    
		}

		public void ResetData()
		{
			Angle = new ObservableCollection<AngleDto>();
			Armor = new ObservableCollection<ArmorDto>();
			Penetration = new ObservableCollection<PenetrationDto>();
			ShellSize = new ObservableCollection<ShellSizeDto>();
			ShellType = new ObservableCollection<ShellTypeDto>();
			DataPoint = new PenetrationDataPointDto();
		}

		public void AddData_Clicked()
		{
			System.Windows.MessageBox.Show("You Have Clicked the button");
		}

		
	}
}
