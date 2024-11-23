using CARS_app.Model;
using CARS_app.Utility;
using System.Data.SqlClient;

namespace CARS_app.Repository
{
	public class IncidentRepository:IIncidentRepository
	{
		SqlCommand _cmd = null;
		string connectionString;

		public IncidentRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public List<Incident> GetAllIncidents()
		{
			List<Incident> incidents = new List<Incident>();
			using(SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = "select * from Incidents";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Incident incident = new Incident();

							incident.IncidentId = (int)reader["IncidentID"];
							incident.IncidentType = (string)reader["IncidentType"];
							incident.IncidentDate = (DateTime)reader["IncidentDate"];
							incident.Location = (string)reader["Location"];
							incident.Description = (string)reader["Description"];
							incident.Status = (string)reader["Status"];
							incident.AgencyId = (int)reader["AgencyID"];

							incidents.Add(incident);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return incidents;
		}

		public int AddIncident(Incident incident)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Incidents (IncidentType, IncidentDate, Location, Description, AgencyID) OUTPUT INSERTED.IncidentID values(@incidentType, @incidentDate, @location, @description, @agencyId)";
					_cmd.Parameters.AddWithValue("@incidentType", incident.IncidentType);
					_cmd.Parameters.AddWithValue("@incidentDate", incident.IncidentDate);
					_cmd.Parameters.AddWithValue("@location", incident.Location);
					_cmd.Parameters.AddWithValue("@description", incident.Description);
					_cmd.Parameters.AddWithValue("@agencyId", incident.AgencyId);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					return (int)_cmd.ExecuteScalar();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
		}

		public int UpdateIncidentStatus(int incidentId, string status)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "update Incidents set Status = @status where IncidentID = @incidentId";
					_cmd.Parameters.AddWithValue("@incidentId", incidentId);
					_cmd.Parameters.AddWithValue("@status", status);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					return _cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				//Console.WriteLine(ex.Message);
				return 0;
			}
		}

		public int GetIncidentById(int incidentId)
		{
			int incidentIdFromDB = -1;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "select IncidentID from Incidents where IncidentId = @incidentId";
					_cmd.Parameters.AddWithValue("@incidentId", incidentId);
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							incidentIdFromDB = (int)reader["IncidentID"];
						}
					}
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return incidentIdFromDB;
		}

		public Incident GetIncidentForCaseReport(int incidentId)
		{
			Incident incidentFetched = new Incident();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "select * from Incidents where IncidentId = @incidentId";
					_cmd.Parameters.AddWithValue("@incidentId", incidentId);
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							incidentFetched.IncidentId = (int)reader["IncidentID"];
							incidentFetched.IncidentType = (string)reader["IncidentType"];
							incidentFetched.IncidentDate = (DateTime)reader["IncidentDate"];
							incidentFetched.Location = (string)reader["Location"];
							incidentFetched.Description = (string)reader["Description"];
							incidentFetched.Status = (string)reader["Status"];
							incidentFetched.AgencyId = (int)reader["AgencyID"];
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return incidentFetched;
		}

		public List<Incident> GetIncidentInDateRange(DateTime startDate, DateTime endDate)
		{
			List<Incident> incidents = new List<Incident>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = $"select * from Incidents where IncidentDate between '{startDate}' and '{endDate}'";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Incident incident = new Incident();

							incident.IncidentId = (int)reader["IncidentID"];
							incident.IncidentType = (string)reader["IncidentType"];
							incident.IncidentDate = (DateTime)reader["IncidentDate"];
							incident.Location = (string)reader["Location"];
							incident.Description = (string)reader["Description"];
							incident.Status = (string)reader["Status"];
							incident.AgencyId = (int)reader["AgencyID"];

							incidents.Add(incident);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return incidents;
		}

		public List<Incident> GetIncidentsByType(string incidentType)
		{
			List<Incident> incidents = new List<Incident>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = $"select * from Incidents where IncidentType = '{incidentType}'";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Incident incident = new Incident();

							incident.IncidentId = (int)reader["IncidentID"];
							incident.IncidentType = (string)reader["IncidentType"];
							incident.IncidentDate = (DateTime)reader["IncidentDate"];
							incident.Location = (string)reader["Location"];
							incident.Description = (string)reader["Description"];
							incident.Status = (string)reader["Status"];
							incident.AgencyId = (int)reader["AgencyID"];

							incidents.Add(incident);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return incidents;
		}

	}
}
