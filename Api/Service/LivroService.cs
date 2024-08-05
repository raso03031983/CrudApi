using Data.Context.Model;
using Data.Dto;
using Data.Interface;
using Service.Dto;
using Service.Interface;
using Service.Request;
using System;
using System.Collections.Generic;

namespace Service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _LivroRepository;

        public LivroService(ILivroRepository LivroRepository)
        {
            _LivroRepository = LivroRepository;
        }

        public DefaultResponse GetByID(int itemID)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _LivroRepository.GetByID(itemID); ;
                resp.success = true;
                return resp;
            }
            catch (Exception ex)
            {
                resp.message = ex.Message;
                resp.success = false;
                return resp;
            }
        }

        public DefaultResponse LoadPaginate(int pagina)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _LivroRepository.LoadPaginate(pagina);
                resp.success = true;
                return resp;
            }
            catch (Exception ex)
            {
                resp.message = ex.Message;
                resp.success = false;
                return resp;
            }

        }

        public List<LivroDto> GetAll()
        {
            return _LivroRepository.GetAll();
        }

        public DefaultResponse Save(LivroReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoLivro(item);

            if (validate.Count > 0)
            {
                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
                var newItem = new LivroDto
                {
                    AnoPublicacao = item.AnoPublicacao,
                    Titulo = item.Titulo,
                    Editora = item.Editora,
                    Edicao = item.Edicao,
                    AssuntoId = item.AssuntoId,
                    AutorId = item.AutorId,
                    AssuntoIds = item.AssuntoIds,
                    AutoresIds = item.AutoresIds,
                };

                _LivroRepository.Save(newItem);
                resp.success = true;
                return resp;
            }
            catch (Exception ex)
            {
                resp.message = ex.Message;
                resp.success = false;
                return resp;
            }

        }

        public DefaultResponse Update(LivroReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoLivro(item);

            var hasItem = _LivroRepository.GetByID(item.Cod);

            if (validate.Count > 0 || hasItem == null)
            {
                if (hasItem == null)
                    validate.Add("Livro não encontrada");

                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
                hasItem.Titulo = item.Titulo;
                hasItem.AnoPublicacao = item.AnoPublicacao;
                hasItem.Edicao = item.Edicao;
                hasItem.Editora = item.Editora;
                hasItem.AssuntoId = item.AssuntoId;
                hasItem.AutorId = item.AutorId;
                hasItem.AssuntoIds = item.AssuntoIds;
                hasItem.AutoresIds = item.AutoresIds;

                _LivroRepository.Update(hasItem);
                resp.success = true;
                return resp;
            }
            catch (Exception ex)
            {
                resp.message = ex.Message;
                resp.success = false;
                return resp;
            }
        }

        private List<string> validacaoLivro(LivroReq item)
        {

            var resp = new List<string>();

            if (item.Titulo.Length > 40)
                resp.Add("Titulo não pode ter mais de 40 caracteres");

            if (item.Editora.Length > 40)
                resp.Add("Editora não pode ter mais de 40 caracteres");

            if (item.AnoPublicacao.Length > 4)
                resp.Add("Ano de publicação não pode ter mais de 4 caracteres");

            return resp;
        }
    }
}
