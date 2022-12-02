
namespace MediaCatalog
{
    partial class EditItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditItem));
            this.id = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.tags = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.url = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(12, 9);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(28, 13);
            this.id.TabIndex = 0;
            this.id.Text = "Id = ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование";
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Location = new System.Drawing.Point(101, 37);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(222, 20);
            this.name.TabIndex = 2;
            // 
            // tags
            // 
            this.tags.Location = new System.Drawing.Point(101, 72);
            this.tags.Name = "tags";
            this.tags.Size = new System.Drawing.Size(115, 20);
            this.tags.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тэг(и)";
            // 
            // path
            // 
            this.path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.path.Location = new System.Drawing.Point(101, 106);
            this.path.Multiline = true;
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(222, 56);
            this.path.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Полный путь к файлу";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(289, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 22);
            this.button1.TabIndex = 7;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Тип элемента";
            // 
            // type
            // 
            this.type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(101, 194);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(222, 21);
            this.type.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(248, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 10;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // url
            // 
            this.url.BackColor = System.Drawing.Color.White;
            this.url.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.url.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.url.Location = new System.Drawing.Point(101, 161);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(45, 22);
            this.url.TabIndex = 11;
            this.url.Text = "+ url";
            this.url.UseVisualStyleBackColor = false;
            this.url.Click += new System.EventHandler(this.url_Click);
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 275);
            this.Controls.Add(this.url);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.type);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tags);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(351, 339);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(244, 314);
            this.Name = "EditItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Елемент";
            this.Load += new System.EventHandler(this.EditItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox tags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button url;
    }
}