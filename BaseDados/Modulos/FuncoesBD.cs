using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDados.Modulos
{
    public class FuncoesBD
    {
        public int BuscaCodigo(string sql)
        {
            int codigo = 1;
                using (MySqlConnection conexao = ConexaoBaseDados.getInstancia().getConexao())
                {
                    try
                    {
                        conexao.Open();
                        MySqlCommand comando = new MySqlCommand();
                        comando = conexao.CreateCommand();

                        comando.CommandText = sql;

                        MySqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                        codigo = Convert.ToInt32(reader["Auto_increment"].ToString());
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
                return codigo;
        }
    }
}
