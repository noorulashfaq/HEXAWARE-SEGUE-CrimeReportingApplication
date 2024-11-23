using CARS_app.Model;
using CARS_app.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Service
{
	internal class AgencyService : IAgencyService
	{
		readonly IAgencyRepository _agencyRepository;

		public AgencyService()
		{
			_agencyRepository = new AgencyRepository();
		}

		public void GetAllAgents()
		{
			List<Agency> allAgencies = _agencyRepository.GetAllAgencies();
			if(allAgencies.Count == 0)
			{
				Console.WriteLine("No agencies found");
				return;
			}
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("----------------------------------------------------\nListing all agencies");
			Console.WriteLine("---------------------\n");
			Console.ResetColor();
			foreach (Agency agency in allAgencies)
			{
				Thread.Sleep(250);
				Console.WriteLine(agency);
			}
			Console.WriteLine("----------------------------------------------------\n");
		}

		public void GetAgentsIdAndName()
		{
			Dictionary<int, string> allAgencies = _agencyRepository.GetAgenciesIdAndName();
			if (allAgencies.Count == 0)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("No agencies found");
				Console.ResetColor();
				return;
			}
			foreach (KeyValuePair<int, string> agency in allAgencies)
			{
				Console.WriteLine($"\t{agency.Key}.{agency.Value}");
			}
		}

		public void AddNewAgency()
		{
			try
			{
				Agency agency = new Agency();

				Console.WriteLine("\nEnter details of the Agency");

				Console.Write("=> Name of the agency: ");
				agency.AgencyName = Console.ReadLine();

				Console.Write("=> Jurisdiction: ");
				agency.Jurisdiction = Console.ReadLine();

				while (true)
				{
					Console.Write("=> Contact number: ");
					agency.PhoneNumber = long.Parse(Console.ReadLine());
					if(agency.PhoneNumber.ToString().Length == 10)
					{
						break;
					}
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Invalid phone number");
					Console.ResetColor();
				}

				Console.Write("=> Address: ");
				agency.Address = Console.ReadLine();

				int addAgencyStatus = _agencyRepository.AddAgency(agency);

				if (addAgencyStatus > 0)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("New agency registered successfully\n");
					Console.ResetColor();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Oops! The agency could not be registered. Please try again!\n");
					Console.ResetColor();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\nRetry!");
			}
		}
	}
}
