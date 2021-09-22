using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Loja.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {

        // declara um objeto da interface
        private readonly IMarcasService _marcasService;

        public MarcasController(IMarcasService marcasService)
        {
            _marcasService = marcasService;
        }

        // API com o método GET
        [HttpGet]
        public IActionResult Get()
        {
            var marcas = _marcasService.Buscar();
            if (marcas == null)
                return NotFound();
            else
                return Ok(marcas);
        }

        // Método GET com ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var marcaSelecionada = _marcasService.BuscarPorId(id);

            if(marcaSelecionada == null)
                return NotFound();
            else     
                return Ok(marcaSelecionada);
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult GetByName(string nome){
            var marcas = _marcasService.BuscarPorNome(nome);
            if(marcas == null)
                return NotFound();
            else    
                return Ok(marcas);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Marcas novasMarcas)
        {
            
            Marcas marcasSelecionada = _marcasService.Adicionar(novasMarcas);
            
            return Created("", marcasSelecionada );
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Marcas marcasAtual)
        {
            marcasAtual = _marcasService.Atualizar(id, marcasAtual);
            if(marcasAtual == null)
                return NotFound();
            else
                return Ok(marcasAtual);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        { 
            bool remocaoOK = _marcasService.Remover(id);

            if (remocaoOK == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("ordenar/{ordenarPor}")]
        public IActionResult GetByOrder(string ordenarPor, string crescenteOuDecrescente) {
            var marcasOrdenadas = _marcasService.OrdernarMarcas(ordenarPor, crescenteOuDecrescente);
            if(marcasOrdenadas == null){
                return NotFound();
            }

            return Ok(marcasOrdenadas);
        }

    }
}