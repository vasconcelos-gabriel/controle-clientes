using ControleClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleClientes.Domain.Repositories
{
    public interface IClienteRepository
    {
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
        List<Cliente> GetAll();
        Cliente GetById(Guid idCliente);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
    }
}
