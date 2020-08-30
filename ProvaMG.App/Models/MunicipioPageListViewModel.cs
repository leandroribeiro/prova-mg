using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProvaMG.App.Models
{
    public class MunicipioPageListViewModel
    {
        [JsonProperty("results")]
        public IList<MunicipioViewModel> Results { get; set; }
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }
        [JsonProperty("pageCount")]
        public int PageCount { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        [JsonProperty("rowCount")]
        public int RowCount { get; set; }
        [JsonProperty("firstRowOnPage")]
        public int FirstRowOnPage { get; set; }
        [JsonProperty("lastRowOnPage")]
        public int LastRowOnPage { get; set; }
    }
}