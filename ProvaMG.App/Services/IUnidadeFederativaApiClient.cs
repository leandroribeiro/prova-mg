using System.Collections.Generic;

namespace ProvaMG.App.Services
{
    public interface IUnidadeFederativaApiClient
    {
        IEnumerable<string> ObterTodas();
    }
}