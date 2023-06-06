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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Ótica_Management
{
    public partial class FuncPerfil : Form
    {
        private SqlConnection CN;

        //  private string nomeRecepcionista;
        public FuncPerfil()
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



        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private string ccRecepcionista;

        private string telemovelRecepcionista;
        private string emailRecepcionista;
        private string moradaRecepcionista;
        private int numFuncionarioRecepcionista;


        private void ObterDadosRecepcionista(string nomeRecepcionista)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("ObterDadosRecepcionista", CN))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NomeRecepcionista", nomeRecepcionista);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ccRecepcionista = reader.GetString(0); // CC
                            nomeRecepcionista = reader.GetString(1); // Nome
                            telemovelRecepcionista = reader.GetString(2); // Telemovel
                            emailRecepcionista = reader.GetString(3); // Email
                            moradaRecepcionista = reader.GetString(4); // Morada
                            numFuncionarioRecepcionista = reader.GetInt32(5); // Num_Funcionario
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao obter os dados do recepcionista: " + ex.Message);
            }
        }


        private void FuncPerfil_Load(object sender, EventArgs e)
        {
            string nomeRecepcionista = name.Text; // Obtenha o nome do recepcionista da TextBox "name" ou de onde você estiver armazenando

            ObterDadosRecepcionista(nomeRecepcionista);

            cc.Text = ccRecepcionista;
            morada.Text = moradaRecepcionista;
            phone.Text = telemovelRecepcionista;
            email.Text = emailRecepcionista;
            num.Text = Convert.ToString(numFuncionarioRecepcionista);


        }
    }
}