using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Service
{
	internal interface IAgencyService
	{
		void GetAllAgents();
		void GetAgentsIdAndName();
		void AddNewAgency();
	}
}
