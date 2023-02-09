using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro_de_fornecedores.Repositorio;
using Cadastro_de_fornecedores.Models;
using Cadastro_de_fornecedores.Data;

namespace Cadastro_de_fornecedores.Repositorio
{
    public class FornecedoresRepositorio : IFornecedoresRepositorio
    {
        private  readonly BancoContext _bancoContext;
        public FornecedoresRepositorio (BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public FornecedoresModel ListarPorId(int id)
        {
            return _bancoContext.Fornecedores.FirstOrDefault(x => x.Id == id);
        }

        public List<FornecedoresModel> BuscarTodos()
        {
            return _bancoContext.Fornecedores.ToList();
        }
        public FornecedoresModel Adicionar(FornecedoresModel Fornecedores)
        {
           _bancoContext.Fornecedores.Add(Fornecedores);
           _bancoContext.SaveChanges();
           return Fornecedores;
        }

        public FornecedoresModel Atualizar(FornecedoresModel fornecedores)
        {
            FornecedoresModel fornecedoresDB = ListarPorId(fornecedores.Id);
            if(fornecedoresDB == null) throw new System.Exception("Houve um erro ao editar!");
            fornecedoresDB.Nome = fornecedores.Nome;
            fornecedoresDB.CNPJ = fornecedores.CNPJ;
            fornecedoresDB.Especialidade = fornecedores.Especialidade;

            _bancoContext.Fornecedores.Update(fornecedoresDB);
            _bancoContext.SaveChanges();

            return fornecedoresDB;
        }

        public bool Apagar(int id)
        {
            FornecedoresModel fornecedoresDB = ListarPorId(id);
            if(fornecedoresDB == null) throw new System.Exception("Houve um erro ao deletar!");
            
            _bancoContext.Fornecedores.Remove(fornecedoresDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}