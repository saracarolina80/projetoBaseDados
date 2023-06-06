namespace Ótica_Management
{
    partial class registoDoutor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.num_sns = new System.Windows.Forms.TextBox();
            this.cc = new System.Windows.Forms.TextBox();
            this.telemovel = new System.Windows.Forms.TextBox();
            this.morada = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.1F);
            this.label1.Location = new System.Drawing.Point(321, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registo Doutor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(133, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(103, 155);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 22);
            this.name.TabIndex = 3;
            this.name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Morada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Telemóvel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(620, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "CC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(609, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "E-mail";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(599, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Numero SNS";
            // 
            // num_sns
            // 
            this.num_sns.Location = new System.Drawing.Point(585, 347);
            this.num_sns.Name = "num_sns";
            this.num_sns.Size = new System.Drawing.Size(100, 22);
            this.num_sns.TabIndex = 10;
            // 
            // cc
            // 
            this.cc.Location = new System.Drawing.Point(585, 155);
            this.cc.Name = "cc";
            this.cc.Size = new System.Drawing.Size(100, 22);
            this.cc.TabIndex = 11;
            this.cc.TextChanged += new System.EventHandler(this.cc_TextChanged);
            // 
            // telemovel
            // 
            this.telemovel.Location = new System.Drawing.Point(103, 347);
            this.telemovel.Name = "telemovel";
            this.telemovel.Size = new System.Drawing.Size(100, 22);
            this.telemovel.TabIndex = 12;
            this.telemovel.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // morada
            // 
            this.morada.Location = new System.Drawing.Point(103, 250);
            this.morada.Name = "morada";
            this.morada.Size = new System.Drawing.Size(100, 22);
            this.morada.TabIndex = 13;
            this.morada.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(585, 250);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(100, 22);
            this.email.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Registar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // registoDoutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.email);
            this.Controls.Add(this.morada);
            this.Controls.Add(this.telemovel);
            this.Controls.Add(this.cc);
            this.Controls.Add(this.num_sns);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "registoDoutor";
            this.Text = "registoDoutor";
            this.Load += new System.EventHandler(this.registoDoutor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox num_sns;
        private System.Windows.Forms.TextBox cc;
        private System.Windows.Forms.TextBox telemovel;
        private System.Windows.Forms.TextBox morada;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Button button1;
    }
}