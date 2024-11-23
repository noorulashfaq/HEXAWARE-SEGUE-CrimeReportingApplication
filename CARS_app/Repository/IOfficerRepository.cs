using CARS_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Repository
{
	internal interface IOfficerRepository
	{
		List<Officer> GetAllOfficers();
		int AddOfficer(Officer officer);
		Officer GetOfficerById(int officerId);
	}
}
