using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Model
{
	internal class Report
	{
		int _reportId, _incidentId, _reportingOfficer;
		DateTime _reportDate;
		string _reportDetails, _status;

		public int ReportId
		{
			get { return _reportId; } 
			set { _reportId = value; } 
		}

		public int IncidentId
		{
			get { return _incidentId; }
			set { _incidentId = value; }
		}

		public int ReportingOfficer
		{
			get { return _reportingOfficer; }
			set { _reportingOfficer = value; }
		}

		public DateTime ReportDate
		{
			get { return _reportDate; }
			set { _reportDate = value; }
		}

		public string ReportDetails
		{
			get { return _reportDetails; }
			set { _reportDetails = value; }
		}

		public string Status
		{
			get { return _status; }
			set { _status = value; }
		}

		public override string ToString()
		{
			return $"Report ID: {ReportId}\nIncident ID: {IncidentId}\nReporting officer: {ReportingOfficer}\nDate: {ReportDate} ({Status})\nDetails: {ReportDetails}\n";
		}


	}
}
