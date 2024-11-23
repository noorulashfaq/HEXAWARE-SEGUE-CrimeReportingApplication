using CARS_app.Model;
using CARS_app.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Repository
{
	internal class CaseReportRepository : ICaseReportRepository
	{
		SqlCommand _cmd = null;
		string connectionString;

		public CaseReportRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public List<CaseReport> GetAllCaseReports()
		{
			throw new NotImplementedException();
		}

		public List<CaseReport> GetCaseReportById(int reportId)
		{
			throw new NotImplementedException();
		}

		//public List<CaseReport> GetAllCaseReports()
		//{
		//	List<CaseReport> caseReports = new List<CaseReport>();
		//	using(SqlConnection conn = new SqlConnection(connectionString))
		//	{
		//		try
		//		{
		//			StringBuilder sb = new StringBuilder();
		//			_cmd.Parameters.Clear();
		//			sb.Append("select * from Reports as R ");
		//			sb.Append("inner join Incidents as I on R.IncidentID = I.IncidentID ");
		//			sb.Append("inner join Victims as V on V.IncidentID = I.IncidentID ");
		//			sb.Append("inner join Suspects as S on S.IncidentID = I.IncidentID ");
		//			sb.Append("inner join Evidences as E on E.IncidentID = I.IncidentID ");
		//			sb.Append("inner join LawEnforcementAgencies as L on L.AgencyID = I.AgencyID ");
		//			sb.Append("inner join Officers as O on O.AgencyID = L.AgencyID");
		//			_cmd.CommandText = sb.ToString();
		//			_cmd.Connection = conn;
		//			conn.Open();
		//			using (SqlDataReader reader = _cmd.ExecuteReader())
		//			{
		//				while (reader.Read())
		//				{
		//					CaseReport caseReport = new CaseReport();

		//					Incident incident = new Incident();
		//					Agency agency = new Agency();
		//					Evidence evidence = new Evidence();
		//					Officer officer = new Officer();
		//					Report report = new Report();
		//					Suspect suspect = new Suspect();
		//					Victim victim = new Victim();

		//					report.ReportId = (int)reader["ReportID"];
		//					report.IncidentId = (int)reader["IncidentID"];
		//					report.ReportingOfficer = (int)reader["ReportingOfficer"];
		//					report.ReportDate = (DateTime)reader["ReportDate"];
		//					report.ReportDetails = (string)reader["ReportDetails"];
		//					report.Status = (string)reader["Status"];

		//					victim.VictimId = (int)reader["VictimID"];
		//					victim.FirstName = (string)reader["FirstName"];
		//					victim.LastName = (string)reader["LastName"];
		//					victim.DateOfBirth = (DateTime)reader["DateOfBirth"];
		//					victim.Gender = (string)reader["Gender"];
		//					victim.PhoneNumber = (long)reader["PhoneNumber"];
		//					victim.Address = (string)reader["Address"];

		//					suspect.SuspectId = (int)reader["SuspectID"];
		//					suspect.FirstName = (string)reader["FirstName"];
		//					suspect.LastName = (string)reader["LastName"];
		//					suspect.DateOfBirth = (DateTime)reader["DateOfBirth"];
		//					suspect.Gender = (string)reader["Gender"];
		//					suspect.PhoneNumber = (long)reader["PhoneNumber"];
		//					suspect.Address = (string)reader["Address"];

		//					evidence.EvidenceId = (int)reader["EvidenceID"];
		//					evidence.Description = (string)reader["Description"];
		//					evidence.LocationFound = (string)reader["LocationFound"];

		//					agency.AgencyId = (int)reader["AgencyID"];
		//					agency.AgencyName = (string)reader["AgencyName"];
		//					agency.Jurisdiction = (string)reader["Jurisdiction"];
		//					agency.PhoneNumber = (long)reader["PhoneNumber"];
		//					agency.Address = (string)reader["Address"];

		//					officer.OfficerId = (int)reader["OfficerID"];
		//					officer.FirstName = (string)reader["FirstName"];
		//					officer.LastName = (string)reader["LastName"];
		//					officer.BadgeNumber = (int)reader["BadgeNumber"];
		//					officer.Rank = (string)reader["Rank"];
		//					officer.PhoneNumber = (long)reader["PhoneNumber"];
		//					officer.Address = (string)reader["Address"];

		//					incident.IncidentId = (int)reader["IncidentID"];
		//					incident.IncidentType = (string)reader["IncidentType"];
		//					incident.IncidentDate = (DateTime)reader["IncidentDate"];
		//					incident.Location = (string)reader["Location"];
		//					incident.Description = (string)reader["Description"];
		//					incident.Status = (string)reader["Status"];
		//					incident.AgencyId = (int)reader["AgencyID"];

		//					caseReport.IncidentDetails = incident;
		//					caseReport.VictimDetails = victim;
		//					caseReport.SuspectDetails = suspect;
		//					caseReport.EvidenceDetails = evidence;
		//					caseReport.AgencyDetails = agency;
		//					caseReport.OfficerDetails = officer;
		//					caseReport.CaseReportDetails = report;

		//					caseReports.Add(caseReport);
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			Console.WriteLine(ex.Message);
		//		}
		//	}
		//	return caseReports;
		//}

		//public List<CaseReport> GetCaseReportById(int reportId)
		//{
		//	List<CaseReport> caseReports = new List<CaseReport>();
		//	using (SqlConnection conn = new SqlConnection(connectionString))
		//	{
		//		try
		//		{
		//			StringBuilder sb = new StringBuilder();
		//			_cmd.Parameters.Clear();
		//			sb.Append("select * from Reports as R ");
		//			sb.Append("inner join Incidents as I on R.IncidentID = I.IncidentID ");
		//			sb.Append("inner join Victims as V on V.IncidentID = I.IncidentID ");
		//			sb.Append("inner join Suspects as S on S.IncidentID = I.IncidentID ");
		//			sb.Append("inner join Evidences as E on E.IncidentID = I.IncidentID ");
		//			sb.Append("inner join LawEnforcementAgencies as L on L.AgencyID = I.AgencyID ");
		//			sb.Append("inner join Officers as O on O.AgencyID = L.AgencyID where R.ReportID = @reportId");
		//			_cmd.CommandText = sb.ToString();
		//			_cmd.Parameters.AddWithValue("@reportId", reportId);
		//			_cmd.Connection = conn;
		//			conn.Open();
		//			using (SqlDataReader reader = _cmd.ExecuteReader())
		//			{
		//				while (reader.Read())
		//				{
		//					CaseReport caseReport = new CaseReport();

		//					Incident incident = new Incident();
		//					Agency agency = new Agency();
		//					Evidence evidence = new Evidence();
		//					Officer officer = new Officer();
		//					Report report = new Report();
		//					Suspect suspect = new Suspect();
		//					Victim victim = new Victim();

		//					report.ReportId = (int)reader["ReportID"];
		//					report.ReportDate = (DateTime)reader["ReportDate"];
		//					report.ReportDetails = (string)reader["ReportDetails"];
		//					report.Status = (string)reader["Status"];

		//					victim.VictimId = (int)reader["VictimID"];
		//					victim.FirstName = (string)reader["FirstName"];
		//					victim.LastName = (string)reader["LastName"];
		//					victim.DateOfBirth = (DateTime)reader["DateOfBirth"];
		//					victim.Gender = (string)reader["Gender"];
		//					victim.PhoneNumber = (long)reader["PhoneNumber"];
		//					victim.Address = (string)reader["Address"];

		//					suspect.SuspectId = (int)reader["SuspectID"];
		//					suspect.FirstName = (string)reader["FirstName"];
		//					suspect.LastName = (string)reader["LastName"];
		//					suspect.DateOfBirth = (DateTime)reader["DateOfBirth"];
		//					suspect.Gender = (string)reader["Gender"];
		//					suspect.PhoneNumber = (long)reader["PhoneNumber"];
		//					suspect.Address = (string)reader["Address"];

		//					evidence.EvidenceId = (int)reader["EvidenceID"];
		//					evidence.Description = (string)reader["Description"];
		//					evidence.LocationFound = (string)reader["LocationFound"];

		//					agency.AgencyId = (int)reader["AgencyID"];
		//					agency.AgencyName = (string)reader["AgencyName"];
		//					agency.Jurisdiction = (string)reader["Jurisdiction"];
		//					agency.PhoneNumber = (long)reader["PhoneNumber"];
		//					agency.Address = (string)reader["Address"];

		//					officer.OfficerId = (int)reader["OfficerID"];
		//					officer.FirstName = (string)reader["FirstName"];
		//					officer.LastName = (string)reader["LastName"];
		//					officer.BadgeNumber = (int)reader["BadgeNumber"];
		//					officer.Rank = (string)reader["Rank"];
		//					officer.PhoneNumber = (long)reader["PhoneNumber"];
		//					officer.Address = (string)reader["Address"];

		//					incident.IncidentId = (int)reader["IncidentID"];
		//					incident.IncidentType = (string)reader["IncidentType"];
		//					incident.IncidentDate = (DateTime)reader["IncidentDate"];
		//					incident.Location = (string)reader["Location"];
		//					incident.Description = (string)reader["Description"];
		//					incident.Status = (string)reader["Status"];
		//					incident.AgencyId = (int)reader["AgencyID"];

		//					caseReport.IncidentDetails = incident;
		//					caseReport.VictimDetails = victim;
		//					caseReport.SuspectDetails = suspect;
		//					caseReport.EvidenceDetails = evidence;
		//					caseReport.AgencyDetails = agency;
		//					caseReport.OfficerDetails = officer;
		//					caseReport.CaseReportDetails = report;

		//					caseReports.Add(caseReport);
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			Console.WriteLine(ex.Message);
		//		}
		//	}
		//	return caseReports;
		//}
	}
}
