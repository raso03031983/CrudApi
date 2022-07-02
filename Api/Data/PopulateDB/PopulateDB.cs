using Bogus;
using Data.Context;
using Data.Context.Model;
using Data.PopulateDB.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Data.PopulateDB
{
    public class PopulateDB : IPopulateDB
    {
        private readonly DefaultContext _ctx;
        public PopulateDB(DefaultContext ctx)
        {
            _ctx = ctx;
        }

        void IPopulateDB.PopulateTables()
        {
            var clienteFaker = new Faker<Cliente>("pt_BR")
              .RuleFor(c => c.nome, f => f.Name.FullName())
              .RuleFor(c => c.dataNascimento, f => f.Date.Recent(100))
              .RuleFor(c => c.cpf, f => f.Random.Int(11).ToString())
              .RuleFor(c => c.rg, f => f.Random.Int(7).ToString())
              .RuleFor(c => c.dataCadastro, f => f.Date.Recent(100))
              .RuleFor(c => c.ativo, f => f.PickRandomParam(new bool[] { true, true, false }))
              .Generate(1000).ToList();

            _ctx.Cliente.AddRange(clienteFaker);
            _ctx.SaveChanges();

            var clientes = _ctx.Cliente.ToList();

            var enderecos = new List<Endereco>();
            var redeSocial = new List<RedeSocial>();
            var telefone = new List<Telefone>();

            foreach (var item in clientes)
            {
                var enderecoFaker = new Faker<Endereco>("pt_BR")
                 .RuleFor(c => c.logradouro, f => f.Address.StreetAddress())
                 .RuleFor(c => c.bairro, f => f.Address.BuildingNumber())
                 .RuleFor(c => c.cidade, f => f.Address.City())
                 .RuleFor(c => c.estado, f => f.Address.State().Substring(0, 2))
                 .RuleFor(c => c.cep, f => f.Address.ZipCode().Replace("-", ""))
                 .RuleFor(c => c.complemento, f => f.PickRandom(new string[] { $"Apt {item.idCliente}", $"Prox ao {f.Company.CompanyName()}", "", "", "" }))
                 .RuleFor(c => c.idCliente, f => item.idCliente)
                 .RuleFor(c => c.dataCadastro, f => f.Date.Recent(100))
                 .RuleFor(c => c.ativo, f => item.ativo)
                 .Generate();

                var redeSocialFaker = new Faker<RedeSocial>("pt_BR")
                .RuleFor(c => c.redeSocial, f => f.PickRandom(new string[] { $"https://www.linkedin.com/", $"https://www.facebook.com/", $"https://www.instagram.com/", $"https://www.youtube.com/channel/" }))
                .RuleFor(c => c.tipoRedeSocial, f => f.PickRandom(new string[] { "FA", "IN", "WH", "YO", "LI", "TW", "PI", "TI", "SK" }))
                .RuleFor(c => c.idCliente, f => item.idCliente)
                .RuleFor(c => c.dataCadastro, f => f.Date.Recent(100))
                .RuleFor(c => c.ativo, f => item.ativo)
                .Generate();

                var telefoneFaker = new Faker<Telefone>("pt_BR")
                 .RuleFor(c => c.telefone, f => f.Phone.PhoneNumberFormat())
                 .RuleFor(c => c.tipoTelefone, f => f.PickRandom(new string[] { "C", "R", "T" }))
                 .RuleFor(c => c.idCliente, f => item.idCliente)
                 .RuleFor(c => c.dataCadastro, f => f.Date.Recent(100))
                 .RuleFor(c => c.ativo, f => item.ativo)
                 .Generate();

                telefone.Add(telefoneFaker);
                redeSocial.Add(redeSocialFaker);
                enderecos.Add(enderecoFaker);
            }

            _ctx.Endereco.AddRange(enderecos);
            _ctx.RedeSocial.AddRange(redeSocial);
            _ctx.Telefone.AddRange(telefone);
            _ctx.SaveChanges();
        }
    }
}
