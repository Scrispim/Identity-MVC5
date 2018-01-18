using System;
using EP.CrudModalDDD.Domain.DTO;
using EP.CrudModalDDD.Domain.Entities;

namespace EP.CrudModalDDD.Domain.Interfaces.Service
{
    public interface IEmpresaService : IDisposable
    {
        Empresa Adicionar(Empresa empresa);
		Empresa ObterPorId(Guid id);
		Empresa ObterPorBairro(string bairro);
		//Empresa ObterPorEmail(string email);
        Paged<Empresa> ObterTodos(string nome, int pageSize, int pageNumber);
		Empresa Atualizar(Empresa empresa);
        void Remover(Guid id);
		
    }
}