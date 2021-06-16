using Entidades.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Pessoas
{
    public class Cliente
    {
        public Cliente()
        {
            this.Enderecos = new List<Endereco>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public long? Telefone { get; set; }
        public long? Celular { get; set; }
        public Status Status { get; set; }
        public DateTime Dt_alteracao { get; set; }
        public int CodigoUsrAlteracao { get; set; }
        public List<Endereco> Enderecos {get; set; }
    }
}
