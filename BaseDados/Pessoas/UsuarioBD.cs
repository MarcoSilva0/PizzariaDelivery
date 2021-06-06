using BaseDados.Modulos;
using Entidades.Entidades;
using Entidades.Enumeradores;
using Entidades.Pessoas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDados.Pessoas
{
    public class UsuarioBD
    {
        private readonly FuncoesBD bdFuncoes = new FuncoesBD();

        public bool Inserir(Usuario oUsuario)
        {
            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    comando.CommandText = @"INSERT INTO 
                    usuario(codigo_tipo_usuario, nome, login, senha, situacao, dtalteracao, codigo_usr_alteracao) 
                    VALUES 
                           (@codigo_tipo_usuario, @nome, @login, @senha, @situacao, NOW(), @codigo_usr_alteracao);";

                    comando.Parameters.AddWithValue("codigo_tipo_usuario", oUsuario.TipoUsuario.Codigo);
                    comando.Parameters.AddWithValue("nome", oUsuario.Nome);
                    comando.Parameters.AddWithValue("login", oUsuario.Login);
                    comando.Parameters.AddWithValue("senha", oUsuario.Senha);
                    comando.Parameters.AddWithValue("situacao", oUsuario.Status);
                    comando.Parameters.AddWithValue("codigo_usr_alteracao", oUsuario.CodigoUsrAlteracao);
                }
                catch (MySqlException mysqle)
                {
                    throw new System.Exception(mysqle.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
            return ListaEntidade;
        }

        public List<EntidadeViewPesquisa> ListarEntidadesViewPesquisa(Status status)
        {
            var ListaEntidade = new List<EntidadeViewPesquisa>();
            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    string query = @"SELECT codigo, nome AS descricao, situacao 
                                            FROM usuario ";

                    if (status != Status.Todos)
                        query += "WHERE situacao = @situacao;";

                    comando.CommandText = query;


                    if (status != Status.Todos)
                        comando.Parameters.AddWithValue("situacao", (int)status);

                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        var oEntidade = new EntidadeViewPesquisa();
                        oEntidade.Codigo = Convert.ToInt32(reader["codigo"].ToString());
                        oEntidade.Descricao = reader["descricao"].ToString();          
                        oEntidade.Status = (Status)Convert.ToInt16(reader["situacao"]);

                        ListaEntidade.Add(oEntidade);
                    }
                }
                catch(MySqlException mysqle)
                {
                    throw new System.Exception(mysqle.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
            return ListaEntidade;
        }

        public List<Usuario> ListarUsuarioAtivos()
        {
            var ListaUsuario = new List<Usuario>();
            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    comando.CommandText = "SELECT * FROM usuario WHERE situacao = 1;";

                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        var oUsuario = new Usuario();
                        oUsuario.Codigo = Convert.ToInt32(reader["codigo"].ToString());
                        oUsuario.TipoUsuario = new TipoUsuario(Convert.ToInt32(reader["codigo_tipo_usuario"].ToString()), string.Empty);
                        oUsuario.Nome = reader["nome"].ToString();
                        oUsuario.Login = reader["login"].ToString();
                        oUsuario.Senha = reader["senha"].ToString();
                        oUsuario.Status = (Status)Convert.ToInt16(reader["situacao"]);
                        oUsuario.DtAlteracao = Convert.ToDateTime(reader["dtalteracao"].ToString());
                        oUsuario.CodigoUsrAlteracao = Convert.ToInt32(reader["codigo_usr_alteracao"].ToString());

                        ListaUsuario.Add(oUsuario);
                    }
                }
                catch (MySqlException mysqle)
                {
                    throw new System.Exception(mysqle.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
            return ListaUsuario;
        }

        public Usuario Buscar(int cod)
        {
            Usuario oUsuario = new Usuario();
            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    comando.CommandText = "SELECT * FROM usuario WHERE codigo = @codigo;";
                    comando.Parameters.AddWithValue("codigo", cod);

                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        oUsuario.Codigo = Convert.ToInt32(reader["codigo"].ToString());
                        oUsuario.TipoUsuario = new TipoUsuario(Convert.ToInt32(reader["codigo_tipo_usuario"].ToString()), string.Empty);
                        oUsuario.Nome = reader["nome"].ToString();
                        oUsuario.Login = reader["login"].ToString();
                        oUsuario.Senha = reader["senha"].ToString();
                        oUsuario.Status = (Status)Convert.ToInt16(reader["situacao"]);
                        oUsuario.DtAlteracao = Convert.ToDateTime(reader["dtalteracao"].ToString());
                        oUsuario.CodigoUsrAlteracao = Convert.ToInt32(reader["codigo_usr_alteracao"].ToString());

                    }
                }
                catch (MySqlException mysqle)
                {
                    throw new System.Exception(mysqle.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
            return oUsuario;
        }

        public int BuscarProximoCodigo()
        {
            return bdFuncoes.BuscaCodigo("SHOW TABLE STATUS LIKE 'usuario'");
        }
        
    }

}
