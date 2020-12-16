using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EncontrarDivisores.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected IActionResult Response(object data = null)
        {
            if (RequestSucceed())
                return Ok(data);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Messages", Errors.ToArray()}
            }));
        }

        protected ICollection<string> Errors = new List<string>();
        protected void NotifyError(string errorDescription)
        {
            Errors.Add(errorDescription);
        }
        protected bool RequestSucceed()
        {
            return !Errors.Any();
        }
        protected void ClearProcessErrors()
        {
            Errors.Clear();
        }
    }
}
