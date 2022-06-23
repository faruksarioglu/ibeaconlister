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
            da = new SqlDataAdapter("Select uuid,rssi,timestamp From devicesignallog where datediff( mi,timestamp,current_timestamp)<50;", baglanti);
            System.Data.DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            dataGridView1.Refresh();
            baglanti.Close();
        }
    }
}
