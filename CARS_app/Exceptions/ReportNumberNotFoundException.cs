using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Exceptions
{
	internal class ReportNumberNotFoundException: ApplicationException
	{
		public ReportNumberNotFoundException()
		{

		}

		public ReportNumberNotFoundException(string message) : base(message)
		{

		}
	}
}
