using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Ótica_Management
{
    public partial class ClientePerfil : Form
    {
        private SqlConnection CN;
        public ClientePerfil()
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

        // Propriedades para armazenar os dados do cliente
        public string nome { get; set; }
        public string email { get; set; }
        public string morada { get; set; }
        public string telemovel { get; set; }
        public string num_contribuinte { get; set; }

        public string cc { get; set; }


        // Método Load do formulário
        private void ClientePerfil_Load(object sender, EventArgs e)
        {

            // Exibir os dados do cliente nos controles do formulário
            label1.Text = nome;
            label2.Text = email;
            label3.Text = morada;
            label4.Text = telemovel;
            label5.Text = num_contribuinte;
            label6.Text = cc;
            // Exibir outros campos...


        }

        private void editar_Click(object sender, EventArgs e)
        {
            AtualizarInfo formAtualizarInfo = new AtualizarInfo();
            formAtualizarInfo.NomeCliente = nome; // Defina o nome atual do cliente na propriedade do formulário
            formAtualizarInfo.email1 = email;
            formAtualizarInfo.morada1 = morada;
            formAtualizarInfo.telemovel1 = telemovel;
            formAtualizarInfo.cc1 = cc;
            formAtualizarInfo.num_contribuinte1 = num_contribuinte;

            formAtualizarInfo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void eliminar_Click_1(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                // Exibe uma caixa de diálogo de confirmação
                DialogResult result = MessageBox.Show("Tem a certeza que pretende eliminar este cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verifica a resposta do usuário
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        CN.Open();
                        SqlTransaction transaction = CN.BeginTransaction(); // Iniciar a transação

                        try
                        {

                            using (SqlCommand cmd = new SqlCommand("RemoverCliente", CN))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@CC", cc);
                                cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                                cmd.Transaction = transaction;

                                cmd.ExecuteNonQuery();

                                string resultado = cmd.Parameters["@Resultado"].Value.ToString();

                                if (resultado == "Cliente removido com sucesso.")
                                {
                                    // Commit da transação se a exclusão for bem-sucedida
                                    transaction.Commit();

                                    MessageBox.Show("Cliente eliminado com sucesso! Necessita de voltar atrás para ver atualizar a lista");
                                    this.Close(); // Feche o perfil do cliente
                                }
                                else
                                {
                                    // Rollback da transação se a exclusão não for bem-sucedida
                                    transaction.Rollback();
                                    MessageBox.Show(resultado);
                                }

                                CN.Close();
                            }
                        }

                        catch (Exception ex)
                        {
                            // Rollback da transação em caso de erro
                            transaction.Rollback();
                            MessageBox.Show("Ocorreu um erro ao eliminar o cliente: " + ex.Message);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao abrir a conexão com o banco de dados: " + ex.Message);
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
}



