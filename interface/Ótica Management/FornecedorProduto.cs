using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ótica_Management
{
    public partial class FornecedorProduto : Form
    {
        private SqlConnection CN;

        public FornecedorProduto()
        {
            InitializeComponent();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=" + ChangeData.DB_string + ";Initial Catalog=" + ChangeData.username + ";User ID=" + ChangeData.username + ";Password=" + ChangeData.password);
        }

        private bool verifySGBDConnection()
        {
            if (CN == null)
                CN = getSGBDConnection();

            if (CN.State != ConnectionState.Open)
                CN.Open();

            return CN.State == ConnectionState.Open;
        }

        private void FornecedorProduto_Load(object sender, EventArgs e)
        {
            if (verifySGBDConnection())
            {
                string query = "SELECT nome FROM Otica_Produto";
                SqlCommand command = new SqlCommand(query, CN);
                string query2 = "SELECT nome FROM Otica_Fornecedor";
                SqlCommand command2 = new SqlCommand(query2, CN);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();

                    while (reader.Read())
                    {
                        string nomeProduto = reader["nome"].ToString();
                        listBox1.Items.Add(nomeProduto);
                    }

                    reader.Close();

                    SqlDataReader reader2 = command2.ExecuteReader();
                    listBox2.Items.Clear();

                    while (reader2.Read())
                    {
                        string nomeFornecedor = reader2["nome"].ToString();
                        listBox2.Items.Add(nomeFornecedor);
                    }

                    reader2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao recuperar os nomes dos produtos: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Falha ao conectar ao banco de dados.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null || listBox2.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um produto e um fornecedor.");
                return;
            }

            string produtoSelecionado = listBox1.SelectedItem.ToString();
            string fornecedorSelecionado = listBox2.SelectedItem.ToString();

            if (verifySGBDConnection())
            {
                try
                {
                    // Obter o ID do produto selecionado
                    string queryProdutoId = "SELECT id FROM Otica_Produto WHERE nome = @produto";
                    SqlCommand cmdProdutoId = new SqlCommand(queryProdutoId, CN);
                    cmdProdutoId.Parameters.AddWithValue("@produto", produtoSelecionado);
                    string produtoId = cmdProdutoId.ExecuteScalar()?.ToString();

                    // Obter o NIF do fornecedor selecionado
                    string queryFornecedorNif = "SELECT nif FROM Otica_Fornecedor WHERE nome = @fornecedor";
                    SqlCommand cmdFornecedorNif = new SqlCommand(queryFornecedorNif, CN);
                    cmdFornecedorNif.Parameters.AddWithValue("@fornecedor", fornecedorSelecionado);
                    string fornecedorNif = cmdFornecedorNif.ExecuteScalar()?.ToString();

                    // Inserir na tabela Otica_Fornecido_Por
                    string queryInserirFornecidoPor = "INSERT INTO Otica_Fornecido_Por (produto_id, fornecedor_nif) " +
                                                      "VALUES (@produtoId, @fornecedorNif)";
                    SqlCommand cmdInserirFornecidoPor = new SqlCommand(queryInserirFornecidoPor, CN);
                    cmdInserirFornecidoPor.Parameters.AddWithValue("@produtoId", produtoId);
                    cmdInserirFornecidoPor.Parameters.AddWithValue("@fornecedorNif", fornecedorNif);
                    cmdInserirFornecidoPor.ExecuteNonQuery();

                    MessageBox.Show("Relacionamento produto-fornecedor adicionado com sucesso!");

                    // Limpar seleções na ListBox
                    listBox1.ClearSelected();
                    listBox2.ClearSelected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar o relacionamento produto-fornecedor: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Falha ao conectar ao banco de dados.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
