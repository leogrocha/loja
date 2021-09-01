using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        public static List<Cliente> clientes = new List<Cliente>();


        public ClienteController()
        {
            if (clientes.Count <= 0)
            {
                Cliente cliente = new Cliente()
                {
                    Id = 1,
                    Nome = "Léo",
                    Credito = 10.00,
                    DataCadastro = Convert.ToDateTime("23/08/2021"),
                    DataNascimento = Convert.ToDateTime("18/03/1998"),
                    Liberado = true,
                }; clientes.Add(cliente);

                cliente = new Cliente()
                {
                    Id = 2,
                    Nome = "Heinsenberg",
                    Credito = 15.00,
                    DataCadastro = Convert.ToDateTime("23/08/2021"),
                    DataNascimento = Convert.ToDateTime("18/03/1998"),
                    Liberado = true,

                }; clientes.Add(cliente);

                cliente = new Cliente()
                {
                    Id = 3,
                    Nome = "Walter White",
                    Credito = 7.00,
                    DataCadastro = Convert.ToDateTime("23/08/2021"),
                    DataNascimento = Convert.ToDateTime("18/03/1998"),
                    Liberado = false,
                }; clientes.Add(cliente);

            }
        }

        // API com o método GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var clienteSelecionado = clientes.Where(
                cli => cli.Id == id);
            return Ok(clienteSelecionado);
        }

       [HttpGet("Cliente/{credito}")]
        public IActionResult Get(double credito)
        {
            var clienteSelecionado = clientes.Where(
                cliente => cliente.Credito >= credito);
            return Ok(clienteSelecionado);
        }



        [HttpGet("Cliente/Liberado")]
        public IActionResult GetClientesLiberados()
        {
            var clienteLiberado = clientes.Where(
                cli => cli.Liberado == true);
            return Ok(clienteLiberado);
        }
        

        [HttpPost]
        public IActionResult NovoCliente([FromBody] Cliente novoCliente)
        {
            clientes.Add(novoCliente);
            return Created("", novoCliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var clienteSelecionado = (Cliente)clientes.FirstOrDefault(c => c.Id == id);

            if (clienteSelecionado != null)
            {
                clientes.Remove(clienteSelecionado);
                return NoContent();
            }

            return NotFound();
        }

    }
}