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

namespace WindowsFormsApplication3
{
    public partial class Musteriler : Form
    {
        public Form1 frm1;
        public Musteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Server=79.123.228.28,5501; DataBase = GeceP3; User Id = GecePrj3; Password = masaustugecep3; ");

        private void Musteriler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'geceP3DataSet3.Musteriler' table. You can move, or remove it, as needed.
            this.musterilerTableAdapter.Fill(this.geceP3DataSet3.Musteriler);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server = 79.123.228.28,5501;" + "Database = GeceP3;" + "User Id=GecePrj3;" + "password=masaustugecep3";
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    baglanti.Open();
                    //using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeDetails VALUES(" + " @Adi, @Soyadi, @KullaniciAdi, @Parola, @Rol, @Tel, @Adres)", baglanti))
                    {

                        if (textBox1.Text == "")
                        { MessageBox.Show("Lütfen Bir Kullanıcı İsmi Giriniz!", "Otomasyon", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                        if (MessageBox.Show("Yeni Kullanıcı Kaydını Onaylıyormusunuz?", "Otomasyon", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                        { return; }

                        //     using (SqlConnection baglanti = new SqlConnection(connectionString))
                        //   SqlConnection baglanti= new SqlConnection();
                        //   baglanti.ConnectionString = Properties.Settings.Default.ConnectionString;

                        //          baglanti.Open();
                        //  SqlCommand cmd = new SqlCommand();
                        string sorgu = "up_MusteriEkle";
                        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MüsteriAdi", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Soyadi", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Tel", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Adres", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Aciklama", textBox5.Text);
                        

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();

                        textBox5.Clear();
                        

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Yeni Kullanıcı Başarıyla Eklendi", "Otomasyon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        public void verileriigoster(string verilerim)
        {
            SqlDataAdapter da = new SqlDataAdapter(verilerim, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button3_Click(object sender, EventArgs e)
        {
            verileriigoster("Select * from Musteriler");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string secmeSorgusu = "SELECT * from Musteriler where MüsteriAdi=@MüsteriAdi";

            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
            secmeKomutu.Parameters.AddWithValue("@MüsteriAdi", textBox6.Text);

            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();

            if (dr.Read())
            {
                string MüsteriAdi = dr["Soyadi"].ToString();
                dr.Close();

                DialogResult durum = MessageBox.Show(MüsteriAdi + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == durum)
                {
                    string silmeSorgusu = "DELETE from Musteriler where MüsteriAdi=@MüsteriAdi";

                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                    silKomutu.Parameters.AddWithValue("@MüsteriAdi", textBox6.Text);
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi...");

                }
            }
            else
                MessageBox.Show("Müşteri Bulunamadı.");
            baglanti.Close();
        }
    }
}
