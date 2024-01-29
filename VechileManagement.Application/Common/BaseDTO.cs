using System;

namespace VechileManagement.Application.Common
{
    public abstract class BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
