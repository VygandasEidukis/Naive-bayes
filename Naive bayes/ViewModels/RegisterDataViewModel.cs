using Naive_bayes.Common.Models;
using System;
using System.Collections.Generic;
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

		public void AddData_Clicked()
		{
			System.Windows.MessageBox.Show("You Have Clicked the button");
		}

		
	}
}
