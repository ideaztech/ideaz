using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solum
{
    public class ProductType
    {
        public ProductType(byte Id, string Description)
        {
            this.Id = Id;
            this.Description = Description;
        }
        public byte Id { get; private set; }
        public string Description { get; private set; }
 
    }
}
