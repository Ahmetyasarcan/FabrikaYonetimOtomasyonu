using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FabrikaOtomasyon
{
    public partial class ÖzelÜretimForm : Form
    {
        public ÖzelÜretimForm()
        {
            InitializeComponent();
        }

        private void ÖzelÜretimForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IletisimForm iletisimform = new IletisimForm();
            iletisimform.ShowDialog();
        }
    }
}
