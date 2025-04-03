namespace BookHavenStoreApp.Forms
{
    partial class OrderManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.btnSendToPOS = new System.Windows.Forms.Button();
            this.btnAddBooks = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvOrderHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(93, 64);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomer.TabIndex = 2;
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Location = new System.Drawing.Point(93, 103);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(121, 21);
            this.cmbOrderType.TabIndex = 3;
            this.cmbOrderType.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(224, 61);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(83, 23);
            this.btnAddOrder.TabIndex = 4;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(224, 119);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(83, 23);
            this.btnDeleteOrder.TabIndex = 5;
            this.btnDeleteOrder.Text = "Delete Order";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Location = new System.Drawing.Point(224, 90);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(83, 23);
            this.btnUpdateOrder.TabIndex = 6;
            this.btnUpdateOrder.Text = "Update Order";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            // 
            // btnSendToPOS
            // 
            this.btnSendToPOS.Location = new System.Drawing.Point(224, 148);
            this.btnSendToPOS.Name = "btnSendToPOS";
            this.btnSendToPOS.Size = new System.Drawing.Size(83, 23);
            this.btnSendToPOS.TabIndex = 7;
            this.btnSendToPOS.Text = "Send To POS";
            this.btnSendToPOS.UseVisualStyleBackColor = true;
            // 
            // btnAddBooks
            // 
            this.btnAddBooks.Location = new System.Drawing.Point(93, 148);
            this.btnAddBooks.Name = "btnAddBooks";
            this.btnAddBooks.Size = new System.Drawing.Size(121, 23);
            this.btnAddBooks.TabIndex = 8;
            this.btnAddBooks.Text = "Select Books";
            this.btnAddBooks.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Order Type";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Select Customer";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvOrderHistory
            // 
            this.dgvOrderHistory.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvOrderHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrderHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvOrderHistory.Location = new System.Drawing.Point(55, 233);
            this.dgvOrderHistory.Name = "dgvOrderHistory";
            this.dgvOrderHistory.RowHeadersVisible = false;
            this.dgvOrderHistory.Size = new System.Drawing.Size(445, 150);
            this.dgvOrderHistory.TabIndex = 11;
            this.dgvOrderHistory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvOrderHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvOrderHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvOrderHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvOrderHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvOrderHistory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvOrderHistory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvOrderHistory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvOrderHistory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvOrderHistory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrderHistory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOrderHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrderHistory.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvOrderHistory.ThemeStyle.ReadOnly = false;
            this.dgvOrderHistory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvOrderHistory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrderHistory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrderHistory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvOrderHistory.ThemeStyle.RowsStyle.Height = 22;
            this.dgvOrderHistory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvOrderHistory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // OrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 424);
            this.Controls.Add(this.dgvOrderHistory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddBooks);
            this.Controls.Add(this.btnSendToPOS);
            this.Controls.Add(this.btnUpdateOrder);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.cmbOrderType);
            this.Controls.Add(this.cmbCustomer);
            this.Name = "OrderManagement";
            this.Text = "OrderManagement";
            this.Load += new System.EventHandler(this.OrderManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbOrderType;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.Button btnSendToPOS;
        private System.Windows.Forms.Button btnAddBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvOrderHistory;
    }
}