using System;

namespace Solum
{
    public class Qds_Bag
    {
        #region Fields

        private int bagID;
        private int dropID;
        private int bagEstimateUnderLitre;
        private int bagEstimateOverLitre;
        private DateTime dateEntered;
        private DateTime dateAccepted;
        private DateTime dateCounted;
        private DateTime datePaid;
        private string depotID;
        private DateTime datePrinted;
        //private bool isNew;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Qds_Bag class.
        /// </summary>
        public Qds_Bag()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Qds_Bag class.
        /// </summary>
        public Qds_Bag(int dropID, int bagEstimateUnderLitre, int bagEstimateOverLitre, DateTime dateEntered, DateTime dateAccepted, DateTime dateCounted, DateTime datePaid, string depotID, DateTime datePrinted) //, bool isNew)
        {
            this.dropID = dropID;
            this.bagEstimateUnderLitre = bagEstimateUnderLitre;
            this.bagEstimateOverLitre = bagEstimateOverLitre;
            this.dateEntered = dateEntered;
            this.dateAccepted = dateAccepted;
            this.dateCounted = dateCounted;
            this.datePaid = datePaid;
            this.depotID = depotID;
            this.datePrinted = datePrinted;
            //this.isNew = isNew;
        }

        /// <summary>
        /// Initializes a new instance of the Qds_Bag class.
        /// </summary>
        public Qds_Bag(int bagID, int dropID, int bagEstimateUnderLitre, int bagEstimateOverLitre, DateTime dateEntered, DateTime dateAccepted, DateTime dateCounted, DateTime datePaid, string depotID, DateTime datePrinted)  //, bool isNew)
        {
            this.bagID = bagID;
            this.dropID = dropID;
            this.bagEstimateUnderLitre = bagEstimateUnderLitre;
            this.bagEstimateOverLitre = bagEstimateOverLitre;
            this.dateEntered = dateEntered;
            this.dateAccepted = dateAccepted;
            this.dateCounted = dateCounted;
            this.datePaid = datePaid;
            this.depotID = depotID;
            this.datePrinted = datePrinted;
            //this.isNew = isNew;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the BagID value.
        /// </summary>
        public virtual int BagID
        {
            get { return bagID; }
            set { bagID = value; }
        }

        /// <summary>
        /// Gets or sets the DropID value.
        /// </summary>
        public virtual int DropID
        {
            get { return dropID; }
            set { dropID = value; }
        }

        /// <summary>
        /// Gets or sets the BagEstimateUnderLitre value.
        /// </summary>
        public virtual int BagEstimateUnderLitre
        {
            get { return bagEstimateUnderLitre; }
            set { bagEstimateUnderLitre = value; }
        }

        /// <summary>
        /// Gets or sets the BagEstimateOverLitre value.
        /// </summary>
        public virtual int BagEstimateOverLitre
        {
            get { return bagEstimateOverLitre; }
            set { bagEstimateOverLitre = value; }
        }

        /// <summary>
        /// Gets or sets the DateEntered value.
        /// </summary>
        public virtual DateTime DateEntered
        {
            get { return dateEntered; }
            set { dateEntered = value; }
        }

        /// <summary>
        /// Gets or sets the DateAccepted value.
        /// </summary>
        public virtual DateTime DateAccepted
        {
            get { return dateAccepted; }
            set { dateAccepted = value; }
        }

        /// <summary>
        /// Gets or sets the DateCounted value.
        /// </summary>
        public virtual DateTime DateCounted
        {
            get { return dateCounted; }
            set { dateCounted = value; }
        }

        /// <summary>
        /// Gets or sets the DatePaid value.
        /// </summary>
        public virtual DateTime DatePaid
        {
            get { return datePaid; }
            set { datePaid = value; }
        }

        /// <summary>
        /// Gets or sets the DepotID value.
        /// </summary>
        public virtual string DepotID
        {
            get { return depotID; }
            set { depotID = value; }
        }

        /// <summary>
        /// Gets or sets the DatePrinted value.
        /// </summary>
        public virtual DateTime DatePrinted
        {
            get { return datePrinted; }
            set { datePrinted = value; }
        }

        /// <summary>
        /// Gets or sets the IsNew value.
        /// </summary>
        //public virtual bool IsNew
        //{
        //    get { return isNew; }
        //    set { isNew = value; }
        //}

        #endregion
    }
}
