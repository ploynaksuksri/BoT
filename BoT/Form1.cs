using BoT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoT.Business;
using BoT.Business.Managers;
using BoT.Business.Utilities;

namespace BoT
{
    public partial class Form1 : Form
    {
        private FileList _fileList = new FileList();
        private CodeConversionManager _codeConversionManager;
        private static int _currentTabIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(CodeConversionManager codeConversionManager)
        {
            InitializeComponent();
            _codeConversionManager = codeConversionManager;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BrowseTransactionFile_Click(object sender, EventArgs e)
        {
            _currentTabIndex = 0;
            DialogResult result = openFileDialog1.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                string filePath = openFileDialog1.FileName;
                TransactionFilePathLabel.Text = filePath;
                _fileList.MainFile = filePath;
                TransactionManager manager = new TransactionManager(_codeConversionManager);
                TransactionPreviewGrid.DataSource =  DataTableHelper.ConvertTo<Transaction>(manager.ReadReport(filePath).Take(10).ToList());
                TransactionPreviewGrid.AutoGenerateColumns = true;
            }
        }

        private void OnlineTransactionBrowse_Click(object sender, EventArgs e)
        {
            _currentTabIndex = 1;
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog2.FileName;
                OnlineTransactionsFilePathLabel.Text = filePath;
                _fileList.StatusFile = filePath;
                
        
            }
        }

        private void RefundTransactionsBrowse_Click(object sender, EventArgs e)
        {
            _currentTabIndex = 2;
            DialogResult result = openFileDialog3.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog3.FileName;
                RefundTransactionsFilePathLabel.Text = filePath;
                _fileList.RefundFile = filePath;
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = ++_currentTabIndex;
        }

        
    }
}
