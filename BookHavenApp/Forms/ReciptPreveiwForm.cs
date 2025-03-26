using System;
using System.Windows.Forms;

namespace BookHavenApp.Forms
{
    public partial class ReceiptPreviewForm : Form
    {
        public ReceiptPreviewForm(string receiptText)
        {
            InitializeComponent();
            txtReceipt.Text = receiptText;
        }
    }
}
