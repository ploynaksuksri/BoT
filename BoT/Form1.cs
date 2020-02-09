using BoT.Business;
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
    }
}
