using CARS_app.Model;
using CARS_app.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Repository
{
	internal class ReportRepository : IReportRepository
	{
		SqlCommand _cmd = null;
		string connectionString;

		public ReportRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public int AddReport(Report report)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Reports (IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status) values (@incidentId, @reportingOfficer, @reportDate, @reportDetails, @status)";
					_cmd.Parameters.AddWithValue("@incidentId", report.IncidentId);
					_cmd.Parameters.AddWithValue("@reportingOfficer", report.ReportingOfficer);
					_cmd.Parameters.AddWithValue("@reportDate", report.ReportDate);
					_cmd.Parameters.AddWithValue("@reportDetails", report.ReportDetails);
					_cmd.Parameters.AddWithValue("@status", report.Status);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					return _cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
		}

		public int UpdateReport(int reportId, string status)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "update Reports set Status = @status WHERE ReportID = @reportId";
					_cmd.Parameters.AddWithValue("@status", status);
					_cmd.Parameters.AddWithValue("@reportId", reportId);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					return _cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
		}

		public Report GetReportForCase(int reportId)
		{
			Report report = new Report();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "select * from Reports where ReportID = @reportId";
					_cmd.Parameters.AddWithValue("@reportId", reportId);
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							report.ReportId = (int)reader["ReportID"];
							report.IncidentId = (int)reader["IncidentID"];
							report.ReportingOfficer = (int)reader["ReportingOfficer"];
							report.ReportDate = (DateTime)reader["ReportDate"];
							report.ReportDetails = (string)reader["ReportDetails"];
							report.Status = (string)reader["Status"];
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return report;
		}

		public int GetReportById(int reportId)
		{
			int reportFromDB = -1;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "select ReportID from Reports where ReportID = @reportId";
					_cmd.Parameters.AddWithValue("@reportId", reportId);
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							reportFromDB = (int)reader["ReportID"];
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return reportFromDB;
		}

		public List<Report> GetAllReports()
		{
			List<Report> reports = new List<Report>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = "select * from Reports";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Report report = new Report();

							report.ReportId = (int)reader["ReportID"];
							report.IncidentId = (int)reader["IncidentID"];
							report.ReportingOfficer = (int)reader["ReportingOfficer"];
							report.ReportDate = (DateTime)reader["ReportDate"];
							report.ReportDetails = (string)reader["ReportDetails"];
							report.Status = (string)reader["Status"];

							reports.Add(report);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return reports;
		}
	}
}
