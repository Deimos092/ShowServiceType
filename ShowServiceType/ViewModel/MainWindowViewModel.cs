using System.Collections.Generic;
using System.Collections.ObjectModel;

using ServiceTypeService.Dto;
using ServiceTypeService.Interface;

using ShowServiceType.Interfaces;
using ShowServiceType.Utils;

namespace ShowServiceType.ViewModel
{
	class MainWindowViewModel : ViewModelBase
	{
		long _id;
		/// <summary>
		/// Create Services for work
		/// </summary>
		ILogService Log => Service.CreateLog();
		IExceptionHandler ExceptionHandler => Service.CreateExeptionHandler();
		IServiceType ServiceType => Service.CreateGetServiceType();


		public ObservableCollection<ServiceTypeDto> servicesCollection;

		public MainWindowViewModel()
		{
			ServiceConfig.Initialization();
			servicesCollection = new ObservableCollection<ServiceTypeDto>();
			var _services = ServiceType.GetServiceTypesTree();

			foreach ( var item in _services )
				servicesCollection.Add(item);
		}

		public long ID
		{
			get => _id;
			set
			{
				_id = value;
				OnPropertyChanged("ID");
			}
		}
		public string Code
		{
			get => string.Format($"{servicesCollection[0].Code} ");
			set
			{
				servicesCollection[0].Code = value;
				OnPropertyChanged("Code");
			}
		}
		public string Name
		{
			get => string.Format($"{servicesCollection[0].Name} "); // ? ?
			set
			{
				servicesCollection[0].Name = value; // ? 
				OnPropertyChanged("Name");
			}
		}
		public List<ServiceTypeDto> ChildrenList
		{
			get => servicesCollection[0].ChildrenList; // ? index ?
			set
			{
				servicesCollection[0].ChildrenList = value; // ? ?
				OnPropertyChanged("ChildrenList");
			}
		}
	}
}
