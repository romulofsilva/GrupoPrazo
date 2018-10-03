using GrupoPrazo_Infra.Data;
using GrupoPrazo_Infra.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;

namespace GrupoPrazo_Infra.Repositorio
{

    public class UsuarioRepositorio
    {
        private readonly GPContext _context;
        public UsuarioRepositorio()
        {
            _context = new GPContext();
        }

        public void Salvar(Usuario usuario)
        {
            _context.Ususario.Add(usuario);
            _context.SaveChanges();
        }
        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var usuario = RetornarUsuario(id);
            _context.Ususario.Remove(usuario);
            _context.SaveChanges();
        }
        public List<Usuario> ListarUsarios()
        {
            return _context.Ususario.ToList();
        }
        public Usuario RetornarUsuario(int? id)
        {
            return _context.Ususario.Find(id);
        }

        public Usuario RetornarUsuarioNome(string nome)
        {
            var query = from st in _context.Ususario
                        where st.Nome  == nome
                        select st;

            var usuario = query.FirstOrDefault<Usuario>();
            
            return usuario;
        }

        public bool AutenticarUsuario(string nome, string senha )
        {
            var query = (from st in _context.Ususario
            where st.Nome == nome &&
            st.Senha == senha
            select st).SingleOrDefault();

            if(query == null)
            {
                return false;
            }

            FormsAuthentication.SetAuthCookie(query.Nome,false);

            return true;
        }
    }
}
