using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    public class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod { get; set; }

        [Required]
        [MaxLength(40)]
        public string Nome { get; set; }

    }
}
