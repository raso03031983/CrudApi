using Data.Dto;
using Service.Dto;
using Service.Request;

namespace Service.Interface
{
    public interface ITipoTransacaoService
    {
        DefaultResponse GetByID(int itemID);
        DefaultResponse LoadPaginate(int pagina);
        DefaultResponse Save(TipoTransacaoReq item);
        DefaultResponse Update(TipoTransacaoReq item);
    }
}
