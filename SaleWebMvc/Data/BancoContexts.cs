using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Models;

namespace SaleWebMvc.Data {
    public class BancoContexts : DbContext {

        public BancoContexts(DbContextOptions<BancoContexts> options) : base(options) { 
        }
        
        // Tabela
        public DbSet<ContatoModel> Contatos { get; set; }

    }
}
/*
O DbContext é responsável por gerenciar a comunicação direta com o banco de dados 
e rastrear as mudanças nas entidades.
*/