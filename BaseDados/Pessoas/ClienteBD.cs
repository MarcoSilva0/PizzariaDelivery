using BaseDados.Modulos;
using Entidades.Entidades;
using Entidades.Enumeradores;
using Entidades.Pessoas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BaseDados.Pessoas
{
    public class ClienteBD
    {
        private readonly FuncoesBD bdFuncoes = new FuncoesBD();

        public bool Inserir(Cliente oCliente)
        {
            bool IsRetorno = false;

            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                MySqlTransaction transacao = null;
                try
                {
                    conexao.Open();
                    transacao = conexao.BeginTransaction();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    comando.Connection = conexao;
                    comando.Transaction = transacao;

                    int valorRetorno = 0;

                    comando.CommandText = @"INSERT INTO cliente(
                                            nome, telefone, celular, situacao, dt_alteracao, codigo_usr_alteracao)
                                            VALUES(
                                            @nome, @telefone, @celular, @situacao, NOW(), @codigo_usr_alteracao)";


                    comando.Parameters.AddWithValue("nome", oCliente.Nome);
                    comando.Parameters.AddWithValue("telefone", oCliente.Telefone);
                    comando.Parameters.AddWithValue("celular", oCliente.Celular);
                    comando.Parameters.AddWithValue("situacao",(int)oCliente.Status);
                    comando.Parameters.AddWithValue("codigo_usr_alteracao", oCliente.CodigoUsrAlteracao);

                    valorRetorno = comando.ExecuteNonQuery();
                    if(valorRetorno < 1)
                        return IsRetorno;
                   
                    comando.CommandText = string.Empty;
                    comando.Parameters.Clear();

                    //buscar codigo do cliente
                    comando.CommandText = "SHOW TABLE STATUS LIKE 'cliente'";

                    int iCodClienteInserido = 0;

                    using(MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                            iCodClienteInserido = Convert.ToInt32(reader["Auto_increment"].ToString()) - 1;

                    }

                    comando.CommandText = string.Empty;
                    comando.Parameters.Clear();

                    //inserindo endereços

                    foreach (Endereco oEnd in oCliente.Enderecos)
                    {
                        oEnd.CodigoCliente = iCodClienteInserido;

                        comando.CommandText = @"INSERT INTO endereco_cliente (
                                                codigo_cliente, rua, numero, complemento, bairro, cidade)
                                                VALUES(
                                                @codigo_cliente, @rua, @numero, @complemento, @bairro, @cidade);";

                        comando.Parameters.AddWithValue("codigo_cliente", oEnd.CodigoCliente);
                        comando.Parameters.AddWithValue("rua", oEnd.Rua);
                        comando.Parameters.AddWithValue("numero", oEnd.Numero);
                        comando.Parameters.AddWithValue("complemento", oEnd.Complemento);
                        comando.Parameters.AddWithValue("bairro", oEnd.Bairro);
                        comando.Parameters.AddWithValue("cidade", oEnd.Cidade);

                        valorRetorno = comando.ExecuteNonQuery();
                        if (valorRetorno < 1)
                        {
                            return IsRetorno;
                        }

                        comando.CommandText = string.Empty;
                        comando.Parameters.Clear();

                        if (oEnd.IsEnderecoPadrao)
                        {
                            //buscar codigo do endereco
                            comando.CommandText = "SHOW TABLE STATUS LIKE 'endereco_cliente'";

                            int iCodEndereoCliente = 0;

                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                while (reader.Read())
                                    iCodEndereoCliente = Convert.ToInt32(reader["Auto_increment"].ToString()) - 1;

                            }
                            comando.CommandText = string.Empty;
                            comando.Parameters.Clear();

                            //inserindo endereco padrao
                            comando.CommandText = @"INSERT INTO endereco_padrao_cliente(
                                                codigo_cliente, codigo_endereco)
                                                VALUES(
                                                @codigo_cliente, @codigo_endereco);";
                            comando.Parameters.AddWithValue("codigo_cliente", iCodClienteInserido);
                            comando.Parameters.AddWithValue("codigo_endereco", iCodEndereoCliente);
                            valorRetorno = comando.ExecuteNonQuery();
                            if (valorRetorno < 1)
                            {
                                return IsRetorno;
                            }

                            comando.CommandText = string.Empty;
                            comando.Parameters.Clear();

                        }
                    }

                    IsRetorno = true;
                }
                catch(MySqlException mysqle)
                {
                   
                    throw new Exception(mysqle.ToString());
                }
                finally
                {
                    if (!IsRetorno)
                    {
                        transacao.Rollback();
                    }
                    else
                    {
                        transacao.Commit();
                    }
                    conexao.Close();
                }
            }

            return IsRetorno;
        }

        public bool Alterar(Cliente oCliente)
        {
            bool IsRetorno = false;

            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                MySqlTransaction transacao = null;
                try
                {
                    conexao.Open();
                    transacao = conexao.BeginTransaction();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    comando.Connection = conexao;
                    comando.Transaction = transacao;

                    int valorRetorno = 0;

                    //Alterar os dados do cliente

                    comando.CommandText = @"UPDATE cliente SET
                                            nome = @nome, telefone = @telefone, celular = @celular, situacao = @situacao, dt_alteracao = NOW(), codigo_usr_alteracao = @codigo_usr_alteracao 
                                             WHERE (codigo = @codigo);";


                    comando.Parameters.AddWithValue("codigo", oCliente.Codigo);
                    comando.Parameters.AddWithValue("nome", oCliente.Nome);
                    comando.Parameters.AddWithValue("telefone", oCliente.Telefone);
                    comando.Parameters.AddWithValue("celular", oCliente.Celular);
                    comando.Parameters.AddWithValue("situacao", (int)oCliente.Status);
                    comando.Parameters.AddWithValue("codigo_usr_alteracao", oCliente.CodigoUsrAlteracao);

                    valorRetorno = comando.ExecuteNonQuery();
                    if (valorRetorno < 1)                  
                        return IsRetorno;                   

                    comando.CommandText = string.Empty;
                    comando.Parameters.Clear();

                    // REMOVENDO ENDERECO CLIENTE PARA INSERIR NOVAMENTE

                    comando.CommandText = "DELETE FROM endereco_padrao_cliente WHERE codigo_cliente = @codigo_cliente";

                    comando.Parameters.AddWithValue("codigo_padrao_cliente", oCliente.Codigo);

                    valorRetorno = comando.ExecuteNonQuery();

                    if (valorRetorno < 1)
                        return IsRetorno;

                    comando.CommandText = string.Empty;
                    comando.Parameters.Clear();

                    //REMOVER ENDERÇO ANTIGO
                    comando.CommandText = "DELETE FROM endereco_cliente WHERE codigo_cliente = @codigo_cliente;";

                    comando.Parameters.AddWithValue("codigo_cliente", oCliente.Codigo);

                    valorRetorno = comando.ExecuteNonQuery();
                    if (valorRetorno < 1)
                        return IsRetorno;

                    comando.CommandText = string.Empty;
                    comando.Parameters.Clear();


                    //inserindo endereços

                    foreach (Endereco oEnd in oCliente.Enderecos)
                    {
                        oEnd.CodigoCliente = oCliente.Codigo;

                        comando.CommandText = @"INSERT INTO endereco_cliente(
                                                codigo_cliente, rua, numero, complemento, bairro, cidade)
                                                VALUES(
                                                @codigo_cliente, @rua, @numero, @complemento, @bairro, @cidade);";

                        comando.Parameters.AddWithValue("codigo_cliente", oEnd.CodigoCliente);
                        comando.Parameters.AddWithValue("rua", oEnd.Rua);
                        comando.Parameters.AddWithValue("numero", oEnd.Numero);
                        comando.Parameters.AddWithValue("complemento", oEnd.Complemento);
                        comando.Parameters.AddWithValue("bairro", oEnd.Bairro);
                        comando.Parameters.AddWithValue("cidade", oEnd.Cidade);

                        valorRetorno = comando.ExecuteNonQuery();
                        if (valorRetorno < 1)
                        {
                            return IsRetorno;
                        }

                        comando.CommandText = string.Empty;
                        comando.Parameters.Clear();

                        if (oEnd.IsEnderecoPadrao)
                        { 
                            //buscar codigo do endereco
                            comando.CommandText = "SHOW TABLE STATUS LIKE 'endereco_cliente'";

                            int iCodEndereoCliente = 0;

                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                while (reader.Read())
                                    iCodEndereoCliente = Convert.ToInt32(reader["Auto_increment"].ToString()) - 1;

                            }
                            comando.CommandText = string.Empty;
                            comando.Parameters.Clear();

                            //inserindo endereco padrao
                            comando.CommandText = @"INSERT INTO endereco_padrao_cliente(
                                                codigo_cliente, codigo_endereco)
                                                VALUES(
                                                @codigo_cliente, @codigo_endereco);";
                            comando.Parameters.AddWithValue("codigo_cliente", oCliente.Codigo);
                            comando.Parameters.AddWithValue("codigo_endereco", iCodEndereoCliente);
                            valorRetorno = comando.ExecuteNonQuery();
                            if (valorRetorno < 1)
                            {
                                return IsRetorno;
                            }

                            comando.CommandText = string.Empty;
                            comando.Parameters.Clear();
                        }
                        
                    }
                    IsRetorno = true;
                }

                catch (MySqlException mysqle)
                {
                    throw new Exception(mysqle.ToString());
                }
                finally
                {
                    if (!IsRetorno)
                    {
                        transacao.Rollback();
                    }
                    else
                    {
                        transacao.Commit();
                    }
                    conexao.Close();

                }
            }

            return IsRetorno;
        }

        public bool Excluir(int iCodCliente)
        {
            bool IsRetorno = false;

            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                MySqlTransaction transacao = null;
                try
                {
                    conexao.Open();
                    transacao = conexao.BeginTransaction();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    comando.Connection = conexao;
                    comando.Transaction = transacao;

                    int valorRetorno = 0;
                    
                    // REMOVENDO ENDERECO CLIENTE PARA INSERIR NOVAMENTE

                    comando.CommandText = "DELETE FROM endereco_padrao_cliente WHERE codigo_cliente = @codigo_cliente";

                    comando.Parameters.AddWithValue("codigo_padrao_cliente", iCodCliente);

                    valorRetorno = comando.ExecuteNonQuery();

                    if (valorRetorno < 1)
                        return IsRetorno;

                    comando.CommandText = string.Empty;
                    comando.Parameters.Clear();

                    //REMOVER ENDERÇO ANTIGO
                    comando.CommandText = "DELETE FROM endereco_cliente WHERE codigo_cliente = @codigo_cliente;";

                    comando.Parameters.AddWithValue("codigo_cliente", iCodCliente);

                    valorRetorno = comando.ExecuteNonQuery();
                    if (valorRetorno < 1)
                        return IsRetorno;

                    comando.CommandText = string.Empty;
                    comando.Parameters.Clear();

                    // REMOVER CLIENTE

                    comando.CommandText = "DELETE FROM cliente WHERE codigo = @codigo";

                    comando.Parameters.AddWithValue("codigo", iCodCliente);

                    valorRetorno = comando.ExecuteNonQuery();
                    if (valorRetorno < 1)
                        return IsRetorno;

                    IsRetorno = true;
                }

                catch (MySqlException mysqle)
                {
                    throw new Exception(mysqle.ToString());
                }
                finally
                {
                    if (!IsRetorno)
                    {
                        transacao.Rollback();
                    }
                    else
                    {
                        transacao.Commit();
                    }
                    conexao.Close();

                }
            }

            return IsRetorno;
        }

        public List<EntidadeViewPesquisaCliente> ListarPesquisaCliente(Status status, string termoBusca)
        {
            var ListaEntidade = new List<EntidadeViewPesquisaCliente>();
            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    string query = @"SELECT codigo, nome, telefone, celular 
                                            FROM cliente";

                    if (status != Status.Todos)
                        query += " WHERE situacao = @situacao";

                    if (!termoBusca.Equals(string.Empty))
                    {
                        if (status == Status.Todos)
                            query += " WHERE";
                        else
                            query += " AND ";

                        var termos = termoBusca.Split(' ');
                        foreach(var termo in termos)
                        {
                            query += " nome LIKE '%" + termo + "%' AND";
                        }
                        query = query.Substring(0, query.Length - 3);
                    }

                    comando.CommandText = query;


                    if (status != Status.Todos)
                        comando.Parameters.AddWithValue("situacao", (int)status);

                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        var oEntidade = new EntidadeViewPesquisaCliente();
                        oEntidade.Codigo = Convert.ToInt32(reader["codigo"].ToString());
                        oEntidade.Nome = reader["nome"].ToString();
                        if (!(reader["telefone"] is System.DBNull)) 
                        oEntidade.Telefone = Convert.ToInt64(reader["telefone"]).ToString("(##) ####-####");
                        if (!(reader["celular"] is System.DBNull))
                            oEntidade.Celular = Convert.ToInt64(reader["celular"]).ToString("(##) #####-####");

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

        public Cliente Buscar(int cod)
        {
            var oCliente = new Cliente();
            using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();
                    comando = conexao.CreateCommand();

                    comando.CommandText = "SELECT * FROM cliente WHERE codigo = @codigo;";
                    comando.Parameters.AddWithValue("codigo", cod);

                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        oCliente.Codigo = Convert.ToInt32(reader["codigo"].ToString());
                        oCliente.Nome = reader["nome"].ToString();
                        if(!(reader["telefone"] is System.DBNull))
                        oCliente.Telefone = Convert.ToInt64(reader["telefone"].ToString());
                        if (!(reader["celular"] is System.DBNull))
                            oCliente.Celular = Convert.ToInt64(reader["celular"].ToString());
                        oCliente.Status = (Status)Convert.ToInt16(reader["situacao"]);
                        oCliente.Dt_alteracao = Convert.ToDateTime(reader["dt_alteracao"].ToString());
                        oCliente.CodigoUsrAlteracao = Convert.ToInt32(reader["codigo_usr_alteracao"].ToString());
                        oCliente.Enderecos = new EnderecoClienteBD().BuscarEnderecosCliente(oCliente.Codigo);
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
            return oCliente;
        }

        public int BuscarProximoCodigo()
        {
            return bdFuncoes.BuscaCodigo("SHOW TABLE STATUS LIKE 'cliente'");
        }
    
    }
}
