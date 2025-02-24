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
    public partial class FabrikaForm : Form
    {
        public FabrikaForm()
        {
            InitializeComponent();
        }

        private void FabrikaForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnNigde_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NigdeForm nigdeform = new NigdeForm();
            nigdeform.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AfyonForm afyonForm = new AfyonForm();
            afyonForm.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdanaForm adanaform = new AdanaForm();
            adanaform.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MersinForm mersinform = new MersinForm();
            mersinform.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
