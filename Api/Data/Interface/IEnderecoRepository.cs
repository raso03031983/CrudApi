using Data.Dto;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IEnderecoRepository
    {
        EnderecoDto GetByID(int itemID);
        List<EnderecoDto> GetListCliente(int idCliente);
        List<EnderecoDto> Load();
        void Save(EnderecoDto item);
        void Update(EnderecoDto item);
        void Delete(int item);
    }
}
