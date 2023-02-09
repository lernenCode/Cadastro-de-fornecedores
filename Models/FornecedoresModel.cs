using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_fornecedores.Models
{
    public class FornecedoresModel
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string CNPJ {get;set;}
        public string Especialidade {get;set;}
    }
}