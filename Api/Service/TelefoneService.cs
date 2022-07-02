using Service.Dto;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TelefoneService : ITelefoneService
    {
        public DefaultResponse GetTiposTelefone()
        {
            Dictionary<string, string> tipos = new Dictionary<string, string>();
            tipos.Add("C", "Celular");
            tipos.Add("T", "Trabalho");
            tipos.Add("R", "Residencial");

            var resp = new DefaultResponse();
            try
            {
                resp.data = tipos; ;
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
