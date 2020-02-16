using BoT.Business;
using BoT.Business.Utilities;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoT
{
    public partial class Form1 : Form
    {
        private ReportGenerator2 _report;

        public Form1()
        {
            InitializeComponent();
        }


        public Form1(ReportGenerator2 report)
        {
            InitializeComponent();
            _report = report;
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            var t = new List<Transaction>();
            await Task.Run(() =>
            {
                if (result == DialogResult.OK)
                {
                    var filePath = openFileDialog1.FileName;
                    t = _report.ReadTransactions(filePath);
                 
                }
            });
            dataGridView1.DataSource = DataTableHelper.ConvertTo<Transaction>(t);
            dataGridView1.AutoGenerateColumns = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filePath = openFileDialog2.FileName;
                var t = _report.GetOnlineTransactions(filePath);
                dataGridView2.DataSource = DataTableHelper.ConvertTo<OnlineTransaction>(t);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.AutoResizeColumns();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = openFileDialog3.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filePath = openFileDialog3.FileName;            
                var t = _report.GetRefundTransactions(filePath);
                dataGridView3.DataSource = DataTableHelper.ConvertTo<RefundTransaction>(t);
                dataGridView3.AutoGenerateColumns = true;
                dataGridView3.AutoResizeColumns();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _report.GenerateReport();
            MessageBox.Show($"Output file: {_report.OutputFilePath}", "Output");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = openFileDialog4.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filePath = openFileDialog4.FileName;
                var t = _report.GetAmazonTransactions(filePath);
                dataGridView4.DataSource = DataTableHelper.ConvertTo<AmazonFile>(t);
                dataGridView4.AutoGenerateColumns = true;
                dataGridView4.AutoResizeColumns();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = openFileDialog5.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filePath = openFileDialog5.FileName;
                var t = _report.GetComplianceList(filePath);
                //dataGridView4.DataSource = DataTableHelper.ConvertTo<Dictionary<string,string>>(t);
                dataGridView4.AutoGenerateColumns = true;
                dataGridView4.AutoResizeColumns();

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var result = openFileDialog6.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filePath = openFileDialog6.FileName;
                var t = _report.GetMonitoringTransactions(filePath);
                dataGridView6.DataSource = DataTableHelper.ConvertTo<MonitoringFile>(t);
                dataGridView6.AutoGenerateColumns = true;
                dataGridView6.AutoResizeColumns();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _report.Clear();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex--;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
