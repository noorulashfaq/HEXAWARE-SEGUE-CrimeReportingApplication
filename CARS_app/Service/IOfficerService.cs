using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Service
{
	internal interface IOfficerService
	{
		void GetAllOfficers();
		void GetAllOfficersForMenu();
		void AddNewOfficer();
		int OfficerLogin(string role);
	}
}
