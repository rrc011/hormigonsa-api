using System;

namespace Talleres.Talleres.Equipment.Dto
{
    public class GetAllEquipmentCycleInput : GetAllInput
    {
        public int EquipmentId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
