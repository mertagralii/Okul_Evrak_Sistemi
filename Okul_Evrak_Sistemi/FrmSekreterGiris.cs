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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        SqlConnection bgl =  new SqlConnection(@"Data Source=Mert;Initial Catalog=OgrenciEvrak;Integrated Security=True");
        private void FrmSekreterGiris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLSekreter Where KullaniciAdi=@P1 And Sifre = @P2", bgl);
            komut.Parameters.AddWithValue("@P1", TxtSekreterGiris.Text);
            komut.Parameters.AddWithValue("@P2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreter frm = new FrmSekreter();
                frm.Skullanici = TxtSekreterGiris.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı yada Şifre Hatalı", "Hata");
            }
            bgl.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ArsivYönetimSistemi frm = new ArsivYönetimSistemi();
            frm.Show();
            this.Hide();
        }
    }
}
