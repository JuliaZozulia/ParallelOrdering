using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data.Odbc;
using System.Threading;
using System.IO;

namespace Уровневый_принцип
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        //LevelPrinciple G;
        Graph G;
        bool IsConst = false;
        bool FromFile = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            dg_h.ColumnCount = 1;
            dg_h.Columns[0].Width = 22;
            dg_h.ColumnHeadersVisible = false;
            dg_h.RowHeadersVisible = false;
            dg_enter.RowCount = 1;
            dg_enter.Columns[0].Width = 22;
            dg_enter.RowHeadersWidth = 60;
            dg_h.RowCount = 1;
            dg_enter.AllowUserToAddRows = true;
            //  dg_enter.RowCount = 1;
          //  dg_h.Rows[0].Cells[0].Value = 2;
        }


        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            FromFile = true;
            G = new Graph();
            G.ReadFromFile();
            G.UpdateDG(dg_enter);
            FromFile = false;
            if (!G.Check())
            {
                G = null;
                return;
            }
            Graphics g = panel1.CreateGraphics();
            G.Draw(g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (G != null)
            {
                G = new LevelPrincipleForTi();
                Build();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                dg_h.AllowUserToAddRows = false;
                dg_h.RowCount = 1;
                label2.Text = "h =";
                IsConst = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dg_h.AllowUserToAddRows = true;
                label2.Text = "h[i]=";
                IsConst = false;
            }
        }

        private void dg_h_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (G == null)
            {
                G = new Graph();
            }
            G.ReadFromTable(dg_enter);
            G.UpdateDG(dg_enter);
            if (!G.Check())
            {
                G = null;
                return;
            }
            Graphics g = panel1.CreateGraphics();
            G.Draw(g);
        }

        private void dg_enter_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!FromFile)
            {
                dg_enter.ColumnCount = dg_enter.Rows.Count;
                for (int i = 0; i < dg_enter.ColumnCount - 1; i++)
                {
                    dg_enter.Rows[i].Visible = true;
                    dg_enter.Columns[i].Visible = true;
                    for (int j = 0; j < dg_enter.ColumnCount - 1; j++)
                    {
                        dg_enter.Rows[i].Cells[j].Style.BackColor = Color.White;
                        dg_enter.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }

                }

                dg_enter.Columns[dg_enter.Rows.Count - 1].Width = 22;
                dg_enter.Rows[dg_enter.Rows.Count - 1].Cells[dg_enter.Rows.Count - 1].Value = 0;
                dg_enter.Rows[dg_enter.Rows.Count - 1].Cells[dg_enter.Rows.Count - 1].Style.BackColor = Color.Snow;
                dg_enter.Rows[dg_enter.Rows.Count - 1].Cells[dg_enter.Rows.Count - 1].Style.ForeColor = Color.Snow;
                dg_enter.Columns[dg_enter.Rows.Count - 1].HeaderText = Convert.ToString(dg_enter.Rows.Count);
                dg_enter.Rows[dg_enter.Rows.Count - 1].HeaderCell.Value = Convert.ToString(dg_enter.Rows.Count);
                for (int i = 0; i < dg_enter.ColumnCount - 1; i++)
                {
                    dg_enter.Rows[dg_enter.Rows.Count - 1].Cells[i].Value = 0;
                    dg_enter.Rows[i].Cells[dg_enter.Rows.Count - 1].Value = 0;
                    dg_enter.Rows[i].Cells[dg_enter.Rows.Count - 1].Style.BackColor = Color.Snow;
                    dg_enter.Rows[dg_enter.Rows.Count - 1].Cells[i].Style.BackColor = Color.Snow;
                    dg_enter.Rows[i].Cells[dg_enter.Rows.Count - 1].Style.ForeColor = Color.Snow;
                    dg_enter.Rows[dg_enter.Rows.Count - 1].Cells[i].Style.ForeColor = Color.Snow;
                }

            }

        }

        private void dg_enter_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // dg_enter.ColumnCount = dg_enter.RowCount;
            dg_enter.Columns.RemoveAt(e.RowIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (G != null)
            {
                G = new Decomposition();
                Build();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (G != null)
            {
                G = new InterruptCondition();               
                Build();
                InterruptCondition g1 = new InterruptCondition(); //really sorry for this
                g1.ReadFromTable(dg_enter);
                g1.canInterrupt();

                if (g1.canInterrupt())
                {
                    label3.Text = "Отримане впорядкування \nз перериваннями \nДовжина - " + dg_Smin.RowCount.ToString();
                    label4.Text = "Оптимальне впорядкування належить до класу\nвпорядкувань з перериваннями.";
                }
                else
                {
                    dg_Smin.Visible = false;
                }
                dg_Smax.Visible = false;


                //InterruptCondition
            }
        }

        void Build()
        {
            G.ReadFromTable(dg_enter);
            Graphics g = panel1.CreateGraphics();
            G.Draw(g);
            G.SetH(dg_h, IsConst);
            G.FindMaxMin(1000);
            G.S_DG_Max(dg_Smax);
            G.S_DG_Min(dg_Smin);
            label3.Text = "З мінімальною довжиною \n впорядкування. \n Довжина - " + dg_Smin.RowCount.ToString();
            label4.Text = "З максимальною довжиною \n впорядкування. \n Довжина - " + dg_Smax.RowCount.ToString();
        }
    }
}
