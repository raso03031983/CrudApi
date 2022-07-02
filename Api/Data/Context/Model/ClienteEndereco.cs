using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("ClienteEndereco")]
    public class ClienteEndereco
    {
        [Key]
        public int idClienteEndereco { get; set; }
        [Required]
        public int idCliente { get; set; }
        [Required]
        public int idEndereco { get; set; }
    }
}
