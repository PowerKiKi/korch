using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace korch
{
    public partial class Form1 : Form
    {
        Translator translator = new Translator();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "nothing";
            this.label1.Text = this.translator.Full;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            foreach (string s in this.textBox1.Text.Split(' '))
            {
                if (s == "") continue;
                this.textBox2.Text += this.translator.mixedTranslation(s) +" ";
            }
        }
    }
}