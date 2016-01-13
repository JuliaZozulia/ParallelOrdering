using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Уровневый_принцип
{
    class LevelPrinciple : Graph
    {
        public List<List<int>> Rez;
        public List<List<int>> Smin = new List<List<int>>();
        public List<List<int>> Smax = new List<List<int>>();

        protected List<int> h;

        public LevelPrinciple() : base()
        {

            h = new List<int>();
            Rez = new List<List<int>>();
        }

        virtual public void Build()
        {
            A = DeepClone(mainA) as List<List<int>>;

            Rez.Clear();
            List<int> index = new List<int>(); // номера вершин, которые мы занесли в упорядочение на это место hi
            List<int> S0 = new List<int>();
            for (int i = 0; i < h.Count; i++) //для всех hi
            {

                if (index.Count > 0)
                {
                    Rez.Add(DeepClone(index) as List<int>);
                }

                A = Remove(index);
                index.Clear();
                if (A.Count == 0)
                {
                    return;
                }
                S = FindS(A, 0);
                s = FindS(A, 1);
                int k = 0;
                for (int j = 0; j < h[i]; j++) // не более, чем hi раз
                {
                    if ((S0.Count == 0) || (j == 0)) //брать из S[0] уже нечего
                    {
                        if (k < S.Count)
                        {
                            S0 = AND(S[k], s[0]);
                            k++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (S0.Count > 0)
                    {
                        int t = r.Next(0, S0.Count);
                        index.Add(S0[t]);
                        S0.RemoveAt(t);
                    }


                }
            }
            if (index.Count > 0)
            {
                Rez.Add(DeepClone(index) as List<int>);
                A = Remove(index);

            }
            if (A.Count > 1)
            {
                Rez.Clear();
            }

        }


        public void FindMaxMin(int n)
        {
            int max = 0;
            int min = System.Int32.MaxValue;

            for (int i = 0; i < n; i++)
            {
                Build();
                if (Rez.Count >= max)
                {
                    max = Rez.Count;
                    Smax = DeepClone(Rez) as List<List<int>>;
                }
                if (Rez.Count <= min)
                {
                    min = Rez.Count;
                    Smin = DeepClone(Rez) as List<List<int>>;
                }

            }
        }

        public void S_DG_Max(DataGridView dg_enter)
        {
            dg_enter.ColumnHeadersVisible = false;
            dg_enter.RowHeadersVisible = false;
            dg_enter.Rows.Clear();
            if (Smax.Count > 0)
            {

                dg_enter.RowCount = Smax.Count;
                dg_enter.ColumnCount = FinfMaxItem(h);

                for (int i = 0; i < Smax.Count; i++)
                {
                    for (int j = 0; j < Smax[i].Count; j++)
                    {
                        dg_enter.Rows[i].Cells[j].Value = Smax[i][j];
                    }
                    for (int j = 0; j < h[i]; j++)
                    {
                        dg_enter.Columns[j].Width = 30;
                        dg_enter.Rows[i].Cells[j].Style.BackColor = Color.MistyRose;
                    }
                }


            }
        }
        public void S_DG_Min(DataGridView dg_enter)
        {
            dg_enter.ColumnHeadersVisible = false;
            dg_enter.RowHeadersVisible = false;
            dg_enter.Rows.Clear();
            if (Smin.Count > 0)
            {

                dg_enter.RowCount = Smin.Count;
                dg_enter.ColumnCount = FinfMaxItem(h);
                for (int i = 0; i < Smin.Count; i++)
                {
                    for (int j = 0; j < Smin[i].Count; j++)
                    {
                        dg_enter.Rows[i].Cells[j].Value = Smin[i][j];
                    }
                    for (int j = 0; j < h[i]; j++)
                    {
                        dg_enter.Columns[j].Width = 30;
                        dg_enter.Rows[i].Cells[j].Style.BackColor = Color.MistyRose;
                    }
                }
            }
        }
        public void SetH(DataGridView dg_enter, bool flag)
        {
            h.Clear();
            if (flag)
            {
                int H = 0;
                try
                {
                    H = Convert.ToInt32(dg_enter.Rows[0].Cells[0].Value.ToString());
                }
                catch
                {; }
                for (int i = 0; i < A.Count; i++)
                {
                    h.Add(H);
                }
            }
            else
            {
                for (int i = 0; i < dg_enter.RowCount - 1; i++)
                {
                    try
                    {
                        h.Add(Convert.ToInt32(dg_enter.Rows[i].Cells[0].Value.ToString()));
                    }
                    catch {; }
                }
            }
        }

        int FinfMaxItem(List<int> l)
        {
            int m = 0;
            for (int i = 0; i < l.Count; i++)
            {
                if (m < l[i])
                {
                    m = l[i];
                }
            }
            return m;
        }


    }

}
