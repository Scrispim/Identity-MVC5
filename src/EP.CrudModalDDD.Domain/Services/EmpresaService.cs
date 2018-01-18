using System;
using EP.CrudModalDDD.Domain.DTO;
using EP.CrudModalDDD.Domain.Entities;
using EP.CrudModalDDD.Domain.Interfaces.Repository;
using EP.CrudModalDDD.Domain.Interfaces.Service;
using EP.CrudModalDDD.Domain.Validations.Clientes;

namespace EP.CrudModalDDD.Domain.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public Empresa Adicionar(Empresa empresa)
        {
            if(!empresa.IsValid())
            {
                return empresa;
            }

            //empresa.ValidationResult = new ClienteAptoParaCadastroValidation(_empresaRepository).Validate(empresa);
            //if (!empresa.ValidationResult.IsValid)
            //{
            //    return empresa;
            //}

            //empresa.ValidationResult.Message = "Empresa cadastrado com sucesso :)";
            return _empresaRepository.Adicionar(empresa);
        }

        public Empresa ObterPorId(Guid id)
        {
            return _empresaRepository.ObterPorId(id);
        }

        public Empresa ObterPorBairro(string bairro)
        {
            return _empresaRepository.ObterPorBairro(bairro);
        }

        //public Empresa ObterPorEmail(string email)
        //{
        //    return _empresaRepository.ObterPorEmail(email);
        //}

        public Paged<Empresa> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            return _empresaRepository.ObterTodos(nome, pageSize, pageNumber);
        }

        public Empresa Atualizar(Empresa Empresa)
        {
            return _empresaRepository.Atualizar(Empresa);
        }

        public void Remover(Guid id)
        {
            _empresaRepository.Remover(id);
        }

        
        public void Dispose()
        {
            _empresaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}