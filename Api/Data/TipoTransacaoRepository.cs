using Data.Context;
using Data.Context.Model;
using Data.Dto;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data
{
    public class TipoTransacaoRepository : ITipoTransacaoRepository
    {
        private readonly DefaultContext _ctx;
        public TipoTransacaoRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }
        public TipoTransacaoDto GetByID(int itemID)
        {
            var model = _ctx.
                               TipoTransacao
                               .Where(x => x.IdTipoTransacao == itemID)
                               .AsNoTracking()
                               .Select(x => new TipoTransacaoDto
                               {
                                   IdTipoTransacao = x.IdTipoTransacao,
                                   Descricao = x.Descricao,
                               }).FirstOrDefault();

            if (model == null)
                return null;

            return model;
        }

        public Grid<TipoTransacaoDto> LoadPaginate(int pagina)
        {
            var retorno = _ctx
                 .TipoTransacao
                 .AsNoTracking();

            var totalPaginas = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(retorno.Count()) / Convert.ToDecimal(ToolsData.TAMANHO_PAGINACAO)));

            return new Grid<TipoTransacaoDto>()
            {
                ItensPorPagina = ToolsData.TAMANHO_PAGINACAO,
                Pagina = pagina,
                Total = retorno.Count(),
                TotalDePaginas = totalPaginas,
                Itens = retorno.Select(x => new TipoTransacaoDto
                {
                    IdTipoTransacao = x.IdTipoTransacao,
                    Descricao = x.Descricao,
                })
                .Skip((pagina - 1) * ToolsData.TAMANHO_PAGINACAO)
                .Take(ToolsData.TAMANHO_PAGINACAO)
                .ToList()
            };
        }

        public void Save(TipoTransacaoDto item)
        {
            var model = Dto_Model(item);
            _ctx.Add(model);
            _ctx.SaveChanges();
        }

        public void Update(TipoTransacaoDto item)
        {
            var model = _ctx.TipoTransacao.Where(x => x.IdTipoTransacao == item.IdTipoTransacao).FirstOrDefault();

            model.Descricao = item.Descricao;

            _ctx.SaveChanges();
        }

        private TipoTransacaoDto Model_Dto(TipoTransacao model)
        {

            var dto = new TipoTransacaoDto
            {
                IdTipoTransacao = model.IdTipoTransacao,
                Descricao = model.Descricao
            };

            return dto;
        }

        private TipoTransacao Dto_Model(TipoTransacaoDto dto)
        {

            var model = new TipoTransacao
            {
                IdTipoTransacao = dto.IdTipoTransacao,
                Descricao = dto.Descricao
            };

            return model;
        }

    }
}
