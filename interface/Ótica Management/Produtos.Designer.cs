namespace Ótica_Management
{
    partial class Produtos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.novo = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Button();
            this.stock = new System.Windows.Forms.Button();
            this.listBoxP = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipo1 = new System.Windows.Forms.TextBox();
            this.marca1 = new System.Windows.Forms.TextBox();
            this.preço1 = new System.Windows.Forms.TextBox();
            this.nome1 = new System.Windows.Forms.TextBox();
            this.ide = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.procura = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // novo
            // 
            this.novo.Location = new System.Drawing.Point(51, 74);
            this.novo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.novo.Name = "novo";
            this.novo.Size = new System.Drawing.Size(150, 41);
            this.novo.TabIndex = 0;
            this.novo.Text = "Inserir novo produto";
            this.novo.UseVisualStyleBackColor = true;
            this.novo.Click += new System.EventHandler(this.novo_Click);
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(385, 278);
            this.info.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(126, 28);
            this.info.TabIndex = 1;
            this.info.Text = "Procurar produto";
            this.info.UseVisualStyleBackColor = true;
            this.info.Click += new System.EventHandler(this.info_Click);
            // 
            // stock
            // 
            this.stock.Location = new System.Drawing.Point(51, 124);
            this.stock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(150, 41);
            this.stock.TabIndex = 2;
            this.stock.Text = "Ver stock";
            this.stock.UseVisualStyleBackColor = true;
            this.stock.Click += new System.EventHandler(this.stock_Click);
            // 
            // listBoxP
            // 
            this.listBoxP.FormattingEnabled = true;
            this.listBoxP.ItemHeight = 16;
            this.listBoxP.Location = new System.Drawing.Point(292, 74);
            this.listBoxP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxP.Name = "listBoxP";
            this.listBoxP.Size = new System.Drawing.Size(219, 180);
            this.listBoxP.TabIndex = 3;
            this.listBoxP.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Preço";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nome";
            // 
            // tipo1
            // 
            this.tipo1.Location = new System.Drawing.Point(552, 288);
            this.tipo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tipo1.Name = "tipo1";
            this.tipo1.Size = new System.Drawing.Size(211, 22);
            this.tipo1.TabIndex = 15;
            // 
            // marca1
            // 
            this.marca1.Location = new System.Drawing.Point(552, 234);
            this.marca1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.marca1.Name = "marca1";
            this.marca1.Size = new System.Drawing.Size(211, 22);
            this.marca1.TabIndex = 14;
            // 
            // preço1
            // 
            this.preço1.Location = new System.Drawing.Point(552, 182);
            this.preço1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.preço1.Name = "preço1";
            this.preço1.Size = new System.Drawing.Size(211, 22);
            this.preço1.TabIndex = 13;
            // 
            // nome1
            // 
            this.nome1.Location = new System.Drawing.Point(552, 124);
            this.nome1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nome1.Name = "nome1";
            this.nome1.Size = new System.Drawing.Size(211, 22);
            this.nome1.TabIndex = 12;
            // 
            // ide
            // 
            this.ide.Location = new System.Drawing.Point(552, 66);
            this.ide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ide.Name = "ide";
            this.ide.Size = new System.Drawing.Size(211, 22);
            this.ide.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(548, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            // 
            // procura
            // 
            this.procura.Location = new System.Drawing.Point(221, 281);
            this.procura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.procura.Name = "procura";
            this.procura.Size = new System.Drawing.Size(159, 22);
            this.procura.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(573, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Informação do produto";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(554, 355);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 27);
            this.button1.TabIndex = 22;
            this.button1.Text = "Eliminar este produto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(552, 325);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 26);
            this.button2.TabIndex = 23;
            this.button2.Text = "Verificar se está em stock";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Produtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 409);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.procura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipo1);
            this.Controls.Add(this.marca1);
            this.Controls.Add(this.preço1);
            this.Controls.Add(this.nome1);
            this.Controls.Add(this.ide);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxP);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.info);
            this.Controls.Add(this.novo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Produtos";
            this.Text = "Produtos";
            this.Load += new System.EventHandler(this.Produtos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button novo;
        private System.Windows.Forms.Button info;
        private System.Windows.Forms.Button stock;
        private System.Windows.Forms.ListBox listBoxP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tipo1;
        private System.Windows.Forms.TextBox marca1;
        private System.Windows.Forms.TextBox preço1;
        private System.Windows.Forms.TextBox nome1;
        private System.Windows.Forms.TextBox ide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox procura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}