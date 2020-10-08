namespace ProvaMG.App.Services
{
    public class UrlsConfig
    {
        public static string ObterMunicipios() => "/municipios";
        public static string ObterMunicipiosPor(string uf) => $"/municipios/{uf}";
        public static string ObterMunicipiosPorPaginado(string uf, int pagina) => $"/municipios/{uf}/{pagina}";
        public static string ObterUnidades = "/unidades";
        public static string AlterNomeMunicipio(short codigo) => $"/municipios/{codigo}";

        public static string Autenticar => $"/autenticacao";
    }
}