using VechileManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Domain.Entities
{
    public  class Factory: BaseAuditableEntity
    {
        public string FactoryNameAmh { get; set; }
        public string FactoryNameEng { get; set; }
        public decimal Code { get; set; }

    }
}
