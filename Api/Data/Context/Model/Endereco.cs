using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("Endereco")]
    public class Endereco : DefaultValues
    {
        [Key]
        public int idEndereco { get; set; }
        [Required]
        [MaxLength(100)]
        public string logradouro { get; set; }
        [Required]
        [MaxLength(25)]
        public string bairro { get; set; }
        [Required]
        [MaxLength(25)]
        public string cidade { get; set; }
        [Required]
        [MaxLength(2)]
        public string estado { get; set; }
        [Required]
        [MaxLength(8)]
        public string cep { get; set; }

        [MaxLength(50)]
        public string complemento { get; set; }
        [Required]
        public int idCliente { get; set; }
    }
}
