namespace BoT
{
    partial class Form1
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
            this.BrowseTransactionFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TransactionFilePathLabel = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TransactionPreviewGrid = new System.Windows.Forms.DataGridView();
            this.Next1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Next2 = new System.Windows.Forms.Button();
            this.OnlineTransactionsFilePathLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OnlineTransactionBrowse = new System.Windows.Forms.Button();
            this.OnlineTransactionsLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.RefundTransactionsFilePathLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RefundTransactionsBrowse = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionPreviewGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // BrowseTransactionFile
            // 
            this.BrowseTransactionFile.Location = new System.Drawing.Point(268, 38);
            this.BrowseTransactionFile.Name = "BrowseTransactionFile";
            this.BrowseTransactionFile.Size = new System.Drawing.Size(162, 47);
            this.BrowseTransactionFile.TabIndex = 1;
            this.BrowseTransactionFile.Text = "Browse";
            this.BrowseTransactionFile.UseVisualStyleBackColor = true;
            this.BrowseTransactionFile.Click += new System.EventHandler(this.BrowseTransactionFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select transaction file";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TransactionFilePathLabel
            // 
            this.TransactionFilePathLabel.AutoSize = true;
            this.TransactionFilePathLabel.Location = new System.Drawing.Point(507, 52);
            this.TransactionFilePathLabel.Name = "TransactionFilePathLabel";
            this.TransactionFilePathLabel.Size = new System.Drawing.Size(0, 25);
            this.TransactionFilePathLabel.TabIndex = 2;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog2";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1521, 819);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TransactionPreviewGrid);
            this.tabPage1.Controls.Add(this.Next1);
            this.tabPage1.Controls.Add(this.TransactionFilePathLabel);
            this.tabPage1.Controls.Add(this.BrowseTransactionFile);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1513, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Transactions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TransactionPreviewGrid
            // 
            this.TransactionPreviewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionPreviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionPreviewGrid.Location = new System.Drawing.Point(25, 101);
            this.TransactionPreviewGrid.Name = "TransactionPreviewGrid";
            this.TransactionPreviewGrid.RowHeadersWidth = 62;
            this.TransactionPreviewGrid.RowTemplate.Height = 28;
            this.TransactionPreviewGrid.Size = new System.Drawing.Size(1463, 315);
            this.TransactionPreviewGrid.TabIndex = 4;
            // 
            // Next1
            // 
            this.Next1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Next1.Location = new System.Drawing.Point(1403, 436);
            this.Next1.Name = "Next1";
            this.Next1.Size = new System.Drawing.Size(85, 33);
            this.Next1.TabIndex = 3;
            this.Next1.Text = "Next";
            this.Next1.UseVisualStyleBackColor = true;
            this.Next1.Click += new System.EventHandler(this.Next_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.Next2);
            this.tabPage2.Controls.Add(this.OnlineTransactionsFilePathLabel);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.OnlineTransactionBrowse);
            this.tabPage2.Controls.Add(this.OnlineTransactionsLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1513, 781);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Online Transactions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1463, 605);
            this.dataGridView1.TabIndex = 9;
            // 
            // Next2
            // 
            this.Next2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Next2.Location = new System.Drawing.Point(1394, 712);
            this.Next2.Name = "Next2";
            this.Next2.Size = new System.Drawing.Size(85, 33);
            this.Next2.TabIndex = 8;
            this.Next2.Text = "Next";
            this.Next2.UseVisualStyleBackColor = true;
            this.Next2.Click += new System.EventHandler(this.Next_Click);
            // 
            // OnlineTransactionsFilePathLabel
            // 
            this.OnlineTransactionsFilePathLabel.AutoSize = true;
            this.OnlineTransactionsFilePathLabel.Location = new System.Drawing.Point(286, 38);
            this.OnlineTransactionsFilePathLabel.Name = "OnlineTransactionsFilePathLabel";
            this.OnlineTransactionsFilePathLabel.Size = new System.Drawing.Size(0, 25);
            this.OnlineTransactionsFilePathLabel.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 6;
            // 
            // OnlineTransactionBrowse
            // 
            this.OnlineTransactionBrowse.Location = new System.Drawing.Point(237, 29);
            this.OnlineTransactionBrowse.Name = "OnlineTransactionBrowse";
            this.OnlineTransactionBrowse.Size = new System.Drawing.Size(162, 47);
            this.OnlineTransactionBrowse.TabIndex = 5;
            this.OnlineTransactionBrowse.Text = "Browse";
            this.OnlineTransactionBrowse.UseVisualStyleBackColor = true;
            this.OnlineTransactionBrowse.Click += new System.EventHandler(this.OnlineTransactionBrowse_Click);
            // 
            // OnlineTransactionsLabel
            // 
            this.OnlineTransactionsLabel.AutoSize = true;
            this.OnlineTransactionsLabel.Location = new System.Drawing.Point(13, 38);
            this.OnlineTransactionsLabel.Name = "OnlineTransactionsLabel";
            this.OnlineTransactionsLabel.Size = new System.Drawing.Size(179, 25);
            this.OnlineTransactionsLabel.TabIndex = 4;
            this.OnlineTransactionsLabel.Text = "Online transactions";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.RefundTransactionsFilePathLabel);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.RefundTransactionsBrowse);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1513, 495);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Refund Transactions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(26, 100);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1463, 319);
            this.dataGridView2.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 9;
            // 
            // RefundTransactionsFilePathLabel
            // 
            this.RefundTransactionsFilePathLabel.AutoSize = true;
            this.RefundTransactionsFilePathLabel.Location = new System.Drawing.Point(307, 44);
            this.RefundTransactionsFilePathLabel.Name = "RefundTransactionsFilePathLabel";
            this.RefundTransactionsFilePathLabel.Size = new System.Drawing.Size(0, 25);
            this.RefundTransactionsFilePathLabel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 7;
            // 
            // RefundTransactionsBrowse
            // 
            this.RefundTransactionsBrowse.Location = new System.Drawing.Point(278, 35);
            this.RefundTransactionsBrowse.Name = "RefundTransactionsBrowse";
            this.RefundTransactionsBrowse.Size = new System.Drawing.Size(162, 47);
            this.RefundTransactionsBrowse.TabIndex = 6;
            this.RefundTransactionsBrowse.Text = "Browse";
            this.RefundTransactionsBrowse.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Refund transactions";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1404, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Next_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 820);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionPreviewGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BrowseTransactionFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label TransactionFilePathLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Next1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridView TransactionPreviewGrid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Next2;
        private System.Windows.Forms.Label OnlineTransactionsFilePathLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OnlineTransactionBrowse;
        private System.Windows.Forms.Label OnlineTransactionsLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label RefundTransactionsFilePathLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RefundTransactionsBrowse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
    }
}

