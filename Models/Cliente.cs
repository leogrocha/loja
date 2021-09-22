using System;

namespace Loja.API.Models
{
    public class Cliente {
        public int? Id {get;set;}
        public string Nome {get;set;}

        private double _Credito;

        public double Credito
        {
            get{return this._Credito;}
            set{this._Credito = (value < 0 ? 0 : value);}
        }
        public DateTime DataNascimento {get; set;}
        public DateTime DataCadastro {get;set;}

        public Boolean Liberado {get;set;}
        

        // Método Construtores
        public Cliente(){
            DataCadastro = DateTime.Now;
        }

        public Cliente(string nome, double credito, DateTime dataNascimento,
         DateTime dataCadastro, Boolean liberado) {
             this.Id = null;
             this.Nome = nome;
             this._Credito = credito;
             this.DataNascimento = dataNascimento;
        }

        public void AtualizarCliente(string nome, double credito, DateTime dataNascimento, Boolean liberado) {
            Nome = nome;
            _Credito = credito;
            DataNascimento = dataNascimento;
            Liberado = liberado;
        }

        public void BloquearCliente() {
            
        }

        public void LiberarCliente() {

        }

    }
}