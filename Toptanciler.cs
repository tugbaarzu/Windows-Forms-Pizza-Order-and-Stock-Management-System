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
    public partial class Toptanciler : Form
    {
        public Form1 frm1;
        public Toptanciler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Server=79.123.228.28,5501; DataBase = GeceP3; User Id = GecePrj3; Password = masaustugecep3; ");
        private void Toptanciler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'geceP3DataSet5.Toptanciler' table. You can move, or remove it, as needed.
            this.toptancilerTableAdapter.Fill(this.geceP3DataSet5.Toptanciler);

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
                        { MessageBox.Show("Lütfen Bir Firma İsmi Giriniz!", "Otomasyon", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                        if (MessageBox.Show("Yeni Toptancı Kaydını Onaylıyormusunuz?", "Otomasyon", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                        { return; }

                        //     using (SqlConnection baglanti = new SqlConnection(connectionString))
                        //   SqlConnection baglanti= new SqlConnection();
                        //   baglanti.ConnectionString = Properties.Settings.Default.ConnectionString;

                        //          baglanti.Open();
                        //  SqlCommand cmd = new SqlCommand();
                        string sorgu = "up_ToptanciEkle";
                        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Firmaİsim", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Tel", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Adres", textBox3.Text);
                        cmd.Parameters.AddWithValue("@KisiAdi", textBox4.Text);
                        cmd.Parameters.AddWithValue("@KisiTel", textBox5.Text);


                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();

                        textBox5.Clear();


                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Yeni Toptancı Başarıyla Eklendi", "Otomasyon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        public void verilergoster(string veri)
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button3_Click(object sender, EventArgs e)
        {
            verilergoster("Select * from Toptanciler");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string secmeSorgusu = "SELECT * from Toptanciler where Firmaİsim=@Firmaİsim";

            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
            secmeKomutu.Parameters.AddWithValue("@Firmaİsim", textBox6.Text);

            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();

            if (dr.Read())
            {
                string Firmaİsim = dr["KisiAdi"].ToString();
                dr.Close();

                DialogResult durum = MessageBox.Show(Firmaİsim + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == durum)
                {
                    string silmeSorgusu = "DELETE from Toptanciler where Firmaİsim=@Firmaİsim";

                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                    silKomutu.Parameters.AddWithValue("@Firmaİsim", textBox6.Text);
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi...");

                }
            }
            else
                MessageBox.Show("Toptancı Bulunamadı.");
            baglanti.Close();
        }
    }
    }

