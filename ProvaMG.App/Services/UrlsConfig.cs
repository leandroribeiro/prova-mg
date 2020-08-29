namespace ProvaMG.App.Services
{
    public class UrlsConfig
    {
        public static string ObterMunicipios() => "/municipios";
        public static string ObterMunicipiosPor(string uf) => $"/municipios/{uf}";
        public static string ObterUnidades = "/unidades";
    }
}