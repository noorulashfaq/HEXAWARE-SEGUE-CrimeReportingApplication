using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Model
{
	internal class Evidence
	{
		int _evidenceId, _incidentId;
		string _description, _locationFound;

		public int EvidenceId
		{
			get { return _evidenceId; }
			set { _evidenceId = value; }
		}

		public int IncidentId
		{
			get { return _incidentId; }
			set { _incidentId = value; }
		}

		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		public string LocationFound
		{
			get { return _locationFound; }
			set { _locationFound = value; }
		}

		public override string ToString()
		{
			return $"Evidence ID: {EvidenceId}\n" +
				$"Incident ID: {IncidentId}\n" +
				$"Description: {Description}\n" +
				$"Location found: {LocationFound}\n";
		}
	}
}
