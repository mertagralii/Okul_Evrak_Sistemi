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

namespace Okul_Evrak_Sistemi
{
    
    public partial class FrmMemurGiris : Form
    {

       
        public FrmMemurGiris()
        {
 
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=OgrenciEvrak;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLMemur Where KullaniciAdi=@P1 And Sifre = @P2", bgl);
            komut.Parameters.AddWithValue("@P1", TxtMemurGiris.Text);
            komut.Parameters.AddWithValue("@P2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmMemur frm = new FrmMemur();
                frm.Mkullanici = TxtMemurGiris.Text;
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
