using CARS_app.Model;
using CARS_app.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Repository
{
	internal class AgencyRepository : IAgencyRepository
	{

		SqlCommand _cmd = null;
		string connectionString;

		public AgencyRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public List<Agency> GetAllAgencies()
		{
			List<Agency> agencies = new List<Agency>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = "select * from LawEnforcementAgencies";
					_cmd.Connection = conn;
					conn.Open();
					SqlDataReader reader = _cmd.ExecuteReader();
					while (reader.Read())
					{
						Agency agency = new Agency();

						agency.AgencyId = (int)reader["AgencyID"];
						agency.AgencyName = (string)reader["AgencyName"];
						agency.Jurisdiction = (string)reader["Jurisdiction"];
						agency.PhoneNumber = (long)(reader["PhoneNumber"]);
						agency.Address = (string)reader["Address"];

						agencies.Add(agency);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return agencies;
		}

		public Dictionary<int, string> GetAgenciesIdAndName()
		{
			Dictionary<int, string> agencies = new Dictionary<int, string>();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.CommandText = "select AgencyID, AgencyName from LawEnforcementAgencies";
					_cmd.Connection = conn;
					conn.Open();
					SqlDataReader reader = _cmd.ExecuteReader();
					while (reader.Read())
					{
						int agencyId = (int)reader["AgencyID"];
						string agencyName = (string)reader["AgencyName"];

						agencies.Add(agencyId, agencyName);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return agencies;
		}

		public int AddAgency(Agency agency)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into LawEnforcementAgencies (AgencyName, Jurisdiction, PhoneNumber, Address) values(@agencyName, @jurisdiction, @phoneNumber, @address)";
					_cmd.Parameters.AddWithValue("@agencyName", agency.AgencyName);
					_cmd.Parameters.AddWithValue("@jurisdiction", agency.Jurisdiction);
					_cmd.Parameters.AddWithValue("@phoneNumber", agency.PhoneNumber);
					_cmd.Parameters.AddWithValue("@address", agency.Address);
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

		public Agency GetAgencyById(int agencyId)
		{
			Agency agency = new Agency();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "select * from LawEnforcementAgencies where AgencyID = @agencyId";
					_cmd.Parameters.AddWithValue("@agencyId", agencyId);
					_cmd.Connection = conn;
					conn.Open();
					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							agency.AgencyId = (int)reader["AgencyID"];
							agency.AgencyName = (string)reader["AgencyName"];
							agency.Jurisdiction = (string)reader["Jurisdiction"];
							agency.PhoneNumber = (long)(reader["PhoneNumber"]);
							agency.Address = (string)reader["Address"];
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return agency;
		}
	}
}
