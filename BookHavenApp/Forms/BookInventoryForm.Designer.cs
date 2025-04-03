namespace BookHavenStoreApp.Forms
{
    partial class BookInventoryForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.dgvBooks = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.BtnSearchBook = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(458, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Clear Feilds";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Stock";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Genre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Author";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(73, 70);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(27, 13);
            this.Title.TabIndex = 30;
            this.Title.Text = "Title";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(471, 144);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 23);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete Book";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(471, 106);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 23);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "Update Book";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(471, 71);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add Book";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(323, 64);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(115, 20);
            this.txtISBN.TabIndex = 25;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(124, 106);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(116, 20);
            this.txtAuthor.TabIndex = 24;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(323, 151);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(115, 20);
            this.txtStock.TabIndex = 23;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(323, 106);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(115, 20);
            this.txtPrice.TabIndex = 22;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(124, 67);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(116, 20);
            this.txtTitle.TabIndex = 20;
            // 
            // dgvBooks
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBooks.ColumnHeadersHeight = 4;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBooks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBooks.Location = new System.Drawing.Point(41, 221);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.Size = new System.Drawing.Size(563, 167);
            this.dgvBooks.TabIndex = 40;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBooks.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBooks.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBooks.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBooks.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBooks.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBooks.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvBooks.ThemeStyle.ReadOnly = false;
            this.dgvBooks.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBooks.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBooks.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBooks.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBooks.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBooks.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellContentClick);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(119, 150);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 41;
            // 
            // BtnSearchBook
            // 
            this.BtnSearchBook.Location = new System.Drawing.Point(244, 188);
            this.BtnSearchBook.Name = "BtnSearchBook";
            this.BtnSearchBook.Size = new System.Drawing.Size(87, 23);
            this.BtnSearchBook.TabIndex = 42;
            this.BtnSearchBook.Text = "Search Book";
            this.BtnSearchBook.UseVisualStyleBackColor = true;
            this.BtnSearchBook.Click += new System.EventHandler(this.BtnSearchBook_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(119, 190);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(116, 20);
            this.txtSearch.TabIndex = 43;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // BookInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 398);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.BtnSearchBook);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtTitle);
            this.Name = "BookInventoryForm";
            this.Load += new System.EventHandler(this.BookInventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBooks;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button BtnSearchBook;
        private System.Windows.Forms.TextBox txtSearch;
    }
}