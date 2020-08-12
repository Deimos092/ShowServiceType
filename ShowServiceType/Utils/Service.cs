﻿using System;

using ServiceTypeService;
using ServiceTypeService.Interface;
using ShowServiceType.Interfaces;

namespace ShowServiceType.Utils
{
	public static class Service
	{
		/// <summary>
		/// Сервис логов
		/// </summary>
		public static Func<ILogService> CreateLog { get; set; } = () => throw new NotImplementedException();

		/// <summary>
		/// Сервис обработки ошибок
		/// </summary>
		public static Func<IExceptionHandler> CreateExeptionHandler { get; set; } = () => throw new NotImplementedException();

		/// <summary>
		/// Сервис сбора данных
		/// </summary>
		public static Func<IServiceType> CreateGetServiceType { get; set; } = () => throw new NotImplementedException();
	}
}
