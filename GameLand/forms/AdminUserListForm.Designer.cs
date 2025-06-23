namespace GameLand.forms
{
    partial class AdminUserListForm
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
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvUserTransactions = new System.Windows.Forms.DataGridView();
            this.btnUpdateReturn = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(49, 39);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowHeadersWidth = 62;
            this.dataGridViewUsers.RowTemplate.Height = 28;
            this.dataGridViewUsers.Size = new System.Drawing.Size(1715, 520);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellClick);
            this.dataGridViewUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellContentClick);
            // 
            // dgvUserTransactions
            // 
            this.dgvUserTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserTransactions.Location = new System.Drawing.Point(49, 662);
            this.dgvUserTransactions.Name = "dgvUserTransactions";
            this.dgvUserTransactions.RowHeadersWidth = 62;
            this.dgvUserTransactions.RowTemplate.Height = 28;
            this.dgvUserTransactions.Size = new System.Drawing.Size(1715, 189);
            this.dgvUserTransactions.TabIndex = 1;
            this.dgvUserTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserTransactions_CellContentClick);
            // 
            // btnUpdateReturn
            // 
            this.btnUpdateReturn.Location = new System.Drawing.Point(333, 894);
            this.btnUpdateReturn.Name = "btnUpdateReturn";
            this.btnUpdateReturn.Size = new System.Drawing.Size(208, 59);
            this.btnUpdateReturn.TabIndex = 2;
            this.btnUpdateReturn.Text = "Make Payment";
            this.btnUpdateReturn.UseVisualStyleBackColor = true;
            this.btnUpdateReturn.Click += new System.EventHandler(this.btnUpdateReturn_Click_1);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(690, 894);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(208, 59);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(978, 894);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 59);
            this.button1.TabIndex = 4;
            this.button1.Text = "Delete User";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AdminUserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 996);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnUpdateReturn);
            this.Controls.Add(this.dgvUserTransactions);
            this.Controls.Add(this.dataGridViewUsers);
            this.Name = "AdminUserListForm";
            this.Text = "AdminUserListForm";
            this.Load += new System.EventHandler(this.AdminUserListForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvUserTransactions;
        private System.Windows.Forms.Button btnUpdateReturn;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button button1;
    }
}