using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using AutoMapper;
using EP.CrudModalDDD.Application.Interfaces;
using EP.CrudModalDDD.Application.ViewModels;
using EP.CrudModalDDD.Domain.Entities;
using EP.CrudModalDDD.Domain.Interfaces.Service;
using EP.CrudModalDDD.Infra.Data.Interfaces;

namespace EP.CrudModalDDD.Application
{
    public class EmpresaAppService : ApplicationService, IEmpresaAppService
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaAppService(IEmpresaService empresaService, IUnitOfWork uow)
            : base(uow)
        {
			_empresaService = empresaService;
        }

        public EmpresaViewModel Adicionar(EmpresaViewModel EmpresaViewModel)
        {
            var empresa = Mapper.Map<Empresa>(EmpresaViewModel);
			
            //var foto = EmpresaViewModel.Foto;

            BeginTransaction();

            var EmpresaReturn = _empresaService.Adicionar(empresa);
            EmpresaViewModel = Mapper.Map<EmpresaViewModel>(EmpresaReturn);
            //if (!EmpresaReturn.ValidationResult.IsValid)
            //{
            //    // Não faz o commit
            //    return EmpresaViewModel;
            //}

            //if (!SalvarImagemEmpresa(foto, EmpresaViewModel.EmpresaId))
            //{
            //    // Tomada de decisão caso a imagem não seja gravada.
            //    EmpresaViewModel.ValidationResult.Message = "Empresa salvo sem foto";
            //}

            Commit();

            return EmpresaViewModel;
        }

        public EmpresaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<EmpresaViewModel>(_empresaService.ObterPorId(id));
        }

        public EmpresaViewModel ObterPorBairro(string bairro)
        {
            return Mapper.Map<EmpresaViewModel>(_empresaService.ObterPorBairro(bairro));
        }

        //public EmpresaViewModel ObterPorEmail(string email)
        //{
        //    return Mapper.Map<EmpresaViewModel>(_empresaService.ObterPorEmail(email));
        //}

        public PagedViewModel<EmpresaViewModel> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            return Mapper.Map<PagedViewModel<EmpresaViewModel>>(_empresaService.ObterTodos(nome, pageSize, pageNumber));
        }

        public EmpresaViewModel Atualizar(EmpresaViewModel EmpresaViewModel)
        {
            BeginTransaction();
            _empresaService.Atualizar(Mapper.Map<Empresa>(EmpresaViewModel));
            Commit();
            return EmpresaViewModel;
        }

        public void Remover(Guid id)
        {
            BeginTransaction();
            _empresaService.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _empresaService.Dispose();
            GC.SuppressFinalize(this);
        }

        private static bool SalvarImagemEmpresa(HttpPostedFileBase img, Guid id)
        {
            if (img == null || img.ContentLength <= 0) return false;

            const string directory = @"D:\Labs\CursoMVC Update\src\contents\Empresas\";
            var fileName = id + Path.GetExtension(img.FileName);
            img.SaveAs(Path.Combine(directory, fileName));
            return File.Exists(Path.Combine(directory, fileName));
        }
    }
}