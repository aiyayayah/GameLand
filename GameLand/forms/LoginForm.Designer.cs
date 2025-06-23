namespace GameLand
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.labelPass = new System.Windows.Forms.Label();
            this.labelIC = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIC = new System.Windows.Forms.TextBox();
            this.labelICNUm = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.BackColor = System.Drawing.Color.Transparent;
            this.labelPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelPass.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.ForeColor = System.Drawing.Color.OldLace;
            this.labelPass.Location = new System.Drawing.Point(478, 444);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(0, 37);
            this.labelPass.TabIndex = 15;
            // 
            // labelIC
            // 
            this.labelIC.AutoSize = true;
            this.labelIC.BackColor = System.Drawing.Color.Transparent;
            this.labelIC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelIC.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIC.ForeColor = System.Drawing.Color.OldLace;
            this.labelIC.Location = new System.Drawing.Point(478, 375);
            this.labelIC.Name = "labelIC";
            this.labelIC.Size = new System.Drawing.Size(0, 37);
            this.labelIC.TabIndex = 13;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Cambria", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.Control;
            this.title.Location = new System.Drawing.Point(375, 249);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(749, 65);
            this.title.TabIndex = 19;
            this.title.Text = "Welcome Back to GameLand";
            this.title.Click += new System.EventHandler(this.title_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OldLace;
            this.label1.Location = new System.Drawing.Point(502, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 37);
            this.label1.TabIndex = 22;
            this.label1.Text = "Password";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxIC
            // 
            this.textBoxIC.AccessibleDescription = "";
            this.textBoxIC.BackColor = System.Drawing.Color.OldLace;
            this.textBoxIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIC.Location = new System.Drawing.Point(694, 365);
            this.textBoxIC.Name = "textBoxIC";
            this.textBoxIC.Size = new System.Drawing.Size(284, 35);
            this.textBoxIC.TabIndex = 21;
            this.textBoxIC.Tag = "";
            this.textBoxIC.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelICNUm
            // 
            this.labelICNUm.AutoSize = true;
            this.labelICNUm.BackColor = System.Drawing.Color.Transparent;
            this.labelICNUm.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelICNUm.ForeColor = System.Drawing.Color.OldLace;
            this.labelICNUm.Location = new System.Drawing.Point(484, 365);
            this.labelICNUm.Name = "labelICNUm";
            this.labelICNUm.Size = new System.Drawing.Size(173, 37);
            this.labelICNUm.TabIndex = 20;
            this.labelICNUm.Text = "IC Number";
            this.labelICNUm.Click += new System.EventHandler(this.labelName_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogin.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.DimGray;
            this.btnLogin.Location = new System.Drawing.Point(694, 542);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(167, 51);
            this.btnLogin.TabIndex = 24;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.AccessibleDescription = "";
            this.textBoxPassword.BackColor = System.Drawing.Color.OldLace;
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(694, 448);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(284, 35);
            this.textBoxPassword.TabIndex = 25;
            this.textBoxPassword.Tag = "";
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1495, 852);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIC);
            this.Controls.Add(this.labelICNUm);
            this.Controls.Add(this.title);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelIC);
            this.Name = "LoginForm";
            this.Text = "User Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelIC;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIC;
        private System.Windows.Forms.Label labelICNUm;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}