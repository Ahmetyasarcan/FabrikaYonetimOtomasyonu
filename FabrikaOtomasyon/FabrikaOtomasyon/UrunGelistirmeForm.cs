﻿using System;
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
    public partial class UrunGelistirmeForm : Form
    {
        public UrunGelistirmeForm()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IletisimForm iletisimform = new IletisimForm();
            iletisimform.ShowDialog();
        }

        private void UrunGelistirmeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
