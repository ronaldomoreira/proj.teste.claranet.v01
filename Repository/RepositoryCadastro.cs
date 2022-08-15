using DomainApp.Entities;
using DomainApp.Interfaces;
using Repository.Base;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryCadastro : RepositoryBaseReadWrite<Cadastro>, IRepositoryCadastro
    {
        AppMainDbContext _context;

        public RepositoryCadastro(AppMainDbContext context): base(context)
        {
            _context = context;

        }
    }
}
