using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncontrarDivisores.API.Models
{
    public class RetornoDivisoresNumero
    {
        public RetornoDivisoresNumero(List<int> listaDivisores, List<int> listaDivisoresPrimos)
        {
            Divisores = listaDivisores;
            DivisoresPrimos = listaDivisoresPrimos;
        }

        public List<int> Divisores { get; set; }
        public List<int> DivisoresPrimos { get; set; }
    }
}
