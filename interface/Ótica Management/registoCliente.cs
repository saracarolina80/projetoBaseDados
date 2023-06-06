using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Ótica_Management
{
    public partial class registoCliente : Form
    {
        private SqlConnection CN;
   
        public registoCliente()
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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void registoCliente_Load(object sender, EventArgs e)
        {

        }

        private void registar_Click(int CC, string nome, int telemovel, string email, string morada, int num_contribuinte, int funcionario_cc)
        {
            bool temp = verifySGBDConnection();
            CN.Close();

            if (temp)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("InserirCliente", CN))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CC", CC);
                        command.Parameters.AddWithValue("@nome", nome);
                        command.Parameters.AddWithValue("@telemovel", telemovel);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@morada", morada);
                        command.Parameters.AddWithValue("@num_contribuinte", num_contribuinte);
                        command.Parameters.AddWithValue("@funcionario_cc", funcionario_cc);

                        CN.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        CN.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente inserido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível inserir o cliente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao inserir o cliente: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Failed to open connection to the database", "Connection Test", MessageBoxButtons.OK);
            }
        }



        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cc_TextChanged(object sender, EventArgs e)
        {

        }

        private void registar_Click(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();

            String nome = name.Text;
            String rua = morada.Text;
            String tele = telemovel.Text;
            String cartao = cc.Text;
            String NIF = nif.Text;
            String mail = email.Text;


            if (temp)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("InserirCliente", CN))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CC", cartao);
                        command.Parameters.AddWithValue("@nome", nome);
                        command.Parameters.AddWithValue("@telemovel", tele);
                        command.Parameters.AddWithValue("@email", mail);
                        command.Parameters.AddWithValue("@morada", rua);
                        command.Parameters.AddWithValue("@num_contribuinte", NIF);
                        command.Parameters.AddWithValue("@funcionario_cc", DBNull.Value );

                        CN.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        CN.Close(); 

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente inserido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível inserir o cliente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao inserir o cliente: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Failed to open connection to the database", "Connection Test", MessageBoxButtons.OK);
            }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
