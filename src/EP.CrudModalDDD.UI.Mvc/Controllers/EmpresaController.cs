using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EP.CrudModalDDD.Application.Interfaces;
using EP.CrudModalDDD.Application.ViewModels;
using EP.CrudModalDDD.Infra.CrossCutting.MvcFilters;
using Microsoft.Ajax.Utilities;

namespace EP.CrudModalDDD.UI.Mvc.Controllers
{
    [Authorize]
    [RoutePrefix("administrativo-Empresa")]
    [Route("{action=listar}")]
    public class EmpresaController : BaseController
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresaController(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }

        //[ClaimsAuthorize("PermissoesCliente", "CL")]
        [Route("listar")]
        public ActionResult Index(string buscar, int pageNumber = 1)
        {
            var paged = _empresaAppService.ObterTodos(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;

            return View(paged.List);
        }

        //[ClaimsAuthorize("PermissoesCliente", "CV")]
		[Route("detalhes/{id:guid}")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel EmpresaViewModel = _empresaAppService.ObterPorId(id.Value);
            if (EmpresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(EmpresaViewModel);
        }

        //[ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("incluir-novo")]
        public ActionResult Create()
        {
            return View();
        }

        //[ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel EmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                EmpresaViewModel = _empresaAppService.Adicionar(EmpresaViewModel);

                if (!EmpresaViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in EmpresaViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(EmpresaViewModel);
                }


                if (!EmpresaViewModel.ValidationResult.Message.IsNullOrWhiteSpace())
                {
                    ViewBag.Sucesso = EmpresaViewModel.ValidationResult.Message;
                    return View(EmpresaViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(EmpresaViewModel);
        }

        //[ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("editar/{id:guid}")]
        public ActionResult Edit(Guid? id)
        {
            ViewBag.Acao = "Editar Empresa";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel EmpresaViewModel = _empresaAppService.ObterPorId(id.Value);
            if (EmpresaViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClienteId = id;
            return View(EmpresaViewModel);
        }

        //[ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpresaViewModel EmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                _empresaAppService.Atualizar(EmpresaViewModel);
                return RedirectToAction("Index");
            }
            return View(EmpresaViewModel);
        }

        //[ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel EmpresaViewModel = _empresaAppService.ObterPorId(id.Value);
            if (EmpresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(EmpresaViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("excluir/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _empresaAppService.Remover(id);
            return RedirectToAction("Index");
        }

        

        public ActionResult ObterImagemCliente(Guid id)
        {
            var root = @"D:\Labs\CursoMVC Update\src\contents\Empresa\";
            var foto = Directory.GetFiles(root, id+"*").FirstOrDefault();
           
            if (foto != null && !foto.StartsWith(root))
            {
                // Validando qualquer acesso indevido além da pasta permitida
                throw new HttpException(403, "Acesso Negado");
            }

            if(foto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return File(foto, "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _empresaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
