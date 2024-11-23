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
	internal class OfficerRepository : IOfficerRepository
	{
		SqlCommand _cmd = null;
		string connectionString;

		public OfficerRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public List<Officer> GetAllOfficers()
		{
			List<Officer> officers = new List<Officer>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = "select * from Officers";
					_cmd.Connection = conn;
					conn.Open();
					SqlDataReader reader = _cmd.ExecuteReader();
					while (reader.Read())
					{
						Officer officer = new Officer();

						officer.OfficerId = (int)reader["OfficerID"];
						officer.FirstName = (string)reader["FirstName"];
						officer.LastName = (string)reader["LastName"];
						officer.BadgeNumber = (int)(reader["BadgeNumber"]);
						officer.Rank = (string)reader["Rank"];
						officer.PhoneNumber = (long)reader["PhoneNumber"];
						officer.Address = (string)reader["Address"];
						officer.AgencyId = (int)reader["AgencyID"];

						officers.Add(officer);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return officers;
		}

		public int AddOfficer(Officer officer)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Officers (FirstName, LastName, BadgeNumber, Rank, PhoneNumber, Address, AgencyID) values (@firstName, @lastName, @badgeNumber, @rank, @phoneNumber, @address, @agencyId)";
					_cmd.Parameters.AddWithValue("@firstName", officer.FirstName);
					_cmd.Parameters.AddWithValue("@lastName", officer.LastName);
					_cmd.Parameters.AddWithValue("@badgeNumber", officer.BadgeNumber);
					_cmd.Parameters.AddWithValue("@rank", officer.Rank);
					_cmd.Parameters.AddWithValue("@phoneNumber", officer.PhoneNumber);
					_cmd.Parameters.AddWithValue("@address", officer.Address);
					_cmd.Parameters.AddWithValue("@agencyId", officer.AgencyId);
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

		public Officer GetOfficerById(int officerId)
		{
			Officer officer = new Officer();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "select * from Officers where OfficerID = @officerId";
					_cmd.Parameters.AddWithValue("@officerId", officerId);
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							officer.OfficerId = (int)reader["OfficerID"];
							officer.FirstName = (string)reader["FirstName"];
							officer.LastName = (string)reader["LastName"];
							officer.BadgeNumber = (int)(reader["BadgeNumber"]);
							officer.Rank = (string)reader["Rank"];
							officer.PhoneNumber = (long)reader["PhoneNumber"];
							officer.Address = (string)reader["Address"];
							officer.AgencyId = (int)reader["AgencyID"];
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return officer;
		}
	}
}
