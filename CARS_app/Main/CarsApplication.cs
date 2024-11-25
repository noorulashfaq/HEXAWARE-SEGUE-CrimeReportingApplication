using CARS_app.Service;
using System.ComponentModel.Design;

namespace CARS_app.Main
{
	internal class CarsApplication
	{
		public static int activeUserId = -1;
		public void Run()
		{
			string title = "------Crime Reporting and Analysis System------\n";
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			foreach (char c in title)
			{
				Thread.Sleep(25);
				Console.Write(c);
			}
			Console.ResetColor();
			int loginChoice = 0;
			do
			{
				IOfficerService officerService = new OfficerService();
				Console.WriteLine("\nChoose login type:\n\t1.Admin\n\t2.Officer\n\t3.Exit");
				Console.Write("Enter option: ");
				loginChoice = int.Parse(Console.ReadLine());
				switch (loginChoice)
				{
					case 1:
						activeUserId = officerService.OfficerLogin("Admin");

						if (activeUserId <= 0)
						{
							activeUserId = -1;
						}
						else
						{
							int adminMenuChoice = 0;
							IAgencyService agencyService = new AgencyService();
							do
							{
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Welcome Admin!");
								Console.ResetColor();
								Console.Write("\nMain menu:\n" +
									"\t1. Get all agencies\n" +
									"\t2. Add new agency\n" +
									"\t3. Get all officers\n" +
									"\t4. Add new officer\n" +
									"\t5. Logout\n" +
									"Enter your choice: ");
								adminMenuChoice = int.Parse(Console.ReadLine());

								switch (adminMenuChoice)
								{
									case 1:
										agencyService.GetAllAgents();
										break;

									case 2:
										agencyService.AddNewAgency();
										break;

									case 3:
										officerService.GetAllOfficers();
										break;

									case 4:
										officerService.AddNewOfficer();
										break;

									case 5:
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("Logging out...");
										Console.ResetColor();
										break;

									default:
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("Invalid choice!");
										Console.ResetColor();
										break;
								}

							} while (adminMenuChoice != 5);
						}
						break;

					case 2:
						activeUserId = officerService.OfficerLogin("Officer");

						if (activeUserId <= 0)
						{
							activeUserId = -1;
						}
						else
						{
							int officerMenuChoice = 0;
							IIncidentService incidentService = new IncidentService();
							IEvidenceService evidenceService = new EvidenceService();
							IVictimService victimService = new VictimService();
							ISuspectService suspectService = new SuspectService();
							IReportService reportService = new ReportService();
							ICaseReportService caseReportService = new CaseReportService();
							do
							{
								try
								{
									Console.ForegroundColor = ConsoleColor.Green;
									Console.WriteLine("Welcome Officer!");
									Console.ResetColor();
									Console.Write("\nMain menu:\n" +
										"\t------- Incidents -------\n" +
										"\t1. Get all incidents\n" +
										"\t2. Register new incident\n" +
										"\t3. Update incident status\n" +
										"\t4. Get incident in date range\n" +
										"\t5. Filter incidents by type\n" +
										"\n\t------- Cases -------\n" +
										"\t6. Report a new case\n" +
										"\t7. Get specific case details\n" +
										"\t8. Update case details\n" +
										"\t9. Get all case reports\n" +
										"\n\t------- Others -------\n" +
										"\t10. Add a new evidence\n" +
										"\t11. Add a new victim\n" +
										"\t12. Add a new suspect\n" +
										"\t13. Logout\n" +
										"\nEnter your choice: ");
									officerMenuChoice = int.Parse(Console.ReadLine());

									switch (officerMenuChoice)
									{
										case 1:
											incidentService.GetAllIncidents();
											break;

										case 2:
											incidentService.AddNewIncident();
											break;

										case 3:
											incidentService.UpdateIncidentStatus();
											break;

										case 4:
											incidentService.GetIncidentInDateRange();
											break;

										case 5:
											incidentService.GetIncidentByType();
											break;

										case 6:
											reportService.AddNewReport();
											break;

										case 7:
											caseReportService.GetCaseReportById();
											break;

										case 8:
											reportService.UpdateReport();
											break;

										case 9:
											caseReportService.GetAllCaseReports();
											break;

										case 10:
											evidenceService.AddNewEvidence();
											break;

										case 11:
											victimService.AddNewVictim();
											break;

										case 12:
											suspectService.AddNewSuspect();
											break;

										case 13:
											Console.ForegroundColor = ConsoleColor.Red;
											Console.WriteLine("Logging out...");
											Console.ResetColor();
											break;

										default:
											Console.ForegroundColor = ConsoleColor.Red;
											Console.WriteLine("Invalid choice!");
											Console.ResetColor();
											break;
									}
									Console.WriteLine();
								}
								catch (FormatException fe)
								{
									Console.WriteLine(fe.Message);
								}
							} while (officerMenuChoice != 13);
						}
						break;

					case 3:
						Console.Write("Do you wish to exit the application (Y/N)? ");
						string exitStatus = Console.ReadLine()?.Trim().ToLower();
						if (exitStatus == "y" || exitStatus == "yes")
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Exiting the application. See you again (*0_0*)");
							Console.ResetColor();
						}
						else
						{
							loginChoice = 0;
						}
						break;

					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Invalid option");
						Console.ResetColor();
						break;
				}
			} while (loginChoice != 3);
		}
	}
}
