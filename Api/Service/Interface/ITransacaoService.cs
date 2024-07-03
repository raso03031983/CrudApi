using Service.Dto;
using Service.Request;
using System;

namespace Service.Interface
{
    public interface ITransacaoService
    {
        DefaultResponse GetByID(Guid itemID);
        DefaultResponse LoadPaginate(int pagina);
        DefaultResponse Save(TransacaoReq item);
        DefaultResponse Update(TransacaoReq item);
    }
}
