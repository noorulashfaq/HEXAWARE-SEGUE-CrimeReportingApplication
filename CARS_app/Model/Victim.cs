using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CARS_app.Model
{
	internal class Victim
	{
		int _victimId, _incidentId;
		string _firstName, _lastName, _gender, _address;
		DateTime _dateOfBirth;
		long _phoneNumber;

		public int VictimId
		{
			get { return _victimId; }
			set { _victimId = value; }
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

		public DateTime DateOfBirth
		{
			get { return _dateOfBirth; }
			set { _dateOfBirth = value; }
		}

		public string Gender
		{
			get { return _gender; }
			set { _gender = value; }
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

		public int IncidentId
		{
			get { return _incidentId; }
			set { _incidentId = value; }
		}

		public override string ToString()
		{
			return $"Victim ID: {VictimId}\n" +
				$"Victim name: {FirstName} {LastName} ({Gender})\n" +
				$"Date of Birth: {DateOfBirth:dd-MMM-yyyy}\n" +
				$"Contact: {PhoneNumber}\n" +
				$"Address: {Address}\n";
		}

	}
}
