namespace ControleClientes.Api.Models
{
    public class ClienteGetModel
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
