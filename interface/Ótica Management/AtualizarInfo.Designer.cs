namespace Ótica_Management
{
    partial class AtualizarInfo
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
            this.nome = new System.Windows.Forms.TextBox();
            this.morada = new System.Windows.Forms.TextBox();
            this.cc = new System.Windows.Forms.TextBox();
            this.telemovel = new System.Windows.Forms.TextBox();
            this.num_contribuinte = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.atualizar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(188, 87);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(183, 26);
            this.nome.TabIndex = 0;
            this.nome.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // morada
            // 
            this.morada.Location = new System.Drawing.Point(188, 180);
            this.morada.Name = "morada";
            this.morada.Size = new System.Drawing.Size(183, 26);
            this.morada.TabIndex = 1;
            // 
            // cc
            // 
            this.cc.Location = new System.Drawing.Point(188, 131);
            this.cc.Name = "cc";
            this.cc.Size = new System.Drawing.Size(183, 26);
            this.cc.TabIndex = 2;
            // 
            // telemovel
            // 
            this.telemovel.Location = new System.Drawing.Point(188, 220);
            this.telemovel.Name = "telemovel";
            this.telemovel.Size = new System.Drawing.Size(183, 26);
            this.telemovel.TabIndex = 3;
            // 
            // num_contribuinte
            // 
            this.num_contribuinte.Location = new System.Drawing.Point(188, 264);
            this.num_contribuinte.Name = "num_contribuinte";
            this.num_contribuinte.Size = new System.Drawing.Size(183, 26);
            this.num_contribuinte.TabIndex = 4;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(188, 319);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(183, 26);
            this.email.TabIndex = 5;
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            // 
            // atualizar
            // 
            this.atualizar.Location = new System.Drawing.Point(64, 381);
            this.atualizar.Name = "atualizar";
            this.atualizar.Size = new System.Drawing.Size(130, 40);
            this.atualizar.TabIndex = 6;
            this.atualizar.Text = "Atualizar";
            this.atualizar.UseVisualStyleBackColor = true;
            this.atualizar.Click += new System.EventHandler(this.atualizar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(243, 381);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(128, 40);
            this.cancelar.TabIndex = 7;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "CC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Morada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Telemovel:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Contribuinte:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Email:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS PGothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(135, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 28);
            this.label7.TabIndex = 14;
            this.label7.Text = "Atualizar dados";
            // 
            // AtualizarInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.atualizar);
            this.Controls.Add(this.email);
            this.Controls.Add(this.num_contribuinte);
            this.Controls.Add(this.telemovel);
            this.Controls.Add(this.cc);
            this.Controls.Add(this.morada);
            this.Controls.Add(this.nome);
            this.Name = "AtualizarInfo";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.AtualizarInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.TextBox morada;
        private System.Windows.Forms.TextBox cc;
        private System.Windows.Forms.TextBox telemovel;
        private System.Windows.Forms.TextBox num_contribuinte;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Button atualizar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}