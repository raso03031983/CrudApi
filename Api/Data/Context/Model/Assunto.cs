using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    public class Assunto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod { get; set; }

        [Required]
        [MaxLength(20)]
        public string Descricao { get; set; }

        public virtual List<LivroAssunto> LivroAssuntos { get; set; } = new();
    }
}
