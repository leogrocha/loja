using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Loja.API.Services;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;


        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // API com o método GET
        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _clienteService.Buscar();
            if(clientes == null)
                return NotFound();
            else 
                return Ok(clientes);    
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var clienteSelecionado = _clienteService.BuscarPorId(id);

            if(clienteSelecionado == null)
                return NotFound();
            else 
                return Ok(clienteSelecionado);    
        }

       [HttpGet("Cliente/{credito}")]
        public IActionResult GetByCreditoMaiorOuIgual(double credito)
        {
            var creditoMaiorOuIgual = _clienteService.GetByCreditoMaiorOuIgual(credito);

            if(creditoMaiorOuIgual == null)
                return NotFound();
            else 
                return Ok(creditoMaiorOuIgual);
        }

        [HttpGet("Cliente/Liberado")]
        public IActionResult GetClientesLiberados()
        {
            var clienteLiberado = _clienteService.GetClientesLiberados();

            if(clienteLiberado == null)
                return NotFound();
            else     
                return Ok(clienteLiberado);
        }

        [HttpGet("Cliente/Bloqueado")]
        public IActionResult GetClientesBloqueados()
        {
            var clienteBloqueado = _clienteService.GetClientesBloqueados();

            if(clienteBloqueado == null)
                return NotFound();
            else     
                return Ok(clienteBloqueado);
        }
        

        [HttpPost]
        public IActionResult NovoCliente([FromBody] Cliente novoCliente)
        {
            Cliente clienteAdicionado = _clienteService.Adicionar(novoCliente);

            return Created("", novoCliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool remocaoOk = _clienteService.Remover(id);

            if(remocaoOk == false)
                return NotFound();

            return NoContent();    
        }

        [HttpGet("ordenar/{ordenarPor}")]
        public IActionResult GetByOrder(string ordenarPor, string crescenteOuDecrescente) {
            var clientesOrdenados = _clienteService.OrdernarClientes(ordenarPor, crescenteOuDecrescente);
            if(clientesOrdenados == null){
                return NotFound();
            }

            return Ok(clientesOrdenados);
        }

    }
}