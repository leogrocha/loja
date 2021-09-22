using System.Collections.Generic;
using Loja.API.Models;

namespace Loja.API.Services {
    public interface IClienteService {
        // Definir os métodos abstratos
        IEnumerable<Cliente> Buscar();

        Cliente BuscarPorId(int id);

        IEnumerable<Cliente> BuscarPorNome(string nome);

        IEnumerable<Cliente> OrdernarClientes(string ordenarPor, string crescenteOuDecrescente);

        IEnumerable<Cliente> GetByCreditoMaiorOuIgual(double credito);

        IEnumerable<Cliente> GetClientesBloqueados();

        IEnumerable<Cliente> GetClientesLiberados();

        Cliente Adicionar(Cliente novoCliente);

        Cliente Atualizar(int id,Cliente ClienteAtualizado);

        bool Remover(int id);
    }
}