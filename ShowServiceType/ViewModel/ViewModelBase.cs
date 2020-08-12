using System.ComponentModel;

namespace ShowServiceType
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged( string propname ) => PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(propname));
	}
}
