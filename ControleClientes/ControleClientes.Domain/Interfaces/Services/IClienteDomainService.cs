using ControleClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleClientes.Domain.Services
{
    public interface IClienteDomainService
    {
        void CadastrarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
        void ExcluirCliente(Guid idCliente);
        List<Cliente> ConsultarClientes();
        Cliente ObterCliente(Guid idCliente);
    }
}
