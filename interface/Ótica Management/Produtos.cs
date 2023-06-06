using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ótica_Management
{
    public partial class Produtos : Form
    {

        private SqlConnection CN;
        public Produtos()
        {
            InitializeComponent();
        }

        // CONNECT TO DB
        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source = " + ChangeData.DB_string + " ;" + "Initial Catalog = " + ChangeData.username + "; uid = " + ChangeData.username + ";" + "password = " + ChangeData.password);
        }


        private bool verifySGBDConnection()
        {
            if (CN == null)
                CN = getSGBDConnection();

            if (CN.State != ConnectionState.Open)
                CN.Open();
            //  MessageBox.Show("DATABASE CONNECTED");

            return CN.State == ConnectionState.Open;
        }


        private void novo_Click(object sender, EventArgs e)
        {
            AddProduto form = new AddProduto();
            form.ListBoxP = listBoxP; // Atribui a referência da ListBox ao formulário AddProduto
            form.FormClosed += (s, args) => { listBoxP.Refresh(); }; // Atualiza a ListBox após fechar o formulário
            form.Show();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se há um item selecionado
            if (listBoxP.SelectedItem != null)
            {
                // Obtém o nome selecionado
                string name = listBoxP.SelectedItem.ToString();

                //PROCURAR DADOS NA BD
                try
                {
                    CN.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Otica_Produto WHERE Otica_Produto.nome = @name", CN);
                    cmd.Parameters.AddWithValue("@name", name);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Crie variáveis para armazenar os dados do cliente
                        string id = string.Empty;
                        string nome = string.Empty;
                        string marca = string.Empty;
                        string tipo = string.Empty;
                        string preco = string.Empty;


                        // Leitura dos dados do cliente
                        while (reader.Read())
                        {
                            nome = reader["nome"].ToString();
                            id = reader["id"].ToString();
                            marca = reader["marca"].ToString();
                            tipo = reader["tipo"].ToString();
                            preco = reader["preço"].ToString();

                        }

                        CN.Close();
                        reader.Close();

                        ide.Text = id;
                        nome1.Text = nome;
                        marca1.Text = marca;
                        preço1.Text = preco;
                        tipo1.Text = tipo;


                    }

                    CN.Close();
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao procurar cliente: " + ex.Message);
                }
            }
        }

        private void Produtos_Load(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                CN.Open();

                SqlCommand cmd = new SqlCommand("SELECT nome, id FROM Otica_Produto", CN);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    string nome = string.Empty;


                    // Limpar a ListBox antes de adicionar os novos nomes
                    listBoxP.Items.Clear();

                    // Leitura dos dados do cliente
                    while (reader.Read())
                    {
                        nome = reader["nome"].ToString();

                        listBoxP.Items.Add(nome);
                    }

                    CN.Close();
                    reader.Close();
                }
            }
        }

        private void info_Click(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {


                String id = procura.Text;



                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("Por favor, insira o ID do produto");
                    return; // Aborta a execução do evento
                }
                else
                {
                    //PROCURAR DADOS NA BD
                    try
                    {

                        SqlCommand cmd = new SqlCommand("getProdutbyID ", CN);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        CN.Open();


                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Crie variáveis para armazenar os dados do cliente
                            string id1 = string.Empty;
                            string nome = string.Empty;
                            string marca = string.Empty;
                            string tipo = string.Empty;
                            string preco = string.Empty;


                            // Leitura dos dados do cliente
                            while (reader.Read())
                            {
                                nome = reader["nome"].ToString();
                                id1 = reader["id"].ToString();
                                marca = reader["marca"].ToString();
                                tipo = reader["tipo"].ToString();
                                preco = reader["preço"].ToString();

                            }

                            CN.Close();
                            reader.Close();

                            ide.Text = id1;
                            nome1.Text = nome;
                            marca1.Text = marca;
                            preço1.Text = preco;
                            tipo1.Text = tipo;
                        }
                        else
                        {
                            CN.Close();
                            reader.Close();
                            throw new Exception("Produto não existe!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao procurar produto: " + ex.Message);
                    }
                    finally
                    {
                        CN.Close(); // Fechar a conexão no caso de exceção
                    }
                }
            }

            else if (!verifySGBDConnection())
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE", "Connection Test", MessageBoxButtons.OK);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ide.Text))
            {
                MessageBox.Show("Tem que selecionar um produto");
                return;
            }
            else
            {

                int idProduto = int.Parse(ide.Text);

                bool temp = verifySGBDConnection();
                CN.Close();
                if (temp)
                {
                    // Exibe uma caixa de diálogo de confirmação
                    DialogResult result = MessageBox.Show("Tem a certeza que pretende eliminar este produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    // Verifica a resposta do usuário
                    if (result == DialogResult.Yes)
                    {

                        // Chama a stored procedure para eliminar o produto
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("RemoverProduto", CN))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id", idProduto);

                                CN.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();
                                CN.Close();

                                if (rowsAffected > 0)
                                {

                                    MessageBox.Show("Produto eliminado com sucesso! Necessita de voltar atrás para atualizar a lista");

                                }
                                else
                                {
                                    MessageBox.Show("Não foi possível eliminar o produto.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocorreu um erro ao eliminar o produto: " + ex.Message);
                        }
                        finally
                        {
                            CN.Close(); // Fechar a conexão no caso de exceção
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cancelado!");
                        return;
                    }
                }

            }
        }

        private void stock_Click(object sender, EventArgs e)
        {
            stock stock = new stock();
            stock.Show();
        }

        public bool VerificarProdutoEmStock(int produtoID)
        {

            bool disponibilidade = false;
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                try
                {

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand($"SELECT dbo.IsProductInStock({produtoID})", CN))
                        {

                            CN.Open();
                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                disponibilidade = (bool)result;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao chamar a UDF: " + ex.Message);
                    }
                    finally
                    {
                        CN.Close();
                    }




                }


                catch (Exception ex)
                {
                    // Trate qualquer exceção ocorrida durante a execução da consulta
                    Console.WriteLine("Erro ao verificar produto em stock: " + ex.Message);


                }
                finally
                {
                    CN.Close(); // Fechar a conexão no caso de exceção
                }

            }
            return disponibilidade;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ide.Text))
            {
                MessageBox.Show("Tem que selecionar um produto");
                return;
            }
            else
            {
                int produtoID = int.Parse(ide.Text);

                bool disponibilidade = VerificarProdutoEmStock(produtoID);

                if (disponibilidade)
                {
                    MessageBox.Show("O produto encontra-se em stock.");
                }
                else
                {
                    MessageBox.Show("O produto encontra-se em stock.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}