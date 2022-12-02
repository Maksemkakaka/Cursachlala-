using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MediaCatalog
{
    public partial class AddUrl : Form
    {
        public string URL = null;
        public AddUrl()
        {
            InitializeComponent();
        }

        private void AddUrl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("UrlImages");
            var temp = $"{Application.StartupPath}\\UrlImages\\{Path.GetFileName(Path.GetTempFileName().Replace(".","_"))}.png";
            try
            {
                using (WebClient client = new WebClient())
                    client.DownloadFile(new Uri(textBox1.Text), temp);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            URL = temp;
            Close();
        }
    }
}
