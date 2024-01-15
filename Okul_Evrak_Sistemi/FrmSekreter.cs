using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Evrak_Sistemi
{
    public partial class FrmSekreter : Form
    {
        private void getdata()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblEvrak", bgl);
            da.Fill(dt);
            DTTablo2.DataSource = dt;
        }
        public FrmSekreter()
        {
            InitializeComponent();
            
        }
        public string Skullanici;
        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=OgrenciEvrak;Integrated Security=True");

        private void FrmSekreter_Load(object sender, EventArgs e)
        {
            DTTablo2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLSekreter Where KullaniciAdi=@P1", bgl);
            komut.Parameters.AddWithValue("@P1", Skullanici);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                label10.Text = dr[3].ToString();
                label11.Text = dr[4].ToString();
                label9.Text = dr[5].ToString();
            }
            bgl.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLEvrak", bgl);
            da.Fill(dt);
            DTTablo2.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Update TBLSekreter Set Sifre=@P1 Where KullaniciAdi=@P2", bgl);
            komut2.Parameters.AddWithValue("@P2", Skullanici);
            komut2.Parameters.AddWithValue("@P1", textBox5.Text);
            komut2.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Şifreniz Değiştirildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMemurİslemleri frm = new FrmMemurİslemleri();
            frm.Show();

        }

        private void BtnEvrakTürüEkle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            int İD = Convert.ToInt32(DTTablo2.SelectedRows[0].Cells[0].Value);
            SqlCommand EvrakTürEkleme = new SqlCommand("UPDATE TBLEvrak SET EvrakTürü = @P1, EvrakNO = @P2 WHERE İD = @P3", bgl);
            EvrakTürEkleme.Parameters.AddWithValue("@P1", CmbEvrakTürü.Text);
            EvrakTürEkleme.Parameters.AddWithValue("@P2", TxtEvrakNo.Text);
            EvrakTürEkleme.Parameters.AddWithValue("@P3", İD);
            EvrakTürEkleme.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Evrak Türü Ekleme İşlemi Başarıyla Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            getdata();
        }

        private void BtnEvrakSil_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand evraksil = new SqlCommand("Delete From TBLEvrak Where EvrakNO =@P1", bgl);
            evraksil.Parameters.AddWithValue("@P1", TxtEvrakNo2.Text);
            evraksil.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Silme İşlemi Gerçekleştirildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
        }

        private void BtnEvrakEkle_Click(object sender, EventArgs e)
        {
           
                int İD = Convert.ToInt32(DTTablo2.SelectedRows[0].Cells[0].Value);

                bgl.Open();
                SqlCommand komut3 = new SqlCommand("Update TBLEvrak Set TeslimAlan=@P1,TeslimEden=@P2,TeslimEdenTC=@P3,EvrakDepartman=@P4, TeslimEdilecekTarih =@P5 Where İD =@P6", bgl);
                komut3.Parameters.AddWithValue("@P1", TxtTeslimAlan.Text);
                komut3.Parameters.AddWithValue("@P2", TxtTeslimEden.Text);
                komut3.Parameters.AddWithValue("@P3", MskTeslimEdenTC.Text);
                komut3.Parameters.AddWithValue("@P4", CmbEvrakDepartman.Text);
                komut3.Parameters.AddWithValue("@P5", DTPTeslim.Value);
                komut3.Parameters.AddWithValue("P6", İD);
                komut3.ExecuteNonQuery();
                bgl.Close();
                MessageBox.Show("Ekle İşlemi Gerçekleştirildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getdata();

        }

        private void BtnEvrakGüncelle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            int İD = Convert.ToInt32(DTTablo2.SelectedRows[0].Cells[0].Value);
            SqlCommand komut4 = new SqlCommand("Update TBLEvrak Set TeslimAlan=@P1,TeslimEden=@P2, EvrakNO=@P3,TeslimEdenTC=@P4,EvrakDepartman=@P5,TeslimEdilecekTarih=@P6 Where İD=@P7", bgl);
            komut4.Parameters.AddWithValue("@P1", TxtTeslimAlan2.Text);
            komut4.Parameters.AddWithValue("@P2", TxtTeslimEden2.Text);
            komut4.Parameters.AddWithValue("@P3",TxtEvrakNo3.Text);
            komut4.Parameters.AddWithValue("@P4", MskTeslimEdenTC2.Text);
            komut4.Parameters.AddWithValue("@P5", CmbEvrakDepartman4.Text);
            komut4.Parameters.AddWithValue("@P6", dateTimePicker2.Value);
            komut4.Parameters.AddWithValue("@P7", İD);
            komut4.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleştirildi.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            getdata();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ArsivYönetimSistemi frm = new ArsivYönetimSistemi();
            frm.Show();
            this.Hide();
        }
    }
}
