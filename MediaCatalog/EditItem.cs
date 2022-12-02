using System;
using System.Linq;
using System.Windows.Forms;

namespace MediaCatalog
{
    public partial class EditItem : Form
    {
        public Item Item = null;
        public Item _item = null;
        public EditItem(Item item = null)
        {
            InitializeComponent();
            if (item == null)
            {
                Text = "Создание элемента";
                item = new Item {Id=Guid.NewGuid()};
            }
            else Text = "Редактирование элемента";
            _item = item;
            foreach (var value in Enum.GetValues(typeof(EItemType)).Cast<EItemType>())
                type.Items.Add(value);

            id.Text = $"id = {_item.Id}";
            name.Text = _item.Name;
            tags.Text = _item.Tag;
            type.SelectedItem = _item.Type;
            path.Text = _item.Path;
            name.TextChanged += (sender, args) => _item.Name = name.Text;
            tags.TextChanged += (sender, args) => _item.Tag = tags.Text;
            type.SelectedIndexChanged += (sender, args) => _item.Type = (EItemType)type.SelectedItem;
            path.TextChanged += (sender, args) => _item.Path = path.Text;
        }

        private void EditItem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog{Filter = "Все допустимые элементы (gif,jpg,png)|*.gif;*.jpg;*.png", Title = "Выбрать стикер, гиф или мэм..."};
            if(f.ShowDialog()!= DialogResult.OK) return;
            path.Text = _item.Path = f.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Item = _item;
            Close();
        }

        private void url_Click(object sender, EventArgs e)
        {
            var f = new AddUrl();
            f.ShowDialog();
            if(f.DialogResult!=DialogResult.OK) return;
            path.Text = f.URL;
        }
    }
}
