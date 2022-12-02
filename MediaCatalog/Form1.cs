using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MediaCatalog.Properties;

namespace MediaCatalog
{
    public partial class Form1 : Form
    {
        private List<Item> Items = new List<Item>();
        private EItemTypes _currentFilter= EItemTypes.ВСЕ;

        public Form1()
        {
            InitializeComponent();
            LoadItems();
            foreach (var value in Enum.GetValues(typeof(EItemTypes)).Cast<EItemTypes>())
                comboBox1.Items.Add(value);
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            trackBar1.Value = timer1.Interval = Settings.Default.GifInterval;

        }

        private void LoadItems()
        {
            if (File.Exists("catalog.db"))
                Items = JsonSettings.Get<List<Item>>("catalog.db");
            else SaveItems();
        }
        private void SaveItems()
        {
            JsonSettings.Save(Items, "catalog.db");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            _currentFilter = (EItemTypes) comboBox1.SelectedItem;
            listBox1.Items.AddRange((_currentFilter == EItemTypes.ВСЕ
                ?Items
                :Items.Where(f=>f.Types == _currentFilter)).ToArray());
            listBox1.Invalidate();
            timer1.Stop();
            pictureBox1.BackgroundImage = null;
            if(listBox1.Items.Count>0)
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if(e.Index<0) return;
            Item itm = (Item) listBox1.Items[e.Index];
            if(itm==null) return;
            if(_currentFilter==EItemTypes.ВСЕ)
                e.Graphics.DrawString(itm.Type.ToString(), e.Font, new SolidBrush(e.ForeColor),e.Bounds.Width-60,e.Bounds.Y);
            e.Graphics.DrawString(itm.Name, e.Font, new SolidBrush(e.ForeColor), 0, e.Bounds.Y);
            e.Graphics.DrawString(itm.Tag, e.Font, new SolidBrush(e.ForeColor), 130, e.Bounds.Y);
            e.Graphics.DrawString(itm.Path, e.Font, new SolidBrush(e.ForeColor), 0, e.Bounds.Y + 12);
        }

        private void add_Click(object sender, EventArgs e)
        {
            var f = new EditItem();
            f.ShowDialog();
            if(f.Item==null) return;
            Items.Add(f.Item);
            listBox1.Items.Add(f.Item);
            SaveItems();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            Item i = (Item) listBox1.SelectedItem;
            if(i==null) return;
            var f = new EditItem(i);
            f.ShowDialog();
            if (f.Item == null) return;
            listBox1.Items[listBox1.SelectedIndex] = f.Item;
            SaveItems();
        }

        private void del_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex<0) 
                return;
            Item i = (Item) listBox1.Items[listBox1.SelectedIndex];
            if(i==null) return;
            if(MessageBox.Show("Удалить выбранный элемент?","Удаление ...", MessageBoxButtons.YesNo)!= DialogResult.Yes) 
                return;
            listBox1.Items.Remove(i);
            if (Items.Remove(i))
                MessageBox.Show("Элемент удален");
            SaveItems();
        }

        private GifImage gifImage;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            Item i = (Item)listBox1.Items[listBox1.SelectedIndex];
            if (i == null) return;
            if (!File.Exists(i.Path))
            {
                MessageBox.Show("Элемент не существует по заданному пути");
                return;
            }

            trackBar1.Visible = i.Type == EItemType.ГИФКА;
            if (i.Type == EItemType.ГИФКА)
            {
                trackBar1.Value = timer1.Interval;
                gifImage = new GifImage(i.Path);
                gifImage.ReverseAtEnd = false;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                pictureBox1.BackgroundImage = new Bitmap(i.Path);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gifImage != null)
                pictureBox1.BackgroundImage = gifImage.GetNextFrame();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
            Settings.Default.GifInterval=timer1.Interval;
            Settings.Default.Save();
        }

        private void find_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            _currentFilter = (EItemTypes)comboBox1.SelectedItem;
            List<Item> item = (_currentFilter == EItemTypes.ВСЕ
                ? Items
                : Items.Where(f => f.Types == _currentFilter))
                .ToList();
            if (find.Text?.Length > 0)
            {
                var f = find.Text?.ToLower();
                item = item.Where(i=>
                    i.Name.ToLower().Contains(f)||i.Tag.ToLower().Contains(f))
                    .ToList();
            }
            listBox1.Items.AddRange(item.ToArray());
            listBox1.Invalidate();
            pictureBox1.BackgroundImage = null;
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;

        }

        private void copyPath_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            Item i = (Item)listBox1.Items[listBox1.SelectedIndex];
            if (i == null) return;
            Clipboard.SetText(i.Path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            Item i = (Item)listBox1.Items[listBox1.SelectedIndex];
            if (i == null) return;
            Clipboard.SetImage(new Bitmap(i.Path));
        }

        private void openFolder_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            Item i = (Item)listBox1.Items[listBox1.SelectedIndex];
            if (i == null) return;
            Process.Start(Path.GetDirectoryName(i.Path));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            Item i = (Item)listBox1.Items[listBox1.SelectedIndex];
            if (i == null) return;
            Process.Start(i.Path);
        }
    }
}
