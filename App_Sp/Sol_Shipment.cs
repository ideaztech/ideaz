using System;

namespace Solum
{
	public class Sol_Shipment
	{
		#region Fields

		private int shipmentID;
		private Guid userID;
		private string userName;
		private string rBillNumber;
		private DateTime date;
		private int agencyID;
		private string agencyName;
		private string agencyAddress1;
		private string agencyAddress2;
		private string agencyCity;
		private string agencyProvince;
		private string agencyCountry;
		private string agencyPostalCode;
		private string status;
		private int carrierID;
		private int plantID;
		private string trailerNumber;
		private string proBillNumber;
		private DateTime shippedDate;
		private string sealNumber;
		private string loadReference;
		private bool eRBillTransmitted;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Shipment class.
		/// </summary>
		public Sol_Shipment()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Shipment class.
		/// </summary>
		public Sol_Shipment(Guid userID, string userName, string rBillNumber, DateTime date, int agencyID, string agencyName, string agencyAddress1, string agencyAddress2, string agencyCity, string agencyProvince, string agencyCountry, string agencyPostalCode, string status, int carrierID, int plantID, string trailerNumber, string proBillNumber, DateTime shippedDate, string sealNumber, string loadReference, bool eRBillTransmitted)
		{
			this.userID = userID;
			this.userName = userName;
			this.rBillNumber = rBillNumber;
			this.date = date;
			this.agencyID = agencyID;
			this.agencyName = agencyName;
			this.agencyAddress1 = agencyAddress1;
			this.agencyAddress2 = agencyAddress2;
			this.agencyCity = agencyCity;
			this.agencyProvince = agencyProvince;
			this.agencyCountry = agencyCountry;
			this.agencyPostalCode = agencyPostalCode;
			this.status = status;
			this.carrierID = carrierID;
			this.plantID = plantID;
			this.trailerNumber = trailerNumber;
			this.proBillNumber = proBillNumber;
			this.shippedDate = shippedDate;
			this.sealNumber = sealNumber;
			this.loadReference = loadReference;
			this.eRBillTransmitted = eRBillTransmitted;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Shipment class.
		/// </summary>
		public Sol_Shipment(int shipmentID, Guid userID, string userName, string rBillNumber, DateTime date, int agencyID, string agencyName, string agencyAddress1, string agencyAddress2, string agencyCity, string agencyProvince, string agencyCountry, string agencyPostalCode, string status, int carrierID, int plantID, string trailerNumber, string proBillNumber, DateTime shippedDate, string sealNumber, string loadReference, bool eRBillTransmitted)
		{
			this.shipmentID = shipmentID;
			this.userID = userID;
			this.userName = userName;
			this.rBillNumber = rBillNumber;
			this.date = date;
			this.agencyID = agencyID;
			this.agencyName = agencyName;
			this.agencyAddress1 = agencyAddress1;
			this.agencyAddress2 = agencyAddress2;
			this.agencyCity = agencyCity;
			this.agencyProvince = agencyProvince;
			this.agencyCountry = agencyCountry;
			this.agencyPostalCode = agencyPostalCode;
			this.status = status;
			this.carrierID = carrierID;
			this.plantID = plantID;
			this.trailerNumber = trailerNumber;
			this.proBillNumber = proBillNumber;
			this.shippedDate = shippedDate;
			this.sealNumber = sealNumber;
			this.loadReference = loadReference;
			this.eRBillTransmitted = eRBillTransmitted;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ShipmentID value.
		/// </summary>
		public virtual int ShipmentID
		{
			get { return shipmentID; }
			set { shipmentID = value; }
		}

		/// <summary>
		/// Gets or sets the UserID value.
		/// </summary>
		public virtual Guid UserID
		{
			get { return userID; }
			set { userID = value; }
		}

		/// <summary>
		/// Gets or sets the UserName value.
		/// </summary>
		public virtual string UserName
		{
			get { return userName; }
			set { userName = value; }
		}

		/// <summary>
		/// Gets or sets the RBillNumber value.
		/// </summary>
		public virtual string RBillNumber
		{
			get { return rBillNumber; }
			set { rBillNumber = value; }
		}

		/// <summary>
		/// Gets or sets the Date value.
		/// </summary>
		public virtual DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		/// <summary>
		/// Gets or sets the AgencyID value.
		/// </summary>
		public virtual int AgencyID
		{
			get { return agencyID; }
			set { agencyID = value; }
		}

		/// <summary>
		/// Gets or sets the AgencyName value.
		/// </summary>
		public virtual string AgencyName
		{
			get { return agencyName; }
			set { agencyName = value; }
		}

		/// <summary>
		/// Gets or sets the AgencyAddress1 value.
		/// </summary>
		public virtual string AgencyAddress1
		{
			get { return agencyAddress1; }
			set { agencyAddress1 = value; }
		}

		/// <summary>
		/// Gets or sets the AgencyAddress2 value.
		/// </summary>
		public virtual string AgencyAddress2
		{
			get { return agencyAddress2; }
			set { agencyAddress2 = value; }
		}

		/// <summary>
		/// Gets or sets the AgencyCity value.
		/// </summary>
		public virtual string AgencyCity
		{
			get { return agencyCity; }
			set { agencyCity = value; }
		}

		/// <summary>
		/// Gets or sets the AgencyProvince value.
		/// </summary>
		public virtual string AgencyProvince
		{
			get { return agencyProvince; }
			set { agencyProvince = value; }
		}

		/// <summary>
		/// Gets or sets the AgencyCountry value.
		/// </summary>
		public virtual string AgencyCountry
		{
			get { return agencyCountry; }
			set { agencyCountry = value; }
		}

		/// <summary>
		/// Gets or sets the AgencyPostalCode value.
		/// </summary>
		public virtual string AgencyPostalCode
		{
			get { return agencyPostalCode; }
			set { agencyPostalCode = value; }
		}

		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public virtual string Status
		{
			get { return status; }
			set { status = value; }
		}

		/// <summary>
		/// Gets or sets the CarrierID value.
		/// </summary>
		public virtual int CarrierID
		{
			get { return carrierID; }
			set { carrierID = value; }
		}

		/// <summary>
		/// Gets or sets the PlantID value.
		/// </summary>
		public virtual int PlantID
		{
			get { return plantID; }
			set { plantID = value; }
		}

		/// <summary>
		/// Gets or sets the TrailerNumber value.
		/// </summary>
		public virtual string TrailerNumber
		{
			get { return trailerNumber; }
			set { trailerNumber = value; }
		}

		/// <summary>
		/// Gets or sets the ProBillNumber value.
		/// </summary>
		public virtual string ProBillNumber
		{
			get { return proBillNumber; }
			set { proBillNumber = value; }
		}

		/// <summary>
		/// Gets or sets the ShippedDate value.
		/// </summary>
		public virtual DateTime ShippedDate
		{
			get { return shippedDate; }
			set { shippedDate = value; }
		}

		/// <summary>
		/// Gets or sets the SealNumber value.
		/// </summary>
		public virtual string SealNumber
		{
			get { return sealNumber; }
			set { sealNumber = value; }
		}

		/// <summary>
		/// Gets or sets the LoadReference value.
		/// </summary>
		public virtual string LoadReference
		{
			get { return loadReference; }
			set { loadReference = value; }
		}

		/// <summary>
		/// Gets or sets the ERBillTransmitted value.
		/// </summary>
		public virtual bool ERBillTransmitted
		{
			get { return eRBillTransmitted; }
			set { eRBillTransmitted = value; }
		}

		#endregion
	}
}
