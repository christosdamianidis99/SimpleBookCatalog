﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.Domain
{
    public class DisplayNameAttribute:Attribute
    {

        public string Name { get; }

        public DisplayNameAttribute(string name)
        {
            Name = name;
        }
    }
}
