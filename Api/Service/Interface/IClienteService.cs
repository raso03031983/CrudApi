using Data.Dto;
using Service.Dto;

namespace Service.Interface
{
    public interface IClienteService
    {
        DefaultResponse GetByID(int itemID);
        DefaultResponse LoadPaginate(int pagina);
        DefaultResponse Save(ClienteDto item);
        DefaultResponse Update(ClienteDto item);
        DefaultResponse Delete(int item);
    }
}
