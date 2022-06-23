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

namespace ibeaconlister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-4SBPHP7\\SQLEXPRESS;Initial Catalog=ibeacon;Integrated Security=True");
            baglanti.Open();
            button1.Text = baglanti.State.ToString();
            string dev = "device2";
            da1 = new SqlDataAdapter("Select deviceid from device", baglanti);
            da = new SqlDataAdapter("Select gatewayId,rssi,timestamp, datediff( mi,devicesignallog.timestamp,current_timestamp) as recent_dk from devicesignallog where gatewayId like '"+dev+"'", baglanti);
          
            System.Data.DataTable tablo = new DataTable();
            System.Data.DataTable tablo1 = new DataTable();

            da.Fill(tablo);
            da1.Fill(tablo1);
            dataGridView1.DataSource = tablo;
           // dataGridView1.Refresh();
            listBox1.DataSource = tablo1;
            listBox1.DisplayMember = "deviceid";
            listBox1.ValueMember = "deviceid";

           // baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dev1 = listBox1.SelectedValue.ToString();
            //baglanti.Open;
            da2 = new SqlDataAdapter("Select gatewayId, rssi, timestamp, datediff(mi, devicesignallog.timestamp, current_timestamp) as recent_dk from devicesignallog where gatewayId like TRIM('" + listBox1.SelectedValue + "')", baglanti);
            System.Data.DataTable tablo2 = new DataTable();
            da2.Fill(tablo2);

            dataGridView1.DataSource = tablo2;
            dataGridView1.Refresh();
            button1.Text = dev1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Refresh();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dev1 = listBox1.SelectedValue.ToString();
            //baglanti.Open;
            da2 = new SqlDataAdapter("Select gatewayId, rssi, timestamp, datediff(mi, devicesignallog.timestamp, current_timestamp) as recent_dk from devicesignallog where gatewayId like TRIM('" + listBox1.SelectedValue + "')", baglanti);
            System.Data.DataTable tablo2 = new DataTable();
            da2.Fill(tablo2);

            dataGridView1.DataSource = tablo2;
            dataGridView1.Refresh();
            button1.Text = dev1;

        }
    }
}
