using EncontrarDivisores.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestAPI.API
{
    public class EncontrarDivisoresControllerTest
    {
        EncontrarDivisores.API.Controllers.EncontrarDivisoresController _encontrarDivisoresController;

        public EncontrarDivisoresControllerTest()
        {
            _encontrarDivisoresController = new EncontrarDivisoresController();
        }

        [Fact]
        public void EncontrarDivisores_NumeroValido()
        {
            var numeroBase = 32;

            var okResult = _encontrarDivisoresController.RetornarDivisoresNumero(numeroBase);

            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void EncontrarDivisores_NumeroInvalido()
        {
            var numeroBase = -5;

            var badRequestResult = _encontrarDivisoresController.RetornarDivisoresNumero(numeroBase);

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
        }

    }
}
