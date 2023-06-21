using ControleClientes.Api.Models;
using ControleClientes.Domain.Entities;
using ControleClientes.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleClientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteDomainService _clientDomainService;

        public ClientesController(IClienteDomainService clientDomainService)
        {
            _clientDomainService = clientDomainService;
        }

        [HttpPost]
        [Route("cadastro")]
        public IActionResult Cadastro(ClienteCadastroModel model)
        {
            try
            {
                var cliente = new Cliente();
                cliente.IdCliente = Guid.NewGuid();
                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Cpf = model.Cpf;
                cliente.DataNascimento = DateTime.Parse(model.DataNasicmento);

                _clientDomainService.CadastrarCliente(cliente);

                return StatusCode(201, new { mensagem = $"Cliente {cliente.Nome}, cadastrado com sucesso!" });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }


        [HttpGet]

        [Route("consultar")]
        public IActionResult Consultar()
        {
            try
            {
                var clientes = _clientDomainService.ConsultarClientes();

                var response = clientes.Select(c => new ClienteGetModel
                {
                    IdCliente = c.IdCliente,
                    Nome = c.Nome,
                    Email = c.Email,
                    Cpf = c.Cpf,
                    DataNascimento = c.DataNascimento
                }).ToList();

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult ObterCliente(Guid idCliente)
        {
            try
            {
                var cliente = _clientDomainService.ObterCliente(idCliente);

                if (cliente == null)
                {
                    return NotFound(new { mensagem = "Cliente não encontrado" });
                }

                var response = new ClienteGetModel
                {
                    IdCliente = cliente.IdCliente,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Cpf = cliente.Cpf,
                    DataNascimento = cliente.DataNascimento
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        [HttpDelete]
        [Route("exclusao/{idCliente}")]
        public IActionResult Exclusao(Guid idCliente)
        {
            try
            {
                _clientDomainService.ExcluirCliente(idCliente);
                return StatusCode(201, new { mensagem = $"Cliente excluído com sucesso!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        } 

        [HttpPut]
        [Route("api/clientes/atualizacao")]
        public IActionResult AtualizarCliente(ClienteEdicaoModel model)
        {
            try
            {
                var cliente = _clientDomainService.ObterCliente(model.IdCliente);

                if (cliente == null)
                {
                    return NotFound(new { mensagem = "Cliente não encontrado" });
                }

                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Cpf = model.Cpf;
                cliente.DataNascimento = model.DataNascimento;

                _clientDomainService.AtualizarCliente(cliente);

                return Ok(new { mensagem = "Cliente atualizado com sucesso" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }
    }
}
