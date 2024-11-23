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
	internal class EvidenceRepository : IEvidenceRepository
	{
		SqlCommand _cmd = null;
		string connectionString;

		public EvidenceRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		//public List<Evidence> GetAllEvidences()
		//{
		//	List<Evidence> evidences = new List<Evidence>();
		//	using (SqlConnection conn = new SqlConnection(connectionString))
		//	{
		//		try
		//		{
		//			_cmd.CommandText = "select * from Evidences";
		//			_cmd.Connection = conn;
		//			conn.Open();
		//			using (SqlDataReader reader = _cmd.ExecuteReader())
		//			{
		//				while (reader.Read())
		//				{
		//					Evidence evidence = new Evidence();

		//					evidence.EvidenceId = (int)reader["EvidenceID"];
		//					evidence.IncidentId = (int)reader["IncidentID"];
		//					evidence.Description = (string)reader["Description"];
		//					evidence.LocationFound = (string)reader["LocationFound"];

		//					evidences.Add(evidence);
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			Console.WriteLine(ex.Message);
		//		}
		//	}
		//	return evidences;
		//}

		public int AddEvidence(Evidence evidence)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Evidences (Description, LocationFound, IncidentID) values (@description, @locationFound, @incidentId)";
					_cmd.Parameters.AddWithValue("@description", evidence.Description);
					_cmd.Parameters.AddWithValue("@locationFound", evidence.LocationFound);
					_cmd.Parameters.AddWithValue("@incidentId", evidence.IncidentId);
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

		public List<Evidence> GetEvidencesByIncidentId(int incidentId)
		{
			List<Evidence> evidences = new List<Evidence>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = $"select * from Evidences where IncidentID = {incidentId}";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Evidence evidence = new Evidence();

							evidence.EvidenceId = (int)reader["EvidenceID"];
							evidence.IncidentId = (int)reader["IncidentID"];
							evidence.Description = (string)reader["Description"];
							evidence.LocationFound = (string)reader["LocationFound"];

							evidences.Add(evidence);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return evidences;
		}

		//public int UpdateEvidence(int evidenceId, int incidentId)
		//{
		//	try
		//	{
		//		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		//		{
		//			_cmd.Parameters.Clear();
		//			_cmd.CommandText = $"update Evidences set IncidentID = {incidentId} where EvidenceID = {evidenceId})";
		//			_cmd.Connection = sqlConnection;
		//			sqlConnection.Open();
		//			return _cmd.ExecuteNonQuery();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex.Message);
		//		return 0;
		//	}
		//}
	}
}
