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
    public partial class FrmMemurİslemleri : Form
    {
        private void getdata()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLMemur", bgl);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public FrmMemurİslemleri()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=OgrenciEvrak;Integrated Security=True");
        private void FrmMemurİslemleri_Load(object sender, EventArgs e)
        {
           getdata();
        }

        private void BtnMemurEkle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand PersonelEkle = new SqlCommand("INSERT INTO TBLMemur (KullaniciAdi,Sifre,TCNO,Adi,Soyadi,TelNumarasi,Eposta) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7)", bgl);
            PersonelEkle.Parameters.AddWithValue("@P1", TxtKullaniciAdi.Text);
            PersonelEkle.Parameters.AddWithValue("@P2", TxtSifre.Text);
            PersonelEkle.Parameters.AddWithValue("@P3", MskMemurTCNO.Text);
            PersonelEkle.Parameters.AddWithValue("@P4", TxtMemurAd.Text);
            PersonelEkle.Parameters.AddWithValue("@P5", TxtMemurSoyad.Text);
            PersonelEkle.Parameters.AddWithValue("@P6",MskMemurTel.Text);
            PersonelEkle.Parameters.AddWithValue("@P7", TxtMemurEposta.Text);
            PersonelEkle.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Memur Ekleme İşlemi Gerçekleştirildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            getdata();
        }

        private void BtnMemurSil_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand PersonelSil = new SqlCommand("Delete From TBLMemur Where TCNO =@P1", bgl);
            PersonelSil.Parameters.AddWithValue("@P1", MskMemurTCNO2.Text);
            PersonelSil.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Memur Silme İşlemi Gerçekleştirildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
        }

        private void BtnMemurGüncelle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand PersonelGüncelleme = new SqlCommand("Update TBLMemur set KullaniciAdi =@P1, Sifre=@P2,TCNO=@P3,Adi=@P4,Soyadi=@P5,TelNumarasi=@P6,Eposta=@P7 Where İD=@P8", bgl);
            PersonelGüncelleme.Parameters.AddWithValue("@P1", TxtKullaniciAdi3.Text);
            PersonelGüncelleme.Parameters.AddWithValue("@P2", textBox14.Text);
            PersonelGüncelleme.Parameters.AddWithValue("@P3", maskedTextBox3.Text);
            PersonelGüncelleme.Parameters.AddWithValue("@P4", textBox13.Text);
            PersonelGüncelleme.Parameters.AddWithValue("@P5", textBox11.Text);
            PersonelGüncelleme.Parameters.AddWithValue("@P6", maskedTextBox1.Text);
            PersonelGüncelleme.Parameters.AddWithValue("@P7", textBox12.Text);
            PersonelGüncelleme.Parameters.AddWithValue("@P8", TxtİD.Text);
            PersonelGüncelleme.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Memur Güncelleme İşlemi Gerçekleştirildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            getdata();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtİD.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtKullaniciAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtKullaniciAdi3.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox14.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            MskMemurTCNO.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskMemurTCNO2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtMemurAd.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox13.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtMemurSoyad.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox11.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            MskMemurTel.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            TxtMemurEposta.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            textBox12.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

        }
    }
}
