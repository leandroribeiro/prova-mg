namespace ProvaMG.App.Services
{
    public class UrlsConfig
    {
        public static string ObterMunicipios() => "/municipios";
        public static string ObterMunicipiosPor(string uf) => $"/municipios/{uf}";
        public static string ObterMunicipiosPorPaginado(string uf, int pagina) => $"/municipios/{uf}/{pagina}";
        public static string ObterUnidades = "/unidades";
    }
}