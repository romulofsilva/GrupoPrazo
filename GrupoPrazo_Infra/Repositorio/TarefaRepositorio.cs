using GrupoPrazo_Infra.Data;
using GrupoPrazo_Infra.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoPrazo_Infra.Repositorio
{
    public class TarefaRepositorio
    {
        private readonly GPContext _context;
        public TarefaRepositorio()
        {
            _context = new GPContext();
        }

        public void Salvar(Tarefa tarefa)
        {
            _context.Tarefa .Add(tarefa);
            _context.SaveChanges();
        }
        public void Alterar(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var tarefa = RetornarTarefa(id);
            _context.Tarefa .Remove(tarefa);
            _context.SaveChanges();
        }
        public List<Tarefa> ListarTarefas()
        {
            return _context.Tarefa .ToList();
        }
        public Tarefa RetornarTarefa(int? id)
        {
            return _context.Tarefa.Find(id);
        }
    }
}
