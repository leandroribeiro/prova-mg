using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProvaMG.Application;
using ProvaMG.Domain;
using ProvaMG.Domain.Entities;
using ProvaMG.Domain.Repositories;
using ProvaMG.Infrasctructure;

namespace ProvaMG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            this._repository = repository;
        }

        [Authorize]
        [ProducesResponseType(typeof(List<Usuario>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public IActionResult GetAllSync()
        {
            var usuarios = _repository.ObterTodos();
            
            return Ok(usuarios);
        }

    }
}