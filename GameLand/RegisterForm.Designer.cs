namespace GameLand
{
    partial class labelLogin
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxIC = new System.Windows.Forms.TextBox();
            this.labelIC = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.textBoxConfirm = new System.Windows.Forms.TextBox();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(441, 165);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(51, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.AccessibleDescription = "";
            this.textBoxName.Location = new System.Drawing.Point(554, 159);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(284, 26);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Tag = "";
            this.textBoxName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // textBoxIC
            // 
            this.textBoxIC.Location = new System.Drawing.Point(554, 236);
            this.textBoxIC.Name = "textBoxIC";
            this.textBoxIC.Size = new System.Drawing.Size(284, 26);
            this.textBoxIC.TabIndex = 3;
            this.textBoxIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxIC.TextChanged += new System.EventHandler(this.txtIC_TextChanged);
            // 
            // labelIC
            // 
            this.labelIC.AutoSize = true;
            this.labelIC.Location = new System.Drawing.Point(441, 242);
            this.labelIC.Name = "labelIC";
            this.labelIC.Size = new System.Drawing.Size(82, 20);
            this.labelIC.TabIndex = 2;
            this.labelIC.Text = "Ic Number";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(554, 305);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(284, 26);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(441, 311);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(78, 20);
            this.labelPass.TabIndex = 4;
            this.labelPass.Text = "Password";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(554, 515);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(122, 39);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click_1);
            // 
            // textBoxConfirm
            // 
            this.textBoxConfirm.Location = new System.Drawing.Point(554, 381);
            this.textBoxConfirm.Name = "textBoxConfirm";
            this.textBoxConfirm.Size = new System.Drawing.Size(284, 26);
            this.textBoxConfirm.TabIndex = 9;
            this.textBoxConfirm.UseSystemPasswordChar = true;
            // 
            // labelConfirm
            // 
            this.labelConfirm.AutoSize = true;
            this.labelConfirm.Location = new System.Drawing.Point(412, 387);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(136, 20);
            this.labelConfirm.TabIndex = 8;
            this.labelConfirm.Text = "Confirm password";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(476, 441);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(268, 20);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Already have an account? Login now";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 817);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBoxConfirm);
            this.Controls.Add(this.labelConfirm);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.textBoxIC);
            this.Controls.Add(this.labelIC);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "labelLogin";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxIC;
        private System.Windows.Forms.Label labelIC;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox textBoxConfirm;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}