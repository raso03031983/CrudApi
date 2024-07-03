using Data.Dto;
using Data.Interface;
using Service.Dto;
using Service.Enum;
using Service.Interface;
using Service.Request;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _TransacaoRepository;
        private readonly ITipoTransacaoRepository _TipoTransacaoRepository;
        private readonly IContaRepository _ContaRepository;

        public TransacaoService(ITransacaoRepository TransacaoRepository,
                                ITipoTransacaoRepository TipoTransacaoRepository,
                                IContaRepository contaRepository)
        {
            _TransacaoRepository = TransacaoRepository;
            _TipoTransacaoRepository = TipoTransacaoRepository;
            _ContaRepository = contaRepository;
        }

        public DefaultResponse GetByID(Guid itemID)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _TransacaoRepository.GetByID(itemID); ;
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
                resp.data = _TransacaoRepository.LoadPaginate(pagina);
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

        public DefaultResponse Save(TransacaoReq item)
        {
            var resp = new DefaultResponse();

            item.Valor = prepareValorTransacao(item);

            var validate = validacaoTransacao(item);

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
                
                var newItem = new TransacaoDto { 
                    IdConta = item.IdConta,
                    DataHora = DateTime.Now,
                    IdTransacao = newId,
                    IdTipoTransacao = item.IdTipoTransacao,
                    Valor = item.Valor,
                };

                _TransacaoRepository.Save(newItem);
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

        public DefaultResponse Update(TransacaoReq item)
        {
            var resp = new DefaultResponse();

            item.Valor = prepareValorTransacao(item);

            var validate = validacaoTransacao(item);

            var hasItem = _TransacaoRepository.GetByID(item.IdConta);

            if (validate.Count > 0 || hasItem == null)
            {
                if (hasItem == null)
                    validate.Add("Trnsação nãa encontrada");

                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
                hasItem.IdConta = item.IdConta;
                hasItem.DataHora = DateTime.Now;
                hasItem.IdTipoTransacao = item.IdTipoTransacao;
                hasItem.Valor = item.Valor;

                _TransacaoRepository.Update(hasItem);
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

        private List<string> validacaoTransacao(TransacaoReq item)
        {

            var resp = new List<string>();

            var hasConta = _ContaRepository.GetByID(item.IdConta);
            var hasTipoTransacao = _TipoTransacaoRepository.GetByID(item.IdTipoTransacao);

            if (hasConta == null)
                resp.Add("Conta não cadastrada");

            if (hasTipoTransacao == null)
                resp.Add("Tipo Transação não cadastrada");

            if (item.Valor == 0)
                resp.Add("Valor transação inválida");

            return resp;
        }

        private decimal prepareValorTransacao(TransacaoReq item)
        {
            if ((int)EnumTipoOperacao.Compra == item.IdTipoTransacao)
               return item.Valor * -1;

            if ((int)EnumTipoOperacao.Pagamento == item.IdTipoTransacao)
                return Math.Abs(item.Valor);

            return 0;
        }
    }
}
