using VechileManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Domain.Entities
{
    public  class Factory: BaseAuditableEntity
    {
        public string FactoryName { get; set; }

    }
}
