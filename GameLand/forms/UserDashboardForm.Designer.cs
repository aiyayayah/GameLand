namespace GameLand.forms
{
    partial class UserDashboardForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dgvAvailableItems = new System.Windows.Forms.DataGridView();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.dgvBorrowedItems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(731, 43);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(103, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "label1";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // dgvAvailableItems
            // 
            this.dgvAvailableItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableItems.Location = new System.Drawing.Point(109, 121);
            this.dgvAvailableItems.Name = "dgvAvailableItems";
            this.dgvAvailableItems.RowHeadersWidth = 62;
            this.dgvAvailableItems.RowTemplate.Height = 28;
            this.dgvAvailableItems.Size = new System.Drawing.Size(1328, 318);
            this.dgvAvailableItems.TabIndex = 1;
            this.dgvAvailableItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(738, 487);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(133, 51);
            this.btnBorrow.TabIndex = 2;
            this.btnBorrow.Text = "Borrow";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click_1);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(738, 755);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(133, 51);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click_1);
            // 
            // dgvBorrowedItems
            // 
            this.dgvBorrowedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowedItems.Location = new System.Drawing.Point(109, 568);
            this.dgvBorrowedItems.Name = "dgvBorrowedItems";
            this.dgvBorrowedItems.RowHeadersWidth = 62;
            this.dgvBorrowedItems.RowTemplate.Height = 28;
            this.dgvBorrowedItems.Size = new System.Drawing.Size(1328, 157);
            this.dgvBorrowedItems.TabIndex = 4;
            this.dgvBorrowedItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBorrowedItems_CellContentClick);
            // 
            // UserDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 852);
            this.Controls.Add(this.dgvBorrowedItems);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.dgvAvailableItems);
            this.Controls.Add(this.lblWelcome);
            this.Name = "UserDashboardForm";
            this.Text = "UserDashboardForm";
            this.Load += new System.EventHandler(this.UserDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvAvailableItems;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DataGridView dgvBorrowedItems;
    }
}