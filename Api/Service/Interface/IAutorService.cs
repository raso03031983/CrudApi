using Data.Dto;
using Service.Dto;
using Service.Request;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IAutorService
    {
        DefaultResponse GetByID(int itemID);
        DefaultResponse LoadPaginate(int pagina);
        DefaultResponse Save(AutorReq item);
        DefaultResponse Update(AutorReq item);
        List<AutorDto> GetAll();
    }
}
