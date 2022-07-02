namespace Service
{
    public class ToolsService
    {
        public string retiraCaracter(string telefone)
        {
            var _telefone = telefone.Replace("-", "").Replace("(", "").Replace(")", "").Replace(".", "");
            return _telefone;
        }
    }
}
