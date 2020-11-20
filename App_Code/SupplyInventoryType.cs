using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solum
{
    public class SupplyInventoryType
    {
        public SupplyInventoryType(string Id, string Description)
        {
            this.Id = Id;
            this.Description = Description;
        }
        public string Id { get; private set; }
        public string Description { get; private set; }

    }
}
