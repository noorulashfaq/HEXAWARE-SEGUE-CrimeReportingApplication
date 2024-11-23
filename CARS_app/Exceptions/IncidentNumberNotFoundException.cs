using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Exceptions
{
	internal class IncidentNumberNotFoundException: ApplicationException
	{
		public IncidentNumberNotFoundException()
		{

		}

		public IncidentNumberNotFoundException(string message) : base(message)
		{

		}
	}
}
