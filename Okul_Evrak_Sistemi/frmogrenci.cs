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
    public partial class frmogrenci : Form 
    {
        public frmogrenci()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=OgrenciEvrak;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLEvrak(AD,Soyad,TC,Telefon,TalepEvrak,Talep) values (@P1,@P2,@P3,@P4,@P5,@P6)", bgl);
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", MskTC.Text);
            komut.Parameters.AddWithValue("@P4", MskTel.Text);
            komut.Parameters.AddWithValue("@P5",TxtTalepEvrak.Text);
            komut.Parameters.AddWithValue("@P6", TxtTalepSebep.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Talep İşleminiz Başarıyla Gerçekleştirildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }


    }
}
