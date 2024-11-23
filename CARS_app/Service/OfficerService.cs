using CARS_app.Model;
using CARS_app.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Service
{
	internal class OfficerService: IOfficerService
	{
		readonly IOfficerRepository _officerRepository;
		readonly IAgencyService _agencyService;

		public OfficerService()
		{
			_officerRepository = new OfficerRepository();
			_agencyService = new AgencyService();
		}

		public void GetAllOfficers()
		{
			try
			{
				List<Officer> allOfficers = _officerRepository.GetAllOfficers();
				if (allOfficers.Count == 0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("No officers found");
					Console.ResetColor();
					return;
				}
				Console.ForegroundColor = ConsoleColor.DarkBlue;
				Console.WriteLine("----------------------------------------------------\nListing all officers");
				Console.WriteLine("---------------------\n");
				Console.ResetColor();
				foreach (Officer officer in allOfficers)
				{
					Thread.Sleep(250);
					Console.WriteLine(officer);
				}
				Console.WriteLine("----------------------------------------------------\n");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void GetAllOfficersForMenu()
		{
			try
			{
				List<Officer> allOfficers = _officerRepository.GetAllOfficers();
				if (allOfficers.Count == 0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("No officers found");
					Console.ResetColor();
					return;
				}
				Console.ForegroundColor = ConsoleColor.DarkBlue;
				Console.WriteLine("----------------------------------------------------\nListing all officers");
				Console.WriteLine("---------------------\n");
				Console.ResetColor();
				foreach (Officer officer in allOfficers)
				{
					Thread.Sleep(250);
					Console.WriteLine($"Officer ID {officer.OfficerId}: {officer.FirstName} {officer.LastName}");
				}
				Console.WriteLine("----------------------------------------------------\n");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void AddNewOfficer()
		{
			try
			{
				Officer officer = new Officer();

				Console.WriteLine("\nEnter officer details");

				Console.Write("=> First name: ");
				officer.FirstName = Console.ReadLine();

				Console.Write("=> Last name: ");
				officer.LastName = Console.ReadLine();

				Console.Write("=> Badge number: ");
				officer.BadgeNumber = int.Parse(Console.ReadLine());

				Console.Write("=> Choose rank (Detective/Inspector/Special Agent): ");
				officer.Rank = Console.ReadLine();

				while (true)
				{
					Console.Write("=> Contact number: ");
					officer.PhoneNumber = long.Parse(Console.ReadLine());
					if (officer.PhoneNumber.ToString().Length == 10)
					{
						break;
					}
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Invalid phone number");
					Console.ResetColor();
				}

				Console.Write("=> Address: ");
				officer.Address = Console.ReadLine();

				Console.WriteLine("List of Agencies:");
				_agencyService.GetAgentsIdAndName();

				Console.Write("=> Enter respective Agency's ID: ");
				officer.AgencyId = int.Parse(Console.ReadLine());

				int addOfficerStatus = _officerRepository.AddOfficer(officer);

				if (addOfficerStatus > 0)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("New officer registered successfully\n");
					Console.ResetColor();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Oops! Something went wrong. Please try again!\n");
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
