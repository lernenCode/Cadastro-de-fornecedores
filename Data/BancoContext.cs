using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cadastro_de_fornecedores.Models;

namespace Cadastro_de_fornecedores.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext (DbContextOptions<BancoContext> options) : base(options) {}

        public DbSet<FornecedoresModel> Fornecedores {get;set;}

    }
}