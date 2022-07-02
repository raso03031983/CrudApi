using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("ClienteTelefone")]
    public class ClienteTelefone
    {
        [Key]
        public int idClienteTelefone { get; set; }
        [Required]
        public int idCliente { get; set; }
        [Required]
        public int idTelefone { get; set; }
    }
}
