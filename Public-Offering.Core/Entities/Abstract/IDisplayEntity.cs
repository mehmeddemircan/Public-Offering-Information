﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Core.Entities.Abstract
{
    public interface IDisplayEntity
    {
        public int DisplayOrder { get; set; }

        public bool IsDisplay { get; set; }
    }
}
