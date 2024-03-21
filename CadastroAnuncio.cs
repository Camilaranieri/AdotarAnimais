using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdotarAnimais
{
    internal class CadastroAnuncio
    {
        private int idAnuncio;
        private string titulo;
        private string descricao;
        private string idade;


        public int IdAnuncio
        {
            get { return idAnuncio; }
            set { idAnuncio = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public string Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        //metodo para cadastrar anuncio no banco de dados
        public bool CadastrarAnuncio()
        {
            try
            {
                MySqlConnection MySqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MySqlConexaoBanco.Open();

                string insert = $" insert into anuncio (titulo,descricao,idade) values ('{Titulo}','{Descricao}','{Idade}')";

                MySqlCommand comandoSql = MySqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = insert;

                comandoSql.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                //mensagem do banco quando nao for possivel cadastrar anuncios no banco
                //erro ligado ao banco de dados
                MessageBox.Show("Erro no banco de dados - metodo cadastrar anuncio: " + ex.Message);
                return false;

            }
        }

        
        public MySqlDataReader LocalizarAnuncio()
        {
            try
            {
                
                MySqlConnection MySqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MySqlConexaoBanco.Open();

                var teste = Titulo;

                string select = $" select idAnuncio, titulo, descricao, idade from anuncio where titulo = '{Titulo}';";
                MySqlCommand comandoSql = MySqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = select;

                MySqlDataReader reader = comandoSql.ExecuteReader();
                return reader;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco da dados - método localizarAnuncio: " + ex.Message);
                return null;

            }
        }


        public bool EditarAnuncio()
        {
            try
            {
                MySqlConnection MySqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MySqlConexaoBanco.Open();

                string update = $"Update anuncio set titulo = '{Titulo}', descricao = '{Descricao}', Idade = '{Idade}' where idAnuncio = {IdAnuncio};";
                MySqlCommand comandoSql = MySqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = update;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro no banco de dados - Método editarAnuncio: " + ex.Message);
                return false;
            }
        }

        public bool DeletarAnuncio()
        {
            try
            {
                MySqlConnection MySqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MySqlConexaoBanco.Open();

                string delete = $"delete from anuncio where idAnuncio = '{IdAnuncio}';";
                MySqlCommand comandoSql = MySqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = delete;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro banco de dados - método deletar anúncio: " + ex.Message);
                return false;
            }
        }
    }
}
