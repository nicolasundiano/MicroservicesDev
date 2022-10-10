using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Servicios.api.Seguridad.Core.Application;
using Servicios.api.Seguridad.Core.Dto;

namespace Servicios.api.Seguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UsuarioController(IMediator mediator, IConfiguration configuration) {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioDto>> Registrar(Register.UsuarioRegisterCommand parametros) {
            return await _mediator.Send(parametros);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(Login.UsuarioLoginCommand parametros)
        {
            var x = _configuration.GetSection("ConnectionStrings:ConexionDB");
            return Ok(x);
            //return await _mediator.Send(parametros);
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> Get()
        {
            return await _mediator.Send(new UsuarioActual.UsuarioActualCommand());
        }


    }
}
