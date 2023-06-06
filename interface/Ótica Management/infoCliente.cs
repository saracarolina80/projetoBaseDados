using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Ótica_Management
{
    public partial class infoCliente : Form
    {
        private Label label1;
        private TextBox cc;
        private Button info;
        private Label label2;
        private Label label3;
        private ListBox listBox1;
        private Label label4;
        private SqlConnection CN;


        public infoCliente()
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

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cc = new System.Windows.Forms.TextBox();
            this.info = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite o CC do cliente que quer encontrar:";
            // 
            // cc
            // 
            this.cc.Location = new System.Drawing.Point(415, 103);
            this.cc.Name = "cc";
            this.cc.Size = new System.Drawing.Size(167, 22);
            this.cc.TabIndex = 1;
            this.cc.TextChanged += new System.EventHandler(this.CCdigitado_TextChanged);
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.info.Font = new System.Drawing.Font("MS PGothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(415, 169);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(189, 34);
            this.info.TabIndex = 2;
            this.info.Text = "Procurar informação";
            this.info.UseVisualStyleBackColor = false;
            this.info.Click += new System.EventHandler(this.info_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Font = new System.Drawing.Font("MS PGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Informação dos clientes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS PGothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(209, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Todos os clientes";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(214, 303);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(256, 202);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS PGothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 532);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(424, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Clique duas vezes no cliente para ver a informação";
            // 
            // infoCliente
            // 
            this.ClientSize = new System.Drawing.Size(668, 617);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.info);
            this.Controls.Add(this.cc);
            this.Controls.Add(this.label1);
            this.Name = "infoCliente";
            this.Load += new System.EventHandler(this.infoCliente_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void info_Click(object sender, EventArgs e)
        {
            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {


                String cartao = cc.Text;



                if (string.IsNullOrWhiteSpace(cartao))
                {
                    MessageBox.Show("Por favor, insira o CC do cliente");
                    return; // Aborta a execução do evento
                }
                else
                {
                    //PROCURAR DADOS NA BD
                    try
                    {



                        SqlCommand cmd = new SqlCommand("getClientebyCC ", CN);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CC", cartao);
                        CN.Open();


                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Crie variáveis para armazenar os dados do cliente
                            string nome = string.Empty;
                            string email = string.Empty;
                            string telemovel = string.Empty;
                            string morada = string.Empty;
                            string num_contribuinte = string.Empty;
                            string cc = string.Empty;

                            // Leitura dos dados do cliente
                            while (reader.Read())
                            {
                                nome = reader["nome"].ToString();
                                email = reader["email"].ToString();
                                telemovel = reader["telemovel"].ToString();
                                morada = reader["morada"].ToString();
                                num_contribuinte = reader["num_contribuinte"].ToString();
                                cc = reader["CC"].ToString();
                            }

                            CN.Close();
                            reader.Close();

                            // Atribuição dos dados ao formulário ClientePerfil
                            ClientePerfil form = new ClientePerfil();
                            form.nome = nome;
                            form.email = email;
                            form.telemovel = telemovel;
                            form.morada = morada;
                            form.num_contribuinte = num_contribuinte;
                            form.cc = cc;

                            // Exibir o formulário ClientePerfil

                            form.Show();
                        }
                        else
                        {
                            CN.Close();
                            reader.Close();
                            throw new Exception("Cliente não existe!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao procurar cliente: " + ex.Message);
                    }
                }
            }

            else if (!verifySGBDConnection())
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE", "Connection Test", MessageBoxButtons.OK);
                return;
            }
        }

        private void CCdigitado_TextChanged(object sender, EventArgs e)
        {

        }

        public void infoCliente_Load_1(object sender, EventArgs e)
        {

            bool temp = verifySGBDConnection();
            CN.Close();
            if (temp)
            {
                CN.Open();

                SqlCommand cmd = new SqlCommand("SELECT nome FROM Otica_Pessoa JOIN Otica_Cliente ON Otica_Pessoa.CC = Otica_Cliente.CC", CN);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    string nome = string.Empty;

                    // Limpar a ListBox antes de adicionar os novos nomes
                    listBox1.Items.Clear();

                    // Leitura dos dados do cliente
                    while (reader.Read())
                    {
                        nome = reader["nome"].ToString();
                        listBox1.Items.Add(nome);
                    }

                    CN.Close();
                    reader.Close();
                }
            }


        }


        private void listBox1_DoubleClick_1(object sender, EventArgs e)
        {
            // Verifica se há um item selecionado
            if (listBox1.SelectedItem != null)
            {
                // Obtém o nome selecionado
                string name = listBox1.SelectedItem.ToString();

                //PROCURAR DADOS NA BD
                try
                {
                    CN.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Otica_Pessoa JOIN Otica_Cliente ON Otica_Pessoa.CC = Otica_Cliente.CC WHERE Otica_Pessoa.nome = @name", CN);
                    cmd.Parameters.AddWithValue("@name", name);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Crie variáveis para armazenar os dados do cliente
                        string email = string.Empty;
                        string telemovel = string.Empty;
                        string morada = string.Empty;
                        string num_contribuinte = string.Empty;
                        string cc = string.Empty;
                        string nome = string.Empty;

                        // Leitura dos dados do cliente
                        while (reader.Read())
                        {
                            nome = reader["nome"].ToString();
                            email = reader["email"].ToString();
                            telemovel = reader["telemovel"].ToString();
                            morada = reader["morada"].ToString();
                            num_contribuinte = reader["num_contribuinte"].ToString();
                            cc = reader["CC"].ToString();
                        }

                        CN.Close();
                        reader.Close();

                        // Atribuição dos dados ao formulário ClientePerfil
                        ClientePerfil form = new ClientePerfil();
                        form.nome = nome;
                        form.email = email;
                        form.telemovel = telemovel;
                        form.morada = morada;
                        form.num_contribuinte = num_contribuinte;
                        form.cc = cc;

                        // Exibir o formulário ClientePerfil

                        form.Show();
                    }

                    CN.Close();
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao procurar cliente: " + ex.Message);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}