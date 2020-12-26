using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Lab5;
using System.Text;
using System.Threading.Tasks;

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
            label2.Visible = false;
            textBox4.Visible = false;
            label6.Text = "";
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
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
                char[] seps = { ' ', '.', ',', '?', ')', '(', '!', '\n', '\f', '\t', '/', '\\' };
                resArr = res.Split(seps);
                foreach (string a in resArr)
                {
                    string word = a.Trim();
                    if (!list.Contains(word) && word != "")
                        list.Add(word.ToLower());
                }
                sw.Stop();
                label6.Text = sw.Elapsed.ToString();
                label5.Visible = true;
                label6.Visible = true;
            }
            catch
            {
                label6.Text = "Файл не выбран";
            }
        }

        private List<ParallelSearchResult> SearchThread(object param)
        {
            ParallelSearchThreadParams real_param = param as ParallelSearchThreadParams;
            List<ParallelSearchResult> res = new List<ParallelSearchResult>();
            foreach (string word in real_param.searchList)
            {
                int dis;
                try
                { dis = Fisher.GetLen(word.ToLower(), real_param.wordTemp); }
                catch
                {
                    MessageBox.Show(word.ToLower());
                    continue;
                }
                if (dis <= real_param.maxDist)
                {
                    ParallelSearchResult temp = new ParallelSearchResult()
                    {
                        dist = dis,
                        word = word,
                        threadNum = real_param.threadNum
                    };
                    res.Add(temp);
                }
            }
            return res;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            listBox1.EndUpdate();
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
                label9.Text = sw.Elapsed.ToString();
                sw.Reset();
                if (listBox1.Items.Count == 0)
                {
                    label9.Text = "Не найдено!";
                }
                label8.Visible = true;
                label9.Visible = true;
                listBox1.EndUpdate();
            }
            else
            {
                if (radioButton2.Checked)
                {
                    int thread_c = -1;
                    int dis = -1;
                    try
                    {
                        dis = Convert.ToInt32(textBox4.Text);
                        if (dis <= 0)
                            throw new Exception();

                    }
                    catch
                    {
                        MessageBox.Show("Введите максимальную длину > 0");
                        return;
                    }

                    try
                    {
                        thread_c = Convert.ToInt32(textBox5.Text);
                        if (thread_c <= 0)
                            throw new Exception();

                    }
                    catch
                    {
                        MessageBox.Show("Введите число потоков");
                        return;
                    }

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    List<ParallelSearchResult> results = new List<ParallelSearchResult>();
                    List<MinMax> iterators = SubArrays.DivideSubArrays(0, list.Count, thread_c);
                    int sub_c = iterators.Count;
                    Task<List<ParallelSearchResult>>[] task_list = new Task<List<ParallelSearchResult>>[sub_c];
                    for (int i = 0; i < sub_c; i++)
                    {
                        int delta = iterators[i].max - iterators[i].min;
                        List<string> temp_list = list.GetRange(iterators[i].min, delta);
                        task_list[i] = new Task<List<ParallelSearchResult>>(
                                SearchThread,
                                new ParallelSearchThreadParams()
                                {
                                wordTemp = textBox2.Text,
                                searchList = temp_list,
                                maxDist = dis,
                                threadNum = i
                                }
                            );
                        task_list[i].Start();
                    }
                    Task.WaitAll();
                    sw.Stop();
                    label9.Text = sw.Elapsed.ToString();
                    label11.Text = thread_c.ToString();
                    sw.Reset();
                    for (int i = 0; i < sub_c; i++)
                    {
                        results.AddRange(task_list[i].Result);
                    }
                    listBox1.BeginUpdate();
                    listBox1.Items.Clear();
                    foreach(var el in results)
                    {
                        listBox1.Items.Add(el.word + " [расстояние = " + el.dist.ToString() + " | поток = " + el.threadNum.ToString() + "]");
                    }    
                    listBox1.EndUpdate();
                    if (listBox1.Items.Count == 0)
                    {
                        label9.Text = "Не найдено!";
                        label10.Visible = false;
                        label11.Visible = false;
                    }
                    else
                    {
                        label10.Visible = true;
                        label11.Visible = true;
                    }
                    label8.Visible = true;
                    label9.Visible = true;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            listBox1.EndUpdate();
            label4.Visible = false;
            label2.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            listBox1.EndUpdate();
            label4.Visible = true;
            label2.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            label10.Visible = false;
            label11.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            string log_name = "log_" + DateTime.Now.ToString("dd_MM_yyyy_hhmmss");
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = log_name;
            save.DefaultExt = ".html";
            save.Filter = "HTML Logs|*.html";
            if(save.ShowDialog() == DialogResult.OK)
            {
                str.AppendLine("<html>");
                str.AppendLine("<head>");
                str.AppendLine("<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'/>");
                str.AppendLine("<title> Отчет: " + save.FileName + "</title>");
                str.AppendLine("</head>");
                str.AppendLine("<body>");
                str.AppendLine("<h1>" + "Отчет: " + save.FileName + "</h1>");
                str.AppendLine("<table border='1'>");
                str.AppendLine("<tr>");
                str.AppendLine("<td>Файл</td>");
                str.Append("<td>" + label1.Text + "</td>\n" +
                    "</tr>\n" +
                    "<tr>\n" +
                    "<td>Время открытия файла</td>\n" +
                    "<td>" + label6.Text + "</td>\n" +
                    "</tr>\n" +
                    "<tr>\n" +
                    "<td>Исследуемое слово</td>\n" +
                    "<td>" + textBox2.Text + "</td>\n" +
                    "</tr>\n" + 
                    "<tr>\n" +
                    "<td>Время поиска слова</td>\n" +
                    "<td>" + label9.Text + "</td>\n" +
                    "</tr>\n");
                str.Append(
                      "<tr>\n" +
                      "<td>Метод поиска</td>\n");
                if (radioButton2.Checked == true)
                {
                    str.Append(
                      "<td>Расстояние Левенштайна</td>\n" +
                      "</tr>\n" +
                      "<tr>\n" +
                      "<td>Масксимальная длина</td>\n" +
                      "<td>" + textBox4.Text + "</td>\n" +
                      "</tr>\n" +
                      "<tr>\n" +
                      "<td>Количество потоков</td>\n" +
                      "<td>" + textBox5.Text + "</td>\n" +
                      "</tr>\n" +
                      "<tr>\n" +
                      "<td>Использовано потоков</td>\n" +
                      "<td>" + label11.Text + "</td>\n" +
                      "</tr>\n");
                }
                else if (radioButton1.Checked == true)
                {
                    str.Append(
                      "<td>Поиск подстроки</td>\n" +
                      "</tr>\n");
                }
                str.Append(
                      "<tr valign='top'>\n" +
                      "<td>Результаты поиска</td>\n" +
                      "<td>\n" +
                      "<ul>\n");
                foreach (var word in listBox1.Items)
                {
                    str.AppendLine("<li>" + word.ToString() + "</li>");
                }
                str.AppendLine("</ul>");
                str.AppendLine("</td>");
                str.AppendLine("</tr>");
                str.AppendLine("</table>");
                str.AppendLine("</html>");
                str.AppendLine("</body>");
                File.AppendAllText(save.FileName, str.ToString());
                MessageBox.Show("Отчет был успешно создан в: " + save.FileName);
            }
        }
    }
}
