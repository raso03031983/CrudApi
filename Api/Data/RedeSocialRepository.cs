using Data.Context;
using Data.Context.Model;
using Data.Dto;
using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class RedeSocialRepository : IRedeSocialRepository
    {
        private readonly DefaultContext _ctx;
        public RedeSocialRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }

        public void Delete(int item)
        {
            var resp = _ctx.RedeSocial.Where(x => x.idCliente == item).FirstOrDefault();

            if (resp != null)
            {
                resp.ativo = false;
                resp.dataExclusao = DateTime.Now;
                _ctx.SaveChanges();
            }
        }

        public RedeSocialDto GetByID(int itemID)
        {
            var model = _ctx.RedeSocial.Where(x => x.idRedeSocial == itemID).FirstOrDefault();

            if (model == null)
                return null;

            return Model_Dto(model);
        }

        public List<RedeSocialDto> GetListCliente(int idCliente)
        {
            var model = _ctx.RedeSocial.Where(x => x.idCliente == idCliente).ToList();

            if (model == null)
                return null;

            return Model_Dto(model);
        }

        public List<RedeSocialDto> Load()
        {
            var model = _ctx.RedeSocial.ToList();

            if (model == null)
                return null;

            return Model_Dto(model);
        }

        public void Save(RedeSocialDto item)
        {
            var model = Dto_Model(item);
            _ctx.Add(model);
            _ctx.SaveChanges();
        }

        public void Update(RedeSocialDto item)
        {
            var model = Dto_Model(item);

            var _item = _ctx.RedeSocial.FirstOrDefault(x => x.idRedeSocial == model.idRedeSocial);

            _item.idRedeSocial = model.idRedeSocial;
            _item.ativo = model.ativo;
            _item.dataAlteracao = model.dataAlteracao;
            _item.dataCadastro = model.dataCadastro;
            _item.dataExclusao = model.dataExclusao;
            _item.redeSocial = model.redeSocial;
            _item.dataAlteracao = DateTime.Now;
            _ctx.SaveChanges();
        }

        private RedeSocial Dto_Model(RedeSocialDto dto)
        {

            var model = new RedeSocial
            {
               idRedeSocial = dto.idRedeSocial,
               ativo = dto.ativo,
               redeSocial = dto.redeSocial
            };

            return model;
        }

        private RedeSocialDto Model_Dto(RedeSocial model)
        {

            var dto = new RedeSocialDto
            {
                idRedeSocial = model.idRedeSocial,
                ativo = model.ativo,
                redeSocial = model.redeSocial
            };

            return dto;
        }

        private List<RedeSocialDto> Model_Dto(List<RedeSocial> model)
        {
            var dto = new List<RedeSocialDto>();

            foreach (var item in model)
            {
                var _item = new RedeSocialDto
                {
                    idRedeSocial = item.idRedeSocial,
                    ativo = item.ativo,
                    redeSocial = item.redeSocial
                };
                dto.Add(_item);
            }
            return dto;
        }

        public Dictionary<string, string> GetTipoRedeSocial()
        {

            Dictionary<string, string> itens = new Dictionary<string, string>();
            itens.Add("FA", "Facebook");
            itens.Add("IN", "Instagram");
            itens.Add("WH", "WhatsApp");
            itens.Add("YO", "YouTube");
            itens.Add("LI", "LinkedIn");
            itens.Add("TW", "Twitter");
            itens.Add("PI", "Pinterest");
            itens.Add("TI", "TikTok");
            itens.Add("SK", "Skype");

            return itens;
        }
    }
}
