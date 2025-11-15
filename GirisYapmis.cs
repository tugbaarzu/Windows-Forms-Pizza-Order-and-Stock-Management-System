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

    public partial class GirisYapmis : Form
    {
        public Toptanciler tpt1;
        public Musteriler mst1;
        Form2 a = new Form2();
        Musteriler b = new Musteriler();
        Toptanciler c = new Toptanciler();

        public Form1 frm1;

        public GirisYapmis()
        {
            InitializeComponent();

        }

        private void GirisYapmis_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'geceP3DataSet9.Siparisler' table. You can move, or remove it, as needed.
            this.siparislerTableAdapter3.Fill(this.geceP3DataSet9.Siparisler);
            // TODO: This line of code loads data into the 'geceP3DataSet8.Siparisler' table. You can move, or remove it, as needed.
            this.siparislerTableAdapter2.Fill(this.geceP3DataSet8.Siparisler);
            // TODO: This line of code loads data into the 'geceP3DataSet7.Siparisler' table. You can move, or remove it, as needed.
            this.siparislerTableAdapter1.Fill(this.geceP3DataSet7.Siparisler);
            // TODO: This line of code loads data into the 'geceP3DataSet6.Siparisler' table. You can move, or remove it, as needed.
            this.siparislerTableAdapter.Fill(this.geceP3DataSet6.Siparisler);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "" + DateTime.Now;
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {



            a.ShowDialog();

        }


        private void asbjToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSiparisAl_Click_1(object sender, EventArgs e)
        {
            int kola, didi, su;
       //     int adet1, adet2, adet3, kola, didi, su;
            MessageBox.Show("Alındı");
            decimal ucret = 0;
            string ekstra = "";
            //http://www.programlamadersleri.com
            //Eğer checkbox'lar seçili ise ekstra değişkenine aktarılıyor.

            if (checkBoxSucuk.Checked == true)
            { ekstra += "Sucuk"; }
            if (checkBoxSosis.Checked == true)
            { ekstra += " - " + "Sosis"; }
            if (checkBoxMantar.Checked == true)
            { ekstra += " - " + "Mantar"; }
            if (checkBoxKasar.Checked == true)
            { ekstra += " - " + "Kaşar"; }
            if (checkBoxPeynir.Checked == true)
            { ekstra += " - " + "Peynir"; }
            if (checkBoxSebze.Checked == true)
            { ekstra += " - " + "Sebze"; }
            //http://www.programlamadersleri.com

            //Seçili olan değeri ucret değişkenine adet bilgisi ile çarparak ekliyoruz.
            if (comboBoxPizzaBoy.Text == "Küçük")
            { ucret = numericUpDownPizza.Value * 10; }
            else if (comboBoxPizzaBoy.Text == "Orta")
            { ucret = numericUpDownPizza.Value * 15; }
            else if (comboBoxPizzaBoy.Text == "Büyük")
            { ucret = numericUpDownPizza.Value * 20; }





           kola = 5;
          didi = 3;
           su = 1;

           if (button26.Enabled == true)
            {
                kola = 0;
              //  adet1 = 0;
              //  adet1 = Convert.ToInt32(textBox1.Text);
              //  adet1 = adet1 * kola;
                ucret = ucret + kola;
            }
            if (button27.Enabled == true)
            {
                didi = 0;


              //  adet2 = Convert.ToInt32(textBox2.Text);
                didi = didi * didi;
                ucret = ucret + didi;
            }
            if (button28.Enabled == true)
            {
                su = 0;


        //        su = Convert.ToInt32(textBox3.Text);
                su = su * su;
                ucret = ucret + su;
            }


            //     if (comboBoxIcecek.Text == "2,5lt Coca Cola")
            //   { ucret += numericUpDownIcecek.Value * 5; }
            //    else if (comboBoxIcecek.Text == "1lt Fanta")
            //     { ucret += numericUpDownIcecek.Value * 3; }
            //   else if (comboBoxIcecek.Text == "1lt Sprite")
            //    { ucret += numericUpDownIcecek.Value * 3; }
            //http://www.programlamadersleri.com

            //Listbox'a değerleri yazdırıyoruz.
            listBoxAdSoyad.Items.Add(textBoxAd.Text);
            listBoxAdSoyad.Items.Add(textBoxSoyad.Text);
            listBoxTelefon.Items.Add(textBoxTelefon.Text);
            listBoxAdres.Items.Add(textBoxAdres.Text);
            listBoxPizza.Items.Add(numericUpDownPizza.Value + " adet " + comboBoxPizzaBoy.Text);
            //   listBoxIcecek.Items.Add(numericUpDownIcecek.Value + " adet " + comboBoxIcecek.Text);
            listBoxEkstra.Items.Add(ekstra);
            listBoxUcret.Items.Add(ucret);



            int sonuc = 0;
            for (int i = 0; i < listBoxUcret.Items.Count; i++)
            {
                sonuc += Convert.ToInt32(listBoxUcret.Items[i]);
            }
            textBox4.Text = Convert.ToString(sonuc + "TL");




        }

        private void buttonTemizle_Click_1(object sender, EventArgs e)
        {
            textBoxAd.Text = "";
            textBoxSoyad.Text = "";
            textBoxTelefon.Text = "";
            textBoxAdres.Text = "";
            //combobox değerlerini temizliyoruz
            //comboBoxIcecek.Text = "";
            comboBoxPizzaBoy.Text = "";
            //numericupdown değerlerini temizliyoruz
            numericUpDownPizza.Value = 0;
            //   numericUpDownIcecek.Value = 0;
            //http://www.programlamadersleri.com
            //checkbox değerlerini temizliyoruz
            checkBoxSucuk.Checked = false;
            checkBoxSosis.Checked = false;
            checkBoxMantar.Checked = false;
            checkBoxKasar.Checked = false;
            checkBoxPeynir.Checked = false;
            checkBoxSebze.Checked = false;

        }

        private void buttonSiparisTemizle_Click_1(object sender, EventArgs e)
        {
            listBoxAdSoyad.Items.Clear();
            listBoxTelefon.Items.Clear();
            listBoxAdres.Items.Clear();
            listBoxPizza.Items.Clear();
            //  listBoxIcecek.Items.Clear();
            listBoxEkstra.Items.Clear();
            listBoxUcret.Items.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden eminmisiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                frm1.Show();
            }

        }

        private void button26_Click(object sender, EventArgs e)
        {
            button26.BackColor = Color.Red;

        }

       

        private void button26_MouseMove(object sender, MouseEventArgs e)
        {
            button26.BackColor = Color.Red;

        }

        private void button26_MouseLeave(object sender, EventArgs e)
        {
           button26.BackColor = Color.Transparent;

        }

        private void button27_MouseLeave(object sender, EventArgs e)
        {
            button27.BackColor = Color.Transparent;
        }

        private void button27_MouseMove(object sender, MouseEventArgs e)
        {
            button27.BackColor = Color.Red;
        }

        private void button28_MouseMove(object sender, MouseEventArgs e)
        {
            button28.BackColor = Color.Red;
        }

        private void button28_MouseLeave(object sender, EventArgs e)
        {
            button28.BackColor = Color.Transparent;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            button28.BackColor = Color.Red;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            button27.BackColor = Color.Red;
        }

       
       private void button26_Checked(object sender, EventArgs e)

        {

            if (button26.Enabled == true)
            {

                button26.BackColor = Color.Red;
            }
            else
            {
                button26.BackColor = Color.Transparent;
            }
        }

          private void button3_Click(object sender, EventArgs e)
           {

           }

           private void button27_Checked(object sender, EventArgs e)

           {
               if (button27.Enabled == true)
               {

                   button27.BackColor = Color.Red;
               }
               else
               {
                   button27.BackColor = Color.Transparent;
               }
           }


           private void button28_Checked(object sender, EventArgs e)

           {
               if (button28.Enabled == true)
               {

                   button28.BackColor = Color.Red;
               }
               else
               {
                   button28.BackColor = Color.Transparent;
               }
           }
   
        private void jgnjnmxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yeniMüşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b.Show();
        }

        private void toptancılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult pdr = printDialog1.ShowDialog();
            if (pdr == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frm1.Show();


        }

        

        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pizza Stok Sipariş Programımız Kullanılmaya hazırdır. HAZIRLAYANLAR: Fatih BAYINDIR- Tuncay GİGİNOĞLU- Tuğba Arzu YILMAZ ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           


            
        }

        private void groupBoxSiparisler_Enter(object sender, EventArgs e)
        {

        }
    }
}
         
    
        
    

