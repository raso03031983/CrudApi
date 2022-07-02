using System.Collections.Generic;

namespace Service.Dto
{
    public class DefaultResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<string> erroList { get; set; }
        public object data { get; set; }
    }
}
