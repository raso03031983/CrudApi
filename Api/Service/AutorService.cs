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
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _AutorRepository;

        public AutorService(IAutorRepository AutorRepository)
        {
            _AutorRepository = AutorRepository;
        }

        public DefaultResponse GetByID(int itemID)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _AutorRepository.GetByID(itemID); ;
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

        public List<AutorDto> GetAll()
        {
            return _AutorRepository.GetAll();
        }

        public DefaultResponse LoadPaginate(int pagina)
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _AutorRepository.LoadPaginate(pagina);
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

        public DefaultResponse Save(AutorReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoAutor(item);

            if (validate.Count > 0)
            {
                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
               
                var newItem = new AutorDto
                {
                    Nome = item.Nome,
                };

                _AutorRepository.Save(newItem);
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

        public DefaultResponse Update(AutorReq item)
        {
            var resp = new DefaultResponse();

            var validate = validacaoAutor(item);

            var hasItem = _AutorRepository.GetByID(item.Cod);

            if (validate.Count > 0 || hasItem == null)
            {
                if (hasItem == null)
                    validate.Add("Autor não encontrado");

                resp.message = "Erro na Validação";
                resp.success = false;
                resp.erroList = validate;
                return resp;
            }

            try
            {
                hasItem.Nome = item.Nome;

                _AutorRepository.Update(hasItem);
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

        private List<string> validacaoAutor(AutorReq item)
        {

            var resp = new List<string>();

            if (item.Nome.Length > 40)
                resp.Add("Autor não pode ter mais de 20 caracteres");

            return resp;
        }
    }
}
