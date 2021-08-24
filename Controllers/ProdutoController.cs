using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        // Lista estática de produtos
        public static List<Produto> produtos = new List<Produto>();


        public ProdutoController()
        {
            if (produtos.Count <= 0)
            {
                Produto produto = new Produto()
                {
                    Id = 1,
                    Nome = "Tênis",
                    Estoque = 10,
                    Valor = 159.99
                }; produtos.Add(produto);

                produto = new Produto()
                {
                    Id = 2,
                    Nome = "Camiseta",
                    Estoque = 15,
                    Valor = 89.78
                }; produtos.Add(produto);

                 produto = new Produto()
                {
                    Id = 3,
                    Nome = "Boné",
                    Estoque = 7,
                    Valor = 55.45
                }; produtos.Add(produto);

            }
        }

        // API com o método GET
        [HttpGet]
        public IActionResult Get()
        {
            // retorna um resultado correto
            return Ok(produtos);
        }

        // Método GET com ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produtoSelecionado = produtos.Where(
                prod => prod.Id == id);
            return Ok(produtoSelecionado);
        }

        // API com o método POST
        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto)
        {   
            // Adicionar o produto na lista
            produtos.Add(novoProduto);
            // Retornar para o cliente o produto adicionado na lista
            return Created("", novoProduto);
        }

        // API com o método PUT
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             // Selecionar o produto que deverá ser removido
                var produtoSelecionado = (Produto)produtos.FirstOrDefault(p => p.Id == id);

            // Verificar se o produto selecionado é diferente de nulo
            if(produtoSelecionado != null){
                // Então foi encontrado um produto com o id passado como parâmetro
               
                // Remove o produto da lista
                produtos.Remove(produtoSelecionado);
                // Retorna um resultado para o cliente
                return NoContent();
            }

            return NotFound();
        }

    }
}