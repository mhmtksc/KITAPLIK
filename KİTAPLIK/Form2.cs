using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace KİTAPLIK
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void listele()
        {
            SqlCommand komut = new SqlCommand("Select*from Kitap", bgl);
            SqlDataAdapter adpt = new SqlDataAdapter(komut);
            DataTable Table = new DataTable();
            int fill = adpt.Fill(Table);
            dataGridView1.DataSource = Table;

        }
        SqlConnection bgl = new SqlConnection(@"Data Source=MEHMET;Initial Catalog=Kitaplık;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {


        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
             bgl.Open();
            if (radioButton1.Checked == true)
            {
               

                SqlCommand Ekle = new SqlCommand("Insert into Kitap (Kitap_Adı,Kitap_Yazar,Kitap_Sayfa,Kitap_Türü,Kitap_Yayın_Evi,Kitap_Fiyat) values(@a1,@a2,@a3,@a4,@a5,@a6)", bgl);
                Ekle.Parameters.AddWithValue("@a1", textBox1.Text);
                Ekle.Parameters.AddWithValue("@a2", textBox2.Text);
                Ekle.Parameters.AddWithValue("@a3", textBox3.Text.ToString());
                Ekle.Parameters.AddWithValue("@a4", textBox4.Text);
                Ekle.Parameters.AddWithValue("@a5", textBox5.Text);
                Ekle.Parameters.AddWithValue("@a6", textBox6.Text.ToString());
                Ekle.ExecuteNonQuery();
                MessageBox.Show("Kayıt Eklendi", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
                listele();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else if (radioButton2.Checked == true)
            {
                
                SqlCommand sil = new SqlCommand("Delete From Kitap where Kitap_Adı=@z1", bgl);
                sil.Parameters.AddWithValue("@z1", textBox1.Text);
                sil.ExecuteNonQuery();
                bgl.Close();
                MessageBox.Show("Kayıt Silindi", "Dikkat", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                listele();

            }
            if (radioButton3.Checked == true)
            {

                SqlCommand guncelle = new SqlCommand("Update Kitap set Kitap_Adı=@c1,Kitap_Yazar=@c2, Kitap_Sayfa=@c3, Kitap_Türü=@c4, Kitap_Yayın_Evi=@c5, Kitap_Fiyat=@c6", bgl);
                guncelle.Parameters.AddWithValue("@c1", textBox1.Text);
                guncelle.Parameters.AddWithValue("@c2", textBox2.Text);
                guncelle.Parameters.AddWithValue("@c3", textBox3.Text.ToString());
                guncelle.Parameters.AddWithValue("@c4", textBox4.Text);
                guncelle.Parameters.AddWithValue("@c5", textBox5.Text);
                guncelle.Parameters.AddWithValue("@c6", textBox6.Text.ToString());
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Kitap Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else if (radioButton4.Checked == true)
            {
                listele();
            }
            bgl.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }
    }

}
