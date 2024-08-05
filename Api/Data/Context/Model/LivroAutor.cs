﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    public class LivroAutor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod { get; set; }
        public int LivroCod { get; set; }
        [ForeignKey("LivroCod")]
        public virtual Livro Livro { get; set; }

        public int AutorCod { get; set; }
        [ForeignKey("AssuntoCod")]
        public virtual Autor Autor { get; set; }
    }
}
