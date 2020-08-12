using System;
using System.Collections.Generic;

using ShowServiceType.Interfaces;
using ShowServiceType.Utils;

using Dto = ServiceTypeService.Dto;
using MedService = ServiceTypeService;

namespace ShowServiceType.Model
{
	public class ServiceList : ViewModelBase
	{
		private static ServiceList _instance;
		private List<Dto.ServiceTypeDto> _collection;
		private MedService.ServiceTypeService _service;
		
		private ILogService Log => Service.CreateLog();
		private IExceptionHandler Exceptions => Service.CreateExeptionHandler();


		// ---------------------------- Constructor ----------------------------
		private ServiceList()
		{
			ServiceConfig.Initialization();
			_service = new MedService.ServiceTypeService();
			_collection = _service.GetServiceTypesTree();
		}

		// ---------------------------- Public property ----------------------------
		public List<Dto.ServiceTypeDto> Collection
		{
			get => _collection;
		}
		public int Count
		{
			get => _collection.Count;
		}
		public Dto.ServiceTypeDto this[int index]
		{
			get
			{
				return Collection[index];
			}
			set
			{
				_collection[index] = value ?? new Dto.ServiceTypeDto();
			}
		}

		// ---------------------------- Private method ----------------------------
		public static ServiceList Create()
		{
			if ( _instance == null )
				return _instance = new ServiceList();
			return _instance;
		}

		// ---------------------------- Public method ----------------------------
		public Dto.ServiceTypeDto FindAny( Predicate<List<Dto.ServiceTypeDto>> predicate )
		{
			foreach ( var item in Collection )
			{
				if ( predicate.Invoke(item.ChildrenList) )
				{
					return item;
				}
			}
			return null;
		}

	}
}
