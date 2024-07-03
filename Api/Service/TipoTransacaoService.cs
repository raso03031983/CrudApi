using Data;
using Data.Dto;
using Data.Interface;
using Service.Dto;
using Service.Interface;
using Service.Request;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TipoTransacaoService : ITipoTransacaoService
    {
        private readonly ITipoTransacaoRepository _TipoTransacaoRepository;

        public TipoTransacaoService(ITipoTransacaoRepository TipoTransacaoRepository)
        {
            _TipoTransacaoRepository = TipoTransacaoRepository;
        }

        public DefaultResponse GetByID(int itemID)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _TipoTransacaoRepository.GetByID(itemID); ;
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
                resp.data = _TipoTransacaoRepository.LoadPaginate(pagina);
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

        public DefaultResponse Save(TipoTransacaoReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoTipoTransacao(item);

            if (validate.Count > 0)
            {
                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
                Guid newId = Guid.NewGuid();
                var newItem = new TipoTransacaoDto
                {
                    Descricao = item.Descricao
                };

                _TipoTransacaoRepository.Save(newItem);
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

        public DefaultResponse Update(TipoTransacaoReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoTipoTransacao(item);

            var hasItem = _TipoTransacaoRepository.GetByID(item.IdTipoTransacao);

            if (validate.Count > 0 || hasItem == null)
            {
                if (hasItem == null)
                    validate.Add("Conta não encontrada");

                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
                hasItem.Descricao = item.Descricao;

                _TipoTransacaoRepository.Update(hasItem);
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

        private List<string> validacaoTipoTransacao(TipoTransacaoReq item)
        {

            var resp = new List<string>();

            if (item.Descricao.Length > 20)
                resp.Add("Documento não pode ter mais 15 caracteres");

            return resp;
        }
    }
}
