using Data.Dto;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface ITelefoneRepository
    {
        TelefoneDto GetByID(int itemID);
        List<TelefoneDto> GetListCliente(int idCliente);
        List<TelefoneDto> Load();
        void Save(TelefoneDto item);
        void Update(TelefoneDto item);
        void Delete(int item);
    }
}
