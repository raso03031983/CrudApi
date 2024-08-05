using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    public class LivroAssunto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod { get; set; }
        public int LivroCod { get; set; }
        [ForeignKey("LivroCod")]
        public virtual Livro Livro { get; set; }

        public int AssuntoCod { get; set; }
        [ForeignKey("AssuntoCod")]
        public virtual Assunto Assunto { get; set; }

    }
}
