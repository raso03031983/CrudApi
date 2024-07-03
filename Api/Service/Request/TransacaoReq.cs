using Data.Context.Model;
using System;

namespace Service.Request
{
    public class TransacaoReq
    {
        public Guid IdTransacao { get; set; }
        public Guid IdConta { get; set; }
        public int IdTipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
