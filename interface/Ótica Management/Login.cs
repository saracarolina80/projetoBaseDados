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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Ótica_Management
{
    public partial class Login : Form
    {


        private string nomeRecepcionista;

        private SqlConnection CN;
        public Login()
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                InitializeComponent();
                //pictureBox1.Image = Image.FromFile("C:\\Users\\Utilizador\\Desktop\\projeto_BD\\imagens\\otica.jpg");
            }
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

        private void log_Click(object sender, EventArgs e)
        {

            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                string username = user.Text;
                string password = pass.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Por favor, insira os dados completos");
                    return; // Aborta a execução do evento
                }
                else
                {
                    try
                    {
                        CN.Open();

                        using (SqlCommand command = new SqlCommand("VerificarCredenciais", CN))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", password);

                            int loginValido = (int)command.ExecuteScalar();

                            if (loginValido == 1)
                            {
                                // Login válido! Obtenha o nome do recepcionista
                                nomeRecepcionista = GetNomeRecepcionista();
                                MessageBox.Show("Login válido! Bem-vindo, " + nomeRecepcionista + "!");
                                DialogResult = DialogResult.OK;
                                Close(); // Fechar o formulário de login



                            }
                            else
                            {
                                MessageBox.Show("Login inválido! Por favor, verifique suas credenciais.");
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao verificar as credenciais: " + ex.Message);
                    }
                    CN.Close();
                }
            }
            else if (!verifySGBDConnection())
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE", "Connection Test", MessageBoxButtons.OK);
                return;
            }
        }

        public string GetNomeRecepcionista()
        {
            string username = user.Text;

            string nomeRecepcionista = "";

            try
            {
                using (SqlCommand command = new SqlCommand("SELECT dbo.GetNomeRecepcionista(@Username)", CN))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    nomeRecepcionista = (string)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao obter o nome do recepcionista: " + ex.Message);
            }

            return nomeRecepcionista;
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            pass.UseSystemPasswordChar = true;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pass.UseSystemPasswordChar = false; // Exibe o texto normalmente
            }
            else
            {
                pass.UseSystemPasswordChar = true; // Oculta os caracteres
            }

        }

        private void registar_Click(object sender, EventArgs e)
        {
            registoFuncionario reg = new registoFuncionario();
            reg.Show();
        }
    }
}

