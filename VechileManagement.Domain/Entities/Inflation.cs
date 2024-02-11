﻿using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Domain.Common;

namespace VechileManagement.Domain.Entities
{
    public class Inflation : BaseAuditableEntity
    {
        public int ServiceYear { get; set; }
        public decimal Point { get; set; }
    }
}
