using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Model
{
	internal class Officer
	{
		int _officerId, _badgeNumber, _agencyId;
		string _firstName, _lastName, _rank, _address;
		long _phoneNumber;

		public int OfficerId
		{
			get { return _officerId; }
			set { _officerId = value; }
		}

		public int BadgeNumber
		{
			get { return _badgeNumber; }
			set { _badgeNumber = value; }
		}

		public int AgencyId
		{
			get { return _agencyId; }
			set { _agencyId = value; }
		}

		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}

		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		public string Rank
		{
			get { return _rank; }
			set { _rank = value; }
		}

		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public long PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}

		public override string ToString()
		{
			return $"Officer ID: {OfficerId}\n" +
				$"Officer name: {FirstName} {LastName}\n" +
				$"Badge number & Rank: {BadgeNumber} - {Rank}\n" +
				$"Contact number: {PhoneNumber}\n" +
				$"Address: {Address}\n" +
				$"Agency ID: {AgencyId}";
		}

	}
}
