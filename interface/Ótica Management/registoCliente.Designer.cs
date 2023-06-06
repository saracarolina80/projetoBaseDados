namespace Ótica_Management
{
    partial class registoCliente
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
            this.registar = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.morada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.telemovel = new System.Windows.Forms.TextBox();
            this.cc = new System.Windows.Forms.TextBox();
            this.nif = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registar
            // 
            this.registar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.registar.Font = new System.Drawing.Font("MS PGothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.registar.Location = new System.Drawing.Point(226, 288);
            this.registar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.registar.Name = "registar";
            this.registar.Size = new System.Drawing.Size(271, 40);
            this.registar.TabIndex = 0;
            this.registar.Text = "Registar o Cliente";
            this.registar.UseVisualStyleBackColor = false;
            this.registar.Click += new System.EventHandler(this.registar_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(89, 73);
            this.name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(230, 22);
            this.name.TabIndex = 1;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // morada
            // 
            this.morada.Location = new System.Drawing.Point(89, 148);
            this.morada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.morada.Name = "morada";
            this.morada.Size = new System.Drawing.Size(230, 22);
            this.morada.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Morada";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telemóvel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(436, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(436, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "CC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(436, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "NIF";
            // 
            // telemovel
            // 
            this.telemovel.Location = new System.Drawing.Point(89, 215);
            this.telemovel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.telemovel.Name = "telemovel";
            this.telemovel.Size = new System.Drawing.Size(230, 22);
            this.telemovel.TabIndex = 9;
            // 
            // cc
            // 
            this.cc.Location = new System.Drawing.Point(441, 73);
            this.cc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cc.Name = "cc";
            this.cc.Size = new System.Drawing.Size(230, 22);
            this.cc.TabIndex = 10;
            this.cc.TextChanged += new System.EventHandler(this.cc_TextChanged);
            // 
            // nif
            // 
            this.nif.Location = new System.Drawing.Point(441, 148);
            this.nif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nif.Name = "nif";
            this.nif.Size = new System.Drawing.Size(230, 22);
            this.nif.TabIndex = 11;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(441, 215);
            this.email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(230, 22);
            this.email.TabIndex = 12;
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.Font = new System.Drawing.Font("MS PGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(234, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 30);
            this.label7.TabIndex = 13;
            this.label7.Text = "Registar Cliente";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // registoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.email);
            this.Controls.Add(this.nif);
            this.Controls.Add(this.cc);
            this.Controls.Add(this.telemovel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.morada);
            this.Controls.Add(this.name);
            this.Controls.Add(this.registar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "registoCliente";
            this.Text = "registoCliente";
            this.Load += new System.EventHandler(this.registoCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registar;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox morada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox telemovel;
        private System.Windows.Forms.TextBox cc;
        private System.Windows.Forms.TextBox nif;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label7;
    }
}