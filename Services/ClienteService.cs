using System.Collections.Generic;
using System.Linq;
using Loja.API.Data;
using Loja.API.Models;

namespace Loja.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly DataContext _context;
        public ClienteService(DataContext context)
        {
            this._context = context;
        }

        public IEnumerable<Cliente> Buscar()
        {
            var clientes = _context.Clientes;
            if (clientes == null || clientes.ToList().Count == 0)
                return null;

            return clientes;
        }

        public Cliente BuscarPorId(int id)
        {
            var clientes = _context.Clientes.FirstOrDefault(
                p => p.Id == id
            );

            return clientes;
        }

        public IEnumerable<Cliente> BuscarPorNome(string nome)
        {
            var clientes = _context.Clientes.Where(
                p => p.Nome.ToLower().Contains(nome.ToLower())
            );

            if (clientes == null || clientes.ToList().Count == 0)
                return null;

            return clientes;
        }

        

        public Cliente Adicionar(Cliente novoCliente)
        {
            var cliente = new Cliente(
                novoCliente.Nome,
                novoCliente.Credito,
                novoCliente.DataCadastro,
                novoCliente.DataNascimento,
                novoCliente.Liberado);

            
            _context.Add(cliente);
            
            _context.SaveChanges();

            return cliente;
        }

        public Cliente Atualizar(int id, Cliente clienteAtualizado)
        {
            var cliente = _context.Clientes.FirstOrDefault(
                cli => cli.Id == id);

            if (cliente == null)
                return null;

            cliente.AtualizarCliente(clienteAtualizado.Nome,
             clienteAtualizado.Credito, clienteAtualizado.DataNascimento, clienteAtualizado.Liberado);
    
            _context.Update(cliente);
            
            _context.SaveChanges();

            return cliente;
        }

        public bool Remover(int id)
        {
            var clientes = _context.Clientes.FirstOrDefault(
                c => c.Id == id
            );

            
            if (clientes == null)
                return false;
            
            _context.Remove(clientes);
            
            _context.SaveChanges();

            return true;
        }

        
        public IEnumerable<Cliente> OrdernarClientes(string ordenarPor, string crescenteOuDecrescente)
        {
            char ordem = (string.IsNullOrEmpty(crescenteOuDecrescente) ? 'C' :
            crescenteOuDecrescente.ToUpper()[0]);

            switch (ordenarPor)
            {
                case "nome":
                    return (
                        ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.Nome) : 
                        _context.Clientes.OrderBy(c => c.Nome) );
                
                case "credito":
                    return (
                        ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.Credito) : 
                        _context.Clientes.OrderBy(c => c.Credito) );
                
                case "dataNascimento":
                    return (
                        ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.DataNascimento) : 
                        _context.Clientes.OrderBy(c => c.DataNascimento) );
                case "liberado":
                    return (
                        ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.Liberado) : 
                        _context.Clientes.OrderBy(c => c.Liberado) );        
                default:
                    return(ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.DataCadastro): 
                    _context.Clientes.OrderBy(c => c.DataCadastro));
            }

        }

         public IEnumerable<Cliente> GetByCreditoMaiorOuIgual(double credito) {
            var clientes = _context.Clientes.Where(
                c => c.Credito >= credito
            );

            if(clientes == null || clientes.ToList().Count == 0)
                return null;

            return clientes;
         }

        public IEnumerable<Cliente> GetClientesBloqueados() {
            var clientes = _context.Clientes.Where(
                c => c.Liberado == false
            );

            if(clientes == null || clientes.ToList().Count == 0)
                return null;

            return clientes;
        }

        public IEnumerable<Cliente> GetClientesLiberados() {
            var clientes = _context.Clientes.Where(
                c => c.Liberado == true
            );

            if(clientes == null || clientes.ToList().Count == 0)
                return null;

            return clientes;    
        }


        
    }
}