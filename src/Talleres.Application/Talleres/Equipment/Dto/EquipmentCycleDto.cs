using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace Talleres.Talleres.Equipment.Dto
{
    [AutoMapFrom(typeof(EquipmentCycle))]
    public class EquipmentCycleDto : EntityDto
    {
        public int EquipmentId { get; set; }
        public int HorometerFrom { get; set; }
        public int HorometerTo { get; set; }
        public float Fuel { get; set; }
        public int TenantId { get; set; }
        public Guid GuidReg { get; set; }
        public long CreatorUserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreationTime { get; set; }
        public EquipmentDto Equipment { get; set; }
    }
}
