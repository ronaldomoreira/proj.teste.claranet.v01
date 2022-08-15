using DomainApp.Entities;
using DomainApp.Interfaces.Business.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp.Interfaces
{
    public interface IBusinessServiceCadastro: IBusinessServiceBase<Cadastro>
    {
        bool ValidarDifAnos(int anoModelo, int anoFabricacao);

        IRepositoryCadastro RepositoryCadastro
        {
            get;
        }
    }
}
