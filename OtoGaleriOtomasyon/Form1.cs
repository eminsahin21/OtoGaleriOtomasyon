using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OtoGaleriOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source="+ Application.StartupPath + "\\otogaleri.accdb");
        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter silmekomutu = new OleDbDataAdapter("delete from otogaleri where ruhsatno='"+textBox1.Text+"'",baglanti);
                DataSet dshafiza = new DataSet();
                silmekomutu.Fill(dshafiza);
                MessageBox.Show("Silme işlemi başarılı");
                baglanti.Close();
                kayitlarilistele();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter guncellekomutu = new OleDbDataAdapter("update otogaleri set fiyat='"+textBox3.Text+"' where ruhsatno='"+textBox1.Text+"'",baglanti);
                DataSet dshafiza = new DataSet();
                guncellekomutu.Fill(dshafiza);
                MessageBox.Show("Fiyat bilgisi güncellendi");
                baglanti.Close();
                kayitlarilistele();
                textBox1.Clear();
                textBox3.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter eklekomutu = new OleDbDataAdapter("insert into otogaleri(ruhsatno,marka,model,yakittipi,kasatipi,km,fiyat) values('"+textBox1.Text+"','"+comboBox1.SelectedItem.ToString()+"','"+comboBox2.SelectedItem.ToString()+"','"+comboBox3.SelectedItem.ToString()+"','"+comboBox4.SelectedItem.ToString()+"','"+textBox2.Text+"','"+textBox3.Text+"')", baglanti);
                DataSet dataSet = new DataSet();
                eklekomutu.Fill(dataSet);
                baglanti.Close();
                MessageBox.Show("Araç veritabanına eklendi");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                kayitlarilistele();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();            
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string marka = comboBox1.SelectedItem.ToString();
            if(marka=="TOYOTA")
            {
                string[] modeller = {"AURIS","COROLLA","YARİS"};
                comboBox2.Items.AddRange(modeller);
            }
            if (marka == "HONDA")
            {
                string[] modeller = { "CIVIC", "ACCORD"};
                comboBox2.Items.AddRange(modeller);
            }
            if (marka == "OPEL")
            {
                string[] modeller = { "INSIGNA", "COMBO", "ASTRA","VECTRA"};
                comboBox2.Items.AddRange(modeller);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] marka = {"TOYOTA","HONDA","OPEL"};
            comboBox1.Items.AddRange(marka);

            kayitlarilistele();
        }

        private void kayitlarilistele()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from otogaleri", baglanti);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter arakomutu = new OleDbDataAdapter("select * from otogaleri where ruhsatno='"+textBox1.Text+"'",baglanti);
                DataSet dataSet = new DataSet();
                arakomutu.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                MessageBox.Show("Aradığınız kayıt getirildi");
                baglanti.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
                
            }
        }
    }
}
