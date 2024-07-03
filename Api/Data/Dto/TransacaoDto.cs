using Data.Context.Model;
using System;

namespace Data.Dto
{
    public class TransacaoDto
    {
        public Guid IdTransacao { get; set; }
        public Guid IdConta { get; set; }
        public virtual Conta Conta { get; set; }
        public int IdTipoTransacao { get; set; }
        public virtual TipoTransacao TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
