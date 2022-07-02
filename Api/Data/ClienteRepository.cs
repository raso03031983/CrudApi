using Data.Context;
using Data.Context.Model;
using Data.Dto;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DefaultContext _ctx;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IRedeSocialRepository _redeSocialRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        public ClienteRepository(DefaultContext ctx, ITelefoneRepository telefoneRepository,IRedeSocialRepository redeSocialRepository, IEnderecoRepository enderecoRepository)
        {
            _ctx = ctx;
            _telefoneRepository = telefoneRepository;
            _redeSocialRepository = redeSocialRepository;
            _enderecoRepository = enderecoRepository;
        }

        public void Delete(int item)
        {
            var cli = _ctx.Cliente.Where(x => x.idCliente == item).FirstOrDefault();

            cli.dataExclusao = DateTime.Now;
            cli.ativo = false;
            _ctx.SaveChanges();

            _telefoneRepository.Delete(item);
            _enderecoRepository.Delete(item);
            _redeSocialRepository.Delete(item);
        }

        public ClienteDto GetByID(int itemID)
        {
            var model = _ctx.
                               Cliente
                               .Where(x => x.idCliente == itemID)
                               .AsNoTracking()
                               .Select(x => new ClienteDto { 
                                    idCliente = x.idCliente,
                                    ativo = x.ativo,
                                    cpf = x.cpf,
                                    dataNascimento = x.dataNascimento,
                                    nome = x.nome,
                                    rg = x.rg
                               }).FirstOrDefault();

            if(model == null)
                return null;

            model.telefone = _telefoneRepository.GetListCliente(model.idCliente);
            model.endereco = _enderecoRepository.GetListCliente(model.idCliente);
            model.redeSocial = _redeSocialRepository.GetListCliente(model.idCliente);

            return model;
        }

        public Grid<ClienteDto> LoadPaginate(int pagina)
        {
            var retorno = _ctx
                 .Cliente
                 .AsNoTracking()
                 .Where(x => x.ativo);

            var totalPaginas = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(retorno.Count()) / Convert.ToDecimal(ToolsData.TAMANHO_PAGINACAO)));

            return new Grid<ClienteDto>()
            {
                ItensPorPagina = ToolsData.TAMANHO_PAGINACAO,
                Pagina = pagina,
                Total = retorno.Count(),
                TotalDePaginas = totalPaginas,
                Itens = retorno.Select(x => new ClienteDto
                {
                    idCliente = x.idCliente,
                    nome = x.nome,
                    ativo = x.ativo,
                    cpf = x.cpf,
                    dataNascimento = x.dataNascimento,
                    rg = x.rg,
                    endereco = _enderecoRepository.GetListCliente(x.idCliente),
                    redeSocial = _redeSocialRepository.GetListCliente(x.idCliente),
                    telefone = _telefoneRepository.GetListCliente(x.idCliente)
                })
                .Skip((pagina - 1) * ToolsData.TAMANHO_PAGINACAO)
                .Take(ToolsData.TAMANHO_PAGINACAO)
                .OrderBy(x => x.nome)
                .ToList()
            };
        }

        public void Save(ClienteDto item)
        {
            var model = Dto_Model(item);
            model.dataCadastro = DateTime.Now;
            _ctx.Add(model);
            _ctx.SaveChanges();

            foreach (var telefones in item.telefone)
            {
                item.idCliente = model.idCliente;
                _telefoneRepository.Save(telefones);
            }

            foreach (var enderecos in item.endereco)
            {
                item.idCliente = model.idCliente;
                _enderecoRepository.Save(enderecos);
            }

            foreach (var rede in item.redeSocial)
            {
                item.idCliente = model.idCliente;
                _redeSocialRepository.Save(rede);
            }


        }

        public void Update(ClienteDto item)
        {
            var cliente = _ctx.Cliente.Where(x => x.idCliente == item.idCliente).FirstOrDefault();

            cliente.ativo = true;
            cliente.cpf = item.cpf;
            cliente.dataNascimento = item.dataNascimento;
            cliente.nome = item.nome;
            cliente.rg = item.rg;
            _ctx.SaveChanges();

            if (item.endereco != null)
            {
                foreach (var _item in item.endereco)
                {
                    _enderecoRepository.Update(_item);
                }
            }

            if (item.telefone != null)
            {
                foreach (var _item in item.telefone)
                {
                    _telefoneRepository.Update(_item);
                }
            }

            if (item.redeSocial != null)
            {
                foreach (var _item in item.redeSocial)
                {
                    _redeSocialRepository.Update(_item);
                }
            }





        }

        private ClienteDto Model_Dto(Cliente model)
        {

            var dto = new ClienteDto
            {
                idCliente = model.idCliente,
                ativo = model.ativo,
                cpf = model.cpf,
                dataNascimento = model.dataNascimento,
                nome = model.nome,
                rg = model.rg
            };

            return dto;
        }

        private Cliente Dto_Model(ClienteDto dto)
        {

            var model = new Cliente
            {
                idCliente = dto.idCliente,
                ativo = dto.ativo,
                cpf = dto.cpf,
                dataNascimento = dto.dataNascimento,
                nome = dto.nome,
                rg = dto.rg
            };

            return model;
        }

    }
}
