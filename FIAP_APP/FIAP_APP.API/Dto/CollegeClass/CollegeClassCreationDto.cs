using System.ComponentModel.DataAnnotations;

namespace FIAP_APP.API.Dto.CollegeClass
{
    public class CollegeClassCreationDto
    {
        [StringLength(45, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracters", MinimumLength = 2)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Turma { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Data { get; set; }

    }
}
