using System.Collections.Generic;
using System.Linq;
using Loja.API.Data;
using Loja.API.Models;

namespace Loja.API.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly DataContext _context;
        public ProdutoService(DataContext context)
        {
            this._context = context;
        }

        public IEnumerable<Produto> Buscar()
        {
            var produtos = _context.Produtos;
            if (produtos == null || produtos.ToList().Count == 0)
                return null;

            return produtos;
        }

        public Produto BuscarPorId(int id)
        {
            var produtos = _context.Produtos.FirstOrDefault(
                p => p.Id == id
            );

            return produtos;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            var produtos = _context.Produtos.Where(
                p => p.Nome.ToLower().Contains(nome.ToLower())
            );

            if (produtos == null || produtos.ToList().Count == 0)
                return null;

            return produtos;
        }

        /*
        public IEnumerable<Produto> OrdernarProdutos(string ordenaPor, string crescenteOuDecrescente)
        {
            throw new System.NotImplementedException();
        } */

        public Produto Adicionar(Produto novoProduto)
        {
            var produto = new Produto(
                novoProduto.Nome,
                novoProduto.Estoque,
                novoProduto.Valor);

            // Adicionar o produto criado no contexto do EF EntityFramework
            _context.Add(produto);
            // Salvar na tabela do BD o produto que foi criado no contexto do EF
            _context.SaveChanges();

            return produto;
        }

        public Produto Atualizar(int id, Produto produtoAtualizado)
        {
            // Retorna o produto da tabela do BD
            var produto = _context.Produtos.FirstOrDefault(
                prod => prod.Id == id);

            // Verifica se retornou algum produto
            if (produto == null)
                return null;

            // Atualizar os dados do produto retornado do Contexto
            produto.AtualizarProduto(produtoAtualizado.Nome,
             produtoAtualizado.Estoque, produtoAtualizado.Valor);
            // Atualizar o produto no contexto do EF
            _context.Update(produto);
            // Salva as altera????es no produto na tabela do BD
            _context.SaveChanges();

            return produto;
        }

        public bool Remover(int id)
        {
            var produto = _context.Marcas.FirstOrDefault(
                p => p.Id == id
            );

            // verificar se existe produto
            if (produto == null)
                return false;
            // remover o produto do contexto EF
            _context.Remove(produto);
            // Remover o produto da tabela do bd
            _context.SaveChanges();

            return true;
        }

        // m??todo que ordena os elementos da lista de produtos
        public IEnumerable<Produto> OrdernarProdutos(string ordenarPor, string crescenteOuDecrescente)
        {
            char ordem = (string.IsNullOrEmpty(crescenteOuDecrescente) ? 'C' :
            crescenteOuDecrescente.ToUpper()[0]);

            switch (ordenarPor)
            {
                case "nome":
                    return (
                        ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Nome) : 
                        _context.Produtos.OrderBy(p => p.Nome) );
                
                case "estoque":
                    return (
                        ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Estoque) : 
                        _context.Produtos.OrderBy(p => p.Estoque) );
                
                case "valor":
                    return (
                        ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.Valor) : 
                        _context.Produtos.OrderBy(p => p.Valor) );
                default:
                    return(ordem == 'D' ? _context.Produtos.OrderByDescending(p => p.DataCadastro): 
                    _context.Produtos.OrderBy(p => p.DataCadastro));
            }

        }

        
    }
}