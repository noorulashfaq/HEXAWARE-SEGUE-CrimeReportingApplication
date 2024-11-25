namespace CARS_app.Exceptions
{
	internal class IncidentNumberNotFoundException: ApplicationException
	{
		public IncidentNumberNotFoundException()
		{

		}

		public IncidentNumberNotFoundException(string message) : base(message)
		{

		}
	}
}
