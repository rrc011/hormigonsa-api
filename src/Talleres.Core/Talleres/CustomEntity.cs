using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Abp.Timing;
using System.ComponentModel.DataAnnotations;

namespace Talleres
{
    [Audited]
    public abstract class CustomEntity<TPrimaryKey> : FullAuditedEntity<TPrimaryKey>, IMustHaveTenant
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public int TenantId { get; set; }

        public CustomEntity()
        {
            CreationTime = Clock.Now;
            IsDeleted = false;
        }
    }

    public abstract class CustomEntity : CustomEntity<int>
    {

    }
}
