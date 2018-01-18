using System;
using EP.CrudModalDDD.Application.ViewModels;

namespace EP.CrudModalDDD.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        EmpresaViewModel Adicionar(EmpresaViewModel empresaViewModel);
        EmpresaViewModel ObterPorId(Guid id);
        EmpresaViewModel ObterPorBairro(string bairro);
        //EmpresaViewModel ObterPorEmail(string email);
        PagedViewModel<EmpresaViewModel> ObterTodos(string nome, int pageSize, int pageNumber);
        EmpresaViewModel Atualizar(EmpresaViewModel EmpresaViewModel);
        void Remover(Guid id);
    }
}