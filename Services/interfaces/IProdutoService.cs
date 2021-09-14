using System.Collections.Generic;
using Loja.API.Models;

namespace Loja.API.Services {
    public interface IProdutoService {
        // Definir os métodos abstratos
        IEnumerable<Produto> Buscar();

        Produto BuscarPorId(int id);

        IEnumerable<Produto> BuscarPorNome(string nome);

        //IEnumerable<Produto> OrdernarProdutos(string ordenaPor, string crescenteOuDecrescente);

        Produto Adicionar(Produto novoProduto);

        Produto Atualizar(int id,Produto produtoAtualizado);

        bool Remover(int id);
    }
}