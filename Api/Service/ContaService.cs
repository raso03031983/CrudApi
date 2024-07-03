using Data.Dto;
using Data.Interface;
using Service.Dto;
using Service.Interface;
using Service.Request;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _ContaRepository;

        public ContaService(IContaRepository ContaRepository)
        {
            _ContaRepository = ContaRepository;
        }

        public DefaultResponse GetByID(Guid itemID)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _ContaRepository.GetByID(itemID); ;
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
                resp.data = _ContaRepository.LoadPaginate(pagina);
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

        public DefaultResponse Save(ContaReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoConta(item);

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
                var newItem = new ContaDto
                {
                    documento_cliente = item.documento_cliente,
                    IdConta = newId
                };

                _ContaRepository.Save(newItem);
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

        public DefaultResponse Update(ContaReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoConta(item);

            var hasItem = _ContaRepository.GetByID(item.IdConta);

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
                hasItem.documento_cliente = item.documento_cliente;

                _ContaRepository.Update(hasItem);
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

        private List<string> validacaoConta(ContaReq item)
        {

            var resp = new List<string>();

            if (item.documento_cliente.Length > 20)
                resp.Add("Documento não pode ter mais 20 caracteres");

            return resp;
        }
    }
}
