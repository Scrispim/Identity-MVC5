using EP.CrudModalDDD.Domain.DTO;
using EP.CrudModalDDD.Domain.Entities;

namespace EP.CrudModalDDD.Domain.Interfaces.Repository
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
		Empresa ObterPorBairro(string bairro);
		//Empresa ObterPorEmail(string email);
        Paged<Empresa> ObterTodos(string nome, int pageSize, int pageNumber);
    }
}