using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OkulAppBILL;

namespace OkulAppSube2BIL
{
    public partial class frmOgrKayit : Form
    {
        public frmOgrKayit()
        {
            InitializeComponent();
        }

       
        public void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();

               bool sonuc= obl.OgrenciKaydet(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme Başarılı" : "Ekleme Başarısız!!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha önce kaydedilmiş");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bilinmeyen Hata!!");
            }

        }
    }

    //class Test : ITest
    //{
    //    public void Metod1()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int Topla(int s1, int s2)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //interface ITest
    //{
    //    void Metod1();
    //    int Topla(int s1, int s2);
    //}

    class Transfer : TransferIslemleri
    {
        public int Eft(string gondereniban, string aliciiban, double tutar)
        {
            throw new NotImplementedException();
        }

        public int Havale(string gondereniban, string aliciiban, double tutar)
        {
            throw new NotImplementedException();
        }
    }
    interface TransferIslemleri
    {
        int Eft(string gondereniban, string aliciiban, double tutar);
        int Havale(string gondereniban, string aliciiban, double tutar);
    }

}