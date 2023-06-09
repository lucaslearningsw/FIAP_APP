﻿using System.ComponentModel.DataAnnotations;

namespace FIAP_APP.API.Dto.Student
{
    public class StudentUpdate
    {
 
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracters", MinimumLength = 2)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [StringLength(45, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracters", MinimumLength = 2)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Usuario { get; set; }

        
        public string Senha { get; set; }

    }
}
