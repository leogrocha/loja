using Microsoft.EntityFrameworkCore;
using Loja.API.Models;

namespace Loja.API.Data
{
    public class DataContext : DbContext
    {
        // Constructor
        public DataContext (DbContextOptions<DataContext> options) : base(options) {

        }

        // Definir as Entidades do BD
        public DbSet<Produto> Produtos {get; set;} 
    }
}