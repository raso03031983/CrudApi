using Data.Dto;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IAssuntoRepository
    {
        AssuntoDto GetByID(int itemID);
        Grid<AssuntoDto> LoadPaginate(int pagina);
        List<AssuntoDto> GetAll();
        void Save(AssuntoDto item);
        void Update(AssuntoDto item);
    }
}
