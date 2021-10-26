using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Atv_2.Models
{
    public class UsuarioRepository
    {
        //objetivo: é criar as funcionalidades/métodos que manipulam os 
        //atributos da classe Usuario

        //Cadastrar,Listar,Alterar,Editar,Excluir - CRUD (C - create, R - read, U - update, D - Delete

        //definir as credencias do banco de dados
        private const string DadosConexao = "Database=atv2_uc04; Data Source=localhost; User Id=root;";

        public void TestarConexao()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando!");
            Conexao.Close();
        }

        public Usuario ValidarLogin(Usuario user)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "select * from Usuario where Login=@Login and Senha=@Senha";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = null;
            if (Reader.Read())
            {

                UsuarioEncontrado = new Usuario();
                UsuarioEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");

                UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }

            Conexao.Close();
            return UsuarioEncontrado;
        }

        public Usuario BuscarPorId(int Id)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "select * from Usuario where Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = new Usuario();
            if (Reader.Read())
            {
                UsuarioEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");

                UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }

            Conexao.Close();

            return UsuarioEncontrado;

        }


        public List<Usuario> Listar()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "select * from Usuario";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Usuario> Lista = new List<Usuario>();

            while (Reader.Read())
            {

                Usuario userEncontrado = new Usuario();
                userEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    userEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    userEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    userEncontrado.Senha = Reader.GetString("Senha");


                userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

                Lista.Add(userEncontrado);
            }

            Conexao.Close();

            return Lista;
        }

        public void Cadastrar(Usuario user)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Insert into Usuario (Nome,Login,Senha,DataNascimento) values (@Nome,@Login,@Senha,@DataNascimento)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);

            Comando.ExecuteNonQuery();

            Conexao.Close();

        }


        public void Editar(Usuario user)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "update Usuario set Nome=@Nome, Login=@Login, Senha=@Senha, DataNascimento=@DataNascimento where Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", user.Id);
            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);

            Comando.ExecuteNonQuery();

            Conexao.Close();

        }


        public void Excluir(Usuario user)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "delete from Usuario where Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", user.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}