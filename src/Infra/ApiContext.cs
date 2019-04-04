using ESX.DesafioSimplificado.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ESX.DesafioSimplificado.Infra
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Patrimonio> Patrimonio { get; set; }

        public DbSet<Marca> Marca { get; set; }
    }
}
