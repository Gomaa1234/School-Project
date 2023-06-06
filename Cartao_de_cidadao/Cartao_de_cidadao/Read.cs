using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cartao_de_cidadao
{
    public partial class Read : Form
    {
        public Read()
        {
            InitializeComponent();
        }
        private void btn_Read_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text + ".dat"))
            {
                Read_cc fm = new Read_cc();
                //fm.read = true;
                fm.id = textBox1.Text;
                this.Hide();
                fm.Show();
            }
            else
            {
                DialogResult res = MessageBox.Show("ID Civil não existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
        }
    }
}
