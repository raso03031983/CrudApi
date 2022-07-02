using Data.Dto;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IRedeSocialRepository
    {
        RedeSocialDto GetByID(int itemID);
        List<RedeSocialDto> GetListCliente(int idCliente);
        List<RedeSocialDto> Load();
        void Save(RedeSocialDto item);
        void Update(RedeSocialDto item);
        void Delete(int item);
        Dictionary<string, string> GetTipoRedeSocial();
    }
}
