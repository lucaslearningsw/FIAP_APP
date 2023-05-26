using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Models
{
    public class Student : Entity
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
