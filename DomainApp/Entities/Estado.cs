using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp.Entities
{
    public class Estado
    {
        public Estado()
        {
            Sigla = String.Empty;
            Descricao = String.Empty;
            
        }

        public string Sigla { get; set; }
        public string Descricao { get; set; }
    }
}
