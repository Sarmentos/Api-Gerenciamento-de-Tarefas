using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repos.Interfecs;

namespace SistemaDeTarefas.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        [Route("todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult <List<Usuario>>>BuscarTodosUsuarios()
        {
            if (_usuarioRepositorio == null)
            {
                return NotFound();
            }
            //List<Usuario> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
           if (_usuarioRepositorio == null)
           {
               return NotFound();
           }
           Usuario usuarios = await _usuarioRepositorio.BuscarPorId(id);
            
           if (usuarios == null)
           {
               return NotFound();
           }

           return usuarios;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuarioModel)
        {
           Usuario usuario =  await _usuarioRepositorio.Adicionar(usuarioModel);

           return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar([FromBody] Usuario usuarioModel, int id)
        {
           if (_usuarioRepositorio == null)
           {
               return Problem("Erro ao criar um produto, contate o suporte!");
           }

           usuarioModel.Id = id;
           Usuario usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);

           return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Apagar(int id)
        {
           bool apagado = await _usuarioRepositorio.Apagar(id);

           return Ok(apagado);
        }

        [HttpGet]
        [Route("Teste")]
        public async Task<ActionResult> Teste()
        {
           return Ok("Pong");
        }

    }
}
