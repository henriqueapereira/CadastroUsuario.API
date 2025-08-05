using CadastroUsuario.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
