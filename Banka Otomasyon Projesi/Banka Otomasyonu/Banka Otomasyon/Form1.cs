using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banka_Otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "hsmbank" && txtSifre.Text == "admin")
            {
                txtKullaniciAdi.Clear();
                txtSifre.Clear();
                FrmHsmBank frmhb = new FrmHsmBank();
                frmhb.ShowDialog();
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Hatalı Giriş Yaptınız..!");
                txtSifre.Clear();
            }
        }

        

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
