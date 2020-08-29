using System.Collections.Generic;
using ProvaMG.App.Models;

namespace ProvaMG.App.Services
{
    public interface IMunicipiosApiClient
    {
        IEnumerable<MunicipioViewModel> Obter(string uf);
        MunicipioPageListViewModel Obter(string uf, int pagina);
    }
}