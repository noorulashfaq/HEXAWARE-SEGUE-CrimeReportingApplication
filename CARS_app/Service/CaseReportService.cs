using CARS_app.Exceptions;
using CARS_app.Model;
using CARS_app.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Service
{
	internal class CaseReportService : ICaseReportService
	{
		readonly ICaseReportRepository _caseReportRepository;
		readonly IReportRepository _reportRepository;
		readonly IIncidentRepository _incidentRepository;
		readonly IEvidenceRepository _evidenceRepository;
		readonly IVictimRepository _victimRepository;
		readonly ISuspectRepository _suspectRepository;
		readonly IOfficerRepository _officerRepository;
		readonly IAgencyRepository _agencyRepository;
		public CaseReportService()
		{
			_caseReportRepository = new CaseReportRepository();
			_reportRepository = new ReportRepository();
			_incidentRepository = new IncidentRepository();
			_evidenceRepository = new EvidenceRepository();
			_victimRepository = new VictimRepository();
			_suspectRepository = new SuspectRepository();
			_officerRepository = new OfficerRepository();
			_agencyRepository = new AgencyRepository();
		}

		//public void GetAllCaseReports()
		//{
		//	try
		//	{
		//		List<CaseReport> allCaseReports = _caseReportRepository.GetAllCaseReports();
		//		if (allCaseReports.Count == 0)
		//		{
		//			Console.WriteLine("No case reports found");
		//			return;
		//		}
		//		Console.WriteLine("----------------------------------------------------\nListing all Case reports");
		//		Console.WriteLine("---------------------\n");
		//		foreach (CaseReport caseReport in allCaseReports)
		//		{
		//			Thread.Sleep(250);
		//			StringBuilder reportBuilder = new StringBuilder();
		//			reportBuilder.AppendLine("==================================================");
		//			reportBuilder.AppendLine($"             INCIDENT {caseReport.IncidentDetails.IncidentId} REPORT SUMMARY              ");
		//			reportBuilder.AppendLine("==================================================");

		//			// Report Details
		//			reportBuilder.AppendLine("Report Details:");
		//			reportBuilder.AppendLine($"  Report ID : {caseReport.CaseReportDetails.ReportId} ({caseReport.CaseReportDetails.Status})\tDate : {caseReport.CaseReportDetails.ReportDate:yyyy-MM-dd}");
		//			//reportBuilder.AppendLine($"  Incident ID   : {caseReport.CaseReportDetails.IncidentId}");
		//			//reportBuilder.AppendLine($"  Reporting Officer: {caseReport.CaseReportDetails.ReportingOfficer}");
		//			//reportBuilder.AppendLine($"  Date          : {caseReport.CaseReportDetails.ReportDate:yyyy-MM-dd}");
		//			reportBuilder.AppendLine($"  {caseReport.CaseReportDetails.ReportDetails}");
		//			//reportBuilder.AppendLine($"  Status        : {caseReport.CaseReportDetails.Status}");
		//			reportBuilder.AppendLine();

		//			// Incident Details
		//			reportBuilder.AppendLine("Incident Details:");
		//			//reportBuilder.AppendLine($"  Incident ID   : {caseReport.IncidentDetails.IncidentId}");
		//			reportBuilder.AppendLine($"  Type          : {caseReport.IncidentDetails.IncidentType}");
		//			reportBuilder.AppendLine($"  Date          : {caseReport.IncidentDetails.IncidentDate:yyyy-MM-dd}");
		//			reportBuilder.AppendLine($"  Location      : {caseReport.IncidentDetails.Location}");
		//			reportBuilder.AppendLine($"  Description   : {caseReport.IncidentDetails.Description}");
		//			reportBuilder.AppendLine($"  Status        : {caseReport.IncidentDetails.Status}");
		//			reportBuilder.AppendLine();

		//			// Victim Details
		//			reportBuilder.AppendLine("Victim Details:");
		//			//reportBuilder.AppendLine($"  Victim ID     : {caseReport.VictimDetails.VictimId}");
		//			reportBuilder.AppendLine($"  Name          : {caseReport.VictimDetails.FirstName} {caseReport.VictimDetails.LastName}");
		//			reportBuilder.AppendLine($"  Date of Birth : {caseReport.VictimDetails.DateOfBirth:yyyy-MM-dd}");
		//			reportBuilder.AppendLine($"  Gender        : {caseReport.VictimDetails.Gender}");
		//			reportBuilder.AppendLine($"  Contact Info  : {caseReport.VictimDetails.PhoneNumber}");
		//			reportBuilder.AppendLine();

		//			// Suspect Details
		//			reportBuilder.AppendLine("Suspect Details:");
		//			//reportBuilder.AppendLine($"  Suspect ID    : {caseReport.SuspectDetails.SuspectId}");
		//			reportBuilder.AppendLine($"  Name          : {caseReport.SuspectDetails.FirstName} {caseReport.SuspectDetails.LastName}");
		//			reportBuilder.AppendLine($"  Date of Birth : {caseReport.SuspectDetails.DateOfBirth:yyyy-MM-dd}");
		//			reportBuilder.AppendLine($"  Gender        : {caseReport.SuspectDetails.Gender}");
		//			reportBuilder.AppendLine($"  Contact Info  : {caseReport.SuspectDetails.PhoneNumber}");
		//			reportBuilder.AppendLine();

		//			// Law Enforcement Agency Details
		//			reportBuilder.AppendLine("Law Enforcement Agency Details:");
		//			//reportBuilder.AppendLine($"  Agency ID     : {caseReport.AgencyDetails.AgencyId}");
		//			reportBuilder.AppendLine($"  Name          : {caseReport.AgencyDetails.AgencyName}");
		//			reportBuilder.AppendLine($"  Jurisdiction  : {caseReport.AgencyDetails.Jurisdiction}");
		//			reportBuilder.AppendLine($"  Contact Info  : {caseReport.AgencyDetails.PhoneNumber}");
		//			reportBuilder.AppendLine();

		//			// Officer Details
		//			reportBuilder.AppendLine("Officer Details:");
		//			//reportBuilder.AppendLine($"  Officer ID    : {caseReport.OfficerDetails.OfficerId}");
		//			reportBuilder.AppendLine($"  Name          : {caseReport.OfficerDetails.FirstName} {caseReport.OfficerDetails.LastName}");
		//			reportBuilder.AppendLine($"  Badge Number  : {caseReport.OfficerDetails.BadgeNumber}");
		//			reportBuilder.AppendLine($"  Rank          : {caseReport.OfficerDetails.Rank}");
		//			reportBuilder.AppendLine($"  Contact Info  : {caseReport.OfficerDetails.PhoneNumber}");
		//			reportBuilder.AppendLine();

		//			// Evidence Details
		//			reportBuilder.AppendLine("Evidence Details:");
		//			//reportBuilder.AppendLine($"  Evidence ID   : {caseReport.EvidenceDetails.EvidenceId}");
		//			reportBuilder.AppendLine($"  Description   : {caseReport.EvidenceDetails.Description}");
		//			reportBuilder.AppendLine($"  Location Found: {caseReport.EvidenceDetails.LocationFound}");
		//			reportBuilder.AppendLine();

		//			reportBuilder.AppendLine("==================================================");
		//			reportBuilder.AppendLine("                 END OF REPORT                    ");
		//			reportBuilder.AppendLine("==================================================");
		//			Console.WriteLine(reportBuilder.ToString());
		//		}
		//		Console.WriteLine("----------------------------------------------------\n");
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex.Message);
		//	}
		//}

		public void GetAllCaseReports()
		{
			List<CaseReport> allCaseReports = new List<CaseReport>();
			try
			{
				List<Report> allReports = _reportRepository.GetAllReports();
				foreach (Report report in allReports)
				{
					CaseReport cr = new CaseReport();
					cr.ReportDetails = report;
					cr.IncidentDetails = _incidentRepository.GetIncidentForCaseReport(report.IncidentId);
					cr.EvidenceDetails = _evidenceRepository.GetEvidencesByIncidentId(report.IncidentId);
					cr.VictimDetails = _victimRepository.GetVictimsByIncidentId(report.IncidentId);
					cr.SuspectDetails = _suspectRepository.GetSuspectsByIncidentId(report.IncidentId);
					cr.OfficerDetails = _officerRepository.GetOfficerById(report.ReportingOfficer);
					cr.AgencyDetails = _agencyRepository.GetAgencyById(cr.OfficerDetails.AgencyId);
					allCaseReports.Add(cr);
				}

				//Console.WriteLine(allCaseReports.Count);
				foreach(CaseReport caseReport in allCaseReports)
				{
					//Console.WriteLine(caseReport.ReportDetails.ReportId);
					StringBuilder reportBuilder = new StringBuilder();
					reportBuilder.AppendLine("==================================================");
					reportBuilder.AppendLine($"             INCIDENT {caseReport.IncidentDetails.IncidentId} REPORT SUMMARY              ");
					reportBuilder.AppendLine("==================================================");

					// Report Details
					reportBuilder.AppendLine("Report Details:");
					reportBuilder.AppendLine($"  Report ID : {caseReport.ReportDetails.ReportId} ({caseReport.ReportDetails.Status})\tDate : {caseReport.ReportDetails.ReportDate:yyyy-MM-dd}");
					reportBuilder.AppendLine($"  {caseReport.ReportDetails.ReportDetails}");
					reportBuilder.AppendLine();

					// Incident Details
					reportBuilder.AppendLine("Incident Details:");
					reportBuilder.AppendLine($"  Type          : {caseReport.IncidentDetails.IncidentType}");
					reportBuilder.AppendLine($"  Date          : {caseReport.IncidentDetails.IncidentDate:yyyy-MM-dd}");
					reportBuilder.AppendLine($"  Location      : {caseReport.IncidentDetails.Location}");
					reportBuilder.AppendLine($"  Description   : {caseReport.IncidentDetails.Description}");
					reportBuilder.AppendLine($"  Status        : {caseReport.IncidentDetails.Status}");
					reportBuilder.AppendLine();


					// Law Enforcement Agency Details
					reportBuilder.AppendLine("Law Enforcement Agency Details:");
					reportBuilder.AppendLine($"  Agency ID     : {caseReport.AgencyDetails.AgencyId}");
					reportBuilder.AppendLine($"  Name          : {caseReport.AgencyDetails.AgencyName}");
					reportBuilder.AppendLine($"  Jurisdiction  : {caseReport.AgencyDetails.Jurisdiction}");
					reportBuilder.AppendLine($"  Contact Info  : {caseReport.AgencyDetails.PhoneNumber}");
					reportBuilder.AppendLine();

					// Officer Details
					reportBuilder.AppendLine("Officer Details:");
					reportBuilder.AppendLine($"  Officer ID    : {caseReport.OfficerDetails.OfficerId}");
					reportBuilder.AppendLine($"  Name          : {caseReport.OfficerDetails.FirstName} {caseReport.OfficerDetails.LastName}");
					reportBuilder.AppendLine($"  Badge Number  : {caseReport.OfficerDetails.BadgeNumber}");
					reportBuilder.AppendLine($"  Rank          : {caseReport.OfficerDetails.Rank}");
					reportBuilder.AppendLine($"  Contact Info  : {caseReport.OfficerDetails.PhoneNumber}");
					reportBuilder.AppendLine();

					//Victim Details
					reportBuilder.AppendLine("Victim Details:");
					reportBuilder.AppendLine();
					foreach (Victim victim in caseReport.VictimDetails)
					{
						reportBuilder.AppendLine($"  Victim ID     : {victim.VictimId}");
						reportBuilder.AppendLine($"  Name          : {victim.FirstName} {victim.LastName}");
						reportBuilder.AppendLine($"  Date of Birth : {victim.DateOfBirth:yyyy-MM-dd}");
						reportBuilder.AppendLine($"  Gender        : {victim.Gender}");
						reportBuilder.AppendLine($"  Contact Info  : {victim.PhoneNumber}");
						reportBuilder.AppendLine();
					}

					//Suspect Details
					reportBuilder.AppendLine("Suspect Details:");
					reportBuilder.AppendLine();
					foreach (Suspect suspect in caseReport.SuspectDetails)
					{
						reportBuilder.AppendLine($"  Suspect ID    : {suspect.SuspectId}");
						reportBuilder.AppendLine($"  Name          : {suspect.FirstName} {suspect.LastName}");
						reportBuilder.AppendLine($"  Date of Birth : {suspect.DateOfBirth:yyyy-MM-dd}");
						reportBuilder.AppendLine($"  Gender        : {suspect.Gender}");
						reportBuilder.AppendLine($"  Contact Info  : {suspect.PhoneNumber}");
						reportBuilder.AppendLine();
					}

					//Evidence Details
					reportBuilder.AppendLine("Evidence Details:");
					reportBuilder.AppendLine();
					foreach (Evidence evidence in caseReport.EvidenceDetails)
					{
						reportBuilder.AppendLine($"  Evidence ID   : {evidence.EvidenceId}");
						reportBuilder.AppendLine($"  Description   : {evidence.Description}");
						reportBuilder.AppendLine($"  Location Found: {evidence.LocationFound}");
						reportBuilder.AppendLine();
					}
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine(reportBuilder.ToString());
					Console.ResetColor();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void GetCaseReportById()
		{
			Console.Write("Enter Case report ID: ");
			int reportId = int.Parse(Console.ReadLine());

			//List<CaseReport> allCaseReports = new List<CaseReport>();
			try
			{
				//List<Report> allReports = _reportRepository.GetAllReports();
				//foreach (Report report in allReports)
				//{
					CaseReport cr = new CaseReport();
					cr.ReportDetails = _reportRepository.GetReportForCase(reportId);
				if(cr.ReportDetails.ReportId == 0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					throw new ReportNumberNotFoundException("Report not available for the given ID");
				}
				Console.WriteLine(cr.ReportDetails.IncidentId);
					cr.IncidentDetails = _incidentRepository.GetIncidentForCaseReport(cr.ReportDetails.IncidentId);
					cr.EvidenceDetails = _evidenceRepository.GetEvidencesByIncidentId(cr.ReportDetails.IncidentId);
					cr.VictimDetails = _victimRepository.GetVictimsByIncidentId(cr.ReportDetails.IncidentId);
					cr.SuspectDetails = _suspectRepository.GetSuspectsByIncidentId(cr.ReportDetails.IncidentId);
					cr.OfficerDetails = _officerRepository.GetOfficerById(cr.ReportDetails.ReportingOfficer);
					cr.AgencyDetails = _agencyRepository.GetAgencyById(cr.OfficerDetails.AgencyId);
					//allCaseReports.Add(cr);
				//}

				//Console.WriteLine(allCaseReports.Count);
				//foreach (CaseReport caseReport in allCaseReports)
				//{
					//Console.WriteLine(caseReport.ReportDetails.ReportId);
					StringBuilder reportBuilder = new StringBuilder();
					reportBuilder.AppendLine("==================================================");
					reportBuilder.AppendLine($"             INCIDENT {cr.IncidentDetails.IncidentId} REPORT SUMMARY              ");
					reportBuilder.AppendLine("==================================================");

					// Report Details
					reportBuilder.AppendLine("Report Details:");
					reportBuilder.AppendLine($"  Report ID : {cr.ReportDetails.ReportId} ({cr.ReportDetails.Status})\tDate : {cr.ReportDetails.ReportDate:yyyy-MM-dd}");
					reportBuilder.AppendLine($"  {cr.ReportDetails.ReportDetails}");
					reportBuilder.AppendLine();

					// Incident Details
					reportBuilder.AppendLine("Incident Details:");
					reportBuilder.AppendLine($"  Type          : {cr.IncidentDetails.IncidentType}");
					reportBuilder.AppendLine($"  Date          : {cr.IncidentDetails.IncidentDate:yyyy-MM-dd}");
					reportBuilder.AppendLine($"  Location      : {cr.IncidentDetails.Location}");
					reportBuilder.AppendLine($"  Description   : {cr.IncidentDetails.Description}");
					reportBuilder.AppendLine($"  Status        : {cr.IncidentDetails.Status}");
					reportBuilder.AppendLine();


					// Law Enforcement Agency Details
					reportBuilder.AppendLine("Law Enforcement Agency Details:");
					reportBuilder.AppendLine($"  Agency ID     : {cr.AgencyDetails.AgencyId}");
					reportBuilder.AppendLine($"  Name          : {cr.AgencyDetails.AgencyName}");
					reportBuilder.AppendLine($"  Jurisdiction  : {cr.AgencyDetails.Jurisdiction}");
					reportBuilder.AppendLine($"  Contact Info  : {cr.AgencyDetails.PhoneNumber}");
					reportBuilder.AppendLine();

					// Officer Details
					reportBuilder.AppendLine("Officer Details:");
					reportBuilder.AppendLine($"  Officer ID    : {cr.OfficerDetails.OfficerId}");
					reportBuilder.AppendLine($"  Name          : {cr.OfficerDetails.FirstName} {cr.OfficerDetails.LastName}");
					reportBuilder.AppendLine($"  Badge Number  : {cr.OfficerDetails.BadgeNumber}");
					reportBuilder.AppendLine($"  Rank          : {cr.OfficerDetails.Rank}");
					reportBuilder.AppendLine($"  Contact Info  : {cr.OfficerDetails.PhoneNumber}");
					reportBuilder.AppendLine();

					//Victim Details
					reportBuilder.AppendLine("Victim Details:");
					reportBuilder.AppendLine();
					foreach (Victim victim in cr.VictimDetails)
					{
						reportBuilder.AppendLine($"  Victim ID     : {victim.VictimId}");
						reportBuilder.AppendLine($"  Name          : {victim.FirstName} {victim.LastName}");
						reportBuilder.AppendLine($"  Date of Birth : {victim.DateOfBirth:yyyy-MM-dd}");
						reportBuilder.AppendLine($"  Gender        : {victim.Gender}");
						reportBuilder.AppendLine($"  Contact Info  : {victim.PhoneNumber}");
						reportBuilder.AppendLine($"  Address       : {victim.Address}");
						reportBuilder.AppendLine();
					}

					//Suspect Details
					reportBuilder.AppendLine("Suspect Details:");
					reportBuilder.AppendLine();
					foreach (Suspect suspect in cr.SuspectDetails)
					{
						reportBuilder.AppendLine($"  Suspect ID    : {suspect.SuspectId}");
						reportBuilder.AppendLine($"  Name          : {suspect.FirstName} {suspect.LastName}");
						reportBuilder.AppendLine($"  Date of Birth : {suspect.DateOfBirth:yyyy-MM-dd}");
						reportBuilder.AppendLine($"  Gender        : {suspect.Gender}");
						reportBuilder.AppendLine($"  Contact Info  : {suspect.PhoneNumber}");
						reportBuilder.AppendLine($"  Address       : {suspect.Address}");
						reportBuilder.AppendLine();
					}

					//Evidence Details
					reportBuilder.AppendLine("Evidence Details:");
					reportBuilder.AppendLine();
					foreach (Evidence evidence in cr.EvidenceDetails)
					{
						reportBuilder.AppendLine($"  Evidence ID   : {evidence.EvidenceId}");
						reportBuilder.AppendLine($"  Description   : {evidence.Description}");
						reportBuilder.AppendLine($"  Location Found: {evidence.LocationFound}");
						reportBuilder.AppendLine();
					}

					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine(reportBuilder.ToString());
					Console.ResetColor();
				//}
			}
			catch(ReportNumberNotFoundException rnf)
			{
				Console.WriteLine(rnf.Message);
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		//public void GetCaseReportById()
		//{

		//	try
		//	{
		//		Console.Write("\n=> Enter Case Report ID: ");
		//		int caseReportId = int.Parse(Console.ReadLine());

		//		List<CaseReport> allCaseReports = _caseReportRepository.GetCaseReportById(caseReportId);
		//		if (allCaseReports.Count == 0)
		//		{
		//			Console.WriteLine("No case reports found");
		//			return;
		//		}
		//		Console.WriteLine("----------------------------------------------------\nListing all Case reports");
		//		Console.WriteLine("---------------------\n");
		//		foreach (CaseReport caseReport in allCaseReports)
		//		{
		//			Thread.Sleep(250);
		//			StringBuilder reportBuilder = new StringBuilder();
		//			reportBuilder.AppendLine("==================================================");
		//			reportBuilder.AppendLine($"             INCIDENT {caseReport.IncidentDetails.IncidentId} REPORT SUMMARY              ");
		//			reportBuilder.AppendLine("==================================================");

		//			// Report Details
		//			reportBuilder.AppendLine("Report Details:");
		//			reportBuilder.AppendLine($"  Report ID : {caseReport.CaseReportDetails.ReportId} ({caseReport.CaseReportDetails.Status})\tDate : {caseReport.CaseReportDetails.ReportDate:yyyy-MM-dd}");
		//			//reportBuilder.AppendLine($"  Incident ID   : {caseReport.CaseReportDetails.IncidentId}");
		//			//reportBuilder.AppendLine($"  Reporting Officer: {caseReport.CaseReportDetails.ReportingOfficer}");
		//			//reportBuilder.AppendLine($"  Date          : {caseReport.CaseReportDetails.ReportDate:yyyy-MM-dd}");
		//			reportBuilder.AppendLine($"  {caseReport.CaseReportDetails.ReportDetails}");
		//			//reportBuilder.AppendLine($"  Status        : {caseReport.CaseReportDetails.Status}");
		//			reportBuilder.AppendLine();

		//			// Incident Details
		//			reportBuilder.AppendLine("Incident Details:");
		//			//reportBuilder.AppendLine($"  Incident ID   : {caseReport.IncidentDetails.IncidentId}");
		//			reportBuilder.AppendLine($"  Type          : {caseReport.IncidentDetails.IncidentType}");
		//			reportBuilder.AppendLine($"  Date          : {caseReport.IncidentDetails.IncidentDate:yyyy-MM-dd}");
		//			reportBuilder.AppendLine($"  Location      : {caseReport.IncidentDetails.Location}");
		//			reportBuilder.AppendLine($"  Description   : {caseReport.IncidentDetails.Description}");
		//			reportBuilder.AppendLine($"  Status        : {caseReport.IncidentDetails.Status}");
		//			reportBuilder.AppendLine();

		//			// Victim Details
		//			reportBuilder.AppendLine("Victim Details:");
		//			//reportBuilder.AppendLine($"  Victim ID     : {caseReport.VictimDetails.VictimId}");
		//			reportBuilder.AppendLine($"  Name          : {caseReport.VictimDetails.FirstName} {caseReport.VictimDetails.LastName}");
		//			reportBuilder.AppendLine($"  Date of Birth : {caseReport.VictimDetails.DateOfBirth:yyyy-MM-dd}");
		//			reportBuilder.AppendLine($"  Gender        : {caseReport.VictimDetails.Gender}");
		//			reportBuilder.AppendLine($"  Contact Info  : {caseReport.VictimDetails.PhoneNumber}");
		//			reportBuilder.AppendLine();

		//			// Suspect Details
		//			reportBuilder.AppendLine("Suspect Details:");
		//			//reportBuilder.AppendLine($"  Suspect ID    : {caseReport.SuspectDetails.SuspectId}");
		//			reportBuilder.AppendLine($"  Name          : {caseReport.SuspectDetails.FirstName} {caseReport.SuspectDetails.LastName}");
		//			reportBuilder.AppendLine($"  Date of Birth : {caseReport.SuspectDetails.DateOfBirth:yyyy-MM-dd}");
		//			reportBuilder.AppendLine($"  Gender        : {caseReport.SuspectDetails.Gender}");
		//			reportBuilder.AppendLine($"  Contact Info  : {caseReport.SuspectDetails.PhoneNumber}");
		//			reportBuilder.AppendLine();

		//			// Law Enforcement Agency Details
		//			reportBuilder.AppendLine("Law Enforcement Agency Details:");
		//			//reportBuilder.AppendLine($"  Agency ID     : {caseReport.AgencyDetails.AgencyId}");
		//			reportBuilder.AppendLine($"  Name          : {caseReport.AgencyDetails.AgencyName}");
		//			reportBuilder.AppendLine($"  Jurisdiction  : {caseReport.AgencyDetails.Jurisdiction}");
		//			reportBuilder.AppendLine($"  Contact Info  : {caseReport.AgencyDetails.PhoneNumber}");
		//			reportBuilder.AppendLine();

		//			// Officer Details
		//			reportBuilder.AppendLine("Officer Details:");
		//			//reportBuilder.AppendLine($"  Officer ID    : {caseReport.OfficerDetails.OfficerId}");
		//			reportBuilder.AppendLine($"  Name          : {caseReport.OfficerDetails.FirstName} {caseReport.OfficerDetails.LastName}");
		//			reportBuilder.AppendLine($"  Badge Number  : {caseReport.OfficerDetails.BadgeNumber}");
		//			reportBuilder.AppendLine($"  Rank          : {caseReport.OfficerDetails.Rank}");
		//			reportBuilder.AppendLine($"  Contact Info  : {caseReport.OfficerDetails.PhoneNumber}");
		//			reportBuilder.AppendLine();

		//			// Evidence Details
		//			reportBuilder.AppendLine("Evidence Details:");
		//			//reportBuilder.AppendLine($"  Evidence ID   : {caseReport.EvidenceDetails.EvidenceId}");
		//			reportBuilder.AppendLine($"  Description   : {caseReport.EvidenceDetails.Description}");
		//			reportBuilder.AppendLine($"  Location Found: {caseReport.EvidenceDetails.LocationFound}");
		//			reportBuilder.AppendLine();

		//			reportBuilder.AppendLine("==================================================");
		//			reportBuilder.AppendLine("                 END OF REPORT                    ");
		//			reportBuilder.AppendLine("==================================================");
		//			Console.WriteLine(reportBuilder.ToString());
		//		}
		//		Console.WriteLine("----------------------------------------------------\n");
		//	}
		//	catch(ReportNumberNotFoundException rnf)
		//	{
		//		Console.WriteLine(rnf.Message);
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex.Message);
		//	}
		//}
	}
}
