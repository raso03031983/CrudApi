using Data.Context;
using Data.Context.Model;
using Data.Dto;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class AssuntoRepository :IAssuntoRepository
    {
        private readonly DefaultContext _ctx;
        public AssuntoRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }
        public AssuntoDto GetByID(int itemID)
        {
            var model = _ctx.
                               Assunto
                               .Where(x => x.Cod == itemID)
                               .AsNoTracking()
                               .Select(x => new AssuntoDto
                               {
                                  Cod = x.Cod,
                                  Descricao = x.Descricao
                               }).FirstOrDefault();

            if (model == null)
                return null;

            return model;
        }

        public List<AssuntoDto> GetAll()
        {
            try
            {
                var model = _ctx.Assunto
                              .AsNoTracking()
                              .Select(x => new AssuntoDto
                              {
                                  Cod = x.Cod,
                                  Descricao = x.Descricao
                              })
                              .OrderByDescending(x => x.Cod)
                              .ToList();

                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public Grid<AssuntoDto> LoadPaginate(int pagina)
        {
            var retorno = _ctx
                 .Assunto
                 .AsNoTracking();

            var totalPaginas = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(retorno.Count()) / Convert.ToDecimal(ToolsData.TAMANHO_PAGINACAO)));

            return new Grid<AssuntoDto>()
            {
                ItensPorPagina = ToolsData.TAMANHO_PAGINACAO,
                Pagina = pagina,
                Total = retorno.Count(),
                TotalDePaginas = totalPaginas,
                Itens = retorno.Select(x => new AssuntoDto
                {
                    Cod = x.Cod,
                    Descricao = x.Descricao
                })
                .Skip((pagina - 1) * ToolsData.TAMANHO_PAGINACAO)
                .Take(ToolsData.TAMANHO_PAGINACAO)
                .ToList()
            };
        }

        public void Save(AssuntoDto item)
        {
            var model = Dto_Model(item);
            _ctx.Add(model);
            _ctx.SaveChanges();
        }

        public void Update(AssuntoDto item)
        {
            var Assunto = _ctx.Assunto.Where(x => x.Cod == item.Cod).FirstOrDefault();

            Assunto.Cod = item.Cod;
            Assunto.Descricao = item.Descricao;

            _ctx.SaveChanges();
        }

        private AssuntoDto Model_Dto(Assunto model)
        {

            var dto = new AssuntoDto
            {
                Cod = model.Cod,
                Descricao = model.Descricao
            };

            return dto;
        }

        private Assunto Dto_Model(AssuntoDto dto)
        {
            var model = new Assunto
            {
                Cod = dto.Cod,
                Descricao = dto.Descricao
            };

            return model;
        }

    }
}
