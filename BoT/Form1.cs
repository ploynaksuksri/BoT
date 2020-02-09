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

        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                var t = _report.ReadTransactions(filePath);
                dataGridView1.DataSource = DataTableHelper.ConvertTo<Transaction>(t);
                dataGridView1.AutoGenerateColumns = true;
            }
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
            }
        }
    }
}
