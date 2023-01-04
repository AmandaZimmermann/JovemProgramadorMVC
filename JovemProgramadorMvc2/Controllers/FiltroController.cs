using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc2.Controllers
{
    public class FiltroController : Controller
    {
        public FiltroController()
        {

        }

        public IActionResult BuscarFiltros()
        {
            return View();

        }
    }
}
