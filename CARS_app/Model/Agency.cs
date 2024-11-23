using System.Numerics;

namespace CARS_app.Model
{
	internal class Agency
	{
		private int _agencyId;
		private string _agencyName, _jurisdiction, _address;
		private long _phoneNumber;

		public int AgencyId
		{
			get { return _agencyId; }
			set { _agencyId = value; }
		}

		public string AgencyName
		{
			get { return _agencyName; }
			set { _agencyName = value; }
		}

		public string Jurisdiction
		{
			get { return _jurisdiction; }
			set { _jurisdiction = value; }
		}

		public long PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}

		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public override string ToString()
		{
			return $"Agency ID: {AgencyId}\n" +
				$"Agency name: {AgencyName}\n" +
				$"Jurisdiction: {Jurisdiction}\n" +
				$"Contact number: {PhoneNumber}\n" +
				$"Address: {Address}\n";
		}

	}
}
