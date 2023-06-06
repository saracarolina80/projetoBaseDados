namespace Ótica_Management
{
    partial class CheckPedidos
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
            this.label5 = new System.Windows.Forms.Label();
            this.ide = new System.Windows.Forms.TextBox();
            this.estado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.quantidade1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataEntrada = new System.Windows.Forms.DateTimePicker();
            this.listBoxS = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(418, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "ID";
            // 
            // ide
            // 
            this.ide.Location = new System.Drawing.Point(422, 89);
            this.ide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ide.Name = "ide";
            this.ide.Size = new System.Drawing.Size(143, 22);
            this.ide.TabIndex = 25;
            // 
            // estado
            // 
            this.estado.Location = new System.Drawing.Point(422, 137);
            this.estado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(272, 22);
            this.estado.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(418, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Quantidade";
            // 
            // quantidade1
            // 
            this.quantidade1.Location = new System.Drawing.Point(422, 189);
            this.quantidade1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quantidade1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.quantidade1.Name = "quantidade1";
            this.quantidade1.Size = new System.Drawing.Size(155, 22);
            this.quantidade1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Data de entrada";
            // 
            // dataEntrada
            // 
            this.dataEntrada.Location = new System.Drawing.Point(422, 254);
            this.dataEntrada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataEntrada.Name = "dataEntrada";
            this.dataEntrada.Size = new System.Drawing.Size(272, 22);
            this.dataEntrada.TabIndex = 19;
            // 
            // listBoxS
            // 
            this.listBoxS.FormattingEnabled = true;
            this.listBoxS.ItemHeight = 16;
            this.listBoxS.Location = new System.Drawing.Point(108, 89);
            this.listBoxS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxS.Name = "listBoxS";
            this.listBoxS.Size = new System.Drawing.Size(219, 180);
            this.listBoxS.TabIndex = 18;
            this.listBoxS.SelectedIndexChanged += new System.EventHandler(this.listBoxS_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 38);
            this.button1.TabIndex = 27;
            this.button1.Text = "Aceitar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CheckPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ide);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quantidade1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataEntrada);
            this.Controls.Add(this.listBoxS);
            this.Name = "CheckPedidos";
            this.Text = "CheckPedidos";
            this.Load += new System.EventHandler(this.CheckPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantidade1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ide;
        private System.Windows.Forms.TextBox estado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown quantidade1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dataEntrada;
        private System.Windows.Forms.ListBox listBoxS;
        private System.Windows.Forms.Button button1;
    }
}