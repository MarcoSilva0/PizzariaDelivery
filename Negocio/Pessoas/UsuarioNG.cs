using BaseDados.Pessoas;
using Entidades.Entidades;
using Entidades.Enumeradores;
using Entidades.Pessoas;
using System.Collections.Generic;

namespace Negocio.Pessoas
{
    public class UsuarioNG
    {
        private readonly UsuarioBD _bd;

        public UsuarioNG()
        {
            _bd = new UsuarioBD();
        }

        public List<EntidadeViewPesquisa> ListarEntidadesViewPesquisa(Status status)
        {
            return _bd.ListarEntidadesViewPesquisa(status);
        }

        public List<Usuario> ListarUsuarioAtivos()
        {
            return _bd.ListarUsuarioAtivos();
        }
        public Usuario Buscar(int cod)
        {
            return _bd.Buscar(cod);
        }

        public int BuscarProximoCodigo()
        {
            return _bd.BuscarProximoCodigo();
        }
    }
}
