﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private List<string> list = new List<string>();
        private OpenFileDialog but;
        public Form1()
        {
            InitializeComponent();
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
            sw.Start();
            but = new OpenFileDialog();
            but.Filter = "Текстовый файл|*.txt";
            but.ShowDialog();
            StreamReader read = new StreamReader(but.FileName);
            label1.Text = but.FileName;
            string res = read.ReadToEnd();
            string[] resArr;
            resArr = res.Split();
            foreach(string a in resArr)
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
                    list.Add(word);
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            textBox1.Text = elapsedTime;
            listBox1.BeginUpdate();
            foreach(string a in list)
            {
                listBox1.Items.Add(a);
            }
            listBox1.EndUpdate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (list.Contains(textBox2.Text))
            {
                listBox1.SetSelected(list.FindIndex(textBox2.Text.StartsWith),true);
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                textBox3.Text = elapsedTime;
            }
            else
            {
                listBox1.ClearSelected();
                textBox3.Text = "Не найдено!";
            }
            sw.Reset();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
