﻿using GibddApp.Core.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Gibdd
{
    public class Rank : NamedEntity
    {
        public Rank(string name, int id) : base(name, id)
        {
        }
    }
}
