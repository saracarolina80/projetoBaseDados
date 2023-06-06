using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ótica_Management
{
    public partial class AddProduto : Form
    {
        public ListBox ListBoxP { get; set; }

        private SqlConnection CN;
        public AddProduto()
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {

                String name = nome.Text;
                String ID = id.Text;
                String preco = preço.Text;
                String typo = tipo.Text;
                String marc = marca.Text;



                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ID) || string.IsNullOrWhiteSpace(preco) || string.IsNullOrWhiteSpace(typo) || string.IsNullOrWhiteSpace(marc))
                {
                    MessageBox.Show("Por favor, insira os dados do produto completos");
                    return; // Aborta a execução do evento
                }
                else
                {
                    // INSERIR DADOS NA BD
                    try
                    {
                        CN.Open();

                        // Inserir dados na tabela Pessoa
                        string queryInserirPessoa = "INSERT INTO Otica_Produto (id, preço, tipo, marca, nome) " +
                                                    "VALUES (@ID, @preco, @typo, @marc, @name);";
                        SqlCommand cmdInserirPessoa = new SqlCommand(queryInserirPessoa, CN);
                        cmdInserirPessoa.Parameters.AddWithValue("@ID", ID);
                        cmdInserirPessoa.Parameters.AddWithValue("@name", name);
                        cmdInserirPessoa.Parameters.AddWithValue("@preco", preco);
                        cmdInserirPessoa.Parameters.AddWithValue("@typo", typo);
                        cmdInserirPessoa.Parameters.AddWithValue("@marc", marc);
                        cmdInserirPessoa.ExecuteNonQuery();

                        MessageBox.Show("Produto registrado com sucesso!");

                        CN.Close();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao registrar o produto: " + ex.Message);
                    }
                }
            }

            else if (!verifySGBDConnection())
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE", "Connection Test", MessageBoxButtons.OK);
                return;
            }

            string nomeProduto = nome.Text;
            ListBoxP.Items.Add(nomeProduto);
            ListBoxP.Refresh();
        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

