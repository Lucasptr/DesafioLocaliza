using EncontrarDivisores.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace EncontrarDivisores.API.Controllers
{
    [ApiController]
    [Route("api/encontrarDivisores")]
    public class EncontrarDivisoresController : MainController
    {
        [HttpGet("retornarDivisores")]
        public IActionResult RetornarDivisoresNumero(int numeroBase)
        {
            try
            {
                if (NumeroBaseInvalido(numeroBase))
                {
                    NotifyError("Número Inválido");
                    return Response();
                }

                var divisores = RetornarModelDivisoresNumero(numeroBase);
                return Response(divisores);

            } catch(Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        private bool NumeroBaseInvalido(int numeroBase)
        {
            return numeroBase <= 0;
        }

        private RetornoDivisoresNumero RetornarModelDivisoresNumero(int numeroBase)
        {
            var listaDivisores = new List<int>();
            var listaDivisoresPrimos = new List<int>();

            for (int i = 1; i <= numeroBase; i++)
            {
                if (EDivisorNumeroBase(numeroBase, i))
                {
                    if (DivisorEPrimo(i) && i != 1)
                    {
                        listaDivisoresPrimos.Add(i);
                    }
                    else
                    {
                        listaDivisores.Add(i);
                    }
                }
            }

            return MontarModelRetorno(listaDivisores, listaDivisoresPrimos);
        }

        private bool EDivisorNumeroBase(int numerBase, int  possivelDivisor)
        {
            return numerBase % possivelDivisor == 0;
        }

        private bool DivisorEPrimo(int possivelPrimo)
        {
            bool numeroEPrimo = true;

            for (int i = 2; i < possivelPrimo; i++)
            {
                if(EDivisorNumeroBase(possivelPrimo, i))
                {
                    numeroEPrimo = false;
                    return numeroEPrimo;
                }
            }

            return numeroEPrimo;
        }

        private RetornoDivisoresNumero MontarModelRetorno(List<int> listaDivisores, List<int> listaDivisoresPrimos)
        {
            return new RetornoDivisoresNumero(listaDivisores, listaDivisoresPrimos);
        }
    }
}
