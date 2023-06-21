using System.ComponentModel.DataAnnotations;

namespace ControleClientes.Api.Models
{
    public class ClienteCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Por favor, informe email do cliente.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor, informe 11 dígitos numéricos")]
        [Required(ErrorMessage = "Por favor, informe o CPF do cliente.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento.")]
        public string DataNasicmento { get; set; }
    }
}
