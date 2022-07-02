using System.Collections.Generic;

namespace Data.Dto
{
    public class Grid<T>
    {
        public int Pagina { get; set; }
        public decimal Total { get; set; }
        public int TotalDePaginas { get; set; }
        public int ItensPorPagina { get; internal set; }
        public ICollection<T> Itens { get; set; }
        
    }
}
