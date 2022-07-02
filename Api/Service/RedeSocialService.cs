using Data.Interface;
using Service.Dto;
using Service.Interface;
using System;

namespace Service
{
    public class RedeSocialService : IRedeSocialService
    {
        private readonly IRedeSocialRepository _redeSocialRepository;

        public RedeSocialService(IRedeSocialRepository redeSocialRepository)
        {
            _redeSocialRepository = redeSocialRepository;
        }


        public DefaultResponse GetRedeSocial()
        {
            var resp = new DefaultResponse();
            try
            {
                resp.data = _redeSocialRepository.GetTipoRedeSocial();
                resp.success = true;
                return resp;
            }
            catch (Exception ex)
            {
                resp.message = ex.Message;
                resp.success = false;
                return resp;
            }
        }
    }
}
