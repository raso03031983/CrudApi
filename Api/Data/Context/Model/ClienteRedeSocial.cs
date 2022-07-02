using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("ClienteRedeSocial")]
    public class ClienteRedeSocial
    {
        [Key]
        public int idClienteRedeSocial { get; set; }
        [Required]
        public int idCliente { get; set; }
        [Required]
        public int idEndereco { get; set; }
    }
}
