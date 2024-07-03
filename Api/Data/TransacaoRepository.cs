using Data.Context;
using Data.Context.Model;
using Data.Dto;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly DefaultContext _ctx;
        public TransacaoRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }
        public TransacaoDto GetByID(Guid itemID)
        {
            var model = _ctx.
                               Transacao
                               .Include(x => x.Conta)
                               .Include(x => x.TipoTransacao)
                               .Where(x => x.IdTransacao == itemID)
                               .AsNoTracking()
                               .Select(x => new TransacaoDto
                               {
                                   IdTransacao = x.IdTransacao,
                                   IdConta = x.IdConta,
                                   Conta = x.Conta,
                                   DataHora = x.DataHora,
                                   IdTipoTransacao = x.IdTipoTransacao,
                                   TipoTransacao = x.TipoTransacao,
                                   Valor = x.Valor
                               }).FirstOrDefault();

            if (model == null)
                return null;

            return model;
        }

        public Grid<TransacaoDto> LoadPaginate(int pagina)
        {
            var retorno = _ctx
                 .Transacao
                 .AsNoTracking();

            var totalPaginas = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(retorno.Count()) / Convert.ToDecimal(ToolsData.TAMANHO_PAGINACAO)));

            return new Grid<TransacaoDto>()
            {
                ItensPorPagina = ToolsData.TAMANHO_PAGINACAO,
                Pagina = pagina,
                Total = retorno.Count(),
                TotalDePaginas = totalPaginas,
                Itens = retorno.Select(x => new TransacaoDto
                {
                    IdTransacao = x.IdTransacao,
                    IdConta = x.IdConta,
                    Conta = x.Conta,
                    DataHora = x.DataHora,
                    IdTipoTransacao = x.IdTipoTransacao,
                    TipoTransacao = x.TipoTransacao,
                    Valor = x.Valor
                })
                .Skip((pagina - 1) * ToolsData.TAMANHO_PAGINACAO)
                .Take(ToolsData.TAMANHO_PAGINACAO)
                .ToList()
            };
        }

        public void Save(TransacaoDto item)
        {
            var model = Dto_Model(item);

            _ctx.Add(model);
            _ctx.SaveChanges();
        }

        public void Update(TransacaoDto item)
        {
            var model = _ctx.Transacao.Where(x => x.IdTransacao == item.IdTransacao).FirstOrDefault();

            model.IdTipoTransacao = item.IdTipoTransacao;
            model.IdConta = item.IdConta;
            model.Valor = item.Valor;
            model.DataHora = DateTime.Now;

            _ctx.SaveChanges();
        }

        private TransacaoDto Model_Dto(Transacao model)
        {
            
            var dto = new TransacaoDto
            {
                IdTransacao = model.IdTransacao,
                IdConta = model.IdConta,
                Conta = model.Conta,
                DataHora = model.DataHora,
                IdTipoTransacao = model.IdTipoTransacao,
                TipoTransacao = model.TipoTransacao,
                Valor = model.Valor
            };

            return dto;
        }

        private Transacao Dto_Model(TransacaoDto dto)
        {

            var model = new Transacao
            {
                IdTransacao = dto.IdTransacao,
                IdConta = dto.IdConta,
                Conta = dto.Conta,
                DataHora = dto.DataHora,
                IdTipoTransacao = dto.IdTipoTransacao,
                TipoTransacao = dto.TipoTransacao,
                Valor = dto.Valor
            };

            return model;
        }

    }
}
