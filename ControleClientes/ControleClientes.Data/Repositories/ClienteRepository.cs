using ControleClientes.Data.Contexts;
using ControleClientes.Domain.Entities;
using ControleClientes.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleClientes.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void Create(Cliente cliente)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Cliente.Add(cliente);
                sqlServerContext.SaveChanges();
            }
        }

        public void Delete(Cliente cliente)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Cliente.Remove(cliente);
                sqlServerContext.SaveChanges();
            }
        }

        public List<Cliente> GetAll()
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Cliente.ToList();
            }
        }

        public Cliente GetById(Guid idCliente)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Cliente.FirstOrDefault(c => c.IdCliente == idCliente);
            }
        }

        public Cliente ObterPorCpf(string cpf)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Cliente.FirstOrDefault(c => c.Cpf == cpf);
            }
        }

        public Cliente ObterPorEmail(string email)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Cliente.FirstOrDefault(c => c.Email == email);
            }
        }

        public void Update(Cliente cliente)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(cliente).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }
    }
}
