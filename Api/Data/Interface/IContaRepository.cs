using Data.Dto;
using System;

namespace Data.Interface
{
    public interface IContaRepository
    {
        ContaDto GetByID(Guid itemID);
        Grid<ContaDto> LoadPaginate(int pagina);
        void Save(ContaDto item);
        void Update(ContaDto item);
    }
}
