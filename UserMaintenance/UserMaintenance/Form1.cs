using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName; // label1

            button1.Text = Resource1.Add; // button1
            button2.Text = Resource1.Write;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,

            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TXT file (*.txt)|*.txt| All Files (*.*)|*.*";
            sfd.Title = "Mentes";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                var emberek = (from x in users select x).ToList();

                using (StreamWriter sw = new StreamWriter(sfd.FileName, true, Encoding.UTF8))
                {
                    sw.WriteLine("ID ; Teljes név");
                    foreach (var item in users)
                    {
                        sw.WriteLine(item.ID + " " + item.FullName);
                        
                    }
                   
                    //devben elfelejtettem kitörölni a dobozt meg a labelt
                }


            }
        }

    }
}
