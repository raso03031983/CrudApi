using Data.Dto;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IAutorRepository
    {
        AutorDto GetByID(int itemID);
        Grid<AutorDto> LoadPaginate(int pagina);
        void Save(AutorDto item);
        void Update(AutorDto item);
        List<AutorDto> GetAll();
    }
}
