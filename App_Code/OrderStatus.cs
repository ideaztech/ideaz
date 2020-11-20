using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solum
{
    public class OrderStatus
    {
        public OrderStatus(string Id, string Description)
        {
            this.Id = Id;
            this.Description = Description;
        }
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
