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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog fileP = new OpenFileDialog();
        public bool read = false;

        private void pbx_Image_Click(object sender, EventArgs e)
        {
            fileP.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            fileP.Title = "Selecione a sua imagem";
            if(fileP.ShowDialog() == DialogResult.OK)
            {
                pbx_Image.Image = Image.FromFile(fileP.FileName);
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream File_stream = new FileStream(txt_ID_Civil.Text + ".dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                string a = txt_Apelido.Text;
                string b = txt_Nome.Text;
                char c = Convert.ToChar(txt_Sexo.Text);
                float.TryParse(txt_Altura.Text, out float d);
                string f = txt_Nacionalidade.Text;

                DateTime tmd = new DateTime();
                tmd = DateTime.Parse(txt_Data_de_Nacimento.Text);
                Int64 g = tmd.Ticks;

                Image Imagem = pbx_Image.Image;
                MemoryStream memory = new MemoryStream();
                Imagem.Save(memory, Imagem.RawFormat);
                string base64 = Convert.ToBase64String(memory.ToArray());

                int h = int.Parse(txt_ID_Civil.Text);
                char i = Convert.ToChar(txt_Documento1.Text);
                string j = txt_Documento2.Text;

                DateTime tmv = new DateTime();
                tmv = DateTime.Parse(txt_Data_de_Validade.Text);
                Int64 k = tmv.Ticks;

                Image ImagemA = pcb_assinatura.Image;
                MemoryStream memoryA = new MemoryStream();
                ImagemA.Save(memoryA, ImagemA.RawFormat);
                string base64A = Convert.ToBase64String(memoryA.ToArray());

                string m = txt_Filiação.Text;
                long n = long.Parse(txt_Identificação_Fiscal.Text);
                long p = long.Parse(txt_NºSegurança_Social.Text);
                long q = long.Parse(txt_NºUtente_de_Saude.Text);
                string r = txt_.Text;

                a = a.ToUpper();
                b = b.ToUpper();
                f = f.ToUpper();
                j = j.ToUpper();
                m = m.ToUpper();
                r = r.ToUpper();

                using (BinaryWriter sWriter = new BinaryWriter(File_stream))
                {
                    sWriter.Write(a);
                    sWriter.Write(b);
                    sWriter.Write(c);
                    sWriter.Write(d);
                    sWriter.Write(f);
                    sWriter.Write(g);

                    sWriter.Write(base64);
                    sWriter.Write(h);
                    sWriter.Write(i);
                    sWriter.Write(j);
                    sWriter.Write(k);

                    sWriter.Write(base64A);
                    sWriter.Write(m);
                    sWriter.Write(n);
                    sWriter.Write(p);
                    sWriter.Write(q);
                    sWriter.Write(r);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A um dado incorreto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Ler_Click(object sender, EventArgs e)
        {
            Read rd = new Read();
            rd.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pcb_assinatura_Click(object sender, EventArgs e)
        {
            
            fileP.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            fileP.Title = "Selecione a sua imagem";
            if (fileP.ShowDialog() == DialogResult.OK)
            {
                pcb_assinatura.Image = Image.FromFile(fileP.FileName);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
