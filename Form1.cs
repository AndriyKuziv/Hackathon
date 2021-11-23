using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_see_sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;

            label1.Text = "Hello, " + Environment.UserName+"!"+" How's it going?";
            label2.Text = thisDay.ToString("d");

            if (File.Exists("list.txt")){
                string line;
                using (StreamReader sr = new StreamReader("list.txt")){
                    line = sr.ReadLine();
                    while (line != null){
                        checkedListBox1.Items.Add(line, false);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hours, minutes;     

            if (textBox1.Text != "")
            { 
            if (textBox2.Text != "")
            {
                    if (Convert.ToInt32(textBox2.Text) > 60)
                    {
                        hours = (Convert.ToInt32(textBox2.Text) / 60);
                        minutes = (Convert.ToInt32(textBox2.Text) % 60);
                        checkedListBox1.Items.Add(textBox1.Text + " (" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + ")" + " Duration : " + hours + " hours " + minutes + " minutes", false);
                    }
                    else
                    {

                        checkedListBox1.Items.Add(textBox1.Text + " (" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + ")" + " Duration : " + textBox2.Text + " minutes", false);
                    }
            }
            else
                {
                    checkedListBox1.Items.Add(textBox1.Text + " (" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + ")", false);
                }
            }
            
            if (!File.Exists("list.txt")) File.Create("list.txt").Close();
            using (StreamWriter sw = File.AppendText("list.txt")) {
                if (textBox2.Text == "")
                {
                    sw.WriteLine(textBox1.Text + " (" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + ")");
                    sw.Close();
                }
                else
                {
                    if (Convert.ToInt32(textBox2.Text) > 60)
                    {
                        hours = (Convert.ToInt32(textBox2.Text) / 60);
                        minutes = (Convert.ToInt32(textBox2.Text) % 60);
                        sw.WriteLine(textBox1.Text + " (" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + ")" + " Duration : " + hours + " hours " + minutes + " minutes");
                    }
                    else
                    {
                        sw.WriteLine(textBox1.Text + "(" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + ")" + " Duration : " + textBox2.Text + " minutes");
                        sw.Close();
                    }
                }
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string line;
            string target = Convert.ToString(checkedListBox1.SelectedItem);
            if (!File.Exists("buf.txt")) File.Create("buf.txt").Close();
            using (StreamReader sr = new StreamReader("list.txt")){
                line = sr.ReadLine();
                while (line != null){
                    if (line != target) using (StreamWriter sw2 = File.AppendText("buf.txt")) sw2.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }

            File.Delete("list.txt");
            File.Create("list.txt").Close();

            using (StreamReader sr2 = new StreamReader("buf.txt")){
                line = sr2.ReadLine();
                while (line != null){
                    using (StreamWriter sw = File.AppendText("list.txt")) { 
                        sw.WriteLine(line);
                        sw.Close();
                    }
                    line = sr2 .ReadLine();
                }
            }
            File.Delete("buf.txt");

            checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);

            //using (StreamReader fr = new StreamReader("list.txt")){
            //    line = fr.ReadLine();
            //    while (true){
            //        try
            //        {
            //            if (line == null) File.Delete("list.txt");
            //            break;
            //        }
            //        catch
            //        {
            //            break;
            //            //Thread.Sleep(1000);
            //        }
            //    }


            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            if (File.Exists("list.txt")) File.Delete("list.txt");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
