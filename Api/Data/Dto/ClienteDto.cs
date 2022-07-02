using System;
using System.Collections.Generic;

namespace Data.Dto
{
    public class ClienteDto : DefaultValuesDto
    {
        public int idCliente { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public List<EnderecoDto> endereco { get; set; }
        public List<TelefoneDto> telefone { get; set; }
        public List<RedeSocialDto> redeSocial { get; set; }
    }
}
