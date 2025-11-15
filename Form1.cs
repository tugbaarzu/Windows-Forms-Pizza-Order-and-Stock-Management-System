using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public GirisYapmis grs;
        public Form2 frm2;
        public Musteriler mst1;
        public Toptanciler tpt1;
        
        


        SqlConnection baglanti = new SqlConnection(@"Server=79.123.228.28,5501; DataBase = GeceP3; User Id = GecePrj3; Password = masaustugecep3; ");

      //  SqlConnection baglanti;
        public Form1()
        {
            InitializeComponent();
            grs = new GirisYapmis();
            frm2 = new Form2();
            mst1 = new Musteriler();
            tpt1 = new Toptanciler();


            tpt1.frm1 = this;
            mst1.frm1 = this;
            grs.frm1 = this;
            frm2.frm1 = this;
            
        }
        
        
        public string MD5Olustur(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string sifrem = MD5Olustur(txtSifre.Text);

            SqlConnection baglanti = new SqlConnection(@"Server=79.123.228.28,5501; DataBase = GeceP3; User Id = GecePrj3; Password = masaustugecep3; ");
          //  baglanti.ConnectionString= "Data Source=79.123.228.28,5501; user=GecePrj3; Password=masaustugecep3 ;Database=Kullanicilar;Trusted_Connection=true;";
           
            try
            {
             

                baglanti.Open();
                SqlParameter prm1 = new SqlParameter("@KullaniciAdi", txtKullaniciAdi.Text);
                SqlParameter prm2 = new SqlParameter("@Parola", sifrem);
                string sql = "SELECT * FROM Kullanicilar WHERE KullaniciAdi=@KullaniciAdi AND Parola=@Parola";
                SqlCommand cmd = new SqlCommand(sql, baglanti);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                SqlDataReader da = cmd.ExecuteReader();
               
                

                if (da.Read())
                {

                    lblDogrulama.Text = "Başarılı bir şekilde giriş yaptınız.";
                  //  MessageBox.Show("Hoşgeldiniz");
                    grs.Show();
                    
                }
                else
                {
                    MessageBox.Show("Hata! Girmiş olduğunuz bilgiler hatalıdır. ");
                    
                }
            }
            catch (Exception ex)
            {
                exHata.Text = ex.Message;
            }
            finally {
               baglanti.Close();
              
            }
          this.Hide();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
