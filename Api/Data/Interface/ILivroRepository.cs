using Data.Dto;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface ILivroRepository
    {
        LivroDto GetByID(int itemID);
        Grid<LivroDto> LoadPaginate(int pagina);
        List<LivroDto> GetAll();
        void Save(LivroDto item);
        void Update(LivroDto item);
    }
}
