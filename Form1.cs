using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AdotarAnimais
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTitulo.Text.Equals("kkkk") &&  !txtDescricao.Text.Equals("")  && !txtIdade.Text.Equals(""))
                {
                    CadastroAnuncio cadAnuncio = new CadastroAnuncio();
                    cadAnuncio.Titulo = txtTitulo.Text;
                    cadAnuncio.Descricao = txtDescricao.Text;
                    cadAnuncio.Idade = txtIdade.Text;


                    if (cadAnuncio.CadastrarAnuncio())
                    {
                        MessageBox.Show($"O an�ncio {cadAnuncio.Titulo} foi publicado com sucesso!");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        txtTitulo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("N�o foi poss�vel publicar an�ncio");
                    }

                }
                else
                {
                    MessageBox.Show("Preencha todos os campos corretamente!");
                    txtTitulo.Clear();
                    txtDescricao.Clear();
                    txtIdade.Clear();
                    txtTitulo.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao publicar an�ncio: " + ex.Message);

            }
        }



        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTitulo.Text.Equals(""))
                {
                    CadastroAnuncio cadAnuncio = new CadastroAnuncio();
                    cadAnuncio.Titulo = txtTitulo.Text;

                    MySqlDataReader reader = cadAnuncio.LocalizarAnuncio();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            lblId.Text = reader["idAnuncio"].ToString();
                            txtDescricao.Text = reader["descricao"].ToString();
                            txtIdade.Text = reader["idade"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("An�ncio n�o encontrado");
                            txtTitulo.Clear();
                            txtDescricao.Clear();
                            txtIdade.Clear();
                            txtTitulo.Focus();
                            lblId.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("An�ncio n�o encontrado");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        txtTitulo.Focus();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher o campo T�tulo para realizar a pesquisa!");
                    txtTitulo.Clear();
                    txtDescricao.Clear();
                    txtIdade.Clear();
                    txtTitulo.Focus();
                    lblId.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao encontrar an�ncio: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtTitulo.Clear();
            txtDescricao.Clear();
            txtIdade.Clear();
            lblId.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTitulo.Text.Equals("") && !txtDescricao.Text.Equals("") && !txtIdade.Text.Equals(""))
                {
                    CadastroAnuncio cadAnuncio = new CadastroAnuncio();
                    cadAnuncio.IdAnuncio = Convert.ToInt32(lblId.Text);
                    cadAnuncio.Titulo = txtTitulo.Text;
                    cadAnuncio.Descricao = txtDescricao.Text;
                    cadAnuncio.Idade = txtIdade.Text;

                    if (cadAnuncio.EditarAnuncio())
                    {
                        MessageBox.Show("As informa��es do an�ncio foram atualizadas com sucesso!");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        lblId.Text = "";
                        txtTitulo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("N�o foi poss�vel editar as informa��es do an�ncio");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        lblId.Text = "";
                        txtTitulo.Focus();
                    }



                }
                else
                {
                    MessageBox.Show("Favor localizar o nome do t�tulo que deseja editar as informa��es");
                    txtTitulo.Clear();
                    txtDescricao.Clear();
                    txtIdade.Clear();
                    lblId.Text = "";
                    txtTitulo.Focus();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar dados do an�ncio: " + ex.Message);

            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTitulo.Text.Equals("") && !txtDescricao.Text.Equals("") && !txtIdade.Text.Equals(""))
                {
                    CadastroAnuncio cadAnuncio = new CadastroAnuncio();
                    cadAnuncio.IdAnuncio = int.Parse(lblId.Text);
                    if (cadAnuncio.DeletarAnuncio())
                    {
                        MessageBox.Show("O an�ncio foi exclu�do com sucesso!");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        lblId.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("N�o foi p�ss�vel excluir an�ncio");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        lblId.Text = "";
                    }
                
                }
                else 
                {
                    MessageBox.Show("Favor pesquisar qual an�ncio deseja excluir");
                    txtTitulo.Clear();
                    txtDescricao.Clear();
                    txtIdade.Clear();
                    lblId.Text = "";
                    txtTitulo.Focus();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao excluir an�ncio: " + ex.Message);
            }
        }
    }
}
