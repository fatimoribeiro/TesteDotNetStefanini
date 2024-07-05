using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Atletas.DTO;

namespace Atletas.BLL
{
    public interface IAtleta<T>
    {
        DataTable ExibirTodos();
        List<T> Exibir();
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
        DataTable Consultar(string nome);
        Atleta GetAtletaId(int id);
    }
}
