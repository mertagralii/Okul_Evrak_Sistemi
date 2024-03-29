﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Evrak_Sistemi
{
    public partial class FrmMemur : Form
    {
        private void getdata()
        {
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblEvrak Where EmanetVerildi=0", bgl);
            da.Fill(dt);
            DTTablo.DataSource = dt;
        }
        public FrmMemur()
        {
            InitializeComponent();
        }
        public string Mkullanici;
        private int SeciliEvrak;

        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=OgrenciEvrak;Integrated Security=True");

        private void button4_Click(object sender, EventArgs e)
        {
            FrmEmanetListesi emntlist = new FrmEmanetListesi();
            emntlist.Show();

        }

        private void FrmMemur_Load(object sender, EventArgs e)
        {
            DTTablo.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLMemur Where KullaniciAdi=@P1", bgl);
            komut.Parameters.AddWithValue("@P1", Mkullanici);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label5.Text = dr[4].ToString();
                label6.Text = dr[5].ToString();
                label7.Text = dr[6].ToString();
            }
            bgl.Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TblEvrak WHERE EmanetVerildi = 0", bgl);
            da.Fill(dt);
            DTTablo.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Update TBLMemur Set Sifre =@P1 Where KullaniciAdi=@P2", bgl);
            komut2.Parameters.AddWithValue("@P2", Mkullanici);
            komut2.Parameters.AddWithValue("@P1", textBox2.Text);
            komut2.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Şifreniz Değiştirildi.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int İD = Convert.ToInt32(DTTablo.SelectedRows[0].Cells[0].Value);

            bgl.Open();
            SqlCommand komut3 = new SqlCommand("Update TBLEvrak Set TeslimAlan=@P1,TeslimEden=@P2,TeslimEdenTC=@P3,EvrakDepartman=@P4, TeslimEdilecekTarih =@P5 Where İD =@P6", bgl);
            komut3.Parameters.AddWithValue("@P1", TxtTeslimAlan.Text);
            komut3.Parameters.AddWithValue("@P2", TxtTeslimEden.Text);
            komut3.Parameters.AddWithValue("@P3", MskTeslimEdenTC.Text);
            komut3.Parameters.AddWithValue("@P4", CmbEvrakDepartman.Text);
            komut3.Parameters.AddWithValue("@P5",dateTimePicker1.Value);
            komut3.Parameters.AddWithValue("P6", İD);
            komut3.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Evrak Ekleme işlemi gerçekleştirildi.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            getdata();
        }

        private void BtnEvrakYeriGüncelle_Click(object sender, EventArgs e)
        {
            int İD = Convert.ToInt32(DTTablo.SelectedRows[0].Cells[0].Value);
            bgl.Open();
            SqlCommand güncelleme = new SqlCommand("Update TBLEvrak Set EvrakTürü=@P1,EvrakNO=@P2 Where İD =@P3", bgl); 
            güncelleme.Parameters.AddWithValue("@P1", CmbEvrakYeri.Text);
            güncelleme.Parameters.AddWithValue("@P2", TxtEvrakNO.Text);
            güncelleme.Parameters.AddWithValue("@P3", İD); 
            güncelleme.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Evrak Güncelleme işlemi Gerçekleştirildi.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            getdata() ;

        }

        private void BtnEmanetListesi_Click(object sender, EventArgs e)
        {
            FrmEmanetListesi fr = new FrmEmanetListesi();
            fr.Show();
        }

        private void DTTablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int SecilenSatir = DTTablo.SelectedCells[0].RowIndex;

            SeciliEvrak = Convert.ToInt32(DTTablo.Rows[SecilenSatir].Cells[0].Value);
        }

        private void BtnEmanetVer_Click(object sender, EventArgs e)
        {
            //secilievrak içerisindeki id değerine göre update işlemi yapılacak
            bgl.Open();
            SqlCommand komut = new SqlCommand("Update TBLEvrak set EmanetVerildi = 1  Where İD=@P2", bgl);
            komut.Parameters.AddWithValue("@P2", SeciliEvrak);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Evrak Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            getdata() ;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ArsivYönetimSistemi frm = new ArsivYönetimSistemi();
            frm.Show();
            this.Hide();
        }
    }
}
