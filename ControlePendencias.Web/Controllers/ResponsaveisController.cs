using ControlePendencias.Application.Interfaces;
using ControlePendencias.Application.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControlePendencias.Web.Controllers
{
    public class ResponsaveisController : Controller
    {
        private readonly IResponsavelApplication _responsavelApp;

        public ResponsaveisController(IResponsavelApplication responsavelApp)
        {
            _responsavelApp = responsavelApp;
        }

        // GET: Responsaveis
        public ActionResult Index()
        {            
            IEnumerable<ResponsavelViewModel> listaResponsaveisVm = _responsavelApp.BuscarTodos();
            return View(listaResponsaveisVm);
        }
    }
}