using System.Collections.Generic;
using Loja.API.Models;

namespace Loja.API.Services {
    public interface IMarcasService {
        // Definir os métodos abstratos
        IEnumerable<Marcas> Buscar();

        Marcas BuscarPorId(int id);

        IEnumerable<Marcas> BuscarPorNome(string nome);

        IEnumerable<Marcas> OrdernarMarcas(string ordenarPor, string crescenteOuDecrescente);

        Marcas Adicionar(Marcas novasMarcas);

        Marcas Atualizar(int id,Marcas marcaAtualizada);

        bool Remover(int id);
    }
}