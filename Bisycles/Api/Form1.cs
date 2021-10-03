using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Api
{
    public partial class Form1 : Form
    {

        static HttpClient client = new HttpClient();


        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44320/api/bicycle";
            string json = new WebClient().DownloadString(url);
            
            var currencies = JsonConvert.DeserializeObject<List<Bicycle>>(json);

            dataGridView1.DataSource = currencies.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;

                string url = "https://localhost:44320/api/bicycle/" + id;
                string json = new WebClient().DownloadString(url);

                var currencies = JsonConvert.DeserializeObject<Bicycle>(json);
                dataGridView1.DataSource = currencies;
            }
            catch (Exception ex)
            {
                dataGridView1.DataSource = ex.Message;
            }



            
        }
    }
}
