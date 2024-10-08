using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("Дата", 100);
            listView1.Columns.Add("Название", 100);
            listView1.Columns.Add("Текст", 300);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            currentTime = Convert.ToDateTime(currentTime.ToString("HH:mm:ss"));

            foreach (ListViewItem item in listView1.Items)
            {
                DateTime columnValue = Convert.ToDateTime(item.SubItems[0].Text);

                if (columnValue == currentTime)
                {
                    timer.Stop();
                    MessageBox.Show($"Выполните заметку {item.SubItems[1].Text} \n {item.SubItems[2].Text}", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    timer.Start();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string userInput = textBox4.Text;

                TimeSpan timeSpan = TimeSpan.Parse(userInput);

            }
            catch (FormatException)
            {
                MessageBox.Show("Введите время в правильном формате (чч:мм:сс).");
            }
            ListViewItem item3 = new ListViewItem(new[]
               {
                    textBox4.Text,
                    textBox5.Text,
                    textBox6.Text
                });
            listView1.Items.Add(item3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Элемент не выбран");
            }
        }
    }
}
