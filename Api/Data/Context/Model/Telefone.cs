using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("Telefone")]
    public class Telefone : DefaultValues
    {
        [Key]
        public int idTelefone { get; set; }
        [Required]
        [MaxLength(20)]
        public string telefone { get; set; }
        [Required]
        [MaxLength(1)]
        public string tipoTelefone { get; set; }
        [Required]
        public int idCliente { get; set; }

    }
}
