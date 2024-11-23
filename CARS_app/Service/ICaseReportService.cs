using CARS_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Service
{
	internal interface ICaseReportService
	{
		void GetAllCaseReports();
		void GetCaseReportById();
	}
}
