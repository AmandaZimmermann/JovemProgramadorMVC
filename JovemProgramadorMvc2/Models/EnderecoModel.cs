using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc2.Models
{
    public class EnderecoModel
    {
        public int Id { get; set; }

        public int IdAluno { get; set; }

        public string logradouro { get; set; }

        public string complemento { get; set; }

        public string bairro { get; set; }

        public string localidade { get; set; }

        public string uf { get; set; }

        public string ddd { get; set; }

        public EnderecoModel()
        {

        }
    }
}
