﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms
{
    public partial class VMenu : Form
    {        
        public delegate void Deleg();
        public event Deleg Click; 
        public VMenu()
        {
            InitializeComponent();
        }

        private void VMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Click();
        }
    }
}
