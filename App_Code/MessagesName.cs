﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solum
{

    public class MessagesName
    {
        public MessagesName(int Id, string Name, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

    }
}
