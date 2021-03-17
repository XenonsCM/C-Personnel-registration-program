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

namespace Personel_Kayit_Programı
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("");//Kendi adresinizi girin

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.personelTableAdapter.Fill(this.personelDataSet.Personel);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of ode loads data into the 'personelDataSet.Personel' table. You can move, or remove it, as needed.
            label8.Visible = false; 
            ad.Focus();
        }
        void Temizle()
        {
            ad.Text = "";
            soyad.Text = "";
            maas.Text = "";
            Sehir.Text = "";
            Meslek.Text = "";
            Evli.Checked = false;
            Bekar.Checked = false;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
      
        private void btnkaydet_Click(object sender, EventArgs e)
        {
          
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Personel (Perad,Persoyad,Persehir,Permaas,Permeslek,Perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", ad.Text);
            komut.Parameters.AddWithValue("@p2", soyad.Text);
            komut.Parameters.AddWithValue("@p3", Sehir.Text);
            komut.Parameters.AddWithValue("@p4", maas.Text);
            komut.Parameters.AddWithValue("@p5", Meslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Personel Kayıt Edilmiştir");
            baglanti.Close();

        }

        private void Sehir_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        
        private void Evli_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "True";
            
        }

        private void Bekar_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "False";
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            Temizle();
            ad.Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            Sehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            Meslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();



        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                Evli.Checked = true;
                Bekar.Checked = false;
            }
            else
            {
                Evli.Checked = false;
                Bekar.Checked = true;
            }


        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Personel where Perid = @k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", id.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutgüncelle = new SqlCommand("Update Personel Set Perad=@a1,Persoyad=@a2,Persehir=@a3,Permaas=@a4,Perdurum=@a5,Permeslek=@a6 where Perid=@a7", baglanti);
            komutgüncelle.Parameters.AddWithValue("@a1", ad.Text);
            komutgüncelle.Parameters.AddWithValue("@a2",soyad.Text);
            komutgüncelle.Parameters.AddWithValue("@a3",Sehir.Text);
            komutgüncelle.Parameters.AddWithValue("@a4", maas.Text);
            komutgüncelle.Parameters.AddWithValue("@a5",label8.Text);
            komutgüncelle.Parameters.AddWithValue("@a6",Meslek.Text);
            komutgüncelle.Parameters.AddWithValue("@a7",id.Text);
            komutgüncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgi Güncellendi");

        }
    }
}
