using Data.Context;
using Data.Context.Model;
using Data.Dto;
using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly DefaultContext _ctx;
        public TelefoneRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }

        public void Delete(int item)
        {
            var resp = _ctx.Telefone.Where(x => x.idCliente == item).FirstOrDefault();

            if (resp != null)
            {
                resp.ativo = false;
                resp.dataExclusao = DateTime.Now;
                _ctx.SaveChanges();
            }
        }

        public TelefoneDto GetByID(int itemID)
        {
            var model = _ctx.Telefone.Where(x => x.idCliente == itemID).FirstOrDefault();

            if (model == null)
                return null;

            return Model_Dto(model);
        }

        public List<TelefoneDto> GetListCliente(int idCliente)
        {
            var model = _ctx.Telefone.Where(x => x.idCliente == idCliente).ToList();

            if (model == null)
                return null;

            return Model_Dto(model);
        }

        public List<TelefoneDto> Load()
        {
            var model = _ctx.Telefone.ToList();

            if (model == null)
                return null;

            return Model_Dto(model);
        }

        public void Save(TelefoneDto item)
        {
            var model = Dto_Model(item);
            model.dataCadastro = DateTime.Now;
            _ctx.Add(model);
            _ctx.SaveChanges();
        }

        public void Update(TelefoneDto item)
        {
            var model = Dto_Model(item);

            var _item = _ctx.Telefone.FirstOrDefault(x => x.idTelefone == model.idTelefone);

            _item.ativo = model.ativo;
            _item.idTelefone = model.idTelefone;
            _item.dataCadastro = model.dataCadastro;
            _item.dataAlteracao = model.dataAlteracao;
            _item.dataExclusao = model.dataExclusao;
            _item.telefone = model.telefone;
            _item.tipoTelefone = model.tipoTelefone;
            _item.dataAlteracao = DateTime.Now;
            _ctx.SaveChanges();
        }

        private Telefone Dto_Model(TelefoneDto dto)
        {

            var model = new Telefone
            {
                ativo = dto.ativo,
                idTelefone = dto.idTelefone,
                telefone = dto.telefone,
                tipoTelefone = dto.tipoTelefone

            };

            return model;
        }

        private TelefoneDto Model_Dto(Telefone model)
        {

            var dto = new TelefoneDto
            {
                ativo = model.ativo,
                idTelefone = model.idTelefone,
                telefone = model.telefone,
                tipoTelefone = model.tipoTelefone
            };

            return dto;
        }

        private List<TelefoneDto> Model_Dto(List<Telefone> model)
        {
            var dto = new List<TelefoneDto>();

            foreach (var item in model)
            {
                var _item = new TelefoneDto
                {
                    ativo = item.ativo,
                    idTelefone = item.idTelefone,
                    telefone = item.telefone,
                    tipoTelefone = item.tipoTelefone
                };
                dto.Add(_item);
            }
            return dto;
        }
    }
}
