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
    public partial class AtualizarInfo : Form
    {
        public string NomeCliente { get; set; }
        public string email1 { get; set; }
        public string morada1 { get; set; }
        public string telemovel1 { get; set; }
        public string num_contribuinte1 { get; set; }

        public string cc1 { get; set; }


        private SqlConnection CN;
        public AtualizarInfo()
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AtualizarInfo_Load(object sender, EventArgs e)
        {
            nome.Text = NomeCliente;
            morada.Text = morada1;
            telemovel.Text = telemovel1;
            num_contribuinte.Text = num_contribuinte1;
            email.Text = email1;
            cc.Text = cc1;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            // Exibe uma caixa de diálogo de confirmação
            DialogResult result = MessageBox.Show("Deseja descartar as alterações feitas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifica a resposta do usuário
            if (result == DialogResult.Yes)
            {
                // Fecha o formulário AtualizarInfo
                this.Close();
            }
            else
            {
                return;
            }
        }


        private void atualizar_Click(object sender, EventArgs e)
        {
            // Captura os novos valores dos campos de texto
            string novoNome = nome.Text;
            string novoEmail = email.Text;
            int novoTelemovel = int.Parse(telemovel.Text);
            string novoMorada = morada.Text;
            int novoContribuinte = int.Parse(num_contribuinte.Text);
            int ccValue = int.Parse(cc.Text);

            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("AtualizarCliente", CN))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Adiciona os parâmetros para os novos valores
                        cmd.Parameters.AddWithValue("@CC", ccValue);
                        cmd.Parameters.AddWithValue("@NovoNome", novoNome);
                        cmd.Parameters.AddWithValue("@NovoEmail", novoEmail);
                        cmd.Parameters.AddWithValue("@NovoMorada", novoMorada);
                        cmd.Parameters.AddWithValue("@NovoTelemovel", novoTelemovel);
                        cmd.Parameters.AddWithValue("@NovoNum_Contribuinte", novoContribuinte);


                        CN.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        CN.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dados do cliente atualizados com sucesso! Deve voltar atrás para atualizar o perfil");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível atualizar os dados do cliente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao atualizar os dados do cliente: " + ex.Message);
                }
            }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}