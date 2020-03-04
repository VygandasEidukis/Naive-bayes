using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Naive_bayes.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		#region Notify property changed
		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged([CallerMemberName] string name = null)
		{
			//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
			if(PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}
}