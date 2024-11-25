using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Exceptions
{
	internal class OfficerNotFoundException: ApplicationException
	{
		public OfficerNotFoundException () { }

		public OfficerNotFoundException (string message) : base(message) { }
	}
}
