using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public UsuariosController(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UsuarioDTO>> Get()
    {
        var usuarios = _uof.UsuarioRepository.GetAll();
        if (usuarios is null)
        {
            return NotFound();
        }
        var usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        return Ok(usuariosDTO);
    }

    [HttpGet("{id:int}")]
    public ActionResult<UsuarioDTO> GetById(int id)
    {
        var usuario = _uof.UsuarioRepository.Get(p => p.UsuarioId == id);

        if (usuario is null)
            return NotFound("Usuário não encontrado...");

        var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);

        return Ok(usuarioDto);
    }

    [HttpPost]
    public ActionResult<UsuarioDTO> Post(UsuarioPostDTO usuarioPostDTO)
    {
        if (usuarioPostDTO is null)
            return BadRequest();

        var usuario = _mapper.Map<Usuario>(usuarioPostDTO);

        var novoUsuario = _uof.UsuarioRepository.Create(usuario);
        _uof.Commit();

        var novoUsuarioDTO = _mapper.Map<UsuarioDTO>(novoUsuario);

        return Ok(novoUsuarioDTO);
    }

    [HttpPut("{id:int}")]
    public ActionResult<UsuarioDTO> Put(int id, UsuarioPostDTO usuarioDTO)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDTO);
        usuario.UsuarioId = id;

        var usuarioAtualizado = _uof.UsuarioRepository.Update(usuario);
        _uof.Commit();

        var usuarioAtualizadoDTO = _mapper.Map<UsuarioDTO>(usuarioAtualizado);

        return Ok(usuarioAtualizadoDTO);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<UsuarioDTO> Delete(int id)
    {
        var usuario = _uof.UsuarioRepository.Get(p => p.UsuarioId == id);
        if (usuario is null)
        {
            return NotFound("Usuário não encontrado...");
        }

        var usuarioDeletado = _uof.UsuarioRepository.Delete(usuario);
        _uof.Commit();

        var usuarioDeletadoDTO = _mapper.Map<UsuarioDTO>(usuarioDeletado);

        return Ok(usuarioDeletadoDTO);
    }
}