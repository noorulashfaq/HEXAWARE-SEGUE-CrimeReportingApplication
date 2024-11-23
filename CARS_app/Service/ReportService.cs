using CARS_app.Exceptions;
using CARS_app.Model;
using CARS_app.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Service
{
	internal class ReportService : IReportService
	{
		readonly IReportRepository _reportRepository;
		readonly IIncidentService _incidentService;
		readonly IOfficerService _officerService;

		public ReportService()
		{
			_incidentService = new IncidentService();
			_reportRepository = new ReportRepository();
			_officerService = new OfficerService();
		}
				
		public void AddNewReport()
		{
			try
			{
				Report report = new Report();

				Console.WriteLine("\nEnter details of the report");

				Console.WriteLine("List of Incidents:");
				_incidentService.GetIncidentsForMenu();

				Console.Write("=> Choose Incident ID to associate with the report: ");
				report.IncidentId = int.Parse(Console.ReadLine());

				Console.WriteLine("\nList of Officers:");
				_officerService.GetAllOfficersForMenu();

				Console.Write("=> Reporting Officer ID: ");
				report.ReportingOfficer = int.Parse(Console.ReadLine());

				//Console.Write("=> Date: ");
				//report.ReportDate = DateTime.Parse(Console.ReadLine());
				report.ReportDate = DateTime.Now;

				Console.Write("=> Description: ");
				report.ReportDetails = Console.ReadLine();

				Console.Write("=> Status (Draft/Finalized): ");
				report.Status = Console.ReadLine();

				int addReportStatus = _reportRepository.AddReport(report);

				if (addReportStatus > 0)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("New report submitted successfully\n");
					Console.ResetColor();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Oops! The report could not be submitted. Please try again!\n");
					Console.ResetColor();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\nRetry!");
			}
		}

		public void UpdateReport()
		{
			try
			{
				Console.Write("\n=> Enter Report ID: ");
				int reportId = int.Parse(Console.ReadLine());

				if (_reportRepository.GetReportById(reportId) == -1)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					throw new ReportNumberNotFoundException($"Report with ID {reportId} does not exists!");
				}

				Console.WriteLine("Select the status: Draft - 1, Finalized - 2");
				Console.Write("=> Choose status: ");
				int statusChoice = int.Parse(Console.ReadLine());

				if (statusChoice != 1 && statusChoice != 2)
				{
					Console.WriteLine("Invalid status choice");
					return;
				}

				string status = (statusChoice == 1) ? "Draft" : "Finalized";

				int updateReportStatus = _reportRepository.UpdateReport(reportId, status);

				if (updateReportStatus > 0)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"Status for Report {reportId} is updated to \"{status}\"\n");
					Console.ResetColor();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Oops! The report status could not be updated. Please try again!\n");
					Console.ResetColor();
				}
			}
			catch (ReportNumberNotFoundException rnf)
			{
				Console.WriteLine(rnf.Message + "\nRetry!");
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\nRetry!");
			}
		}

	}
}
