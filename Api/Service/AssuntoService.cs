using Data.Dto;
using Data.Interface;
using Service.Dto;
using Service.Interface;
using Service.Request;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AssuntoService : IAssuntoService
    {
        private readonly IAssuntoRepository _AssuntoRepository;

        public AssuntoService(IAssuntoRepository AssuntoRepository)
        {
            _AssuntoRepository = AssuntoRepository;
        }

        public DefaultResponse GetByID(int itemID)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _AssuntoRepository.GetByID(itemID); ;
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

        public List<AssuntoDto> GetAll()
        {
            return _AssuntoRepository.GetAll();
        }

        public DefaultResponse LoadPaginate(int pagina)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _AssuntoRepository.LoadPaginate(pagina);
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

        public DefaultResponse Save(AssuntoReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoAssunto(item);

            if (validate.Count > 0)
            {
                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
                var newItem = new AssuntoDto
                {
                   Descricao = item.Descricao,
                };

                _AssuntoRepository.Save(newItem);
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

        public DefaultResponse Update(AssuntoReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoAssunto(item);

            var hasItem = _AssuntoRepository.GetByID(item.Cod);

            if (validate.Count > 0 || hasItem == null)
            {
                if (hasItem == null)
                    validate.Add("Assunto não encontrada");

                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
                hasItem.Descricao = item.Descricao;

                _AssuntoRepository.Update(hasItem);
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

        private List<string> validacaoAssunto(AssuntoReq item)
        {

            var resp = new List<string>();

            if (item.Descricao.Length > 20)
                resp.Add("descrição não pode ter mais 20 caracteres");

            return resp;
        }
    }
}
