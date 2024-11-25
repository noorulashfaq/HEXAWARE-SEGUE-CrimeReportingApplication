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
	internal class SuspectRepository : ISuspectRepository
	{

		SqlCommand _cmd = null;
		string connectionString;

		public SuspectRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public int AddSuspect(Suspect suspect)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into suspects (IncidentID, FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address) values (@incidentId, @firstName, @lastName, @dateOfBirth, @gender, @phoneNumber, @address)";
					_cmd.Parameters.AddWithValue("@incidentId", suspect.IncidentId);
					_cmd.Parameters.AddWithValue("@firstName", suspect.FirstName);
					_cmd.Parameters.AddWithValue("@lastName", suspect.LastName);
					_cmd.Parameters.AddWithValue("@dateOfBirth", suspect.DateOfBirth);
					_cmd.Parameters.AddWithValue("@gender", suspect.Gender);
					_cmd.Parameters.AddWithValue("@phoneNumber", suspect.PhoneNumber);
					_cmd.Parameters.AddWithValue("@address", suspect.Address);
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

		public List<Suspect> GetSuspectsByIncidentId(int incidentId)
		{
			List<Suspect> suspects = new List<Suspect>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = $"select * from Suspects where IncidentID = {incidentId}";
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Suspect suspect = new Suspect();

							suspect.SuspectId = (int)reader["SuspectID"];
							suspect.FirstName = (string)reader["FirstName"];
							suspect.LastName = (string)reader["LastName"];
							suspect.DateOfBirth = (DateTime)reader["DateOfBirth"];
							suspect.Gender = (string)reader["Gender"];
							suspect.PhoneNumber = (long)reader["PhoneNumber"];
							suspect.Address = (string)reader["Address"];

							suspects.Add(suspect);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return suspects;
		}
	}
}
