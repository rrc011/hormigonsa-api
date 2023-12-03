using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Talleres
{
    [Table(nameof(EquipmentCycle), Schema = "Taller")]
    public class EquipmentCycle : FullAuditedEntity, IMustHaveTenant
    {
        public EquipmentCycle()
        {
            GuidReg = Guid.NewGuid();
        }

        public int EquipmentId { get; set; }
        public int HorometerFrom { get; set; }
        public int HorometerTo { get; set; }
        public float Fuel { get; set; }
        public int TenantId { get; set; }
        public Guid GuidReg { get; set; }

        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; }
    }
}
