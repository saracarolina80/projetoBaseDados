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
    public partial class Receita : Form
    {
        private SqlConnection CN;
        private int receitaId = 1;

        public Receita()
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

        private void Receita_Load(object sender, EventArgs e)
        {
            CN = getSGBDConnection(); // Adicione esta linha para obter uma nova instância de conexão
            try
            {
                CN.Open();

                // Consultar os nomes dos doutores e adicionar ao comboBox1
                string queryDoutores = "SELECT nome FROM Otica_Pessoa JOIN Otica_Doutor ON Otica_Pessoa.CC = Otica_Doutor.CC";
                SqlCommand cmdDoutores = new SqlCommand(queryDoutores, CN);
                SqlDataReader readerDoutores = cmdDoutores.ExecuteReader();

                comboBox1.Items.Clear();
                while (readerDoutores.Read())
                {
                    string nomeDoutor = readerDoutores["nome"].ToString();
                    comboBox1.Items.Add(nomeDoutor);
                }
                readerDoutores.Close();

                // Consultar os produtos e adicionar ao comboBox2
                string queryProdutos = "SELECT nome FROM Otica_Produto";
                SqlCommand cmdProdutos = new SqlCommand(queryProdutos, CN);
                SqlDataReader readerProdutos = cmdProdutos.ExecuteReader();

                comboBox2.Items.Clear();
                while (readerProdutos.Read())
                {
                    string nomeProduto = readerProdutos["nome"].ToString();
                    comboBox2.Items.Add(nomeProduto);
                }
                readerProdutos.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao consultar os doutores: " + ex.Message);
            }
            finally
            {
                CN.Close(); // Certifique-se de fechar a conexão no evento Load
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obter os valores selecionados nos controles
            string selectedDoctor = comboBox1.SelectedItem.ToString();
            string selectedProduct = comboBox2.SelectedItem.ToString();
            int clientCC = int.Parse(textBox1.Text);
            string description = textBox2.Text;

            try
            {
                CN.Open();

                string queryLastReceitaId = "SELECT MAX(id) FROM Otica_Receita";
                SqlCommand cmdLastReceitaId = new SqlCommand(queryLastReceitaId, CN);
                object result = cmdLastReceitaId.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    // Se houver receitas na base de dados, definir o valor de receitaId como o próximo ID disponível
                    receitaId = Convert.ToInt32(result) + 1;
                }

                // Consultar o CC do doutor selecionado
                string queryDoctorCC = "SELECT Otica_Doutor.CC FROM Otica_Pessoa JOIN Otica_Doutor ON Otica_Pessoa.CC = Otica_Doutor.CC WHERE nome = @doctorName";
                SqlCommand cmdDoctorCC = new SqlCommand(queryDoctorCC, CN);
                cmdDoctorCC.Parameters.AddWithValue("@doctorName", selectedDoctor);
                int doctorCC = (int)cmdDoctorCC.ExecuteScalar();

                // Consultar o ID do produto selecionado
                string queryProductID = "SELECT id FROM Otica_Produto WHERE nome = @productName";
                SqlCommand cmdProductID = new SqlCommand(queryProductID, CN);
                cmdProductID.Parameters.AddWithValue("@productName", selectedProduct);
                int productID = (int)cmdProductID.ExecuteScalar();

                // Inserir a nova receita com o ID incrementado
                string queryInsertReceita = "INSERT INTO Otica_Receita (id, descricao, doutor_cc, cliente_cc, produto_id) VALUES (@id, @descricao, @doutorCC, @clienteCC, @produtoID)";
                SqlCommand cmdInsertReceita = new SqlCommand(queryInsertReceita, CN);
                cmdInsertReceita.Parameters.AddWithValue("@id", receitaId);
                cmdInsertReceita.Parameters.AddWithValue("@descricao", description);
                cmdInsertReceita.Parameters.AddWithValue("@doutorCC", doctorCC);
                cmdInsertReceita.Parameters.AddWithValue("@clienteCC", clientCC);
                cmdInsertReceita.Parameters.AddWithValue("@produtoID", productID);
                cmdInsertReceita.ExecuteNonQuery();

                // Incrementar o ID da receita
                receitaId++;

                MessageBox.Show("Receita guardada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao guardar a receita: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }

    }
}
