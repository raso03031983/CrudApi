using Data.Dto;

namespace Data.Interface
{
    public interface ITipoTransacaoRepository
    {
        TipoTransacaoDto GetByID(int itemID);
        Grid<TipoTransacaoDto> LoadPaginate(int pagina);
        void Save(TipoTransacaoDto item);
        void Update(TipoTransacaoDto item);
    }
}
