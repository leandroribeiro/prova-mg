using System.Collections.Generic;
using ProvaMG.App.Controllers;

namespace ProvaMG.App.Models
{
    public class IndexViewModel
    {
        public IEnumerable<MunicipioViewModel> Municipios { get; set; }
        public IEnumerable<string> Unidades { get; set; }

        public IndexViewModel()
        {
            this.Unidades = new List<string>();
            this.Municipios = new List<MunicipioViewModel>();
        }
    }
}