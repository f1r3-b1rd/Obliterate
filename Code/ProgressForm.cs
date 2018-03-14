using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obliterate
{
    public partial class ProgressForm : Form
    {
        public string Caption
        {
            set { this.Text = value; }
        }

        public int ProgressValue
        {
            set { pBar1.Value = value; }
        }
        
        public int ProgressMaximum
        {
            set { pBar1.Maximum = value; }
        }

        public ProgressForm()
        {
            InitializeComponent();
        }

        public void DoStep()
        {
            pBar1.PerformStep();
        }
    }
}
