
using CARS_app.Model;

namespace CARS_app.Service
{
	internal interface IIncidentService
	{
		void GetAllIncidents();
		void GetIncidentsForMenu();
		void AddNewIncident();
		void UpdateIncidentStatus();
		void GetIncidentInDateRange();
		void GetIncidentByType();
	}
}
