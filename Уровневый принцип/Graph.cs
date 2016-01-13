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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing.Drawing2D;
using System.Collections;




namespace Уровневый_принцип
{
    public class Graph

    {
        protected List<List<int>> A;
        protected List<List<int>> mainA;
        protected List<List<int>> S;
        protected List<List<int>> s;

        protected Random r;

        public Graph()
        {
            A = new List<List<int>>();
            mainA = new List<List<int>>();
            r = new Random();
        }

        protected List<int> ConnectedNode(int el, List<List<int>> A)
        {
            List<int> returning = new List<int>();
            for (int i = 1; i < A.Count; i++)
            {
                if (A[A[0].IndexOf(el)][i] > 0)
                    returning.Add(A[0][i]);
            }
            return returning;
        }

        protected List<int> ConnectedPreviousNode(int el, List<List<int>> A)
        {
            List<int> returning = new List<int>();
            for (int i = 1; i < A.Count; i++)
            {
                if (A[i][A[0].IndexOf(el)] > 0)
                    returning.Add(A[0][i]);
            }
            return returning;
        }

        public virtual void Draw(Graphics g)
        {
            Dictionary<int, Point> Node = new Dictionary<int, Point>();
            g.Clear(Color.Snow);
            int w = 5;
            int x1 = 10, dx = 70;
            int y1 = 10, dy = 70;

            S = FindS(mainA, 0);
            if (S.Count > 0)
            {
                for (int i = 0; i < S.Count; i++)
                {
                    for (int j = 0; j < S[i].Count; j++)
                    {
                        if (!Node.ContainsKey(S[i][j]))
                        {
                            Node.Add(S[i][j], new Point(x1 + dx * j, y1 + dy * i));
                        }                      
                    }
                }

                for (int i = 0; i < S.Count; i++)
                {
                    for (int j = 0; j < S[i].Count; j++)
                    {
                        Point p1 = new Point(), p2;
                        List<int> connected = ConnectedNode(S[i][j], mainA);
                        Color c = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                        Pen pen = new Pen(c, w);                        
                        for (int k = 0; k < connected.Count; k++)
                        {
                            Node.TryGetValue(S[i][j], out p1);
                            Node.TryGetValue(connected[k], out p2);
                            pen.EndCap = LineCap.ArrowAnchor;
                            g.DrawLine(pen, p1, p2);
                        }
                        Node.TryGetValue(S[i][j], out p1);
                        g.DrawString((S[i][j]).ToString(), new Font("Times New Roman", 12.0f), Brushes.Black, p1);
                      //  g.DrawString((mainA[S[i][j]][S[i][j]]).ToString(), new Font("Times New Roman", 12.0f), Brushes.Brown, p1.X - 2*x1, p1.Y);
                        //Size size = new Size(10, 10);
                        //pen.Color = Color.Brown;
                        //pen.Width = 1;
                        //g.DrawRectangle(pen, new Rectangle(new Point(p1.X - 2 * x1, p1.Y - y1), size));
                    }
                }
            }

        }

        protected List<int> AND(List<int> small, List<int> big)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < small.Count; i++)
            {
                if ((big.Contains(small[i])))
                {
                    temp.Add(small[i]);
                }
            }
            return temp;
        }

        public static object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }

        protected virtual List<List<int>> Remove(List<int> index)
        {
            List<List<int>> NEW = new List<List<int>>();
            for (int i = 0; i < A.Count; i++)
            {
                if (!(index.Contains(A[i][0])))
                {
                    List<int> temp = new List<int>();
                    for (int j = 0; j < A[i].Count; j++)
                    {
                        if (!(index.Contains(A[0][j])))
                        {
                            temp.Add(A[i][j]);
                        }
                    }
                    NEW.Add(temp);
                }

            }
            return NEW;
        }

        protected virtual List<List<int>> Remove(List<List<int>> A, List<int> index)
        {
            List<List<int>> NEW = new List<List<int>>();
            for (int i = 0; i < A.Count; i++)
            {
                if (!(index.Contains(A[i][0])))
                {
                    List<int> temp = new List<int>();
                    for (int j = 0; j < A[i].Count; j++)
                    {
                        if (!(index.Contains(A[0][j])))
                        {
                            temp.Add(A[i][j]);
                        }
                    }
                    NEW.Add(temp);
                }

            }
            return NEW;
        }


        protected List<int> LookForNotIn(List<List<int>> A, int flag)
        {
            List<int> a = new List<int>();
            for (int i = 1; i < A.Count(); i++)
            {
                bool IsIn = false;

                if (flag == 1)
                {
                    for (int j = 1; j < A.Count; j++)
                    {
                        if ((A[j][i] != 0) && (i != j)) { IsIn = true; }
                    }
                }

                if (flag == 0)
                {
                    for (int j = 1; j < A.Count; j++)
                    {
                        if ((A[i][j] != 0) && (i != j)) { IsIn = true; }
                    }
                }

                if (!IsIn) { a.Add(A[i][0]); }
            }
            return a;
        }

        public bool Check()
        {
            List<List<int>> ss = FindS(mainA, 0);
            if (ss == null)
            {
                return false;
            }
            return true;
        }

        protected virtual List<List<int>> FindS(List<List<int>> a, int flag)
        {
            int acount = a.Count;
            List<List<int>> s = new List<List<int>>();

            while (a.Count() > 1)
            {
                if (s.Count > acount)
                {
                    MessageBox.Show("Граф має бути ациклічним та не мати петель!");
                    return null;
                }
                List<int> temp = new List<int>();
                temp = LookForNotIn(a, flag);
                // if (flag == 1) temp = LookForNotIn(a, 1); //орграфі G шукаємо вершини, які не мають вхідних (вихідних) дуг 
                // if (flag == 0) temp = LookForNotIn(a, 0); //орграфі G шукаємо вершини, які не мають вхідних (вихідних) дуг
                s.Add(temp);                              //записуємо їх на k-те місце в S

                List<List<int>> newA = new List<List<int>>();
                List<int> Aa = new List<int>();
                for (int i = 0; i < a.Count(); i++)
                {
                    if (temp.Contains(a[i][0]))        //пропускаємо запис тих вершин, які додали в упорядкування S
                        continue;
                    else
                    {
                        Aa.Add(a[i][0]);
                    }
                }
                newA.Add(Aa);

                for (int i = 1; i < a.Count(); i++)
                {
                    List<int> temp1 = new List<int>();
                    temp1.Add(a[i][0]);
                    for (int j = 1; j < a.Count(); j++)
                    {
                        //if ((temp.Contains(i)) || (temp.Contains(j)))
                        if ((temp.Contains(a[i][0])) || (temp.Contains(a[j][0])))
                            continue;
                        else
                        {
                            temp1.Add(a[i][j]);
                        }
                    }
                    if (temp1.Count() > 1)
                    {
                        newA.Add(temp1);
                    }
                }
                a = newA;
            }
            if (flag == 0)
            {
                List<List<int>> sInvers = new List<List<int>>();
                for (int i = s.Count() - 1; i >= 0; i--)
                {
                    sInvers.Add(s[i]);
                }
                return sInvers;
            }
            return s;
        }

        public bool ReadFromFile()
        {
            Excel.Application App = new Excel.Application();
            Excel.Range rng = null;
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Excel Worksheets|*.xls;*.xlsx;*.xlsm;*.csv";
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //App = new Excel.Application();
                App.Visible = true;
                App.Workbooks.Open(OFD.FileName);
            }
            else { return false; }

            try { rng = (Excel.Range)App.InputBox("Оберіть діапазон", "Range Selection", Type: 8); }
            catch { } // user pressed cancel on input box

            if (rng != null)
            {
                mainA.Clear();
                A.Clear();
                for (int i = 0; i < rng.Columns.Count; i++)
                {
                    List<int> temp = new List<int>();
                    for (int j = 0; j < rng.Columns.Count; j++)
                    {
                        temp.Add(Convert.ToInt32(rng.Cells[i + 1, j + 1].Value2));
                    }
                    A.Add(temp);
                    mainA.Add(temp);
                }
            }

            try { Marshal.ReleaseComObject(rng); }
            catch { }
            finally { rng = null; }
            try { App.Quit(); Marshal.ReleaseComObject(App); }
            catch { }
            finally { App = null; }
            if (A.Count > 0)
            {
                return true;
            }
            return false;

        }

        public void ReadFromTable(DataGridView dg_enter)
        {
            int n = dg_enter.Rows.Count;
            if (dg_enter.Rows[n - 1].Cells[0].Style.BackColor == Color.Snow)
            {
                n = dg_enter.Columns.Count - 1;
            }
            List<int> Aa = new List<int>();
            for (int i = 0; i < n + 1; i++)
            {
                Aa.Add(i);
            }
            mainA.Add(Aa);
            A.Add(Aa);

            //try
            //{
            for (int i = 0; i < n; i++)
            {
                List<int> temp = new List<int>();
                temp.Add(i + 1);
                for (int j = 0; j < n; j++)
                {
                    temp.Add(Convert.ToInt32(dg_enter.Rows[i].Cells[j].Value));
                }
                mainA.Add(temp);
                A.Add(temp);
            }
            //}
            //catch { ;}
        }


        public void UpdateDG(DataGridView dg_enter)
        {

            if (A.Count > 0)
            {
                dg_enter.RowHeadersWidth = 60;
                dg_enter.RowCount = A.Count - 1;
                dg_enter.ColumnCount = A.Count - 1;

                for (int i = 0; i < A.Count - 1; i++)
                {
                    dg_enter.Columns[i].Width = 22;

                    dg_enter.Columns[i].HeaderText = (A[i + 1][0]).ToString();
                    dg_enter.Rows[i].HeaderCell.Value = (A[i + 1][0]).ToString();
                }
                for (int i = 0; i < A.Count - 1; i++)
                {
                    for (int j = 0; j < A.Count - 1; j++)
                    {

                        dg_enter.Rows[i].Cells[j].Value = A[i + 1][j + 1].ToString();
                        dg_enter.Rows[i].Cells[j].Style.BackColor = Color.White;
                        dg_enter.Rows[i].Cells[j].Style.ForeColor = Color.SaddleBrown;


                    }
                }
            }


        }


    }
}
