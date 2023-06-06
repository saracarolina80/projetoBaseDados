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
    public partial class registoFornecedor : Form
    {
        private SqlConnection CN;
        public registoFornecedor()
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {

                String nif = textBox1.Text;
                String nome = textBox2.Text;
                String tele = textBox3.Text;
                String email = textBox4.Text;
                String rua = textBox5.Text;


                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(rua) || string.IsNullOrWhiteSpace(tele) || string.IsNullOrWhiteSpace(nif) || string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Por favor, insira os dados completos");
                    return; // Aborta a execução do evento
                }
                else
                {
                    try
                    {
                        CN.Open();

                        string queryInserirFornecedor = "INSERT INTO Otica_Fornecedor (nif, nome, telemovel, email, morada) " +
                                                        "VALUES (@nif, @nome, @tele, @email, @rua);";
                        SqlCommand cmdInserirFornecedor = new SqlCommand(queryInserirFornecedor, CN);
                        cmdInserirFornecedor.Parameters.AddWithValue("@nif", nif);
                        cmdInserirFornecedor.Parameters.AddWithValue("@nome", nome);
                        cmdInserirFornecedor.Parameters.AddWithValue("@tele", tele);
                        cmdInserirFornecedor.Parameters.AddWithValue("@email", email);
                        cmdInserirFornecedor.Parameters.AddWithValue("@rua", rua);
                        cmdInserirFornecedor.ExecuteNonQuery();

                        MessageBox.Show("Fornecedor registrado com sucesso!");

                        CN.Close();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao registrar o fornecedor: " + ex.Message);
                    }
                }
            }
            else if (!verifySGBDConnection())
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE", "Connection Test", MessageBoxButtons.OK);
                return;
            }
        }
        
    }
}
