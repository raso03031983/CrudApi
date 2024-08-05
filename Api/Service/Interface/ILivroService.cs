using Data.Dto;
using Service.Dto;
using Service.Request;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface ILivroService
    {
        DefaultResponse GetByID(int itemID);
        DefaultResponse LoadPaginate(int pagina);
        List<LivroDto> GetAll();
        DefaultResponse Save(LivroReq item);
        DefaultResponse Update(LivroReq item);
    }
}
