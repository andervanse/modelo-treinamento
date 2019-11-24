using ControlePendencias.Application.Interfaces;
using ControlePendencias.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ControlePendencias.Web.Controllers
{
    public class PendenciasController : Controller
    {
        private readonly IPendenciaApplication _pendenciaApp;
        private readonly IResponsavelApplication _responsavelApp;

        public PendenciasController(
            IPendenciaApplication pendenciaApp,
            IResponsavelApplication responsavelApp)
        {
            _responsavelApp = responsavelApp;
            _pendenciaApp = pendenciaApp;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<PendenciaViewModel> listaPendenciasVm = _pendenciaApp.BuscarTodos();
            return View(listaPendenciasVm);
        }

        [HttpGet]
        public ActionResult Detalhe(int id = 0)
        {
            PendenciaViewModel listaPendenciasVm = _pendenciaApp.BuscarPorIdentificador(id);
            return View(listaPendenciasVm);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            PendenciaViewModel pendenciaVm = new PendenciaViewModel();            
            PopularViewBagResponsaveis(pendenciaVm);
            return View(pendenciaVm);
        }

        [HttpPost]
        public ActionResult Novo(PendenciaViewModel pendenciaVm)
        {

            if (ModelState.IsValid)
            {
                _pendenciaApp.Salvar(pendenciaVm);
                return RedirectToAction("Index");
            }
            else
            {
                PopularViewBagResponsaveis(pendenciaVm);
                return View(pendenciaVm);
            }
        }


        [HttpGet]
        public ActionResult Editar(int id = 0)
        {
            PendenciaViewModel pendencia = _pendenciaApp.BuscarPorIdentificador(id);
            PopularViewBagResponsaveis(pendencia);
            return View(pendencia);
        }


        [HttpPost]
        public ActionResult Editar(PendenciaViewModel pendenciaVm)
        {

            if (ModelState.IsValid)
            {
                _pendenciaApp.Salvar(pendenciaVm);
                return RedirectToAction("Index");
            }
            else
            {
                PopularViewBagResponsaveis(pendenciaVm);
                return View(pendenciaVm);
            }
        }

        [HttpGet]
        public ActionResult Excluir(int id = 0)
        {
            PendenciaViewModel pendencia = _pendenciaApp.BuscarPorIdentificador(id);
            return View(pendencia);
        }

        [ActionName("Excluir")]
        [HttpPost]
        public ActionResult ExcluirPendencia(int id = 0)
        {
            _pendenciaApp.Deletar(new PendenciaViewModel { Id = id });
            return RedirectToAction("Index");
        }

        private void PopularViewBagResponsaveis(PendenciaViewModel pendenciaVm)
        {
            IEnumerable<ResponsavelViewModel> responsaveisVm = _responsavelApp.BuscarTodos();
            var listaResponsaveis = new List<ResponsavelViewModel> { new ResponsavelViewModel { Id = 0, Nome = "Selecione" } };
            listaResponsaveis.AddRange(responsaveisVm);

            ViewBag.Responsaveis = listaResponsaveis
                                             .Select(resp => new SelectListItem
                                             {
                                                 Selected = (resp.Id == pendenciaVm.IdResponsavelSelecionado),
                                                 Text = resp.Nome,
                                                 Value = resp.Id.ToString()
                                             });
        }

    }
}
