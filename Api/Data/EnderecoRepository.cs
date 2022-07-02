using Data.Context;
using Data.Context.Model;
using Data.Dto;
using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DefaultContext _ctx;
        public EnderecoRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }
        public void Delete(int item)
        {
            var resp = _ctx.Endereco.Where(x => x.idCliente == item).FirstOrDefault();

            if (resp != null) {
                resp.ativo = false;
                resp.dataExclusao = DateTime.Now;
                _ctx.SaveChanges();
            }
        }

        public EnderecoDto GetByID(int itemID)
        {
            var model =  _ctx.Endereco.Where(x => x.idEndereco == itemID).FirstOrDefault();

            if(model == null)
                return null;

            return Model_Dto(model);
        }

        public List<EnderecoDto> GetListCliente(int idCliente)
        {
            var model = _ctx.Endereco.Where(x => x.idCliente == idCliente).ToList();

            if (model == null)
                return null;

            return Model_Dto(model);
        }

        public List<EnderecoDto> Load()
        {
            var model = _ctx.Endereco.ToList();

            if (model == null)
                return null;

            return Model_Dto(model);
        }

        public void Save(EnderecoDto item)
        {
            var model = Dto_Model(item);
            model.dataCadastro = DateTime.Now;
            _ctx.Add(model);
            _ctx.SaveChanges();
        }

        public void Update(EnderecoDto item)
        {
            var model = Dto_Model(item);

            var _item = _ctx.Endereco.FirstOrDefault(x => x.idEndereco == model.idEndereco);

            _item.estado = model.estado;
            _item.idEndereco = model.idEndereco;
            _item.logradouro = model.logradouro;
            _item.complemento = model.complemento;
            _item.cep = model.cep;
            _item.bairro = model.bairro;
            _item.cidade = model.cidade;
            _item.dataAlteracao = DateTime.Now;
            _ctx.SaveChanges();
        }

        private Endereco Dto_Model(EnderecoDto dto) {

            var model = new Endereco
            {
                estado = dto.estado,
                idEndereco = dto.idEndereco,
                logradouro = dto.logradouro,
                complemento = dto.complemento,
                cep = dto.cep,
                bairro = dto.bairro,
                cidade = dto.cidade,

            };

            return model;
        }

        private EnderecoDto Model_Dto(Endereco model) {

            var dto = new EnderecoDto
            {
                estado = model.estado,
                idEndereco = model.idEndereco,
                logradouro = model.logradouro,
                complemento = model.complemento,
                cep = model.cep,
                bairro = model.bairro,
                cidade = model.cidade,
            };

            return dto;
        }

        private List<EnderecoDto> Model_Dto(List<Endereco> model)
        {
            var dto = new List<EnderecoDto>();

            foreach (var item in model)
            {
                var _item = new EnderecoDto
                {
                    estado = item.estado,
                    idEndereco = item.idEndereco,
                    logradouro = item.logradouro,
                    complemento = item.complemento,
                    cep = item.cep,
                    bairro = item.bairro,
                    cidade = item.cidade,
                };
                dto.Add(_item);
            }
            return dto;
        }

    }
}
