using System.Collections.Generic;

namespace Service.Request
{
    public  class LivroReq
    {
        public int Cod { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public int AutorId { get; set; }
        public int AssuntoId { get; set; }
        public List<int> AssuntoIds { get; set; }
        public List<int> AutoresIds { get; set; }
    }
}
