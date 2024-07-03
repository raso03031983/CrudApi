using Data.Context;
using Data.Context.Model;
using Data.Dto;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data
{
    public class ContaRepository :IContaRepository
    {
        private readonly DefaultContext _ctx;
        public ContaRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }
        public ContaDto GetByID(Guid itemID)
        {
            var model = _ctx.
                               Conta
                               .Where(x => x.IdConta == itemID)
                               .AsNoTracking()
                               .Select(x => new ContaDto
                               {
                                   IdConta = x.IdConta,
                                   documento_cliente = x.documento_cliente
                               }).FirstOrDefault();

            if (model == null)
                return null;

            return model;
        }

        public Grid<ContaDto> LoadPaginate(int pagina)
        {
            var retorno = _ctx
                 .Conta
                 .AsNoTracking();

            var totalPaginas = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(retorno.Count()) / Convert.ToDecimal(ToolsData.TAMANHO_PAGINACAO)));

            return new Grid<ContaDto>()
            {
                ItensPorPagina = ToolsData.TAMANHO_PAGINACAO,
                Pagina = pagina,
                Total = retorno.Count(),
                TotalDePaginas = totalPaginas,
                Itens = retorno.Select(x => new ContaDto
                {
                    IdConta = x.IdConta,
                    documento_cliente = x.documento_cliente
                })
                .Skip((pagina - 1) * ToolsData.TAMANHO_PAGINACAO)
                .Take(ToolsData.TAMANHO_PAGINACAO)
                .ToList()
            };
        }

        public void Save(ContaDto item)
        {
            var model = Dto_Model(item);
            _ctx.Add(model);
            _ctx.SaveChanges();
        }

        public void Update(ContaDto item)
        {
            var Conta = _ctx.Conta.Where(x => x.IdConta == item.IdConta).FirstOrDefault();

            Conta.documento_cliente = item.documento_cliente;
           
            _ctx.SaveChanges();
        }

        private ContaDto Model_Dto(Conta model)
        {

            var dto = new ContaDto
            {
                IdConta = model.IdConta,
                documento_cliente = model.documento_cliente
            };

            return dto;
        }

        private Conta Dto_Model(ContaDto dto)
        {

            var model = new Conta
            {
                IdConta = dto.IdConta,
                documento_cliente = dto.documento_cliente
            };

            return model;
        }

    }
}
