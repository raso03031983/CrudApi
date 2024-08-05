using Data.Dto;
using Service.Dto;
using Service.Request;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IAssuntoService
    {
        DefaultResponse GetByID(int itemID);
        DefaultResponse LoadPaginate(int pagina);
        DefaultResponse Save(AssuntoReq item);
        DefaultResponse Update(AssuntoReq item);
        List<AssuntoDto> GetAll();
    }
}
