using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController: ControllerBase{
        public ProdutoController(){}

        // API com o método GET
        [HttpGet]
        public string Get() {
            return "Retorno de todos os produtos";
        }

        // Método GET com ID
        [HttpGet("{id}")]
        public string Get(int id){
            return $"Retorno do produto com id = {id}";
        }

        // API com o método POST
        [HttpPost]
        public string Post() {
            return "Exemplo de Post";
        }
        
        // API com o método PUT
        [HttpPut("{id}")]
        public string Put(int id) {
            return $"Exemplo de Put com id = {id}";
        }

        // Delete
        [HttpDelete("{id}")]
        public string Delete(int id) {
            return $"Exemplo de Delete com id = {id}";
        }
   
    }
}