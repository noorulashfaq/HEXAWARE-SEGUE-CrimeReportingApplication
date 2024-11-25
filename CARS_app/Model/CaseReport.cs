namespace CARS_app.Model
{
	internal class CaseReport
	{
		#region OG model
		//Incident _incidentDetails;
		//Evidence _evidenceDetails;
		//Victim _victimDetails;
		//Suspect _suspectDetails;
		//Report _caseReportDetails;
		//Agency _agencyDetails;
		//Officer _officerDetails;

		//public Incident IncidentDetails
		//{
		//	get { return _incidentDetails; }
		//	set { _incidentDetails = value; }
		//}

		//public Evidence EvidenceDetails
		//{
		//	get { return _evidenceDetails; }
		//	set { _evidenceDetails = value; }
		//}

		//public Victim VictimDetails
		//{
		//	get { return _victimDetails; }
		//	set { _victimDetails = value; }
		//}

		//public Suspect SuspectDetails
		//{
		//	get { return _suspectDetails; }
		//	set { _suspectDetails = value; }
		//}

		//public Report CaseReportDetails
		//{
		//	get { return _caseReportDetails; }
		//	set { _caseReportDetails = value; }
		//}

		//public Agency AgencyDetails
		//{
		//	get { return _agencyDetails; }
		//	set { _agencyDetails = value; }
		//}

		//public Officer OfficerDetails
		//{
		//	get { return _officerDetails; }
		//	set { _officerDetails = value; }
		//}
		#endregion


		#region new logic
		Incident _incidentDetails;
		List<Evidence> _evidenceDetails;
		List<Suspect> _suspectDetails;
		List<Victim> _victimDetails;
		Agency _agencyDetails;
		Officer _officerDetails;
		Report _reportDetails;

		public Incident IncidentDetails
		{
			get { return _incidentDetails; }
			set { _incidentDetails = value; }
		}

		public Report ReportDetails
		{
			get { return _reportDetails; }
			set { _reportDetails = value; }
		}

		public Agency AgencyDetails
		{
			get { return _agencyDetails; }
			set { _agencyDetails = value; }
		}

		public Officer OfficerDetails
		{
			get { return _officerDetails; }
			set { _officerDetails = value; }
		}

		public List<Evidence> EvidenceDetails
		{
			get { return _evidenceDetails; }
			set { _evidenceDetails = value; }
		}

		public List<Victim> VictimDetails
		{
			get { return _victimDetails; }
			set { _victimDetails = value; }
		}

		public List<Suspect> SuspectDetails
		{
			get { return _suspectDetails; }
			set { _suspectDetails = value; }
		}

		#endregion
	}
}
