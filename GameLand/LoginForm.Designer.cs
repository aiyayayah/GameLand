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
            this.btnLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBoxIC = new System.Windows.Forms.TextBox();
            this.labelIC = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(676, 480);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(122, 39);
            this.btnLogin.TabIndex = 18;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(621, 403);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(284, 26);
            this.textBoxPassword.TabIndex = 16;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.BackColor = System.Drawing.Color.Transparent;
            this.labelPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelPass.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.ForeColor = System.Drawing.Color.OldLace;
            this.labelPass.Location = new System.Drawing.Point(408, 403);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(160, 37);
            this.labelPass.TabIndex = 15;
            this.labelPass.Text = "Password";
            // 
            // textBoxIC
            // 
            this.textBoxIC.Location = new System.Drawing.Point(621, 334);
            this.textBoxIC.Name = "textBoxIC";
            this.textBoxIC.Size = new System.Drawing.Size(284, 26);
            this.textBoxIC.TabIndex = 14;
            this.textBoxIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelIC
            // 
            this.labelIC.AutoSize = true;
            this.labelIC.BackColor = System.Drawing.Color.Transparent;
            this.labelIC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelIC.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIC.ForeColor = System.Drawing.Color.OldLace;
            this.labelIC.Location = new System.Drawing.Point(408, 334);
            this.labelIC.Name = "labelIC";
            this.labelIC.Size = new System.Drawing.Size(170, 37);
            this.labelIC.TabIndex = 13;
            this.labelIC.Text = "Ic Number";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Cambria", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.Control;
            this.title.Location = new System.Drawing.Point(488, 205);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(400, 65);
            this.title.TabIndex = 19;
            this.title.Text = "Welcome Back";
            this.title.Click += new System.EventHandler(this.title_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 782);
            this.Controls.Add(this.title);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.textBoxIC);
            this.Controls.Add(this.labelIC);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxIC;
        private System.Windows.Forms.Label labelIC;
        private System.Windows.Forms.Label title;
    }
}