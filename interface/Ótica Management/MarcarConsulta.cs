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
    public partial class MarcarConsulta : Form
    {
        private SqlConnection CN;
        private int numConsulta = 1;
        public MarcarConsulta()
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

        private void MarcarConsulta_Load(object sender, EventArgs e)
        {
            CN = getSGBDConnection(); // Adicione esta linha para obter uma nova instância de conexão
            try
            {
                CN.Open();

                DateTime startTime = DateTime.Parse("08:00");
                DateTime endTime = DateTime.Parse("17:00");

                while (startTime <= endTime)
                {
                    comboBox1.Items.Add(startTime.ToString("HH:mm"));
                    startTime = startTime.AddMinutes(30);
                }


                // Consultar os nomes dos doutores e adicionar ao comboBox1
                string queryDoutores = "SELECT nome FROM Otica_Pessoa JOIN Otica_Doutor ON Otica_Pessoa.CC = Otica_Doutor.CC";
                SqlCommand cmdDoutores = new SqlCommand(queryDoutores, CN);
                SqlDataReader readerDoutores = cmdDoutores.ExecuteReader();

                comboBox2.Items.Clear();
                while (readerDoutores.Read())
                {
                    string nomeDoutor = readerDoutores["nome"].ToString();
                    comboBox2.Items.Add(nomeDoutor);
                }
                readerDoutores.Close();

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


        private void button1_Click(object sender, EventArgs e)
        {
            // Obter os valores selecionados pelo usuário
            string selectedDoctorName = comboBox2.SelectedItem.ToString();
            DateTime selectedDate = dateTimePicker1.Value.Date;
            string selectedTime = comboBox1.SelectedItem.ToString();

            // Montar a data e hora selecionadas em um único objeto DateTime
            DateTime selectedDateTime = selectedDate.Add(TimeSpan.Parse(selectedTime));

            CN = getSGBDConnection();
            try
            {
                CN.Open();

                // Consultar a tabela de doutores para obter o CC do doutor selecionado
                string queryDoctorCC = "SELECT CC FROM Otica_Doutor " +
                                       "WHERE CC IN (SELECT CC FROM Otica_Pessoa WHERE nome = @DoctorName)";
                SqlCommand cmdDoctorCC = new SqlCommand(queryDoctorCC, CN);
                cmdDoctorCC.Parameters.AddWithValue("@DoctorName", selectedDoctorName);
                int doctorCC = (int)cmdDoctorCC.ExecuteScalar();

                // Consultar a tabela de consultas para verificar se há algum conflito
                string query = "SELECT COUNT(*) FROM Otica_Consulta " +
                               "WHERE doutor_cc = @DoctorCC " +
                               "AND data_consulta = @SelectedDate " +
                               "AND hora = @SelectedTime";
                SqlCommand cmd = new SqlCommand(query, CN);
                cmd.Parameters.AddWithValue("@DoctorCC", doctorCC);
                cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);
                cmd.Parameters.AddWithValue("@SelectedTime", selectedTime);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("O doutor não está disponível na data e hora selecionadas.");
                }
                else
                {
                    MessageBox.Show("O doutor está disponível na data e hora selecionadas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao verificar a disponibilidade: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obter os valores selecionados pelo usuário
            string selectedDoctorName = comboBox2.SelectedItem.ToString();
            DateTime selectedDate = dateTimePicker1.Value.Date;
            string selectedTime = comboBox1.SelectedItem.ToString();
            int clientCC = int.Parse(textBox1.Text);
            decimal consultaPrice = decimal.Parse(textBox2.Text);

            // Montar a data e hora selecionadas em um único objeto DateTime
            DateTime selectedDateTime = selectedDate.Add(TimeSpan.Parse(selectedTime));

            CN = getSGBDConnection();
            try
            {
                CN.Open();

                string queryLastId = "SELECT MAX(numero_consulta) FROM Otica_Consulta";
                SqlCommand cmdLastId = new SqlCommand(queryLastId, CN);
                object result = cmdLastId.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    // Se houver receitas na base de dados, definir o valor de receitaId como o próximo ID disponível
                    numConsulta = Convert.ToInt32(result) + 1;
                }

                // Consultar a tabela de doutores para obter o CC do doutor selecionado
                string queryDoctorCC = "SELECT CC FROM Otica_Doutor " +
                                       "WHERE CC IN (SELECT CC FROM Otica_Pessoa WHERE nome = @DoctorName)";
                SqlCommand cmdDoctorCC = new SqlCommand(queryDoctorCC, CN);
                cmdDoctorCC.Parameters.AddWithValue("@DoctorName", selectedDoctorName);
                int doctorCC = (int)cmdDoctorCC.ExecuteScalar();

                SqlCommand cmdAgendarConsulta = new SqlCommand("AgendarConsulta", CN);
                cmdAgendarConsulta.CommandType = CommandType.StoredProcedure;

                // Defina os parâmetros necessários para a stored procedure
                cmdAgendarConsulta.Parameters.AddWithValue("@numero_consulta", numConsulta);
                cmdAgendarConsulta.Parameters.AddWithValue("@hora", selectedTime);
                cmdAgendarConsulta.Parameters.AddWithValue("@preço", consultaPrice);
                cmdAgendarConsulta.Parameters.AddWithValue("@data_consulta", selectedDate);
                cmdAgendarConsulta.Parameters.AddWithValue("@recepcionista_cc", 190381839); // Define o valor 457171717 para o campo recepcionista_cc
                cmdAgendarConsulta.Parameters.AddWithValue("@doutor_cc", doctorCC);
                cmdAgendarConsulta.Parameters.AddWithValue("@cliente_cc", clientCC);

                // Execute a stored procedure
                cmdAgendarConsulta.ExecuteNonQuery();

                MessageBox.Show("Consulta marcada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao marcar a consulta: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            string selectedDoctorName = comboBox2.SelectedItem.ToString();
            DateTime selectedDate = dateTimePicker1.Value.Date;
            string selectedTime = comboBox1.SelectedItem.ToString();
            string clientCC = textBox1.Text;
            decimal consultaPrice = decimal.Parse(textBox2.Text);

            // Montar a data e hora selecionadas em um único objeto DateTime
            DateTime selectedDateTime = selectedDate.Add(TimeSpan.Parse(selectedTime));

            CN = getSGBDConnection();
            try
            {
                CN.Open();

                string queryLastId = "SELECT ISNULL(MAX(id), 0) FROM Otica_Fatura";
                SqlCommand cmdLastId = new SqlCommand(queryLastId, CN);
                int lastId = (int)cmdLastId.ExecuteScalar();
                int novoID = lastId + 1;

                // Inserir os dados na tabela Otica_Fatura
                string queryInsert = "INSERT INTO Otica_Fatura (id, descriçao, iva, preco, cliente_cc) " +
                                     "VALUES (@id, @descricao, @iva, @preco, @clienteCC)";
                SqlCommand cmdInsert = new SqlCommand(queryInsert, CN);
                cmdInsert.Parameters.AddWithValue("@id", novoID);
                cmdInsert.Parameters.AddWithValue("@descricao", "Consulta");
                cmdInsert.Parameters.AddWithValue("@iva", 23);
                cmdInsert.Parameters.AddWithValue("@preco", consultaPrice);
                cmdInsert.Parameters.AddWithValue("@clienteCC", clientCC);
                cmdInsert.ExecuteNonQuery();

                MessageBox.Show("Dados inseridos com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao inserir os dados: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
