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
                        MessageBox.Show($"O anúncio {cadAnuncio.Titulo} foi publicado com sucesso!");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        txtTitulo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível publicar anúncio");
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

                MessageBox.Show("Erro ao publicar anúncio: " + ex.Message);

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
                            MessageBox.Show("Anúncio não encontrado");
                            txtTitulo.Clear();
                            txtDescricao.Clear();
                            txtIdade.Clear();
                            txtTitulo.Focus();
                            lblId.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Anúncio não encontrado");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        txtTitulo.Focus();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher o campo Título para realizar a pesquisa!");
                    txtTitulo.Clear();
                    txtDescricao.Clear();
                    txtIdade.Clear();
                    txtTitulo.Focus();
                    lblId.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao encontrar anúncio: " + ex.Message);
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
                        MessageBox.Show("As informações do anúncio foram atualizadas com sucesso!");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        lblId.Text = "";
                        txtTitulo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível editar as informações do anúncio");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        lblId.Text = "";
                        txtTitulo.Focus();
                    }



                }
                else
                {
                    MessageBox.Show("Favor localizar o nome do título que deseja editar as informações");
                    txtTitulo.Clear();
                    txtDescricao.Clear();
                    txtIdade.Clear();
                    lblId.Text = "";
                    txtTitulo.Focus();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar dados do anúncio: " + ex.Message);

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
                        MessageBox.Show("O anúncio foi excluído com sucesso!");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        lblId.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Não foi póssível excluir anúncio");
                        txtTitulo.Clear();
                        txtDescricao.Clear();
                        txtIdade.Clear();
                        lblId.Text = "";
                    }
                
                }
                else 
                {
                    MessageBox.Show("Favor pesquisar qual anúncio deseja excluir");
                    txtTitulo.Clear();
                    txtDescricao.Clear();
                    txtIdade.Clear();
                    lblId.Text = "";
                    txtTitulo.Focus();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao excluir anúncio: " + ex.Message);
            }
        }
    }
}
