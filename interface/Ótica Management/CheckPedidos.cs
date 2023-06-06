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

    public partial class CheckPedidos : Form
    {
        private SqlConnection CN;
        public CheckPedidos()
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

        private void listBoxS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxS.SelectedItem != null)
            {
                // Obtém o ID selecionado
                string id_stock = listBoxS.SelectedItem.ToString();

                try
                {
                    CN.Open();

                    SqlCommand cmd = new SqlCommand("SELECT s.id, p.nome, s.estado, s.quantidade, s.data_entrada FROM Otica_Stock s " +
                                                     "JOIN Otica_Produto p ON p.id = s.produto_id " +
                                                     "WHERE s.id = @id_stock", CN);
                    cmd.Parameters.AddWithValue("@id_stock", id_stock);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string id = string.Empty;
                        string nome = string.Empty;
                        string state = string.Empty;
                        int quant = 0;
                        DateTime data = DateTime.MinValue;

                        while (reader.Read())
                        {
                            id = reader["id"].ToString();
                            state = reader["estado"].ToString();
                            quant = Convert.ToInt32(reader["quantidade"]);
                            data = Convert.ToDateTime(reader["data_entrada"]);
                        }

                        CN.Close();
                        reader.Close();

                        ide.Text = id;
                        estado.Text = state;
                        quantidade1.Value = quant;
                        dataEntrada.Value = data;
                    }
                    else
                    {
                        CN.Close();
                        reader.Close();
                        MessageBox.Show("Não foram encontrados dados do estoque para o ID selecionado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao procurar dados no estoque: " + ex.Message);
                }
                finally
                {
                    CN.Close();
                }
            }
        }

        private void CheckPedidos_Load(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                CN.Open();
                string query = "SELECT s.id FROM Otica_Stock s " +
                               "WHERE s.estado = 'Pendente'";

                SqlCommand command = new SqlCommand(query, CN);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    listBoxS.Items.Clear();

                    while (reader.Read())
                    {
                        string idStock = reader["id"].ToString();
                        listBoxS.Items.Add(idStock);
                    }
                    CN.Close();
                    reader.Close();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxS.SelectedItem != null)
            {
                string ID = listBoxS.SelectedItem.ToString();

                try
                {
                    CN.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Otica_Stock SET estado = 'Em stock' WHERE id = @id", CN);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("O estado do pedido foi atualizado para 'Em stock'.");
                }
                catch (Exception ex)
                {   
                    MessageBox.Show("Ocorreu um erro ao atualizar o estado do pedido: " + ex.Message);
                }
                finally
                {
                    CN.Close();
                }
            }
        }
    }
    
}
