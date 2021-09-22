using System;

namespace Loja.API.Models
{
    public class Marcas
    {
        public int? Id { get; set; }
        public string Nome { get; set; }

        public Marcas(string nome){
            this.Id = null;
            this.Nome = nome;
        }

        public void AtualizarMarcas (string nome){
           Nome = nome;
        }

    }
}