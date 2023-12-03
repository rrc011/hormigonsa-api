using AutoMapper;
using static Talleres.Constants;

namespace Talleres
{
    public class EquipmentFormatter : IValueConverter<Equipment, string>
    {

        public string Convert(Equipment sourceMember, ResolutionContext context) => sourceMember.Reference == ReferenceType.Chassis ? sourceMember.Chassis :
                                        (sourceMember.Reference == ReferenceType.Serial ? sourceMember.Serial :
                                        (sourceMember.Reference == ReferenceType.Tab ? sourceMember.Tab :
                                        (sourceMember.Reference == ReferenceType.Plate ? sourceMember.Plate : string.Empty)));
    }
}
