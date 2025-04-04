namespace BookHavenStoreApp.Forms
{
    partial class AdminDashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel3 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel4 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel5 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel6 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.chartMonthlySales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTopBooksPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblPendingOrders = new System.Windows.Forms.Label();
            this.lblCancelledOrders = new System.Windows.Forms.Label();
            this.lblBestSeller = new System.Windows.Forms.Label();
            this.btnRequestStock = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.guna2CustomGradientPanel3.SuspendLayout();
            this.guna2CustomGradientPanel4.SuspendLayout();
            this.guna2CustomGradientPanel5.SuspendLayout();
            this.guna2CustomGradientPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlySales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopBooksPie)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.lblTotalBooks);
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(12, 23);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(120, 92);
            this.guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.Controls.Add(this.lblTotalSales);
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(154, 23);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(120, 92);
            this.guna2CustomGradientPanel2.TabIndex = 1;
            // 
            // guna2CustomGradientPanel3
            // 
            this.guna2CustomGradientPanel3.Controls.Add(this.lblTotalOrders);
            this.guna2CustomGradientPanel3.Location = new System.Drawing.Point(292, 23);
            this.guna2CustomGradientPanel3.Name = "guna2CustomGradientPanel3";
            this.guna2CustomGradientPanel3.Size = new System.Drawing.Size(120, 92);
            this.guna2CustomGradientPanel3.TabIndex = 1;
            // 
            // guna2CustomGradientPanel4
            // 
            this.guna2CustomGradientPanel4.Controls.Add(this.lblBestSeller);
            this.guna2CustomGradientPanel4.Location = new System.Drawing.Point(292, 121);
            this.guna2CustomGradientPanel4.Name = "guna2CustomGradientPanel4";
            this.guna2CustomGradientPanel4.Size = new System.Drawing.Size(120, 92);
            this.guna2CustomGradientPanel4.TabIndex = 1;
            // 
            // guna2CustomGradientPanel5
            // 
            this.guna2CustomGradientPanel5.Controls.Add(this.lblCancelledOrders);
            this.guna2CustomGradientPanel5.Location = new System.Drawing.Point(154, 121);
            this.guna2CustomGradientPanel5.Name = "guna2CustomGradientPanel5";
            this.guna2CustomGradientPanel5.Size = new System.Drawing.Size(120, 92);
            this.guna2CustomGradientPanel5.TabIndex = 1;
            this.guna2CustomGradientPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2CustomGradientPanel5_Paint);
            // 
            // guna2CustomGradientPanel6
            // 
            this.guna2CustomGradientPanel6.Controls.Add(this.lblPendingOrders);
            this.guna2CustomGradientPanel6.Location = new System.Drawing.Point(12, 121);
            this.guna2CustomGradientPanel6.Name = "guna2CustomGradientPanel6";
            this.guna2CustomGradientPanel6.Size = new System.Drawing.Size(120, 92);
            this.guna2CustomGradientPanel6.TabIndex = 2;
            // 
            // chartMonthlySales
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMonthlySales.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMonthlySales.Legends.Add(legend1);
            this.chartMonthlySales.Location = new System.Drawing.Point(9, 230);
            this.chartMonthlySales.Name = "chartMonthlySales";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartMonthlySales.Series.Add(series1);
            this.chartMonthlySales.Size = new System.Drawing.Size(403, 208);
            this.chartMonthlySales.TabIndex = 3;
            this.chartMonthlySales.Text = "chart1";
            this.chartMonthlySales.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chartTopBooksPie
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTopBooksPie.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTopBooksPie.Legends.Add(legend2);
            this.chartTopBooksPie.Location = new System.Drawing.Point(424, 19);
            this.chartTopBooksPie.Name = "chartTopBooksPie";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTopBooksPie.Series.Add(series2);
            this.chartTopBooksPie.Size = new System.Drawing.Size(251, 216);
            this.chartTopBooksPie.TabIndex = 4;
            this.chartTopBooksPie.Text = "chart2";
            this.chartTopBooksPie.Click += new System.EventHandler(this.chart2_Click);
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.AutoSize = true;
            this.lblTotalBooks.Location = new System.Drawing.Point(27, 40);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(76, 13);
            this.lblTotalBooks.TabIndex = 5;
            this.lblTotalBooks.Text = "Total Books: 0";
            this.lblTotalBooks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalBooks.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Location = new System.Drawing.Point(14, 40);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(103, 13);
            this.lblTotalSales.TabIndex = 6;
            this.lblTotalSales.Text = "Total Sales: ₨ 0.00";
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Location = new System.Drawing.Point(24, 40);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(77, 13);
            this.lblTotalOrders.TabIndex = 7;
            this.lblTotalOrders.Text = "Total Orders: 0";
            // 
            // lblPendingOrders
            // 
            this.lblPendingOrders.AutoSize = true;
            this.lblPendingOrders.Location = new System.Drawing.Point(11, 39);
            this.lblPendingOrders.Name = "lblPendingOrders";
            this.lblPendingOrders.Size = new System.Drawing.Size(92, 13);
            this.lblPendingOrders.TabIndex = 8;
            this.lblPendingOrders.Text = "Pending Orders: 0";
            // 
            // lblCancelledOrders
            // 
            this.lblCancelledOrders.AutoSize = true;
            this.lblCancelledOrders.Location = new System.Drawing.Point(14, 39);
            this.lblCancelledOrders.Name = "lblCancelledOrders";
            this.lblCancelledOrders.Size = new System.Drawing.Size(100, 13);
            this.lblCancelledOrders.TabIndex = 9;
            this.lblCancelledOrders.Text = "Cancelled Orders: 0";
            this.lblCancelledOrders.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblBestSeller
            // 
            this.lblBestSeller.AutoSize = true;
            this.lblBestSeller.Location = new System.Drawing.Point(24, 39);
            this.lblBestSeller.Name = "lblBestSeller";
            this.lblBestSeller.Size = new System.Drawing.Size(81, 13);
            this.lblBestSeller.TabIndex = 10;
            this.lblBestSeller.Text = "Top Seller: N/A";
            // 
            // btnRequestStock
            // 
            this.btnRequestStock.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRequestStock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRequestStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRequestStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRequestStock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRequestStock.ForeColor = System.Drawing.Color.White;
            this.btnRequestStock.Location = new System.Drawing.Point(431, 296);
            this.btnRequestStock.Name = "btnRequestStock";
            this.btnRequestStock.Size = new System.Drawing.Size(180, 45);
            this.btnRequestStock.TabIndex = 5;
            this.btnRequestStock.Text = "guna2Button1";
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 450);
            this.Controls.Add(this.btnRequestStock);
            this.Controls.Add(this.chartTopBooksPie);
            this.Controls.Add(this.chartMonthlySales);
            this.Controls.Add(this.guna2CustomGradientPanel6);
            this.Controls.Add(this.guna2CustomGradientPanel5);
            this.Controls.Add(this.guna2CustomGradientPanel4);
            this.Controls.Add(this.guna2CustomGradientPanel3);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Name = "AdminDashboardForm";
            this.Text = "AdminDashboardForm";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            this.guna2CustomGradientPanel3.ResumeLayout(false);
            this.guna2CustomGradientPanel3.PerformLayout();
            this.guna2CustomGradientPanel4.ResumeLayout(false);
            this.guna2CustomGradientPanel4.PerformLayout();
            this.guna2CustomGradientPanel5.ResumeLayout(false);
            this.guna2CustomGradientPanel5.PerformLayout();
            this.guna2CustomGradientPanel6.ResumeLayout(false);
            this.guna2CustomGradientPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlySales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopBooksPie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel3;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel4;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel5;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMonthlySales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopBooksPie;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblBestSeller;
        private System.Windows.Forms.Label lblCancelledOrders;
        private System.Windows.Forms.Label lblPendingOrders;
        private Guna.UI2.WinForms.Guna2Button btnRequestStock;
    }
}