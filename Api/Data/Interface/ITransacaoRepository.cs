using Data.Dto;
using System;

namespace Data.Interface
{
    public interface ITransacaoRepository
    {
        TransacaoDto GetByID(Guid itemID);
        Grid<TransacaoDto> LoadPaginate(int pagina);
        void Save(TransacaoDto item);
        void Update(TransacaoDto item);
    }
}
