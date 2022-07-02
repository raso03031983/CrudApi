using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("RedeSocial")]
    public class RedeSocial : DefaultValues
    {
        [Key]
        public int idRedeSocial { get; set; }
        [Required]
        [MaxLength(50)]
        public string redeSocial { get; set; }
        [Required]
        [MaxLength(2)]
        public string tipoRedeSocial { get; set; }
        [Required]
        public int idCliente { get; set; }
    }
}
