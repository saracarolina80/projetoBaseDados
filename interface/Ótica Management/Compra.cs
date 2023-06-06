using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ótica_Management
{
    public partial class Compra : Form
    {
        private SqlConnection CN;
        public Compra()
        {
            InitializeComponent();
        }

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

        private void Compra_Load(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                CN.Open();
                string query = "SELECT CC FROM Otica_Cliente";
                SqlCommand command = new SqlCommand(query, CN);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    listBox1.Items.Clear();

                    while (reader.Read())
                    {
                        string cc = reader["CC"].ToString();
                        listBox1.Items.Add(cc);
                    }

                    reader.Close();
                }

                string query2 = "SELECT nome FROM Otica_Produto";
                SqlCommand command2 = new SqlCommand(query2, CN);
                SqlDataReader reader2 = command2.ExecuteReader();

                if (reader2.HasRows)
                {
                    listBox2.Items.Clear();

                    while (reader2.Read())
                    {
                        string nome = reader2["nome"].ToString();
                        listBox2.Items.Add(nome);
                    }

                    CN.Close();
                    reader2.Close();
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && listBox2.SelectedItem != null && !string.IsNullOrEmpty(textBox1.Text))
            {
                string ccCliente = listBox1.SelectedItem.ToString();
                string nomeProduto = listBox2.SelectedItem.ToString();
                int quantidade = Convert.ToInt32(textBox1.Text);

                try
                {
                    CN.Open();

                    SqlCommand cmdCliente = new SqlCommand("SELECT CC FROM Otica_Cliente WHERE CC = @ccCliente", CN);
                    cmdCliente.Parameters.AddWithValue("@ccCliente", ccCliente);
                    int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

                    SqlCommand cmdProduto = new SqlCommand("SELECT id, preço FROM Otica_Produto WHERE nome = @nomeProduto", CN);
                    cmdProduto.Parameters.AddWithValue("@nomeProduto", nomeProduto);
                    SqlDataReader readerProduto = cmdProduto.ExecuteReader();
                    int idProduto = 0;
                    decimal precoProduto = 0;

                    if (readerProduto.Read())
                    {
                        idProduto = Convert.ToInt32(readerProduto["id"]);
                        precoProduto = Convert.ToDecimal(readerProduto["preço"]);
                    }

                    readerProduto.Close();

                    decimal precoTotal = precoProduto * quantidade;

                    //SqlCommand cmdUpdateStock = new SqlCommand("UPDATE Otica_Stock SET quantidade = quantidade - @quantidade WHERE produto_id = @idProduto", CN);
                    //cmdUpdateStock.Parameters.AddWithValue("@quantidade", quantidade);
                    //cmdUpdateStock.Parameters.AddWithValue("@idProduto", idProduto);
                    //cmdUpdateStock.ExecuteNonQuery();

                    SqlCommand command = new SqlCommand("RegistarVendaProduto", CN);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cliente_cc", ccCliente);
                    command.Parameters.AddWithValue("@produto_id", idProduto);
                    command.Parameters.AddWithValue("@n_produtos", quantidade);
                    command.ExecuteNonQuery();

                    SqlCommand cmdUltimoID = new SqlCommand("SELECT ISNULL(MAX(id), 0) FROM Otica_Fatura", CN);
                    int ultimoID = Convert.ToInt32(cmdUltimoID.ExecuteScalar());
                    int novoID = ultimoID + 1;

                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Otica_Fatura (id, descriçao, iva, preco, cliente_cc) VALUES (@id, @descricao, @iva, @preco, @ccCliente)", CN);
                    cmdInsert.Parameters.AddWithValue("@id", novoID);
                    cmdInsert.Parameters.AddWithValue("@descricao", nomeProduto);
                    cmdInsert.Parameters.AddWithValue("@iva", 23);
                    cmdInsert.Parameters.AddWithValue("@preco", precoTotal);
                    cmdInsert.Parameters.AddWithValue("@ccCliente", ccCliente);
                    cmdInsert.ExecuteNonQuery();

                    int idFatura = Convert.ToInt32(cmdInsert.Parameters["@id"].Value); // Recupera o ID da fatura inserida

                    // Adicionar informações à tabela Otica_Pagamento
                    SqlCommand cmdRegistarPagamento = new SqlCommand("RegistarPagamentoFatura", CN);
                    cmdRegistarPagamento.CommandType = CommandType.StoredProcedure;
                    cmdRegistarPagamento.Parameters.AddWithValue("@id", novoID); // Defina o ID adequado para o pagamento
                    cmdRegistarPagamento.Parameters.AddWithValue("@data", DateTime.Now); // Define a data atual para o pagamento
                    cmdRegistarPagamento.Parameters.AddWithValue("@valor", precoTotal); // Define o valor adequado para o pagamento
                    cmdRegistarPagamento.Parameters.AddWithValue("@metodo", "dinheiro"); // Define o método de pagamento como "dinheiro"
                    cmdRegistarPagamento.Parameters.AddWithValue("@comprovativo", "Pagamento efetuado"); // Define o comprovativo como "Pagamento efetuado"
                    cmdRegistarPagamento.Parameters.AddWithValue("@cliente_cc", idCliente); // Define o CC do cliente adequado para o pagamento
                    cmdRegistarPagamento.Parameters.AddWithValue("@fatura_id", idFatura); // Define o ID da fatura adequado para o pagamento
                    cmdRegistarPagamento.ExecuteNonQuery();

                    MessageBox.Show("Dados inseridos com sucesso!");

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ocorreu um erro ao inserir os dados: " + ex.Message);
                }
                finally
                {
                    CN.Close();
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente, um produto e insira a quantidade antes de prosseguir.");
            }
        }




    }
}
