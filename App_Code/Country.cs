using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solum
{
    public class Country
    {
        public Country(string Code, string Name)
        {
            this.Code = Code;
            this.Name = Name;
        }

        public string Code { get; private set; }
        public string Name { get; private set; }

    }
}
