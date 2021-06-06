using Entidades.Entidades;
using Entidades.Enumeradores;
using Entidades.Pessoas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BaseDados.Pessoas
{
    public class TipoUsuarioBD
    {
        public List<EntidadeViewPesquisa> ListarEntidadesViewPesquisa()
        {
            var ListaEntidade = new List<EntidadeViewPesquisa>();
            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    string query = @"SELECT codigo, descricao, '1' AS situacao 
                                            FROM tipo_usuario;";
                    
                    comando.CommandText = query;

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

        public TipoUsuario BucasTipoUsuarioDoUsuario(int codigo)
        {
            TipoUsuario tipoUsuario = new TipoUsuario();
            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    comando.CommandText = @"SELECT 
                                        U.codigo_tipo_usuario AS CodigoTipoUsuario,
                                        TU.descricao AS DescricaoTipoUsuario
                                        FROM usuario AS U
                                        INNER JOIN tipo_usuario AS TU ON U.codigo_tipo_usuario = TU.codigo
                                        WHERE U.codigo = @codigo";

                    comando.Parameters.AddWithValue("codigo", codigo);

                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        tipoUsuario = new TipoUsuario();
                        tipoUsuario.Codigo = Convert.ToInt32(reader["CodigoTipoUsuario"].ToString());
                        tipoUsuario.Descricao = reader["DescricaoTipoUsuario"].ToString();


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
            return tipoUsuario;
        }

        public TipoUsuario Buscar(int codigo)
        {
            TipoUsuario tipoUsuario = new TipoUsuario();
            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    comando.CommandText = @"SELECT * FROM tipo_usuario WHERE codigo = @codigo";
                    comando.Parameters.AddWithValue("codigo", codigo);

                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        tipoUsuario = new TipoUsuario();
                        tipoUsuario.Codigo = Convert.ToInt32(reader["codigo"].ToString());
                        tipoUsuario.Descricao = reader["descricao"].ToString();


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
            return tipoUsuario;
        }
    }
}
