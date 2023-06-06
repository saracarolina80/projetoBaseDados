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
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Ótica_Management
{
    public partial class registoFuncionario : Form
    {
        private SqlConnection CN;
        public registoFuncionario()
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {

                String nome = name.Text;
                String rua = morada.Text;
                String tele = phone.Text;
                String cartao = cidadao.Text;
                String mail = email.Text;
                String nume = num.Text;
                String user = username.Text;
                String password = pass.Text;


                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(rua) || string.IsNullOrWhiteSpace(tele) || string.IsNullOrWhiteSpace(cartao) || string.IsNullOrWhiteSpace(mail))
                {
                    MessageBox.Show("Por favor, insira os dados completos");
                    return; // Aborta a execução do evento
                }
                else
                {
                    try
                    {
                        CN.Open();
                        SqlTransaction transaction = CN.BeginTransaction(); // Iniciar a transação

                        try
                        {
                            // Inserir dados na tabela Pessoa
                            string queryInserirPessoa = "INSERT INTO Otica_Pessoa (CC, nome, telemovel, email, morada) " +
                                                        "VALUES (@cc, @nome, @tele, @mail, @rua);";
                            SqlCommand cmdInserirPessoa = new SqlCommand(queryInserirPessoa, CN);
                            cmdInserirPessoa.Parameters.AddWithValue("@cc", cartao);
                            cmdInserirPessoa.Parameters.AddWithValue("@nome", nome);
                            cmdInserirPessoa.Parameters.AddWithValue("@tele", tele);
                            cmdInserirPessoa.Parameters.AddWithValue("@mail", mail);
                            cmdInserirPessoa.Parameters.AddWithValue("@rua", rua);
                            cmdInserirPessoa.Transaction = transaction;
                            cmdInserirPessoa.ExecuteNonQuery();

                            // Inserir dados na tabela Funcionario
                            string queryInserirFuncionario = "INSERT INTO Otica_Funcionario (CC) " +
                                                             "VALUES (@cc);";
                            SqlCommand cmdInserirFuncionario = new SqlCommand(queryInserirFuncionario, CN);
                            cmdInserirFuncionario.Parameters.AddWithValue("@cc", cartao);
                            cmdInserirFuncionario.Transaction = transaction;
                            cmdInserirFuncionario.ExecuteNonQuery();

                            // Inserir dados na tabela Recepcionista
                            string queryInserirRecepcionista = "INSERT INTO Otica_Recepcionista (CC, num_funcionario) " +
                                                               "VALUES (@cc, @num_funcionario);";
                            SqlCommand cmdInserirRecepcionista = new SqlCommand(queryInserirRecepcionista, CN);
                            cmdInserirRecepcionista.Parameters.AddWithValue("@cc", cartao);
                            cmdInserirRecepcionista.Parameters.AddWithValue("@num_funcionario", nume);
                            cmdInserirRecepcionista.Transaction = transaction;
                            cmdInserirRecepcionista.ExecuteNonQuery();

                            // Inserir dados na tabela Login
                            string queryLogin = "INSERT INTO Otica_Login (CC, username, password) " +
                                                "VALUES (@cc, @user, @password);";
                            SqlCommand cmdLogin = new SqlCommand(queryLogin, CN);
                            cmdLogin.Parameters.AddWithValue("@cc", cartao);
                            cmdLogin.Parameters.AddWithValue("@user", user);
                            cmdLogin.Parameters.AddWithValue("@password", password);
                            cmdLogin.Transaction = transaction;
                            cmdLogin.ExecuteNonQuery();

                            // Commit da transação se tudo ocorrer sem erros
                            transaction.Commit();

                            MessageBox.Show("Funcionário registrado com sucesso! Bem-vindo " + nome);

                            MainPage page = new MainPage();
                            page.Show();

                            CN.Close();
                            this.Hide();
                        }
                        catch (Exception ex)
                        {

                            // Rollback da transação em caso de erro
                            transaction.Rollback();
                            MessageBox.Show("Ocorreu um erro ao registrar o funcionário: " + ex.Message);
                        }
                        finally
                        {
                            CN.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao abrir a conexão com o banco de dados: " + ex.Message);
                    }
                }

            }

            else if (!verifySGBDConnection())
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE", "Connection Test", MessageBoxButtons.OK);
                return;
            }

        }

        private void num_TextChanged(object sender, EventArgs e)
        {

        }

        private void registoFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void cc_TextChanged(object sender, EventArgs e)
        {

        }
    }

}