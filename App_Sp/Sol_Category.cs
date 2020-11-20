using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solum
{
    public class Sol_Category
    {
        #region Fields

        private int categoryID;
        private string description;
        private decimal refundAmount;
        private int subContainerQuantity;
        private int stagingMethodID;
        private int stagingProductID;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Sol_Category class.
        /// </summary>
        public Sol_Category()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Sol_Category class.
        /// </summary>
        public Sol_Category(string description, decimal refundAmount, int subContainerQuantity, int stagingMethodID, int stagingProductID)
        {
            this.description = description;
            this.refundAmount = refundAmount;
            this.subContainerQuantity = subContainerQuantity;
            this.stagingMethodID = stagingMethodID;
            this.stagingProductID = stagingProductID;
        }

        /// <summary>
        /// Initializes a new instance of the Sol_Category class.
        /// </summary>
        public Sol_Category(int categoryID, string description, decimal refundAmount, int subContainerQuantity, int stagingMethodID, int stagingProductID)
        {
            this.categoryID = categoryID;
            this.description = description;
            this.refundAmount = refundAmount;
            this.subContainerQuantity = subContainerQuantity;
            this.stagingMethodID = stagingMethodID;
            this.stagingProductID = stagingProductID;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the CategoryID value.
        /// </summary>
        public virtual int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Gets or sets the RefundAmount value.
        /// </summary>
        public virtual decimal RefundAmount
        {
            get { return refundAmount; }
            set { refundAmount = value; }
        }

        /// <summary>
        /// Gets or sets the SubContainerQuantity value.
        /// </summary>
        public virtual int SubContainerQuantity
        {
            get { return subContainerQuantity; }
            set { subContainerQuantity = value; }
        }

        /// <summary>
        /// Gets or sets the StagingMethodID value.
        /// </summary>
        public virtual int StagingMethodID
        {
            get { return stagingMethodID; }
            set { stagingMethodID = value; }
        }

        /// <summary>
        /// Gets or sets the StagingProductID value.
        /// </summary>
        public virtual int StagingProductID
        {
            get { return stagingProductID; }
            set { stagingProductID = value; }
        }

        #endregion
    }
}
