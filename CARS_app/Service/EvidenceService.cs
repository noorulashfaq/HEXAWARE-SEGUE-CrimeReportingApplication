using CARS_app.Model;
using CARS_app.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Service
{
	internal class EvidenceService : IEvidenceService
	{
		readonly IEvidenceRepository _evidenceRepository;
		readonly IIncidentService _incidentService;

		public EvidenceService()
		{
			_evidenceRepository = new EvidenceRepository();
			_incidentService = new IncidentService();
		}

		//public void GetAllEvidences()
		//{
		//	try
		//	{
		//		List<Evidence> allEvidences = _evidenceRepository.GetAllEvidences();
		//		if (allEvidences.Count == 0)
		//		{
		//			Console.WriteLine("No evidences found");
		//			return;
		//		}
		//		Console.WriteLine("----------------------------------------------------\nListing all evidences");
		//		Console.WriteLine("---------------------\n");
		//		foreach (Evidence evidence in allEvidences)
		//		{
		//			Thread.Sleep(250);
		//			Console.WriteLine(evidence);
		//		}
		//		Console.WriteLine("----------------------------------------------------\n");
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex.Message);
		//	}
		//}

		public void AddNewEvidence()
		{
			try
			{
				Evidence evidence = new Evidence();

				Console.WriteLine("\nEnter particulars of the Evidence");

				Console.WriteLine("List of Incidents:");
				_incidentService.GetIncidentsForMenu();

				Console.Write("=> Select incident ID to add evidence: ");
				evidence.IncidentId = int.Parse(Console.ReadLine());

				Console.Write("=> Evidence description: ");
				evidence.Description = Console.ReadLine();

				Console.Write("=> Location where evidence is found: ");
				evidence.LocationFound = Console.ReadLine();

				int addEvidenceStatus = _evidenceRepository.AddEvidence(evidence);

				if (addEvidenceStatus > 0)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("New evidence added successfully\n");
					Console.ResetColor();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Oops! The evidence could not be added. Please try again!\n");
					Console.ResetColor();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\nRetry!");
			}
		}

		public void GetEvidencesByIncidentId()
		{
			try
			{
				Console.Write("Enter Incident ID: ");
				int incidentId = int.Parse(Console.ReadLine());
				List<Evidence> allEvidences = _evidenceRepository.GetEvidencesByIncidentId(incidentId);
				if (allEvidences.Count == 0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("No evidences found");
					Console.ResetColor();
					return;
				}
				Console.ForegroundColor = ConsoleColor.DarkBlue;
				Console.WriteLine("----------------------------------------------------\nListing all evidences");
				Console.WriteLine("---------------------\n");
				Console.ResetColor();
				foreach (Evidence evidence in allEvidences)
				{
					Thread.Sleep(250);
					Console.WriteLine(evidence);
				}
				Console.WriteLine("----------------------------------------------------\n");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

	}
}
