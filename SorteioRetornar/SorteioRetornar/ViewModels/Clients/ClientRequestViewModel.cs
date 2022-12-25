using System.ComponentModel.DataAnnotations;

namespace SorteioRetornar.ViewModels.Clients
{
    public class ClientRequestViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 255 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O número de telefone é obrigatório")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }
    }
}
