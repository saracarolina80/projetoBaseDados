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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Ótica_Management
{
    public partial class registoDoutor : Form
    {
        private SqlConnection CN;
        public registoDoutor()
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




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {

                String nome = name.Text;
                String rua = morada.Text;
                String tele = telemovel.Text;
                String cartao = cc.Text;
                String num = num_sns.Text;
                String mail = email.Text;


                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(rua) || string.IsNullOrWhiteSpace(tele) || string.IsNullOrWhiteSpace(cartao) || string.IsNullOrWhiteSpace(num) || string.IsNullOrWhiteSpace(mail))
                {
                    MessageBox.Show("Por favor, insira os dados completos");
                    return; // Aborta a execução do evento
                }
                else
                {
                    // INSERIR DADOS NA BD
                    try
                    {
                        CN.Open();

                        // Inserir dados na tabela Pessoa
                        string queryInserirPessoa = "INSERT INTO Otica_Pessoa (CC, nome, telemovel, email, morada) " +
                                                    "VALUES (@cc, @nome, @tele, @mail, @rua);";
                        SqlCommand cmdInserirPessoa = new SqlCommand(queryInserirPessoa, CN);
                        cmdInserirPessoa.Parameters.AddWithValue("@cc", cartao);
                        cmdInserirPessoa.Parameters.AddWithValue("@nome", nome);
                        cmdInserirPessoa.Parameters.AddWithValue("@tele", tele);
                        cmdInserirPessoa.Parameters.AddWithValue("@mail", mail);
                        cmdInserirPessoa.Parameters.AddWithValue("@rua", rua);
                        cmdInserirPessoa.ExecuteNonQuery();

                        string queryInserirFuncionario = "INSERT INTO Otica_Funcionario (CC) " +
                                                     "VALUES (@cc);";
                        SqlCommand cmdInserirFuncionario = new SqlCommand(queryInserirFuncionario, CN);
                        cmdInserirFuncionario.Parameters.AddWithValue("@cc", cartao);
                        cmdInserirFuncionario.ExecuteNonQuery();

                        // Inserir dados na tabela Doutor
                        string queryInserirDoutor = "INSERT INTO Otica_Doutor (CC, num_SNS) " +
                                                     "VALUES (@cc, @num_sns);";
                        SqlCommand cmdInserirDoutor = new SqlCommand(queryInserirDoutor, CN);
                        cmdInserirDoutor.Parameters.AddWithValue("@cc", cartao);
                        cmdInserirDoutor.Parameters.AddWithValue("@num_sns", num);
                        cmdInserirDoutor.ExecuteNonQuery();

                        MessageBox.Show("Doutor registrado com sucesso!");

                        CN.Close();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao registrar o doutor: " + ex.Message);
                    }
                }
            }

            else if (!verifySGBDConnection())
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE", "Connection Test", MessageBoxButtons.OK);
                return;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void cc_TextChanged(object sender, EventArgs e)
        {

        }

        private void registoDoutor_Load(object sender, EventArgs e)
        {

        }
    }
}
