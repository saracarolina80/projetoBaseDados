namespace Ótica_Management
{
    partial class MainRecepcionista
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.registoCliente = new System.Windows.Forms.Button();
            this.registoDoutor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.produtos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(61, 502);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Funcionário";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(61, 445);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Informação Cliente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // registoCliente
            // 
            this.registoCliente.Location = new System.Drawing.Point(61, 148);
            this.registoCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.registoCliente.Name = "registoCliente";
            this.registoCliente.Size = new System.Drawing.Size(173, 40);
            this.registoCliente.TabIndex = 1;
            this.registoCliente.Text = "Registar Cliente";
            this.registoCliente.UseVisualStyleBackColor = true;
            this.registoCliente.Click += new System.EventHandler(this.registoCliente_Click);
            // 
            // registoDoutor
            // 
            this.registoDoutor.Location = new System.Drawing.Point(61, 207);
            this.registoDoutor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.registoDoutor.Name = "registoDoutor";
            this.registoDoutor.Size = new System.Drawing.Size(173, 40);
            this.registoDoutor.TabIndex = 5;
            this.registoDoutor.Text = "Registar Doutor";
            this.registoDoutor.UseVisualStyleBackColor = true;
            this.registoDoutor.Click += new System.EventHandler(this.registoDoutor_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 266);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Registar Funcionário";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(374, 67);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 240);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(61, 399);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 40);
            this.button4.TabIndex = 7;
            this.button4.Text = "Doutor";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // produtos
            // 
            this.produtos.Location = new System.Drawing.Point(603, 427);
            this.produtos.Name = "produtos";
            this.produtos.Size = new System.Drawing.Size(161, 44);
            this.produtos.TabIndex = 8;
            this.produtos.Text = "Produtos";
            this.produtos.UseVisualStyleBackColor = true;
            this.produtos.Click += new System.EventHandler(this.produtos_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(927, 615);
            this.Controls.Add(this.produtos);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.registoDoutor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.registoCliente);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainPage";
            this.Text = "Ótica Management";
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button registoCliente;
        private System.Windows.Forms.Button registoDoutor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button produtos;
    }
}
