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
    public partial class Read_cc : Form
    {
        public Read_cc()
        {
            InitializeComponent();
        }
        public string id = "";

        private void Read_cc_Load(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader sRead = new BinaryReader(File.Open(id + ".dat", FileMode.Open)))
                {
                    label1.Text = sRead.ReadString();
                    label2.Text = sRead.ReadString();
                    label3.Text = sRead.ReadChar().ToString();
                    label4.Text = sRead.ReadSingle().ToString();
                    label5.Text = sRead.ReadString();
                    Int64 t = sRead.ReadInt64();
                    DateTime tm = new DateTime(t);
                    label6.Text = tm.ToShortDateString();
                    MemoryStream memory = new MemoryStream(Convert.FromBase64String(sRead.ReadString()));
                    Image result = Image.FromStream(memory);
                    memory.Close();
                    pbx_image.Image = result;
                    label7.Text = sRead.ReadInt32().ToString();
                    label8.Text = sRead.ReadChar().ToString();
                    label9.Text = sRead.ReadString();
                    Int64 tv = sRead.ReadInt64();
                    DateTime tmv = new DateTime(tv);
                    label10.Text = tmv.ToShortDateString();
                    MemoryStream memoryA = new MemoryStream(Convert.FromBase64String(sRead.ReadString()));
                    Image resultA = Image.FromStream(memoryA);
                    memoryA.Close();
                    pbx_assinatura.Image = resultA;
                    label11.Text = "";
                    string a = sRead.ReadString();
                    int ip = 0;
                    for(int i = 0; i < a.Length;i++)
                    {
                        label11.Text += a[i];
                        if (a[i] == ' ')
                        {
                            ip++;
                            
                        }
                        if (ip == 7)
                        {
                            ip = 0;
                            label11.Text += "\n";
                        }
                    }
                    label12.Text = sRead.ReadInt64().ToString();
                    label13.Text = sRead.ReadInt64().ToString();
                    label14.Text = sRead.ReadInt64().ToString();
                    label15.Text = "";
                    string b = sRead.ReadString();
                    int id = 1;
                    for (int i = 0; i < b.Length; i++)
                    {
                        label15.Text += b[i];
                        if (i ==50*id-1)
                        {
                            id++;
                            label15.Text += "\n";
                        }
                    }
                }
                id = "";
            }
            catch (Exception ex)
            {
                
                DialogResult res =  MessageBox.Show("erro na leitora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(res == DialogResult.OK)
                {
                    this.Hide();
                    Read fm = new Read();
                    
                    fm.Show();
                }
            }
        }

        private void Read_cc_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
