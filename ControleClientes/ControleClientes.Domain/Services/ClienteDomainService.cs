using ControleClientes.Domain.Entities;
using ControleClientes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ControleClientes.Domain.Services
{
    // O Sistema não deverá permitir o cadastro de clientes com o mesmo email
    // O Sistema não deverá permitir o cadastro de clientes com o mesmo cpf
    // O Sistema não deverá permitir o cadastro de clientes menores de idade.
    public class ClienteDomainService : IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void AtualizarCliente(Cliente cliente)
        {

            if(_clienteRepository.GetById(cliente.IdCliente) == null)
            {
                throw new Exception("Cliente nao encontrao.");
            }

            _clienteRepository.Update(cliente); 
        }

        public void CadastrarCliente(Cliente cliente)
        {
            var clienteExistenteCpf = _clienteRepository.ObterPorCpf(cliente.Cpf);
            if (clienteExistenteCpf != null)
            {
                throw new InvalidOperationException("CPF já cadastrado");
            }

            var clienteExistenteEmail = _clienteRepository.ObterPorEmail(cliente.Email);
            if (clienteExistenteEmail != null)
            {
                throw new InvalidOperationException("E-mail já cadastrado");
            }



            var idadeMinima = 18;
            var idade = DateTime.Today.Year - cliente.DataNascimento.Year;
            if (DateTime.Today < cliente.DataNascimento.AddYears(idade)) idade--;

            if (idade < idadeMinima)
            {
                throw new InvalidOperationException("O cliente deve ter pelo menos 18 anos");
            }

            _clienteRepository.Create(cliente);
        }

        public List<Cliente> ConsultarClientes()
        {
            return _clienteRepository.GetAll();
        }

        public void ExcluirCliente(Guid idCliente)
        {
            var cliente = _clienteRepository.GetById(idCliente);

            if (cliente == null)
            {
                throw new Exception("O cliente não foi encontrado no sistema, verifique o ID.");
            }
            _clienteRepository.Delete(cliente);
        }

        public Cliente ObterCliente(Guid idCliente)
        {
           var cliente = _clienteRepository.GetById(idCliente);

            return cliente;
        }
    }
}
