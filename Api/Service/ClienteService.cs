using Data.Dto;
using Data.Interface;
using Service.Dto;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
       
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public DefaultResponse Delete(int item)
        {
            var resp = new DefaultResponse();
            try
            {
                _clienteRepository.Delete(item);
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

        public DefaultResponse GetByID(int itemID)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _clienteRepository.GetByID(itemID); ;
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
                resp.data =  _clienteRepository.LoadPaginate(pagina);
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

        public DefaultResponse Save(ClienteDto item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoCliente(item);

            if (validate.Count > 0) {
                resp.message ="Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }
                
            try
            {
                _clienteRepository.Save(item);
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

        public DefaultResponse Update(ClienteDto item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoCliente(item);

            if (validate.Count > 0)
            {
                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
                _clienteRepository.Update(item);
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

        private List<string> validacaoCliente(ClienteDto item) {

            var resp = new List<string>();

            if (item.nome.Length > 100)
                resp.Add("Nome não pode ter mais 100 caracteres");

            if (item.cpf.Length > 11)
                resp.Add("CPF não pode ter mais 11 caracteres");

            if (item.rg.Length > 20)
                resp.Add("RG não pode ter mais 20 caracteres");

            if (item.dataNascimento < DateTime.MinValue || item.dataNascimento > DateTime.MaxValue)
                resp.Add("Data Nascimento inválida");

            return resp;
        }
    }
}
