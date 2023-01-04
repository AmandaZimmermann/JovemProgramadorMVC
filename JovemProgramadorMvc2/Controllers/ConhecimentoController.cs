using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc2.Controllers
{
    public class ConhecimentoController : Controller
    {
    
        public ConhecimentoController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
