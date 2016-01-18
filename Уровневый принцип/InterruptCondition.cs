using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Уровневый_принцип
{
    class InterruptCondition : LevelPrincipleForTi
    {

        List<List<int>> combination;

        public InterruptCondition() : base() { }

        void generateCombinations(int summaryDuration, List<int> vs)
        {

            combination = GetPowerSet(vs) as List<List<int>>;
            for (int i = 0; i < combination.Count; i++)
            {
                if (getSummaryDuration(combination[i]) != summaryDuration)
                {
                    combination.Remove(combination[i]);
                    i--;
                }
            }

        }

        int getSummaryDuration(List<int> list)
        {
            int sum = 0;
            foreach (int v in list)
            {
                sum += A[v][v]; //не правильно!!!
            }
            return sum;
         
        }

        public static List<List<int>> GetPowerSet(List<int> list)
        {
            List<List<int>> ps = new List<List<int>>();
            ps.Add(new List<int>());   // add the empty set

            // for every item in the original list
            foreach (int item in list)
            {
                List<List<int>> newPs = new List<List<int>>();

                foreach (List<int> subset in ps)
                {
                    // copy all of the current powerset's subsets
                    newPs.Add(subset);

                    // plus the subsets appended with the current item
                    List<int> newSubset = new List<int>(subset);
                    newSubset.Add(item);
                    newPs.Add(newSubset);
                }

                // powerset is now powerset of list.subList(0, list.indexOf(item)+1)
                ps = newPs;
            }
            return ps;
        }

        List<int> getPossibleVs(int mUpIPlusOne)
        {
            List<int> rez = new List<int>();
            for (int i = mUpIPlusOne; i < s.Count - 1; i++)
            {
                foreach (int j in s[i])
                    if (!s[i - 1].Contains(j)) //якщо вершини немає на попередньому рівні, тобто, мю стартове
                    {
                        rez.Add(j);
                    }
            }

            return rez;
        }

        int getmUpStart(int v)
        {
            for (int i = 0; i < S.Count; i++)
            {

                // if (S[i].Contains(v))
                if (s[i].Contains(v))
                {
                    return i;
                }
                
            }

            return -1;
        }

        int getmDownStart(int v)
        {
            for (int i = 0; i < s.Count; i++)
            {

                if (s[i].Contains(v))
                {
                    return i;
                }

            }

            return -1;
        }

        int getmUpFinish(int v)
        {
            for (int i = S.Count - 1; i >= 0; i--)
            {

                if (S[i].Contains(v))
                {
                    return i;
                }

            }

            return -1;
        }
        void checkFirstPlace(int mUpIPlusOne)
        {
            for (int i = 0; i < combination.Count; i++)
            {
                List<int> muSet = new List<int>();
                foreach (int v in combination[i])
                {
                    muSet.Add(getmDownStart(v));
                }
                if (muSet.Min()!= mUpIPlusOne)
                {
                    combination.Remove(combination[i]);
                    i--;
                }
            }
        }

        List<int> getMaxFinishTime(List<int> vs)
        {
            Dictionary<int, int> muSet = new Dictionary<int, int>(); // v, mu
            foreach (int v in vs)
            {
                muSet.Add(v, getmUpFinish(v));
            }
            List<int> maxV = new List<int>();
            int max = -1;
            foreach (int v in muSet.Keys)
            {
                int mu;
                muSet.TryGetValue(v, out mu);
                if ( mu > max) //зараз додається лише одна вершина. напевно треба всі
                {
                    max = mu;
                    maxV.Clear();
                    maxV.Add(v);
                }

            }
            return maxV;

        }

        int existR(int I, List<int> maxFinishTime, List<int> vs_)
        {
            List<int> freeV = new List<int>();
            for (int i = 1; i < A.Count; i++) //all v
            {
                int v = A[i][0];
                if ((!vs_.Contains(v)) && (v != I))
                {
                    //чи є в її попередниках вершина з максимальним часом завершення
                    List<int> prev = ConnectedPreviousNode(v, mainA);
                    foreach (int max in maxFinishTime)
                    {
                        if (prev.Contains(max))
                        {
                            if (!ConnectedNode(I, mainA).Contains(v))
                            {
                                return v;
                            }
                        }
                                                    
                    }
                }
            }
            return -1;
        }


        void checkLastPlace(int I)
        {
            for (int i = 0; i < combination.Count; i++)
            {
                List<int> maxV = getMaxFinishTime(combination[i]);
                if (existR(I, maxV, combination[i]) < 0)
                {
                    combination.Remove(combination[i]);
                    i--;
                }
            }
        }

        public bool canInterrupt()
        {
            A = DeepClone(mainA) as List<List<int>>;
            s = FindS(A, 1);
            S = FindS(A, 0);

            A = DeepClone(mainA) as List<List<int>>;
            for (int i = 0; i < A.Count; i++) //all v
            {
                if (A[i][i] < 2)
                {
                    continue;
                }
                int m = A[i][i];

                int mUpStart = getmUpStart(A[i][0]);
                List<int> possibleVs = getPossibleVs(mUpStart + 1); //беремо вершини, що починаються на рівень пізніше за поточну, і завершуються не на останньому кроці

                generateCombinations(m, possibleVs);
                checkFirstPlace(mUpStart + 1);
                checkLastPlace(A[i][0]);
                if (combination.Count > 0)
                {
                    return true;
                }

            }
                        
            return false;

    }
    }

}
