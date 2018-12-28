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
    public partial class FrmHsmBank : Form
    {
        public long bireyselNo = 100000;
        public long bireyselHesapNo = 5000000;
        public long ticariNo = 300000;
        public long ticariHesapNo = 7000000;
        public int q = 0;
        public decimal ToplamTutar = 0;
        public Banka banka;
        public FrmHsmBank()
        {
            banka = new Banka();
            InitializeComponent();
        }
        public int TCKontrol()
        {
            int tckontrol = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtTCKimlikNo.Text))
                {
                    tckontrol++;
                }
            }
            return tckontrol;
        }
        public void BuyukHarf(Musteri m)
        {
            m.kimlikBilgisi.AdSoyad = m.kimlikBilgisi.Ad.ToUpper() + " " + m.kimlikBilgisi.Soyad.ToUpper();
        }

        private void btnHesapKapatmaKapat_Click(object sender, EventArgs e)
        {

        }

        private void btnHesapKapatmaIptal_Click(object sender, EventArgs e)
        {

        }
        public decimal ToplamKasa = 0;
        private void FrmHsmBank_Load(object sender, EventArgs e)
        {
            rdoBireysel.Checked = true;
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnMusteriKaydet_Click(object sender, EventArgs e)
        {
            Hesap hesap = new Hesap();
            if (TCKontrol() == 0)
            {
                if (rdoBireysel.Checked == true)
                {
                    BireyselMusteri bireysel = new BireyselMusteri();
                    bireysel.kimlikBilgisi.TCKimlikNo = Convert.ToInt64(txtTCKimlikNo.Text);
                    bireysel.kimlikBilgisi.Ad = txtAd.Text;
                    bireysel.kimlikBilgisi.Soyad = txtSoyad.Text;
                    bireysel.kimlikBilgisi.DogumYeri = txtDogumYeri.Text;
                    bireysel.kimlikBilgisi.Cinsiyet = cmbCinsiyet.Text;
                    bireysel.MusteriValidasyon();
                    BuyukHarf(bireysel);
                    if (bireysel.k == 0)
                    {
                        bireysel.MusteriNo = bireyselNo;
                        bireyselNo++;
                        hesap.HesapNo = bireyselHesapNo;
                        bireyselHesapNo++;
                        hesap.Bakiye = 0;
                        bireysel.HesapEkle(hesap);
                        banka.MusteriEkle(bireysel);
                        MessageBox.Show("Müşteri No: " + bireysel.MusteriNo + "\nHesap No: " + hesap.HesapNo + "\nTC Kimlik No: " + bireysel.kimlikBilgisi.TCKimlikNo + "\nAd Soyad: " + bireysel.kimlikBilgisi.AdSoyad + "\nDoğum Yeri: " + bireysel.kimlikBilgisi.DogumYeri + "\nCinsiyet: " + bireysel.kimlikBilgisi.Cinsiyet + "\nMüşteri Tipi: " + bireysel.MusteriTipi + "\n\n\nMüşteri Başarıyla Kaydedildi ve Hesap Oluşturuldu");
                        txtAd.Clear();
                        txtDogumYeri.Clear();
                        txtSoyad.Clear();
                        txtTCKimlikNo.Text = "0";
                        cmbCinsiyet.Text = "";
                        rdoBireysel.Checked = true;
                        rdoTicari.Checked = false;
                        dataGridView2.Rows.Add(bireysel.MusteriNo, bireysel.kimlikBilgisi.TCKimlikNo, bireysel.kimlikBilgisi.AdSoyad, bireysel.kimlikBilgisi.DogumYeri, bireysel.kimlikBilgisi.Cinsiyet, bireysel.MusteriTipi);
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                        MessageBox.Show(bireysel.MusteriValidasyon());
                    }
                }
                if (rdoTicari.Checked == true)
                {
                    TicariMusteri ticari = new TicariMusteri();
                    ticari.kimlikBilgisi.TCKimlikNo = Convert.ToInt64(txtTCKimlikNo.Text);
                    ticari.kimlikBilgisi.Ad = txtAd.Text;
                    ticari.kimlikBilgisi.Soyad = txtSoyad.Text;
                    ticari.kimlikBilgisi.DogumYeri = txtDogumYeri.Text;
                    ticari.kimlikBilgisi.Cinsiyet = cmbCinsiyet.Text;
                    ticari.MusteriValidasyon();
                    BuyukHarf(ticari);
                    if (ticari.k == 0)
                    {
                        ticari.MusteriNo = ticariNo;
                        ticariNo++;
                        hesap.HesapNo = ticariHesapNo;
                        ticariHesapNo++;
                        hesap.Bakiye = 0;
                        ticari.HesapEkle(hesap);
                        banka.MusteriEkle(ticari);
                        MessageBox.Show("Müşteri No: " + ticari.MusteriNo + "\nHesap No: " + hesap.HesapNo + "\nTC Kimlik No: " + ticari.kimlikBilgisi.TCKimlikNo + "\nAd Soyad: " + ticari.kimlikBilgisi.AdSoyad + "\nDoğum Yeri: " + ticari.kimlikBilgisi.DogumYeri + "\nCinsiyet: " + ticari.kimlikBilgisi.Cinsiyet + "\nMüşteri Tipi: " + ticari.MusteriTipi + "\n\n\nMüşteri Başarıyla Kaydedildi ve Hesap Oluşturuldu");
                        txtAd.Clear();
                        txtDogumYeri.Clear();
                        txtSoyad.Clear();
                        txtTCKimlikNo.Text = "0";
                        cmbCinsiyet.Text = "";
                        rdoBireysel.Checked = true;
                        rdoTicari.Checked = false;
                        dataGridView2.Rows.Add(ticari.MusteriNo, ticari.kimlikBilgisi.TCKimlikNo, ticari.kimlikBilgisi.AdSoyad, ticari.kimlikBilgisi.DogumYeri, ticari.kimlikBilgisi.Cinsiyet, ticari.MusteriTipi);
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                        MessageBox.Show(ticari.MusteriValidasyon());
                    }
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Bu TC Kimlik No Zaten Bir Müşterimize Aittir");

            }
        }

        private void btnHesapEkle_Click(object sender, EventArgs e)
        {
            Hesap h = new Hesap();
            q = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (Convert.ToInt64(txtHesapEkleTC.Text) == m.kimlikBilgisi.TCKimlikNo)
                {
                    if (m.MusteriTipi == "Ticari")
                    {
                        h.Bakiye = 0;
                        h.HesapNo = ticariHesapNo;
                        ticariHesapNo++;
                        m.HesapEkle(h);
                        MessageBox.Show("Hesap No: " + h.HesapNo + "\n\nHesap Başarıyla Eklendi");
                        q++;
                    }
                    if (m.MusteriTipi == "Bireysel")
                    {
                        h.Bakiye = 0;
                        h.HesapNo = bireyselHesapNo;
                        bireyselHesapNo++;
                        m.HesapEkle(h);
                        MessageBox.Show("Hesap No: " + h.HesapNo + "\n\nHesap Başarıyla Eklendi");
                        q++;
                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Müşteri Bulunamadı");
            }
            txtHesapEkleTC.Text = "0";
        }

        private void btnParaYatirma_Click(object sender, EventArgs e)
        {
            IslemBilgisi isb = new IslemBilgisi();
            q = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtParaYatirmaTC.Text))
                {
                    foreach (Hesap h in m.Hesaplar)
                    {
                        if (h.HesapNo == Convert.ToInt64(cmbParaYatırmaHesapNo.Text))
                        {
                            q++;
                            if (Convert.ToDecimal(txtParaYatirmaTutar.Text) > 0)
                            {
                                isb.IslemTarihi = DateTime.Now.Date;
                                isb.Tutar = Convert.ToDecimal(txtParaYatirmaTutar.Text);
                                h.ParaYatir(isb);
                                MessageBox.Show("Para Yatırma Başarıyla Gerçekleşmiştir" + "\n\nGüncel Bakiye: " + h.Bakiye);
                                cmbParaYatırmaHesapNo.Items.Clear();
                                txtParaYatirmaTC.Text = "0";
                                cmbParaYatırmaHesapNo.Text = "0";
                                txtParaYatirmaTutar.Text = "0";
                                dataGridView1.Rows.Add(isb.IslemTarihi.ToShortDateString(), h.HesapNo, isb.Detay, isb.Tutar, 0);
                                ToplamKasa += isb.Tutar;
                                lblKasa.Text = ToplamKasa.ToString();
                            }
                            else
                            {
                                System.Media.SystemSounds.Beep.Play();
                                MessageBox.Show("Geçerli Tutar Giriniz");
                            }

                        }

                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("TC Kimlik No veya Hesap Numarasını Yanlış Girdiniz");
            }
        }

        private void btnParaYatırmaSorgula_Click(object sender, EventArgs e)
        {
            cmbParaYatırmaHesapNo.Items.Clear();
            q = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtParaYatirmaTC.Text))
                {
                    q++;
                    foreach (Hesap h in m.Hesaplar)
                    {
                        cmbParaYatırmaHesapNo.Items.Add(h.HesapNo);
                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Yanlış TC Girdiniz");
            }
        }

        private void btnParaCekmeCek_Click(object sender, EventArgs e)
        {
            ToplamTutar = 0;
            q = 0;
            IslemBilgisi islembilgisi = new IslemBilgisi();
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtParaCekmeTC.Text))
                {
                    foreach (Hesap h in m.Hesaplar)
                    {
                        if (h.HesapNo == Convert.ToInt64(cmbParaCekmeHesapNo.Text))
                        {
                            q++;
                            if (Convert.ToDecimal(txtParaCekmeTutar.Text) > 0 && Convert.ToDecimal(txtParaCekmeTutar.Text) <= h.Bakiye && Convert.ToDecimal(txtParaCekmeTutar.Text) <= 750)
                            {
                                islembilgisi.IslemTarihi = DateTime.Now.Date;
                                islembilgisi.Tutar = 0;
                                h.ParaCek(islembilgisi);
                                foreach (IslemBilgisi ib in h.IslemBilgileri)
                                {
                                    if (ib.Detay == "Para Çekme" && DateTime.Compare(ib.IslemTarihi, islembilgisi.IslemTarihi) == 0)
                                    {
                                        h.Iptal(islembilgisi);
                                        if (ib.Tutar == 0)
                                        {
                                            ib.GunlukParaCekme = 0;
                                        }
                                        ToplamTutar += ib.GunlukParaCekme;
                                        ToplamTutar += Convert.ToDecimal(txtParaCekmeTutar.Text);
                                        if (ToplamTutar <= 750)
                                        {
                                            ib.IslemTarihi = DateTime.Now.Date;
                                            ib.Tutar = Convert.ToDecimal(txtParaCekmeTutar.Text);
                                            ib.GunlukParaCekme += Convert.ToDecimal(txtParaCekmeTutar.Text);
                                            h.ParaCek(ib);
                                            MessageBox.Show(ib.Tutar + " TL Para Çekme İşlemi Başarıyla Gerçekleşmiştir\nGüncel Bakiye:" + h.Bakiye);
                                            dataGridView1.Rows.Add(ib.IslemTarihi.ToShortDateString(), h.HesapNo, ib.Detay, -ib.Tutar, 0);
                                            ToplamKasa -= ib.Tutar;
                                            lblKasa.Text = ToplamKasa.ToString();
                                            cmbParaCekmeHesapNo.Items.Clear();
                                            txtParaCekmeTC.Text = "0";
                                            cmbParaCekmeHesapNo.Text = "0";
                                            txtParaCekmeTutar.Text = "0";
                                            break;
                                        }
                                        else
                                        {
                                            ToplamTutar -= Convert.ToDecimal(txtParaCekmeTutar.Text);
                                            System.Media.SystemSounds.Beep.Play();
                                            MessageBox.Show("Günlük Çekme Tutarınızı Geçtiniz");
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                System.Media.SystemSounds.Beep.Play();
                                MessageBox.Show("Geçerli Tutar Giriniz");
                            }

                        }

                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("TC Kimlik No veya Hesap Numarasını Yanlış Girdiniz");
            }
        }

        private void btnParaCekmeSorgula_Click(object sender, EventArgs e)
        {
            cmbParaCekmeHesapNo.Items.Clear();
            q = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtParaCekmeTC.Text))
                {
                    q++;
                    foreach (Hesap h in m.Hesaplar)
                    {
                        cmbParaCekmeHesapNo.Items.Add(h.HesapNo);
                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Yanlış TC Girdiniz");
            }
        }

        private void btnParaTransferGSorgula_Click(object sender, EventArgs e)
        {
            cmbParaTransferGHesapNo.Items.Clear();
            q = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtParaTransferGTC.Text))
                {
                    q++;
                    foreach (Hesap h in m.Hesaplar)
                    {
                        cmbParaTransferGHesapNo.Items.Add(h.HesapNo);
                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Yanlış TC Girdiniz");
            }
        }

        private void btnParaTransferASorgula_Click(object sender, EventArgs e)
        {
            cmbParaTransferAHesapNo.Items.Clear();
            q = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtParaTransferiATC.Text))
                {
                    q++;
                    foreach (Hesap h in m.Hesaplar)
                    {
                        cmbParaTransferAHesapNo.Items.Add(h.HesapNo);
                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Yanlış TC Girdiniz");
            }
        }

        private void btnParaTransferGonder_Click(object sender, EventArgs e)
        {
            IslemBilgisi isb = new IslemBilgisi();
            IslemBilgisi isb2 = new IslemBilgisi();
            q = 0;
            if (cmbParaTransferAHesapNo.Text != cmbParaTransferGHesapNo.Text)
            {
                foreach (Musteri b in banka.Musteriler)
                {
                    if (b.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtParaTransferGTC.Text))
                    {
                        foreach (Hesap h in b.Hesaplar)
                        {
                            if (h.HesapNo == Convert.ToInt64(cmbParaTransferGHesapNo.Text))
                            {
                                foreach (Musteri m in banka.Musteriler)
                                {
                                    if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtParaTransferiATC.Text))
                                    {
                                        foreach (Hesap hesap in m.Hesaplar)
                                        {
                                            if (hesap.HesapNo == Convert.ToInt64(cmbParaTransferAHesapNo.Text))
                                            {
                                                if (b.MusteriTipi == "Bireysel")
                                                {
                                                    q++;

                                                    isb.Tutar = Convert.ToDecimal(txtParaTransferTutar.Text);
                                                    isb.TransferUcreti = b.HavaleYap(isb.Tutar);
                                                    if (h.Bakiye >= (isb.TransferUcreti + isb.Tutar))
                                                    {
                                                        isb2.TransferUcreti = -isb.TransferUcreti;
                                                        isb2.Tutar = Convert.ToDecimal(txtParaTransferTutar.Text);
                                                        isb2.IslemTarihi = DateTime.Now.Date;
                                                        isb2.HesapNo = Convert.ToInt64(cmbParaTransferAHesapNo.Text);
                                                        isb2.Detay = isb2.HesapNo + " Nolu Hesaba Giden Transfer";
                                                        h.ParaTranserYap(isb2);
                                                        dataGridView1.Rows.Add(isb2.IslemTarihi.ToShortDateString(), h.HesapNo, isb2.Detay, -isb2.Tutar, -isb2.TransferUcreti);
                                                        isb.IslemTarihi = DateTime.Now.Date;
                                                        h.Bakiye -= isb.Tutar;
                                                        h.Bakiye -= isb.TransferUcreti;
                                                        hesap.Bakiye += isb.Tutar;
                                                        isb.TransferUcreti = 0;
                                                        isb.HesapNo = Convert.ToInt64(cmbParaTransferGHesapNo.Text);
                                                        isb.Detay = isb.HesapNo + " Nolu Hesaptan Gelen Transfer";
                                                        hesap.ParaTranserYap(isb);
                                                        dataGridView1.Rows.Add(isb.IslemTarihi.ToShortDateString(), hesap.HesapNo, isb.Detay, +isb.Tutar, 0);
                                                        
                                                        MessageBox.Show(-isb2.TransferUcreti + " Tl Transfer Ücreti Kesilmiştir\n" + isb.Tutar + " TL Para Transferi Başarıyla Tamamlanmıştır\nGüncel Bakiyeniz: " + h.Bakiye);
                                                        cmbParaTransferAHesapNo.Items.Clear();
                                                        cmbParaTransferGHesapNo.Items.Clear();
                                                        cmbParaTransferAHesapNo.Text = "0";
                                                        txtParaTransferiATC.Text = "0";
                                                        txtParaTransferGTC.Text = "0";
                                                        cmbParaTransferGHesapNo.Text = "0";
                                                        txtParaTransferTutar.Text = "0";
                                                        ToplamKasa -= isb2.TransferUcreti;
                                                        lblKasa.Text = ToplamKasa.ToString();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        System.Media.SystemSounds.Beep.Play();
                                                        MessageBox.Show("Yetersiz Bakiye");
                                                    }
                                                }
                                                if (b.MusteriTipi == "Ticari")
                                                {
                                                    q++;
                                                    isb.IslemTarihi = DateTime.Now.Date;
                                                    isb.Tutar = Convert.ToDecimal(txtParaTransferTutar.Text);

                                                    if (h.Bakiye >= isb.Tutar)
                                                    {
                                                        isb2.IslemTarihi = DateTime.Now.Date;
                                                        isb2.HesapNo = Convert.ToInt64(cmbParaTransferAHesapNo.Text);
                                                        isb2.Detay = isb2.HesapNo + " Nolu Hesaba Giden Transfer";
                                                        isb2.Tutar = Convert.ToDecimal(txtParaTransferTutar.Text);
                                                        h.ParaTranserYap(isb2);
                                                        dataGridView1.Rows.Add(isb2.IslemTarihi.ToShortDateString(), h.HesapNo, isb2.Detay, -isb2.Tutar, 0);
                                                        isb.HesapNo = Convert.ToInt64(cmbParaTransferGHesapNo.Text);
                                                        isb.Detay = isb.HesapNo + " Nolu Hesaptan Gelen Transfer";
                                                        hesap.ParaTranserYap(isb);
                                                        dataGridView1.Rows.Add(isb.IslemTarihi.ToShortDateString(), hesap.HesapNo, isb.Detay, +isb.Tutar, 0);
                                                        h.Bakiye -= isb.Tutar;
                                                        hesap.Bakiye += isb.Tutar;
                                                        MessageBox.Show(isb.Tutar + " TL Para Transferi Başarıyla Tamamlanmıştır\nGüncel Bakiyeniz: " + h.Bakiye);
                                                        cmbParaTransferAHesapNo.Items.Clear();
                                                        cmbParaTransferGHesapNo.Items.Clear();
                                                        cmbParaTransferAHesapNo.Text = "0";
                                                        txtParaTransferiATC.Text = "0";
                                                        txtParaTransferGTC.Text = "0";
                                                        cmbParaTransferGHesapNo.Text = "0";
                                                        txtParaTransferTutar.Text = "0";
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        System.Media.SystemSounds.Beep.Play();
                                                        MessageBox.Show("Yetersiz Bakiye");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Hesap Numaraları Aynı Tekrar Deneyiniz..!");
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Girilen Bilgiler Hatalı Lütfen Tekrar Deneyiniz");
            }
        }

        private void btnHesapKapatmaSorgula_Click(object sender, EventArgs e)
        {
            cmbHesapKapatmaHesapNo.Items.Clear();
            q = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtHesapKapatmaTC.Text))
                {
                    q++;
                    foreach (Hesap h in m.Hesaplar)
                    {
                        cmbHesapKapatmaHesapNo.Items.Add(h.HesapNo);
                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Yanlış TC Girdiniz");
            }
        }

        private void btnHesapKapatmaKapat_Click_1(object sender, EventArgs e)
        {
            q = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtHesapKapatmaTC.Text))
                {
                    foreach (Hesap h in m.Hesaplar)
                    {
                        if (h.HesapNo == Convert.ToInt64(cmbHesapKapatmaHesapNo.Text))
                        {
                            q++;
                            if (h.Bakiye == 0)
                            {
                                m.HesapKapat(h);
                                MessageBox.Show("Hesap Başarıyla Kapatıldı");
                                cmbHesapKapatmaHesapNo.Text = "0";
                                cmbHesapKapatmaHesapNo.Items.Clear();
                                txtHesapKapatmaTC.Text = "0";
                                break;
                            }
                            else
                            {
                                System.Media.SystemSounds.Beep.Play();
                                MessageBox.Show("Hesabı Kapatabilmeniz İçin Bakiyeniz 0 TL Olmalıdır\nMevcut Bakiye: " + h.Bakiye);
                            }
                        }
                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Hesap Bulunamadı");
            }
        }

        private void btnHesapOzetiListele_Click(object sender, EventArgs e)
        {
            btnHesapOzetiListele.Enabled = false;
            DateTime tarih1 = new DateTime();
            DateTime tarih2 = new DateTime();
            tarih1 = Convert.ToDateTime(txtTarih1.Text);
            tarih2 = Convert.ToDateTime(txtTarih2.Text);
            int sayac = 0;
            sayac = listView1.Items.Count;
            foreach(Musteri m in banka.Musteriler)
            {
                if (Convert.ToInt64(txtHesapOzetiTC.Text) == m.kimlikBilgisi.TCKimlikNo)
                {
                    foreach(Hesap h in m.Hesaplar)
                    {
                        if (Convert.ToInt64(cmbHesapOzetiHesapNo.Text) == h.HesapNo)
                        {
                            foreach(IslemBilgisi i in h.IslemBilgileri)
                            {
                                if(DateTime.Compare(tarih1, i.IslemTarihi)<=0 && DateTime.Compare(i.IslemTarihi, tarih2) <= 0)
                                {
                                    lblAdSoyad.Text = m.kimlikBilgisi.AdSoyad;
                                    lblBakiye.Text = h.Bakiye.ToString();
                                    lblHesapNo.Text = h.HesapNo.ToString();
                                    lblTC.Text = m.kimlikBilgisi.TCKimlikNo.ToString();
                                    lblTarihAraligi.Text = tarih1.ToShortDateString() + " / " + tarih2.ToShortDateString();
                                    listView1.Items.Add(i.IslemTarihi.ToShortDateString());
                                    listView1.Items[sayac].SubItems.Add(i.Detay);
                                    listView1.Items[sayac].SubItems.Add(i.Tutar.ToString());
                                    listView1.Items[sayac].SubItems.Add(i.TransferUcreti.ToString());
                                    sayac++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbHesapOzetiHesapNo.Items.Clear();
            q = 0;
            foreach (Musteri m in banka.Musteriler)
            {
                if (m.kimlikBilgisi.TCKimlikNo == Convert.ToInt64(txtHesapOzetiTC.Text))
                {
                    q++;
                    foreach (Hesap h in m.Hesaplar)
                    {
                        cmbHesapOzetiHesapNo.Items.Add(h.HesapNo);
                    }
                }
            }
            if (q == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Yanlış TC Girdiniz");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
            lblSaat.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;


        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtTCKimlikNo.Text = "0";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtDogumYeri.Text = "";
            cmbCinsiyet.Text = "";
            rdoBireysel.Checked = true;
        }

        private void btnParaYatirmaTemizle_Click(object sender, EventArgs e)
        {
            txtParaYatirmaTC.Text = "0";
            txtParaYatirmaTutar.Text = "0";
            cmbParaYatırmaHesapNo.Items.Clear();
            cmbParaYatırmaHesapNo.Text = "0";
        }

        private void btnParaCekTemizle_Click(object sender, EventArgs e)
        {
            txtParaCekmeTC.Text = "0";
            txtParaCekmeTutar.Text = "0";
            cmbParaCekmeHesapNo.Items.Clear();
            cmbParaCekmeHesapNo.Text = "0";
        }

        private void btnParaTransferTemizle_Click(object sender, EventArgs e)
        {
            txtParaTransferGTC.Text = "0";
            txtParaTransferiATC.Text = "0";
            txtParaTransferTutar.Text = "0";
            cmbParaTransferAHesapNo.Items.Clear();
            cmbParaTransferGHesapNo.Items.Clear();
            cmbParaTransferGHesapNo.Text = "0";
            cmbParaTransferAHesapNo.Text = "0";

        }

        private void btnHesapKapatmaTemizle_Click(object sender, EventArgs e)
        {
            txtHesapKapatmaTC.Text = "0";
            cmbHesapKapatmaHesapNo.Items.Clear();
            cmbHesapKapatmaHesapNo.Text = "0";
        }

        private void btnHesapOzetiTemizle_Click(object sender, EventArgs e)
        {
            lblAdSoyad.Text ="";
            lblBakiye.Text = "0";
            lblHesapNo.Text = "";
            lblTC.Text = "";
            lblTarihAraligi.Text ="";
            txtHesapOzetiTC.Text = "0";
            cmbHesapOzetiHesapNo.Items.Clear();
            cmbHesapOzetiHesapNo.Text = "0";
            txtTarih1.Text = "0";
            txtTarih2.Text = "0";
            listView1.Items.Clear();
            listView1.View = View.Details;
            btnHesapOzetiListele.Enabled = true;
        }
    }
}
