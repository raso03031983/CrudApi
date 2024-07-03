using System;

namespace Service.Request
{
    public  class ContaReq
    {
        public Guid IdConta { get; set; }
        public string documento_cliente { get; set; }
    }
}
