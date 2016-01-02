using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Уровневый_принцип
{
    class InterruptCondition : LevelPrinciple
    {

        public InterruptCondition() : base() { }


        protected override List<List<int>> FindS(List<List<int>> originalA, int flag)
        {

            List<List<int>> a = DeepClone(originalA) as List<List<int>>;
            int acount = a.Count;
            List<List<int>> s = new List<List<int>>();

            while (a.Count() > 1)
            {
                if (s.Count > acount)
                {
                    MessageBox.Show("Граф має бути ациклічним та не мати петель!");
                    return null;
                }
                List<int> NotInItems = new List<int>();
                if (flag == 1) NotInItems = LookForNotIn(a, 1); //орграфі G шукаємо вершини, які не мають вхідних (вихідних) дуг 
                if (flag == 0) NotInItems = LookForNotIn(a, 0); //орграфі G шукаємо вершини, які не мають вхідних (вихідних) дуг
                s.Add(DeepClone(NotInItems) as List<int>);                              //записуємо їх на k-те місце в S

                for (int i = 0; i < a.Count; i++)
                {
                    if (NotInItems.Contains(a[i][0]))
                    {
                        a[i][i]--;
                        if ((a[i][i]) > 0)
                        {
                            NotInItems.Remove(a[i][0]);
                        }

                    }
                }
                List<List<int>> newA = new List<List<int>>();
                List<int> Aa = new List<int>();
                for (int i = 0; i < a.Count(); i++)
                {
                    if (NotInItems.Contains(a[i][0]))
                    {
                        continue;
                    }
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

                        if ((NotInItems.Contains(a[i][0])) || (NotInItems.Contains(a[j][0])))
                        {
                            continue;
                        }

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
                
        public  void Build1()
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
                for (int j = 0; j < h[i]; j++) // не более, чем hi раз             каждый раз добавляем по одной вершине
                {

                    //брать из S[0] уже нечего 
                    if ((S0.Count == 0) || (j == 0))
                    {
                        if (k < S.Count) //длина искомого упорядочения не может быть больше числа вершин
                        {
                            //если еще остасли вершины, которые можно было ставить на прошлом шаге, то ставим их
                            //иначе, т.е. если (S0.Count == 0), ищем новые
                            if (S0.Count == 0)
                            {
                                S0 = AND(S[k], s[0]);
                                k++;
                            }

                        }
                        else
                        {                           
                            break;
                        }
                    }
                    if (S0.Count > 0)
                    {
                        //берем не рандомные, а те, которые стояли на прошлом шаге.
                        //это не делает хуже, т.к. можно брать любые.
                        int t = findBestFitEasy(S0, Rez);

                        //если попалась вершина, которая уже стоит на этом месте - берем следующую.
                        //в такую ситуацию попадаем из-за того, что вершину с длительностью больше 1
                        //по сути представляем просто как цепочку независимых вершин.
                        if (index.Contains(S0[t])) //TODO find something better
                        {
                            j--;
                        }

                        //добавляем вершину в упорядочение
                        else
                        {
                            index.Add(S0[t]);
                        }

                        //удаляем вершину с списка вершин-кандидатов
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

        int findBestFitEasy(List<int> S0, List<List<int>> Rez)
        {
            if (Rez.Count > 1)
            {
                for (int i = 0; i < S0.Count; i++)
                {
                    if (Rez[Rez.Count - 1].Contains(i))
                    {
                        return i;
                    }
                }
                
            }
            return r.Next(0, S0.Count);

        }

        int findAny(List<int> V)
        {
            return r.Next(0, V.Count);

        }

        int findBestFitEuristic(List<int> S0, List<int> fromPrevious, List<int> nessesary, List<List<int>> Rez)
        {
            if (Rez.Count > 1)
            {
               // List<int> sorted = S0.

            }
            return r.Next(0, S0.Count);

        }

        List<int> fromPreviousLevel(List<List<int>> Rez)  //return all ver from previous level from rezult which are still exsist
        {
            List <int> newv = new List<int>();
            if (Rez.Count > 1)
            {
                for (int i=0; i < Rez[Rez.Count - 1].Count; i++)
                {
                    try
                    {
                        if (A[Rez[Rez.Count - 1][i]][0] > 0)
                        {
                            newv.Add(Rez[Rez.Count - 1][i]);
                        }
                    }
                    catch { }
                }
            }
            return newv;
        }


        //  public void BuildEuristic()
        public override void Build()
        {
            A = DeepClone(mainA) as List<List<int>>;
            int l = FindS(A, 1).Count;

            while (true)  //for l0
            {
                Rez.Clear();
                List<int> index = new List<int>(); // номера вершин, которые мы занесли в упорядочение на это место hi
                List<int> S0 = new List<int>();
                List<int> fromPrevious = new List<int>();
                List<int> nessesary = new List<int>();



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
                    //находим вершины, которые поставили в упорядочение на прошлом шаге,
                    //и которые еще существуют
                    fromPrevious = fromPreviousLevel(Rez);

                    //вершины, которые ставить необхдимо из-за того, что на этом шаге у них заканчивается мю.
                    nessesary = findNessesary(l, i, A);

                    for (int j = 0; j < h[i]; j++) // не более, чем hi раз             каждый раз добавляем по одной вершине
                    {



                        //остальное как обычно в уровневом

                        //брать из S[0] уже нечего 
                        if ((S0.Count == 0) || (j == 0))
                        {
                            if (k < S.Count) //вспомнить бы, зачем на самом деле тут k
                            {

                                //если еще остаслись вершины, которые можно было ставить на прошлом шаге, то ставим их
                                //иначе, т.е. если (S0.Count == 0), ищем новые
                                if (S0.Count == 0)
                                {
                                    S0 = AND(S[k], s[0]);
                                    k++;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }
                        if ((S0.Count > 0) || (nessesary.Count > 0) || (fromPrevious.Count > 0))
                        {

                            int t;
                            if (nessesary.Count > 0)
                            {
                                t = findAny(nessesary);
                                if (index.Contains(nessesary[t])) //TODO find something better
                                {
                                    j--;
                                }
                                //добавляем вершину в упорядочение
                                else
                                {
                                    index.Add(nessesary[t]);
                                }
                                //удаляем вершину с списка вершин-кандидатов
                                nessesary.RemoveAt(t);

                            }
                            else
                            {
                                if (fromPrevious.Count > 0)
                                {
                                    t = findAny(fromPrevious);
                                    if (index.Contains(fromPrevious[t])) //TODO find something better
                                    {
                                        j--;
                                    }

                                    //добавляем вершину в упорядочение
                                    else
                                    {
                                        index.Add(fromPrevious[t]);
                                    }

                                    //удаляем вершину с списка вершин-кандидатов
                                    fromPrevious.RemoveAt(t);

                                }

                                else
                                {

                                    //было в не эвристическом
                                    //берем не рандомные, а те, которые стояли на прошлом шаге.
                                    //это не делает хуже, т.к. можно брать любые.
                                    t = findBestFitEasy(S0, Rez);

                                    //если попалась вершина, которая уже стоит на этом месте - берем следующую.
                                    //в такую ситуацию попадаем из-за того, что вершину с длительностью больше 1
                                    //по сути представляем просто как цепочку независимых вершин.
                                    if (index.Contains(S0[t])) //TODO find something better
                                    {
                                        j--;
                                    }

                                    //добавляем вершину в упорядочение
                                    else
                                    {
                                        index.Add(S0[t]);
                                    }

                                    //удаляем вершину с списка вершин-кандидатов
                                    S0.RemoveAt(t);
                                }
                            }
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

        }


        //проверяем, есть ли вершины, которые ставить необхдимо из-за того, что на этом шаге у них заканчивается мю. 
        List<int> findNessesary(int length, int step, List<List<int>> A)
        {
            List<int> result = new List<int>();

            List<List<int>> Mu = FindMu(A, length - step + 1);
            for (int i = 0; i < A.Count; i++)
            {
                int t = A[i][0];
                if (Mu[i][Mu[i].Count - 1] == step)
                {
                    result.Add(t);
                }
            }
            return result;
        }


        protected override List<List<int>> Remove(List<int> index)
        {

            for (int i = 0; i < A.Count; i++)
            {
                if (index.Contains(A[i][0]))
                {
                    A[i][i]--;
                    if ((A[i][i]) > 0)
                    {
                        index.Remove(A[i][0]);
                    }

                }
            }

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


        List<List<int>> FindMu(List<List<int>> A, int l0)
        {
            List<List<int>> S = FindS(A, 1); if (S == null) { return null; }
            List<List<int>> s = FindS(A, 0);
            int delta = l0 - s.Count;
            List<List<int>> returning = new List<List<int>>();
            int count = 0;
            for (int i = 0; i < s.Count(); i++)
            {
                for (int j = 0; j < s[i].Count(); j++) //просто для всех элементов, не важно с какого с.
                {
                    count++;
                }
            }

            int m = 0;
            int M = 0;
            List<int> t = new List<int>();
            t.Add(-1);
            returning.Add(t);

            for (int i = 1; i <= count; i++)
            {
                List<int> temp = new List<int>();
                M = Mm(s, i);
                m = Mm(S, i);
                for (int k = m; k <= M + delta; k++)
                {
                    temp.Add(k);
                }
                returning.Add(temp);
            }
            return returning;
        }

        int Mm(List<List<int>> s, int num)  // I don't remember why does it have such name, it was 3 years ago
        {
            for (int i = 0; i < s.Count(); i++)
            {
                if (s[i].Contains(num))
                {
                    return i + 1;
                }
            }
            return -1;
        }
    }
}
