using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ótica_Management
{
    public partial class stock : Form
    {
        private SqlConnection CN;
        public stock()
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

        private void listBoxS_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Verifica se há um item selecionado
            if (listBoxS.SelectedItem != null)
            {
                // Obtém o nome selecionado
                string ID = listBoxS.SelectedItem.ToString();

                //PROCURAR DADOS NA BD
                try
                {
                    CN.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Otica_Stock WHERE Otica_Stock.id = @id", CN);
                    cmd.Parameters.AddWithValue("@id", ID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Crie variáveis para armazenar os dados do cliente
                        string ides;
                        string state;
                        int quantidade;
                        DateTime dataInicio;

                        // Leitura dos dados do cliente
                        while (reader.Read())
                        {
                            // Atribuir os valores às variáveis
                            ides = reader["id"].ToString();
                            state = reader["estado"].ToString();
                            quantidade = (int)reader["quantidade"];
                            dataInicio = (DateTime)reader["data_entrada"];

                            // Atribuir os valores aos controles
                            ide.Text = ides;
                            estado.Text = state;
                            quantidade1.Value = quantidade;
                            dataEntrada.Value = dataInicio;

                        }

                        CN.Close();
                        reader.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao procurar cliente: " + ex.Message);
                }
            }
        }


        private void stock_Load(object sender, EventArgs e)
        {

            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                CN.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Otica_Stock WHERE Otica_Stock.estado = 'Em stock'", CN);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    string id = string.Empty;


                    // Limpar a ListBox antes de adicionar os novos nomes
                    listBoxS.Items.Clear();

                    // Leitura dos dados do cliente
                    while (reader.Read())
                    {
                        id = reader["id"].ToString();

                        listBoxS.Items.Add(id);
                    }

                    CN.Close();
                    reader.Close();
                }
            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ide.Text))
            {
                MessageBox.Show("Tem que selecionar um produto");
                return;
            }
            else
            {
                int idProduto = int.Parse(ide.Text);

                MessageBox.Show("ID do produto: " + idProduto);
                bool temp = verifySGBDConnection();
                CN.Close();
                if (temp)
                {
                    // Exibe uma caixa de diálogo de confirmação
                    DialogResult result = MessageBox.Show("Tem a certeza que pretende retirar este produto do stock?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    // Verifica a resposta do usuário
                    if (result == DialogResult.Yes)
                    {

                        // Chama a stored procedure para eliminar o produto
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("RemoverProdutodoStock", CN))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id", idProduto);

                                CN.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();
                                CN.Close();

                                if (rowsAffected > 0)
                                {

                                    MessageBox.Show("Produto retirado com sucesso! Necessita de voltar atrás para atualizar a lista");

                                }
                                else
                                {
                                    MessageBox.Show("Não foi possível retirar o produto.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocorreu um erro ao retirar o produto: " + ex.Message);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Pedido p = new Pedido();
            p.Show();
        }

        private void adicionar_Click(object sender, EventArgs e)
        {

        }

        private void estado_TextChanged(object sender, EventArgs e)
        {

        }

        private void ide_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void quantidade1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataEntrada_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}