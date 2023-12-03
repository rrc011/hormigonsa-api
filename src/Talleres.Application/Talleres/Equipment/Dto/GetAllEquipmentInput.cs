using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres
{
    public class GetAllEquipmentInput : GetAllInput
    {
        public string Reference { get; set; }
        public string Serial { get; set; }
        public string Chassis { get; set; }
        public string Tab { get; set; }
        public string Plate { get; set; }
        public int? Year { get; set; }
    }
}
