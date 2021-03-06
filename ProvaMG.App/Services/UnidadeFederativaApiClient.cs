﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ProvaMG.App.Services
{
    public class UnidadeFederativaApiClient : BaseApiClient, IUnidadeFederativaApiClient
    {
        private readonly HttpClient _httpClient;

        public UnidadeFederativaApiClient(IConfiguration configuration, HttpClient httpClient) : base(configuration)
        {
            _httpClient = httpClient;
        }
        public IEnumerable<string> ObterTodas()
        {
            var response = _httpClient.GetAsync($"{UrlBase}{UrlsConfig.ObterUnidades}").Result;

            response.EnsureSuccessStatusCode();

            var ordersDraftResponse = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<string>>(ordersDraftResponse);
        }
    }
}