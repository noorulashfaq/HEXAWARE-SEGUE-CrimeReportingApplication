
namespace CARS_app.Model
{
	public class Incident
	{
		private int _incidentId, _agencyId;
		private string _incidentType, _location, _description, _status;
		private DateTime _incidentDate;

		public int IncidentId
		{
			get { return _incidentId; }
			set { _incidentId = value; }
		}

		public string IncidentType
		{
			get { return _incidentType; }
			set { _incidentType = value; }
		}

		public DateTime IncidentDate
		{
			get { return _incidentDate; }
			set { _incidentDate = value; }
		}

		public string Location
		{
			get { return _location; }
			set { _location = value; }
		}

		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		public string Status
		{
			get { return _status; }
			set { _status = value; }
		}

		public int AgencyId
		{
			get { return _agencyId; }
			set { _agencyId = value; }
		}

		public override string ToString()
		{
			return $"Incident ID: {IncidentId} (Status: {Status})\n" +
				$"Description: {IncidentType} - {Description}\n" +
				$"Location & date: {Location}, {IncidentDate:dd-MMM-yyyy}\n";
				//$"Description: {Description}\n" +
				//$"Status: {Status}\n" +
				//$"Agency ID: {AgencyId}\n";
		}
	}
}
