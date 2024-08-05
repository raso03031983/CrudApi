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
    public class LivroRepository :ILivroRepository
    {
        private readonly DefaultContext _ctx;
        public LivroRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }
        public LivroDto GetByID(int itemID)
        {
            var model = _ctx.
                               Livro
                               .Where(x => x.Cod == itemID)
                               .AsNoTracking()
                               .Select(x => new LivroDto
                               {
                                  Cod = x.Cod,
                                  AnoPublicacao = x.AnoPublicacao,
                                  Edicao = x.Edicao,
                                  Editora = x.Editora,
                                  Titulo = x.Titulo
                               }).FirstOrDefault();

            if (model == null)
                return null;

            return model;
        }

        public List<LivroDto> GetAll()
        {
            try
            {
                var model = _ctx.
                                   Livro
                                   .AsNoTracking()
                                   .Select(x => new LivroDto
                                   {
                                       Cod = x.Cod,
                                       AnoPublicacao = x.AnoPublicacao,
                                       Edicao = x.Edicao,
                                       Editora = x.Editora,
                                       Titulo = x.Titulo,
                                   })
                                   .OrderByDescending(x => x.Cod)
                                   .ToList();

                foreach (var item in model)
                {
                    var livroAutor = _ctx.LivroAutor.ToList().Where(x => x.LivroCod == item.Cod);
                    if (livroAutor != null && livroAutor.Any())
                    {
                        var autorIds = livroAutor.Select(la => la.AutorCod).ToList();
                        var autores = _ctx.Autor.Where(a => autorIds.Contains(a.Cod)).ToList();
                        var nomesAutores = autores.Select(a => a.Nome).ToList();
                        item.Autor = string.Join(", ", nomesAutores);
                    }

                    var livroAssunto = _ctx.LivroAssunto.ToList().Where(x => x.LivroCod == item.Cod);
                    if (livroAssunto != null && livroAssunto.Any())
                    {
                        var assuntoIds = livroAssunto.Select(la => la.AssuntoCod).ToList();
                        var assuntos = _ctx.Assunto.Where(a => assuntoIds.Contains(a.Cod)).ToList();
                        var descAssuntos = assuntos.Select(a => a.Descricao).ToList();
                        item.Assunto = string.Join(", ", descAssuntos);
                    }
                }

                if (model == null)
                    return null;

                return model;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Grid<LivroDto> LoadPaginate(int pagina)
        {
            var retorno = _ctx
                 .Livro
                 .AsNoTracking();

            var totalPaginas = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(retorno.Count()) / Convert.ToDecimal(ToolsData.TAMANHO_PAGINACAO)));

            return new Grid<LivroDto>()
            {
                ItensPorPagina = ToolsData.TAMANHO_PAGINACAO,
                Pagina = pagina,
                Total = retorno.Count(),
                TotalDePaginas = totalPaginas,
                Itens = retorno.Select(x => new LivroDto
                {
                    Cod = x.Cod,
                    AnoPublicacao = x.AnoPublicacao,
                    Edicao = x.Edicao,
                    Editora = x.Editora,
                    Titulo = x.Titulo
                })
                .Skip((pagina - 1) * ToolsData.TAMANHO_PAGINACAO)
                .Take(ToolsData.TAMANHO_PAGINACAO)
                .ToList()
            };
        }

        public void Save(LivroDto item)
        {
            try
            {
                var model = Dto_Model(item);
                _ctx.Livro.Add(model);
               
                int idDoNovoLivro = model.Cod;
                _ctx.SaveChanges();

                foreach (var autorId in item.AutoresIds)
                {
                    var newAutorAssunto = new LivroAutor
                    {
                        AutorCod = autorId,
                        LivroCod = model.Cod
                    };

                    _ctx.LivroAutor.Add(newAutorAssunto);
                    _ctx.SaveChanges();
                }

                foreach (var assuntoId in item.AssuntoIds)
                {
                    var newLivroAssunto = new LivroAssunto
                    {
                        AssuntoCod = assuntoId,
                        LivroCod = model.Cod
                    };

                    _ctx.LivroAssunto.Add(newLivroAssunto);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(LivroDto item)
        {
            var Livro = _ctx.Livro.Where(x => x.Cod == item.Cod).FirstOrDefault();

            Livro.AnoPublicacao = item.AnoPublicacao;
            Livro.Edicao = item.Edicao;
            Livro.Editora = item.Editora;
            Livro.Titulo = item.Titulo;

            _ctx.SaveChanges();

            foreach (var autorId in item.AutoresIds)
            {
                var newAutorAssunto = new LivroAutor
                {
                    AutorCod = autorId,
                    LivroCod = Livro.Cod
                };

                _ctx.LivroAutor.Add(newAutorAssunto);
                _ctx.SaveChanges();
            }

            foreach (var assuntoId in item.AssuntoIds)
            {
                var newLivroAssunto = new LivroAssunto
                {
                    AssuntoCod = assuntoId,
                    LivroCod = Livro.Cod
                };

                _ctx.LivroAssunto.Add(newLivroAssunto);
                _ctx.SaveChanges();
            }
        }

        private LivroDto Model_Dto(Livro model)
        {

            var dto = new LivroDto
            {
                Cod = model.Cod,
                AnoPublicacao = model.AnoPublicacao,
                Edicao = model.Edicao,
                Editora = model.Editora,
                Titulo = model.Titulo
            };

            return dto;
        }

        private Livro Dto_Model(LivroDto dto)
        {
            var model = new Livro
            {
                Cod = dto.Cod,
                AnoPublicacao = dto.AnoPublicacao,
                Edicao = dto.Edicao,
                Editora = dto.Editora,
                Titulo = dto.Titulo
            };

            return model;
        }

    }
}
