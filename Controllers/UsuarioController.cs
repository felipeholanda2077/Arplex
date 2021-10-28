using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Atv_2.Models;

namespace Atv_2.Controllers
{
    public class UsuarioController: Controller
    {

        public IActionResult Login(){ // Faz o login na pagina
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario u){
           
           UsuarioRepository ur = new UsuarioRepository();
           Usuario userEncontrado = ur.ValidarLogin(u);

           if (userEncontrado==null){
              ViewBag.Mensagem = "Falha no Login!";
              return View();
            } else {
              
              //registrar na sessao: ID e nome do Usuario logado
              HttpContext.Session.SetInt32("IdUsuario",userEncontrado.Id);
              HttpContext.Session.SetString("NomeUsuario",userEncontrado.Nome);

              return RedirectToAction("Listagem","Usuario");
            }
        
        }

        public IActionResult Logout(){ // Sai do login da pagina inteira
            HttpContext.Session.Clear(); //Limpa todos os dados registrados na sessao
            return RedirectToAction("Login","Usuario");
        }

        public IActionResult Cadastro(){

            return View();
        }

       public IActionResult Editar(int Id){

           UsuarioRepository ur = new UsuarioRepository();
           Usuario userEncontrado = ur.BuscarPorId(Id);
           return View(userEncontrado);
       }

       [HttpPost]
        public IActionResult  Editar(Usuario u){
            
            UsuarioRepository ur = new UsuarioRepository();

            ur.Editar(u);

            return RedirectToAction("Listagem","Usuario");

        }
        
       public IActionResult Excluir(int Id){ // Exclui o Usuario Cadastrado
           
           UsuarioRepository ur = new UsuarioRepository();
           Usuario userEncontrado = ur.BuscarPorId(Id);
           ur.Excluir(userEncontrado);
           return RedirectToAction("Listagem","Usuario");
       }


        [HttpPost]
        public IActionResult  Cadastro(Usuario u){

            UsuarioRepository ur = new UsuarioRepository();

            ur.Cadastrar(u);

            return RedirectToAction("Listagem","Usuario");

        }

        public IActionResult Listagem(){

           
            UsuarioRepository ur = new UsuarioRepository();
            List<Usuario> Lista = ur.Listar();
            return View(Lista);
        }

    }
}