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
    public class AutorRepository :IAutorRepository
    {
        private readonly DefaultContext _ctx;
        public AutorRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }
        public AutorDto GetByID(int itemID)
        {
            var model = _ctx.
                               Autor
                               .Where(x => x.Cod == itemID)
                               .AsNoTracking()
                               .Select(x => new AutorDto
                               {
                                  Cod = x.Cod,
                                  Nome = x.Nome,
                               }).FirstOrDefault();

            if (model == null)
                return null;

            return model;
        }

        public List<AutorDto> GetAll()
        {
            var model = _ctx.
                               Autor
                               .AsNoTracking()
                               .Select(x => new AutorDto
                               {
                                   Cod = x.Cod,
                                   Nome = x.Nome,
                               })
                               .OrderByDescending(x => x.Cod)
                               .ToList();

            if (model == null)
                return null;

            return model;
        }

        public Grid<AutorDto> LoadPaginate(int pagina)
        {
            var retorno = _ctx
                 .Autor
                 .AsNoTracking();

            var totalPaginas = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(retorno.Count()) / Convert.ToDecimal(ToolsData.TAMANHO_PAGINACAO)));

            return new Grid<AutorDto>()
            {
                ItensPorPagina = ToolsData.TAMANHO_PAGINACAO,
                Pagina = pagina,
                Total = retorno.Count(),
                TotalDePaginas = totalPaginas,
                Itens = retorno.Select(x => new AutorDto
                {
                    Cod = x.Cod,
                    Nome = x.Nome,
                })
                .Skip((pagina - 1) * ToolsData.TAMANHO_PAGINACAO)
                .Take(ToolsData.TAMANHO_PAGINACAO)
                .ToList()
            };
        }

        public void Save(AutorDto item)
        {
            var model = Dto_Model(item);
            _ctx.Add(model);
            _ctx.SaveChanges();
        }

        public void Update(AutorDto item)
        {
            var Autor = _ctx.Autor.Where(x => x.Cod == item.Cod).FirstOrDefault();

            Autor.Nome = item.Nome;
           
            _ctx.SaveChanges();
        }

        private AutorDto Model_Dto(Autor model)
        {

            var dto = new AutorDto
            {
                Cod = model.Cod,
                Nome = model.Nome,
            };

            return dto;
        }

        private Autor Dto_Model(AutorDto dto)
        {
            var model = new Autor
            {
                Cod = dto.Cod,
                Nome = dto.Nome,
            };

            return model;
        }

    }
}
