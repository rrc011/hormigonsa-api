using System.ComponentModel.DataAnnotations.Schema;

namespace Talleres
{
    [Table("Model", Schema = "Taller")]
    public class Model : CustomEntity
    {
        [ForeignKey(nameof(BrandId))]
        public Brand BrandAssigned { get; set; }
        public int BrandId { get; set; }
        public string TechnicalName { get; set; }
    }
}
