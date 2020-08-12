using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShowServiceType.Utils;

namespace ShowServiceType.Utils
{
	class ServiceConfig
	{
		public static void Initialization()
		{
			Service.CreateLog = () => Debug.Create();
			Service.CreateExeptionHandler = () => ExceptionHandler.Create();
			Service.CreateGetServiceType = () => new ServiceTypeService.ServiceTypeService();// не стал изменять на Singleton паттерн
		}
	}
}
