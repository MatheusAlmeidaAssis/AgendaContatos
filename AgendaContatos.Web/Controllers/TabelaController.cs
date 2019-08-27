using AgendaContatos.Dominio.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendaContatos.Web.Controllers
{
    public class TabelaController : Controller
    {
        private readonly TabelaApplication _appTabela;

        public TabelaController()
        {
            _appTabela = new TabelaApplication();
        }
        public ActionResult Index()
        {
            var tabelas = _appTabela.Listar();
            return View(tabelas);
        }
    }
}