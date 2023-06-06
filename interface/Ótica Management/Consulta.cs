using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ótica_Management
{
    public partial class Consulta : Form
    {
        private SqlConnection CN;

        public Consulta()
        {
            InitializeComponent(); ;
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


        private void Consulta_Load(object sender, EventArgs e)
        {
            CN = getSGBDConnection(); // Adicione esta linha para obter uma nova instância de conexão
            try
            {
                dataGridView1.Columns.Add("NomeCliente", "Nome do Cliente");
                dataGridView1.Columns.Add("Dia", "Dia da Consulta");
                dataGridView1.Columns.Add("Hora", "Hora da Consulta");

                CN.Open();

                // Consultar os nomes dos doutores
                string query = "SELECT nome FROM Otica_Pessoa JOIN Otica_Doutor ON Otica_Pessoa.CC = Otica_Doutor.CC";
                SqlCommand cmd = new SqlCommand(query, CN);
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpar a ComboBox antes de adicionar os nomes dos doutores
                comboBox1.Items.Clear();

                // Adicionar os nomes dos doutores à ComboBox
                while (reader.Read())
                {
                    string nome = reader["nome"].ToString();
                    comboBox1.Items.Add(nome);
                }
                reader.Close();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked");
            string selectedDoctor = comboBox1.SelectedItem.ToString();

            try
            {
                CN.Open();

                // Consultar as consultas do doutor selecionado
                string query = @"SELECT Cliente.nome AS NomeCliente, Otica_Consulta.data_consulta AS Dia, Otica_Consulta.hora AS Hora
                                FROM Otica_Consulta
                                JOIN Otica_Cliente ON Otica_Cliente.CC = Otica_Consulta.cliente_cc
                                JOIN Otica_Pessoa AS Cliente ON Cliente.CC = Otica_Cliente.CC
                                JOIN Otica_Doutor ON Otica_Doutor.CC = Otica_Consulta.doutor_cc
                                JOIN Otica_Pessoa AS Doutor ON Doutor.CC = Otica_Doutor.CC
                                WHERE Doutor.nome = @doctorName";

                SqlCommand cmd = new SqlCommand(query, CN);
                cmd.Parameters.AddWithValue("@doctorName", selectedDoctor);
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpar o DataGridView antes de preencher com os dados das consultas
                dataGridView1.Rows.Clear();

                // Preencher o DataGridView com os dados das consultas
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string nomeCliente = reader["NomeCliente"].ToString();
                    string diaConsulta = reader["Dia"].ToString();
                    string horaConsulta = reader["Hora"].ToString();

                    dataGridView1.Rows.Add(nomeCliente, diaConsulta, horaConsulta);
                }
                MessageBox.Show("Total de registros: " + count);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao consultar as consultas: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectedDoctor = comboBox1.SelectedItem.ToString();

            try
            {
                CN.Open();

                // Consultar as consultas do doutor selecionado
                string query = @"SELECT Cliente.nome AS NomeCliente, Otica_Consulta.data_consulta AS Dia, Otica_Consulta.hora AS Hora
                                FROM Otica_Consulta
                                JOIN Otica_Cliente ON Otica_Cliente.CC = Otica_Consulta.cliente_cc
                                JOIN Otica_Pessoa AS Cliente ON Cliente.CC = Otica_Cliente.CC
                                JOIN Otica_Doutor ON Otica_Doutor.CC = Otica_Consulta.doutor_cc
                                JOIN Otica_Pessoa AS Doutor ON Doutor.CC = Otica_Doutor.CC
                                WHERE Doutor.nome = @doctorName";

                SqlCommand cmd = new SqlCommand(query, CN);
                cmd.Parameters.AddWithValue("@doctorName", selectedDoctor);
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpar o DataGridView antes de preencher com os dados das consultas
                dataGridView1.Rows.Clear();

                // Preencher o DataGridView com os dados das consultas
                while (reader.Read())
                {
                    string nomeCliente = reader["NomeCliente"].ToString();
                    string diaConsulta = reader["Dia"].ToString();
                    string horaConsulta = reader["Hora"].ToString();

                    dataGridView1.Rows.Add(nomeCliente, diaConsulta, horaConsulta);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao consultar as consultas: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }
    }

}