using DomainApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class AppMainDbContext : DbContext
    {
        public AppMainDbContext(DbContextOptions<AppMainDbContext> options)
                 : base(options)
        {
            //
        }

        public DbSet<Cadastro> dbCadastro { get; set; }

    }
}
