using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form1 frm1;

       // private PrintDocument printDocument1;

        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Server=79.123.228.28,5501; DataBase = GeceP3; User Id = GecePrj3; Password = masaustugecep3; ");
        


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

                        if (textBox3.Text == "")
                        { MessageBox.Show("Lütfen Bir Kullanıcı İsmi Giriniz!", "Otomasyon", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                        if (MessageBox.Show("Yeni Kullanıcı Kaydını Onaylıyormusunuz?", "Otomasyon", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                        { return; }

                        //     using (SqlConnection baglanti = new SqlConnection(connectionString))
                        //   SqlConnection baglanti= new SqlConnection();
                        //   baglanti.ConnectionString = Properties.Settings.Default.ConnectionString;

                        //          baglanti.Open();
                        //  SqlCommand cmd = new SqlCommand();
                        string sorgu = "up_KullaniciEkle";
                        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@Adi", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Soyadi", textBox2.Text);
                        cmd.Parameters.AddWithValue("@KullaniciAdi", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Parola", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Rol", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Tel", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Adres", textBox7.Text);

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();

                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();

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

    /*    private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server = 79.123.228.28,5501;" + "Database = GeceP3;" + "User Id=GecePrj3;" + "password=masaustugecep3";
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    baglanti.Open();

                    string sorgu = "up_KullaniciGüncelle";
                    SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da;
                    //   string  = "Update Ogrenci Set Ad=@ad,Soyad=@soyad,Telefon=@tel Where Numara=@no";
                    cmd = new SqlCommand(sorgu, baglanti);
                    
                    cmd.Parameters.AddWithValue("@Id", 1);
                    ////cmd.Parameters.AddWithValue("@Ad", textBox11.Text);
                    //cmd.Parameters.AddWithValue("@Soyad", textBox12.Text);
                    //cmd.Parameters.AddWithValue("@KullaniciAdi", textBox13.Text);
                    //cmd.Parameters.AddWithValue("@Parola", textBox14.Text);
                    //cmd.Parameters.AddWithValue("@Rol", textBox15.Text);
                    //cmd.Parameters.AddWithValue("@Tel", textBox16.Text);
                    //cmd.Parameters.AddWithValue("@Adres", textBox17.Text);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Yeni Kullanıcı Başarıyla Eklendi", "Otomasyon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        */
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'geceP3DataSet.Kullanicilar' table. You can move, or remove it, as needed.
            this.kullanicilarTableAdapter.Fill(this.geceP3DataSet.Kullanicilar);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.kullanicilarTableAdapter.FillBy(this.geceP3DataSet.Kullanicilar);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.kullanicilarTableAdapter.FillBy1(this.geceP3DataSet.Kullanicilar);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
       // string connectionString = "server = 79.123.228.28,5501;" + "Database = GeceP3;" + "User Id=GecePrj3;" + "password=masaustugecep3";
            
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string secmeSorgusu = "SELECT * from Kullanicilar where KullaniciAdi=@KullaniciAdi";
            
            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
            secmeKomutu.Parameters.AddWithValue("@KullaniciAdi", textBox8.Text);
            
            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();
           
            if (dr.Read()) 
            {
                string KullaniciAdi = dr["Adi"].ToString() + " " + dr["Soyadi"].ToString();
                dr.Close();
               
                DialogResult durum = MessageBox.Show(KullaniciAdi + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
               
                if (DialogResult.Yes == durum) 
                {
                    string silmeSorgusu = "DELETE from Kullanicilar where KullaniciAdi=@KullaniciAdi";
                    
                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                    silKomutu.Parameters.AddWithValue("@KullaniciAdi", textBox8.Text);
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi...");
                    
                }
            }
            else
                MessageBox.Show("Kullanıcı Bulunamadı.");
            baglanti.Close();
        }

        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            verilerigoster("Select * from Kullanicilar");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Kullanicilar where KullaniciAdi like '%" + textBox9.Text + "%'",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string Adi = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string Soyadi = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string KullaniciAdi = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string Parola = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string Rol = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string Tel = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string Adres = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();

            textBox1.Text = Adi;
            textBox2.Text = Soyadi;
            textBox3.Text = KullaniciAdi;
            textBox4.Text = Parola;
            textBox5.Text = Rol;
            textBox6.Text = Tel;
            textBox7.Text = Adres;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update Kullanicilar set Adi='"+textBox1.Text+"',Soyadi='"+textBox2.Text+"',Parola='"+textBox4.Text+"',Rol='"+textBox5.Text+"',Tel='"+textBox6.Text+"',Adres='"+textBox7.Text+"' where KullaniciAdi='"+textBox3.Text+"'",baglanti);
            komut.ExecuteNonQuery();
            verilerigoster("Select * from Kullanicilar");
            baglanti.Close();

        }
    }

    
    }

    

    
  

