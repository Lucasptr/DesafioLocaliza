using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.MVC.Models
{
    public class DivisoresNumero
    {
        public int NumeroBase { get; set; }
        public List<int> Divisores { get; set; }
        public List<int> DivisoresPrimos { get; set; }
    }
}
