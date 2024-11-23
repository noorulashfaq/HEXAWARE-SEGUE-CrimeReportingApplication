using CARS_app.Model;
using CARS_app.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Repository
{
	internal class VictimRepository : IVictimRepository
	{

		SqlCommand _cmd = null;
		string connectionString;

		public VictimRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public int AddVictim(Victim victim)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Victims (IncidentID, FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address) values (@incidentId, @firstName, @lastName, @dateOfBirth, @gender, @phoneNumber, @address)";
					_cmd.Parameters.AddWithValue("@incidentId", victim.IncidentId);
					_cmd.Parameters.AddWithValue("@firstName", victim.FirstName);
					_cmd.Parameters.AddWithValue("@lastName", victim.LastName);
					_cmd.Parameters.AddWithValue("@dateOfBirth", victim.DateOfBirth);
					_cmd.Parameters.AddWithValue("@gender", victim.Gender);
					_cmd.Parameters.AddWithValue("@phoneNumber", victim.PhoneNumber);
					_cmd.Parameters.AddWithValue("@address", victim.Address);
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

		public List<Victim> GetVictimsByIncidentId(int incidentId)
		{
			List<Victim> victims = new List<Victim>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = $"select * from Victims where IncidentID = {incidentId}";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Victim victim = new Victim();

							victim.VictimId = (int)reader["VictimID"];
							victim.FirstName = (string)reader["FirstName"];
							victim.LastName = (string)reader["LastName"];
							victim.DateOfBirth = (DateTime)reader["DateOfBirth"];
							victim.Gender = (string)reader["Gender"];
							victim.PhoneNumber = (long)reader["PhoneNumber"];
							victim.Address = (string)reader["Address"];

							victims.Add(victim);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return victims;
		}

		//public List<Victim> GetAllVictims()
		//{
		//	List<Victim> victims = new List<Victim>();
		//	using (SqlConnection conn = new SqlConnection(connectionString))
		//	{
		//		try
		//		{
		//			_cmd.CommandText = "select * from Victims";
		//			_cmd.Connection = conn;
		//			conn.Open();
		//			SqlDataReader reader = _cmd.ExecuteReader();
		//			while (reader.Read())
		//			{
		//				Victim victim = new Victim();

		//				victim.VictimId = (int)reader["VictimID"];
		//				victim.FirstName = (string)reader["FirstName"];
		//				victim.LastName = (string)reader["LastName"];
		//				victim.DateOfBirth = (DateTime)reader["DateOfBirth"];
		//				victim.Gender = (string)reader["Gender"];
		//				victim.PhoneNumber = (long)reader["PhoneNumber"];
		//				victim.Address = (string)reader["Address"];
		//				victim.IncidentId = (int)reader["IncidentId"];

		//				victims.Add(victim);
		//			}
		//		}
		//		catch(Exception ex)
		//		{
		//			Console.WriteLine(ex.Message);
		//		}
		//	}
		//	return victims;
		//}
	}
}
