using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Lab5;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private List<string> list = new List<string>();
        private OpenFileDialog but;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.Clear();
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            listBox1.EndUpdate();
            Stopwatch sw = new Stopwatch();
            but = new OpenFileDialog();
            but.Filter = "Текстовый файл|*.txt";
            but.ShowDialog();
            try
            {
                StreamReader read = new StreamReader(but.FileName);
                sw.Start();
                label1.Text = but.FileName;
                string res = read.ReadToEnd();
                string[] resArr;
                resArr = res.Split();
                foreach (string a in resArr)
                {
                    string word;
                    word = a.Replace(",", "");
                    word = word.Replace(" ", "");
                    word = word.Replace(".", "");
                    word = word.Replace(";", "");
                    word = word.Replace(":", "");
                    word = word.Replace("(", "");
                    word = word.Replace(")", "");
                    if (!list.Contains(word) && word != "")
                        list.Add(word.ToLower());
                }
                sw.Stop();
                textBox1.Text = sw.Elapsed.ToString();
                listBox1.BeginUpdate();
                foreach (string a in list)
                {
                    listBox1.Items.Add(a);
                }
                listBox1.EndUpdate();
            }
            catch
            {
                textBox1.Text = "Файл не выбран";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listBox1.BeginUpdate();
                listBox1.Items.Clear();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Contains(textBox2.Text))
                        listBox1.Items.Add(list[i]);
                }
                sw.Stop();
                textBox3.Text = sw.Elapsed.ToString();
                sw.Reset();
                if (listBox1.Items.Count == 0)
                {
                    textBox3.Text = "Не найдено!";
                }
                listBox1.EndUpdate();
            }
            else
            {
                if (radioButton2.Checked)
                {
                    if (textBox4.Text == "" || Convert.ToInt32(textBox4.Text) <=0)
                    {
                        MessageBox.Show("Введите максимальную длину > 0");
                    }
                    else
                    {
                        listBox1.BeginUpdate();
                        listBox1.Items.Clear();
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (Fisher.GetLen(list[i], textBox2.Text) <= 
                                Convert.ToInt32(textBox4.Text))
                                listBox1.Items.Add(list[i]);
                        }
                        sw.Stop();
                        textBox3.Text = sw.Elapsed.ToString();
                        sw.Reset();
                        if (listBox1.Items.Count == 0)
                        {
                            textBox3.Text = "Не найдено!";
                        }
                        listBox1.EndUpdate();
                    }
                }
            }
        }
    }
}
