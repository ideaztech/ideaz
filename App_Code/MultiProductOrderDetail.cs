using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solum
{
    public class MultiProductOrderDetail
    {
        public MultiProductOrderDetail()
        {
            DetailID = 0;
            OrderID = 0;
            OrderType = string.Empty;
            ProductID = 0;
            ProductDescription = string.Empty;
            Quantity = 0;
            Price = 0;
            Amount = 0;
            MasterProductID = 0;
            AgencyID = 0;
            AutoGenerateTagNumber = false;
            Weight = 0;
            Volume = 0;
        }
        public virtual int DetailID { get; set; }
        public virtual int OrderID { get; set; }
        public virtual string OrderType { get; set; }
        public virtual int ProductID { get; set; }
        public virtual string ProductDescription { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual int AgencyID { get; set; }
        public virtual int MasterProductID { get; set; }
        public virtual bool AutoGenerateTagNumber { get; set; }
        public virtual decimal Weight { get; set; }
        public virtual decimal Volume { get; set; }
    }
}
