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
    public partial class FrmEmanetListesi : Form
    {
        private void getdata()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLEvrak Where EmanetVerildi=1", bgl);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public FrmEmanetListesi()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=OgrenciEvrak;Integrated Security=True");
        private void FrmEmanetListesi_Load(object sender, EventArgs e)
        {
           getdata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Update TBLEvrak set EmanetVerildi=0 Where EvrakNO=@P1", bgl);
            komut2.Parameters.AddWithValue("@P1", textBox1.Text);
            komut2.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Evrak Teslim Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            getdata();

        }
    }
}
