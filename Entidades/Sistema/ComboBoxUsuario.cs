namespace Entidades.Sistema
{
    public class ComboBoxUsuario
    {
        public string Login { get; set; }
        public int Codigo { get; set; }
        public string Senha { get; set; }
        public ComboBoxUsuario(string login, int codigo, string senha)
        {
            Login = login;
            Codigo = codigo;
            Senha = senha;
        }

        public override string ToString()
        {
            return Login;
        }
    }
}