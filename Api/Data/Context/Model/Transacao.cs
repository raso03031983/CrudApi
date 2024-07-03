using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("Transacao")]
    public class Transacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IdTransacao { get; set; }
        public Guid IdConta { get; set; }
        [ForeignKey("IdConta")]
        public virtual Conta Conta { get; set; }  
        public int IdTipoTransacao { get; set; }
        [ForeignKey("IdTipoTransacao")]
        public virtual TipoTransacao TipoTransacao { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
