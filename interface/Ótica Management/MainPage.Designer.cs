namespace Ótica_Management
{
    partial class MainPage
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
            this.button4 = new System.Windows.Forms.Button();
            this.produtos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(254, 346);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 46);
            this.button3.TabIndex = 3;
            this.button3.Text = "Fornecedor";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 213);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Informação Cliente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // registoCliente
            // 
            this.registoCliente.Location = new System.Drawing.Point(43, 167);
            this.registoCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.registoCliente.Name = "registoCliente";
            this.registoCliente.Size = new System.Drawing.Size(189, 46);
            this.registoCliente.TabIndex = 1;
            this.registoCliente.Text = "Registar Cliente";
            this.registoCliente.UseVisualStyleBackColor = true;
            this.registoCliente.Click += new System.EventHandler(this.registoCliente_Click);
            // 
            // registoDoutor
            // 
            this.registoDoutor.Location = new System.Drawing.Point(254, 167);
            this.registoDoutor.Name = "registoDoutor";
            this.registoDoutor.Size = new System.Drawing.Size(189, 46);
            this.registoDoutor.TabIndex = 5;
            this.registoDoutor.Text = "Registar Doutor";
            this.registoDoutor.UseVisualStyleBackColor = true;
            this.registoDoutor.Click += new System.EventHandler(this.registoDoutor_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(254, 213);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(189, 46);
            this.button4.TabIndex = 7;
            this.button4.Text = "Doutor";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // produtos
            // 
            this.produtos.Location = new System.Drawing.Point(43, 343);
            this.produtos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.produtos.Name = "produtos";
            this.produtos.Size = new System.Drawing.Size(189, 50);
            this.produtos.TabIndex = 8;
            this.produtos.Text = "Cliente";
            this.produtos.UseVisualStyleBackColor = true;
            this.produtos.Click += new System.EventHandler(this.produtos_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(492, 492);
            this.Controls.Add(this.produtos);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.registoDoutor);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.registoCliente);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainPage";
            this.Text = "Ótica Management";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button registoCliente;
        private System.Windows.Forms.Button registoDoutor;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button produtos;
    }
}
