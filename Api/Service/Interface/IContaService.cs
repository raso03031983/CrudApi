using Data.Dto;
using Service.Dto;
using Service.Request;
using System;

namespace Service.Interface
{
    public interface IContaService
    {
        DefaultResponse GetByID(Guid itemID);
        DefaultResponse LoadPaginate(int pagina);
        DefaultResponse Save(ContaReq item);
        DefaultResponse Update(ContaReq item);
    }
}
