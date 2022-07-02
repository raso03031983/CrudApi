namespace Data.Dto
{
    public class EnderecoDto : DefaultValuesDto
    {
        public int idEndereco { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string complemento { get; set; }
    }
}
