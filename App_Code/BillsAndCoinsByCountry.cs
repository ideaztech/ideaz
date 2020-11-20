using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solum
{
    public class BillsAndCoinsByCountry
    {
        public BillsAndCoinsByCountry(byte Id, string Country, byte Type, int Value, string Description, int Total)
        {
            this.Id = Id;
            this.Country = Country;
            this.Type = Type;
            this.Value = Value;
            this.Description = Description;
            this.Total = Total;
        }

        public byte Id { get; private set; }
        public string Country { get; private set; }
        public byte Type { get; private set; }
        public int Value { get; private set; }
        public string Description { get; private set; }
        public int Total { get; set; }

    }
}
