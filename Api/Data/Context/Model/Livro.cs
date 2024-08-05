using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    public class Livro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod { get; set; }

        [Required]
        [MaxLength(40)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(40)]
        public string Editora { get; set; }

        [Required]
        public int Edicao { get; set; }

        [Required]
        [MaxLength(4)]
        public string AnoPublicacao { get; set; }
    }
}

