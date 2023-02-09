using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro_de_fornecedores.Models;

namespace Cadastro_de_fornecedores.Repositorio
{
    public interface IFornecedoresRepositorio
    {
       FornecedoresModel ListarPorId(int id);
       List<FornecedoresModel> BuscarTodos();
       FornecedoresModel Adicionar(FornecedoresModel Fornecedores);
       FornecedoresModel Atualizar(FornecedoresModel fornecedores);
       bool Apagar (int id);
    }
}