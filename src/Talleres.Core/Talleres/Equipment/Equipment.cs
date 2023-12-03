using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using static Talleres.Constants;

namespace Talleres
{
    [Table("Equipment", Schema = "Taller")]
    public class Equipment : FullAuditedEntity, IMustHaveTenant
    {
        public string Serial { get; set; }
        public string Chassis { get; set; }
        public string Plate { get; set; }
        public string Tab { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public EquipmentType Type { get; set; }
        public ReferenceType Reference { get; set; }        
        public CombustionType Combustion { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand BrandAssigned { get; set; }
        public int? BrandId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public Model ModelAssigned { get; set; }
        public int? ModelId { get; set; }
        public double? Capacity { get; set; }
        public string Comment { get; set; }
        public double? Horometer { get; set; }
        public int TenantId { get; set; }
    }
}
