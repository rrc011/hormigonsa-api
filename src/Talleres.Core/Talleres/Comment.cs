using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Talleres.Authorization.Users;

namespace Talleres
{
    [Audited]
    [Table("Comment", Schema = "Taller")]
    public class Comment : FullAuditedEntity, IMustHaveTenant
    {
        public Guid? OriginId { get; set; }
        public string Description { get; set; }
        public int TenantId { get; set; }
        public User CreatorUser { get; set; }
    }
}
