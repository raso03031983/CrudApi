using Data.Dto;

namespace Data.Interface
{
    public interface IClienteRepository
    {
        ClienteDto GetByID(int itemID);
        Grid<ClienteDto> LoadPaginate(int pagina);
        void Save(ClienteDto item);
        void Update(ClienteDto item);
        void Delete(int item);
    }
}
