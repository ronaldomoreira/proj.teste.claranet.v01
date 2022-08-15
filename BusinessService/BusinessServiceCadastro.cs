using BusinessService.Base;
using DomainApp.Entities;
using DomainApp.Interfaces;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSevice
{
    public class BusinessServiceCadastro: BusinessServiceBase<Cadastro>, IBusinessServiceCadastro
    {
        private IRepositoryCadastro _repositoryCadastro;

        public bool ValidarDifAnos(int anoModelo, int anoFabricacao)
        {
            int difAnos = anoModelo - anoFabricacao;
            return ((difAnos >= 0) && (difAnos <= 1));
        }

        public BusinessServiceCadastro(IRepositoryCadastro repositoryCadastro) : base(repositoryCadastro)
        {
            _repositoryCadastro = repositoryCadastro;
        }

        public IRepositoryCadastro RepositoryCadastro 
        { 
            get { return _repositoryCadastro;}
        }

        public override Task<Cadastro?> Add(Cadastro item)
        {
            //if (!ValidarDifAnos(item.AnoModelo, item.AnoFabricacao))
            //{
            //    throw new Exception("Ano de fabricação e do modelo, devem ser iguais, ou no máximo ter uma diferença de 1 ano.");
            //}  

            return base.Add(item);  
        }

        public override void Update(Cadastro item)
        {
            //if (!ValidarDifAnos(item.AnoModelo, item.AnoFabricacao))
            //{
            //    throw new Exception("Ano de fabricação e do modelo, devem ser iguais, ou no máximo ter uma diferença de 1 ano.");
            //}

            base.Update(item);
        }
    }
}
