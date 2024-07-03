using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("TipoTransacao")]
    public class TipoTransacao
    {
        [Key]
        public int IdTipoTransacao { get; set; }
        [Required]
        [MaxLength(15)]
        public string Descricao { get; set; }
    }
}
