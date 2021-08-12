using System;

namespace Loja.API.Models
{
    public class Produto
    {
        // A lista de atributos / propriedades
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }

        // O valor do produto não poderá ser negativo
        private double _valor;

        public double Valor
        {
            get{return this._valor;}
            set{this._valor = (value < 0 ? 0 : value);}
        }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        // Métodos construtores
        public Produto(){
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public Produto(string nome, int estoque, double valor){
            this.Id = null;
            this.Nome = nome;
            this.Valor = valor;
            this.DataCadastro = this.DataAtualizacao = DateTime.Now;
        }

        // Método para atualizar um objeto já existente
        public void AtualizarProduto (string nome, int estoque, double valor){
           Nome = nome;
           Estoque = estoque;
           Valor = valor;
           DataAtualizacao = DateTime.Now; 
        }

    }
}