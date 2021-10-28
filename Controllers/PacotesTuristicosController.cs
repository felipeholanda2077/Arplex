using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atv_2.Models;

namespace Atv_2.Controllers
{
    public class PacotesTuristicosController : Controller
    {
        public IActionResult CadastrarPT() // Cadastrar os pacotes turisticos em uma pagina
        {
            return View();
        }

        public IActionResult EditarPT(int Id) // Edita os pacotes Turisticos em uma pagina
        {
            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();
            PacotesTuristicos PacoteEncontrado = pt.BuscarPorId(Id);
            return View(PacoteEncontrado);
        }

        [HttpPost]
        public IActionResult EditarPT(PacotesTuristicos Pacote)
        {

            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();

            pt.EditarPT(Pacote);

            return RedirectToAction("ListagemPT", "PacotesTuristicos");

        }

        public IActionResult ExcluirPT(int Id) // Eclui os pacotes
        {

            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();
            PacotesTuristicos PacoteEncontrado = pt.BuscarPorId(Id);
            pt.ExcluirPT(PacoteEncontrado);
            return RedirectToAction("ListagemPT", "PacotesTuristicos");
        }


        [HttpPost]
        public IActionResult CadastroPT(PacotesTuristicos Pacote)
        {

            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();

            pt.CadastrarPT(Pacote);

            return RedirectToAction("ListagemPT", "PacotesTuristicos");

        }

        public IActionResult ListagemPT() // Lista os pacotes
        {

            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();
            List<PacotesTuristicos> ListaPT = pt.ListarPT();
            return View(ListaPT);
        }
    }
}