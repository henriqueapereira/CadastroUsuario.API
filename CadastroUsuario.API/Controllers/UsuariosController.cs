using CadastroUsuario.API.Data;
using CadastroUsuario.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;
    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Usuario usuario)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Usuarios.ToList());
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null)
            return NotFound();
        
        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();


        return Ok(_context.Usuarios.ToList());
    }
}
