using CARS_app.Exceptions;
using CARS_app.Model;
using CARS_app.Repository;
using CARS_app.Utility;

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

				Console.Write("=> Email: ");
				officer.Email = Console.ReadLine();

				while (true)
				{
					Console.WriteLine("Password must be\n\t- at least 8 characters long\n\t- include an uppercase letter\n\t- a lowercase letter\n\t- a digit\n\t- and a special character.");

					Console.Write("=> Create a password: ");
					officer.Password = Console.ReadLine();

					if (!PasswordChecker.isValid(officer.Password))
					{
						Console.WriteLine("Invalid password. Ensure it meets the requirements.");
						continue;
					}

					Console.Write("=> Confirm password: ");
					string verifyPassword = Console.ReadLine();

					if (officer.Password.Equals(verifyPassword))
					{
						Console.WriteLine("Password successfully set!");
						break;
					}
					else
					{
						Console.WriteLine("Password doesn't match! Please try again.");
					}
				}

				Console.Write("=> Badge number: ");
				officer.BadgeNumber = int.Parse(Console.ReadLine());

				Console.Write("=> Choose rank (1.Detective / 2.Inspector / 3.Special Agent): ");
				int rankChoice = int.Parse(Console.ReadLine());

				officer.Rank = (rankChoice == 1) ? "Detective" : (rankChoice == 2) ? "Inspector" : "Special Agent";

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

				Console.Write("=> Choose rank (1.Admin / 2.Officer): ");
				int roleChoice = int.Parse(Console.ReadLine());

				officer.Role = (roleChoice == 1) ? "Admin" : "Officer";

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

		public int OfficerLogin(string role)
		{
			Console.WriteLine($"\n-------------{role} login-------------");

			Console.Write("Email: ");
			string email = Console.ReadLine();

			Console.Write("Password: ");
			string password = Console.ReadLine();

			int resultId = -1;
			try
			{
				resultId = _officerRepository.OfficerLogin(email, password, role);
				if(resultId <= 0)
				{
					throw new OfficerNotFoundException("Invalid login credentials!");
				}
			}
			catch(OfficerNotFoundException onf)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(onf.Message);
				Console.ResetColor();
			}
			return resultId;
		}
	}
}
