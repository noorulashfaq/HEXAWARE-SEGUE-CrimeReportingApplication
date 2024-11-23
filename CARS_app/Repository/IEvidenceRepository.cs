using CARS_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Repository
{
	internal interface IEvidenceRepository
	{
		//List<Evidence> GetAllEvidences();
		List<Evidence> GetEvidencesByIncidentId(int incidentId);
		int AddEvidence(Evidence evidence);
	}
}
