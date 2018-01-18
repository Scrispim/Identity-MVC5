using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Dapper;
using EP.CrudModalDDD.Domain.DTO;
using EP.CrudModalDDD.Domain.Entities;
using EP.CrudModalDDD.Domain.Interfaces.Repository;
using EP.CrudModalDDD.Infra.Data.Context;

namespace EP.CrudModalDDD.Infra.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {

        public EmpresaRepository(CrudModalDDDContext context)
            : base(context)
        {
            
        }
        
        //public Empresa ObterPorEmail(string email)
        //{
        //    return Buscar(c => c.Email == email).FirstOrDefault();
        //}

        public Paged<Empresa> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Empresa " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') " +
                      "ORDER BY [Nome] " +
                      "OFFSET " + pageSize*(pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                      " " +
                      "SELECT COUNT(EmpresaId) FROM Empresa " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') ";

            var multi = cn.QueryMultiple(sql, new {Nome = nome});
            var empresa = multi.Read<Empresa>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<Empresa>()
            {
                List = empresa,
                Count = total
            };

            return pagedList;
        }

        public override Empresa ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Empresa c " +
                       "WHERE c.EmpresaId = @sid";

            var Empresa = new List<Empresa>();
            //cn.Query<Empresa, Endereco, Empresa>(sql,
            //    (c, e) =>
            //    {
            //        Empresa.Add(c);
            //        if(e != null)
            //            Empresa[0].Enderecos.Add(e);

            //        return Empresa.FirstOrDefault();
            //    }, new { sid = id }, splitOn: "EmpresaId, EnderecoId");

            //throw new Exception("MORTE!!!");

            return Empresa.FirstOrDefault();
        }

		public Empresa ObterPorBairro(string bairro)
		{
			throw new NotImplementedException();
		}
	}
}