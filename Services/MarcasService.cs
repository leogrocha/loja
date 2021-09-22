using System.Collections.Generic;
using System.Linq;
using Loja.API.Data;
using Loja.API.Models;

namespace Loja.API.Services
{
    public class MarcasService : IMarcasService
    {
        private readonly DataContext _context;
        public MarcasService(DataContext context)
        {
            this._context = context;
        }

        public IEnumerable<Marcas> Buscar()
        {
            var marcas = _context.Marcas;
            if (marcas == null || marcas.ToList().Count == 0)
                return null;

            return marcas;
        }

        public Marcas BuscarPorId(int id)
        {
            var marcas = _context.Marcas.FirstOrDefault(
                m => m.Id == id
            );

            return marcas;
        }

        public IEnumerable<Marcas> BuscarPorNome(string nome)
        {
            var marcas = _context.Marcas.Where(
                m => m.Nome.ToLower().Contains(nome.ToLower())
            );

            if (marcas == null || marcas.ToList().Count == 0)
                return null;

            return marcas;
        }

     
        public Marcas Adicionar(Marcas novasMarcas)
        {
            var marcas = new Marcas(
                novasMarcas.Nome
            );
            
            _context.Add(marcas);
            

            _context.SaveChanges();

            return marcas;
        }

        public Marcas Atualizar(int id, Marcas marcasAtualizadas)
        {
            var marcas = _context.Marcas.FirstOrDefault(
                m => m.Id == id);

            if (marcas == null)
                return null;
            
            marcas.AtualizarMarcas(marcasAtualizadas.Nome);
            
            _context.Update(marcas);
            
            _context.SaveChanges();

            return marcas;
        }

        public bool Remover(int id)
        {
            var marcas = _context.Marcas.FirstOrDefault(
                m => m.Id == id
            );

            if (marcas == null)
                return false;
            _context.Remove(marcas);
            _context.SaveChanges();

            return true;
        }

        
        public IEnumerable<Marcas> OrdernarMarcas(string ordenarPor, string crescenteOuDecrescente)
        {
            char ordem = (string.IsNullOrEmpty(crescenteOuDecrescente) ? 'C' :
            crescenteOuDecrescente.ToUpper()[0]);

            switch (ordenarPor)
            {
                case "nome":
                    return (
                        ordem == 'D' ? _context.Marcas.OrderByDescending(m => m.Nome) : 
                        _context.Marcas.OrderBy(m => m.Nome) );     
                 default:
                    return(ordem == 'D' ? _context.Marcas.OrderByDescending(m => m.Id): 
                    _context.Marcas.OrderBy(m => m.Id));        
            }

        }

        
    }
}