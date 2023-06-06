namespace Ótica_Management
{
    partial class stock
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
            this.listBoxS = new System.Windows.Forms.ListBox();
            this.eliminar = new System.Windows.Forms.Button();
            this.dataEntrada = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.quantidade1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.estado = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ide = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxS
            // 
            this.listBoxS.FormattingEnabled = true;
            this.listBoxS.ItemHeight = 16;
            this.listBoxS.Location = new System.Drawing.Point(71, 58);
            this.listBoxS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxS.Name = "listBoxS";
            this.listBoxS.Size = new System.Drawing.Size(219, 180);
            this.listBoxS.TabIndex = 4;
            this.listBoxS.SelectedIndexChanged += new System.EventHandler(this.listBoxS_SelectedIndexChanged);
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(384, 290);
            this.eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(219, 27);
            this.eliminar.TabIndex = 6;
            this.eliminar.Text = "Eliminar produto do stock";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // dataEntrada
            // 
            this.dataEntrada.Location = new System.Drawing.Point(385, 215);
            this.dataEntrada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataEntrada.Name = "dataEntrada";
            this.dataEntrada.Size = new System.Drawing.Size(272, 22);
            this.dataEntrada.TabIndex = 7;
            this.dataEntrada.ValueChanged += new System.EventHandler(this.dataEntrada_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Data de entrada";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // quantidade1
            // 
            this.quantidade1.Location = new System.Drawing.Point(385, 150);
            this.quantidade1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quantidade1.Name = "quantidade1";
            this.quantidade1.Size = new System.Drawing.Size(155, 22);
            this.quantidade1.TabIndex = 11;
            this.quantidade1.ValueChanged += new System.EventHandler(this.quantidade1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Quantidade";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Estado";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // estado
            // 
            this.estado.Location = new System.Drawing.Point(385, 98);
            this.estado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(272, 22);
            this.estado.TabIndex = 14;
            this.estado.TextChanged += new System.EventHandler(this.estado_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 290);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 26);
            this.button1.TabIndex = 15;
            this.button1.Text = "Fazer pedido ao fornecedor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ide
            // 
            this.ide.Location = new System.Drawing.Point(385, 50);
            this.ide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ide.Name = "ide";
            this.ide.Size = new System.Drawing.Size(143, 22);
            this.ide.TabIndex = 16;
            this.ide.TextChanged += new System.EventHandler(this.ide_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "ID";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 459);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ide);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quantidade1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataEntrada);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.listBoxS);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "stock";
            this.Text = "stock";
            this.Load += new System.EventHandler(this.stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantidade1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxS;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.DateTimePicker dataEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown quantidade1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox estado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ide;
        private System.Windows.Forms.Label label5;
    }
}