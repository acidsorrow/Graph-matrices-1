using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n = 1;       
        string q = Environment.NewLine;
        List<int> dinosaurs = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            numSize_ValueChanged(sender, e);
            button2.Enabled = true;
            numericUpDown1_ValueChanged(sender, e);
            numericUpDown2_ValueChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            dinosaurs.Clear();
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    sum += Convert.ToInt32(dataGridView1[j, i].Value);
                }
                dinosaurs.Add(sum);
                listBox1.Items.Add(sum);
                
                int h = listBox1.Items.Count;
                String s;
                int t1, k = 0, l = 0;
                int max = dinosaurs.Max();
                for (int i = 0; i < h; i++)
                {
                    s = listBox1.Items[i].ToString();
                    t1 = int.Parse(s);
                    if (max == t1)
                    {
                        k = i;
                        l++;
                    }
                }
                if (l > 1)
                {
                    textBox1.Text = "Нет";
                }
                else
                textBox1.Text = (k + 1).ToString();
            }


        }

        private void numSize_ValueChanged(object sender, EventArgs e)
        {
            button2.Enabled = false;
            n = (byte)numSize.Value;
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;
            //dataGridView2.ColumnCount = n;
            //dataGridView2.RowCount = n;


            //for (int i = 0; i < n; i++)
            //{
            //    dataGridView1.Columns[i].Name = (i + 1).ToString();
            //    dataGridView1.Rows[i]. = (i + 1).ToString();
            //}
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value= (i + 1).ToString();
                dataGridView1.Rows[i].HeaderCell.Style.BackColor = Color.BurlyWood;
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.BurlyWood;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }



            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1[i, j].Value = rand.Next(0, 2);
                    //dataGridView2[i, j].Value = rand.Next(0, 2);
                }
            }
            //for (short j = 0; j < n; j++)
            //{
            //    for (short i = (short)(j + 1); i < n; i++)
            //    {
            //        dataGridView1[i, j].Value = rand.Next(0, 2);
            //    }
            //}
            //for (short i = 0; i < n; i++)
            //{
            //    dataGridView1[i, i].Value = rand.Next(0, 2);
            //    for (short j = (short)(i + 1); j < n; j++)
            //    {
            //        dataGridView1[i, j].Value = rand.Next(0, 2);
            //    }
            //}
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if((byte)numericUpDown1.Value > n)
            {
                MessageBox.Show("Такой вершины не существует");
                button2.Enabled = false;
            }
            else button2.Enabled = true;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if ((byte)numericUpDown2.Value > n)
            {
                MessageBox.Show("Такой вершины не существует");
                button2.Enabled = false;
            }
            else button2.Enabled = true;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if ((byte)numericUpDown2.Value == (byte)numericUpDown1.Value)
            {
                MessageBox.Show("Изменений не будет");
                button2.Enabled = false;
            }
            else
            {             //int n = dataGridView1.ColumnCount;
                          //int m = dataGridView1.RowCount;
                          //dataGridView2.ColumnCount = dataGridView1.ColumnCount;
                          //dataGridView2.RowCount = dataGridView1.RowCount;
                          //int[,] a = new int[n, m];
                          //int[,] b = new int[n, m];
                          //int[,] c = new int[n, m];
                          //int[,] d = new int[n, m];
                          //for (int i = 0; i < n; i++)
                          //    for (int j = 0; j < m; j++)
                          //        a[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
                          //for (int i = 0 ; i < n; i++)
                          //    for (int j = 0; j < m; j++)
                          //        b[i, j] = Convert.ToInt32(dataGridView1[(byte)numericUpDown2.Value-1, j].Value);
                          //for (int i = 0; i < n; i++)
                          //    for (int j = 0; j < m; j++)
                          //        d[i, j] = Convert.ToInt32(dataGridView1[i, (byte)numericUpDown2.Value-1].Value);
                          //for (int i = 0; i < n; i++)
                          //    for (int j = 0; j < m; j++)
                          //        dataGridView2[i, j].Value = SumMatrix(a[i, j], b[i, j], d[i, j]);





                int n = dataGridView1.ColumnCount;
                int m = dataGridView1.RowCount;
                dataGridView2.ColumnCount = dataGridView1.ColumnCount;
                dataGridView2.RowCount = dataGridView1.RowCount;
                int[,] a = new int[n, m];
                int[,] b = new int[n, m];
                int[,] d = new int[n, m];                      
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                         a[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
                         dataGridView2[i, j].Value = a[i, j];
                    }
                for (int i = (byte)numericUpDown1.Value-1; i == ((byte)numericUpDown1.Value-1); i= (byte)numericUpDown2.Value-1)
                    for (int j = 0; j < m; j++)
                    {
                        b[i, j] = Convert.ToInt32(dataGridView1[(byte)numericUpDown1.Value -1, j].Value)+ Convert.ToInt32(dataGridView1[(byte)numericUpDown2.Value-1, j].Value);
                        if (b[i, j] > 1)
                            b[i, j] = 1;
                        dataGridView2[i, j].Value = b[i, j];
                        
                    }
                for (int i = 0; i < n; i++)
                    for (int j = (byte)numericUpDown1.Value-1; j == ((byte)numericUpDown1.Value-1); j = (byte)numericUpDown2.Value-1)
                    {
                        d[i, j] = Convert.ToInt32(dataGridView1[i, (byte)numericUpDown1.Value-1].Value) + Convert.ToInt32(dataGridView1[i, (byte)numericUpDown2.Value-1].Value);
                        if (d[i, j] > 1)
                            d[i, j] = 1;
                        dataGridView2[i, j].Value = d[i, j];

                    }














                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    dataGridView2.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    dataGridView2.Rows[i].HeaderCell.Style.BackColor = Color.BurlyWood;
                }
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    dataGridView2.Columns[i].HeaderCell.Value = (i + 1).ToString();
                    dataGridView2.Columns[i].HeaderCell.Style.BackColor = Color.BurlyWood;
                }
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridView2.Columns.Remove(dataGridView2.Columns[(byte)numericUpDown2.Value - 1]);
                dataGridView2.Rows.Remove(dataGridView2.Rows[(byte)numericUpDown2.Value - 1]);
            }
        }

        //public int SumMatrix(int a, int b, int d)
        //{
        //    int c;
        //    c = a - b - d;
        //    return c;
        //}             
     }
 }

