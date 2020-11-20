using System;

namespace Solum
{
	public class Sol_Employee
	{
		#region Fields

		private Guid userId;
		private string firstName;
		private string lastName;
		private string middleName;
		private DateTime birthDate;
		private DateTime hireDate;
		private string employeeNotes;
		private string sIN;
		private byte gender;
		private string employeeNumber;
		private string payrollNumber;
		private decimal compensationAmount;
		private byte compensationType;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Employee class.
		/// </summary>
		public Sol_Employee()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Employee class.
		/// </summary>
		public Sol_Employee(Guid userId, string firstName, string lastName, string middleName, DateTime birthDate, DateTime hireDate, string employeeNotes, string sIN, byte gender, string employeeNumber, string payrollNumber, decimal compensationAmount, byte compensationType)
		{
			this.userId = userId;
			this.firstName = firstName;
			this.lastName = lastName;
			this.middleName = middleName;
			this.birthDate = birthDate;
			this.hireDate = hireDate;
			this.employeeNotes = employeeNotes;
			this.sIN = sIN;
			this.gender = gender;
			this.employeeNumber = employeeNumber;
			this.payrollNumber = payrollNumber;
			this.compensationAmount = compensationAmount;
			this.compensationType = compensationType;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the UserId value.
		/// </summary>
		public virtual Guid UserId
		{
			get { return userId; }
			set { userId = value; }
		}

		/// <summary>
		/// Gets or sets the FirstName value.
		/// </summary>
		public virtual string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		/// <summary>
		/// Gets or sets the LastName value.
		/// </summary>
		public virtual string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		/// <summary>
		/// Gets or sets the MiddleName value.
		/// </summary>
		public virtual string MiddleName
		{
			get { return middleName; }
			set { middleName = value; }
		}

		/// <summary>
		/// Gets or sets the BirthDate value.
		/// </summary>
		public virtual DateTime BirthDate
		{
			get { return birthDate; }
			set { birthDate = value; }
		}

		/// <summary>
		/// Gets or sets the HireDate value.
		/// </summary>
		public virtual DateTime HireDate
		{
			get { return hireDate; }
			set { hireDate = value; }
		}

		/// <summary>
		/// Gets or sets the EmployeeNotes value.
		/// </summary>
		public virtual string EmployeeNotes
		{
			get { return employeeNotes; }
			set { employeeNotes = value; }
		}

		/// <summary>
		/// Gets or sets the SIN value.
		/// </summary>
		public virtual string SIN
		{
			get { return sIN; }
			set { sIN = value; }
		}

		/// <summary>
		/// Gets or sets the Gender value.
		/// </summary>
		public virtual byte Gender
		{
			get { return gender; }
			set { gender = value; }
		}

		/// <summary>
		/// Gets or sets the EmployeeNumber value.
		/// </summary>
		public virtual string EmployeeNumber
		{
			get { return employeeNumber; }
			set { employeeNumber = value; }
		}

		/// <summary>
		/// Gets or sets the PayrollNumber value.
		/// </summary>
		public virtual string PayrollNumber
		{
			get { return payrollNumber; }
			set { payrollNumber = value; }
		}

		/// <summary>
		/// Gets or sets the CompensationAmount value.
		/// </summary>
		public virtual decimal CompensationAmount
		{
			get { return compensationAmount; }
			set { compensationAmount = value; }
		}

		/// <summary>
		/// Gets or sets the CompensationType value.
		/// </summary>
		public virtual byte CompensationType
		{
			get { return compensationType; }
			set { compensationType = value; }
		}

		#endregion
	}
}
