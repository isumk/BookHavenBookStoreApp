namespace BookHavenApp.Forms
{
    partial class ReceiptPreviewForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox txtReceipt;

        private void InitializeComponent()
        {
            this.txtReceipt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtReceipt
            // 
            this.txtReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceipt.Font = new System.Drawing.Font("Consolas", 10);
            this.txtReceipt.ReadOnly = true;
            this.txtReceipt.Location = new System.Drawing.Point(0, 0);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.Size = new System.Drawing.Size(500, 600);
            this.txtReceipt.TabIndex = 0;
            this.txtReceipt.Text = "";
            // 
            // ReceiptPreviewForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.txtReceipt);
            this.Name = "ReceiptPreviewForm";
            this.Text = "Receipt Preview";
            this.ResumeLayout(false);
        }
    }
}
