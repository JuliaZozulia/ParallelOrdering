using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Уровневый_принцип
{
    class Decomposition : LevelPrinciple
    {
        List<List<int>> spanningTree;
        List<Point> listSpanningTree;
        List<Point> gMinusSpanningTree;
        public List<Point> conflictPairs;
        public Decomposition() : base() { return; }

        private void resetMatrix(List<List<int>> A)
        {
            for (int i = 0; i < A.Count - 1; i++)
            {
                for (int j = 0; j < A.Count - 1; j++)
                {
                    A[i + 1][j + 1] = 0;
                }
            }
        }

        void getAnySpanningTree()
        {
            gMinusSpanningTree = new List<Point>();

            spanningTree = new List<List<int>>();
            spanningTree = DeepClone(mainA) as List<List<int>>;
            resetMatrix(spanningTree);
            // resetMatrix(gMinusSpanningTree);
            for (int i = 1; i < mainA.Count; i++)
            {
                List<int> connected = ConnectedNode(mainA[i][0], mainA);

                if (connected.Count > 0)
                {
                    int t = r.Next(0, connected.Count - 1);
                    spanningTree[i][connected[t]] = 1;                  //for level principle
                    //   listSpanningTree.Add(new Point(i, connected[t]));   //more convinient to futher calculation
                    foreach (int c in connected)
                    {
                        if (c != t)
                        {
                            //gMinusSpanningTree[i][connected[c]] = 1;
                            gMinusSpanningTree.Add(new Point(i, c));
                        }
                    }
                }
            }
        }

        int LevelOfV(List<List<int>> Rez, int v)
        {
            foreach (List<int> l in Rez)
            {
                if (l.Contains(v))
                {
                    return Rez.IndexOf(l);
                }
            }
            return 0;
        }

        List<Point> getAllConflicts()
        {
            List<Point> conflictPairs = new List<Point>();
            foreach (Point p in gMinusSpanningTree)
            {
                if (LevelOfV(Rez, p.X) >= LevelOfV(Rez, p.Y))
                {
                    conflictPairs.Add(p);
                }
            }
            return conflictPairs;
        }

        int canSwitchPrev(int currentLevel)
        {
            // п.3. Якщо на попередньому місці в упорядкуванні є вершина 𝑡, 
            //яка не має наступників на поточному місці
            if (currentLevel == 0)
            {
                return -1;
            }
            foreach (int candidate in Rez[currentLevel - 1])
            {
                if (!hasNextOnLevel(candidate, currentLevel))
                {
                    return candidate;
                }
            }
            return -1;
        }

        bool hasPreOnLevel(int v, int currentLevel)
        {

            List<int> connected = ConnectedPreviousNode(v, mainA);
            foreach (int con in connected)
            {
                if (LevelOfV(Rez, con) == currentLevel)
                {
                    return true;
                }
            }
            return false;
        }

        bool hasNextOnLevel(int v, int currentLevel)
        {

            List<int> connected = ConnectedNode(v, mainA);
            foreach (int con in connected)
            {
                if (LevelOfV(Rez, con) == currentLevel)
                {
                    return true;
                }
            }
            return false;
        }

        int canSwitchNext(int currentLevel)
        {
            // п.4.	Якщо на наступному місці в упорядкуванні є вершина 𝑡, 
            // яка не має попередників на поточному місці
            if (currentLevel == Rez.Count - 1)
            {
                return -1;
            }
            foreach (int candidate in Rez[currentLevel + 1])
            {
                if (!hasPreOnLevel(candidate, currentLevel))
                {
                    return candidate;
                }
            }
            return -1;
        }

        void SwitchVs(int v1, int v2)
        {
            int l1 = LevelOfV(Rez, v1);
            int l2 = LevelOfV(Rez, v2);
            Rez[l1].Remove(v1);
            Rez[l2].Add(v1);

            Rez[l2].Remove(v2);
            Rez[l1].Add(v2);

        }

        List<List<int>> getCurrentMatrix(int currentLevel) //те, що залишилося 
        {
            List<List<int>> temp = DeepClone(mainA) as List<List<int>>;
            for (int i = 0; i <= currentLevel; i++)
            {
                temp = Remove(temp, Rez[i]);
            }
            return temp;
        }

        override public void Build()
        {

            getAnySpanningTree();

            List<List<int>> temp = DeepClone(mainA) as List<List<int>>;
            mainA = spanningTree;
            base.Build(); //into Rez
            mainA = temp;

            if (Rez.Count == 0)
            {
                return;
            }
            //   getAllConflicts();
            while (getAllConflicts().Count > 0)
            {
                conflictPairs = getAllConflicts();
                Point conf = conflictPairs[0]; //TODO: в загальному випадку ітератор просто по конфліктним парам навряд чи гарна ідея. Але має процювати.
                int currentLevel = LevelOfV(Rez, conf.X); //TODO: меншого за рівнем з пари

                if (LevelOfV(Rez, conf.X) > LevelOfV(Rez, conf.Y))
                {
                    Rez.Insert(currentLevel + 1, new List<int>());
                    Rez[LevelOfV(Rez, conf.Y)].Remove(conf.Y);
                    Rez[currentLevel + 1].Add(conf.Y);
                    conflictPairs.Remove(conf);
                    continue;
                }

                int t = -1;
                if (currentLevel > 1)
                {
                    if (!hasPreOnLevel(conf.X, currentLevel - 1))
                    {
                        if (Rez[currentLevel - 1].Count < h[0])
                        {
                            Rez[currentLevel - 1].Add(conf.X);
                            Rez[currentLevel].Remove(conf.X);
                            conflictPairs.Remove(conf);
                            //вільне місце!
                            continue;
                        }
                        t = canSwitchPrev(currentLevel);
                        if (t != -1)
                        {
                            // п.4. Міняємо місцями початкову вершину зі знайденого конфлікту, і вершину 𝑡. 
                            SwitchVs(t, conf.X);
                            conflictPairs.Remove(conf);
                            continue;

                        }
                    }

                }


                if (currentLevel < Rez.Count - 1)
                {

                    if (!hasNextOnLevel(conf.Y, currentLevel + 1))
                    {
                        if (Rez[currentLevel + 1].Count < h[0]) //або на наступному місці є вільне місце і наша вершина не має наступників на наступному місці
                        {
                            Rez[currentLevel + 1].Add(conf.Y);
                            Rez[currentLevel].Remove(conf.Y);
                            conflictPairs.Remove(conf);
                            continue;
                        }
                        t = canSwitchNext(currentLevel);
                        if (t != -1)
                        {
                            //п.6. Міняємо місцями кінцеву вершину зі знайденого конфлікту, і вершину 𝑡. 
                            SwitchVs(t, conf.Y);
                            conflictPairs.Remove(conf);
                            continue;
                        }
                    }
                }


                // п.7. Збільшуємо довжину впорядкування, додавши місце в упорядкування відразу за поточним. 
                // Ставимо на нього кінцеву вершину з конфліктної пари. 
                Rez.Insert(currentLevel + 1, new List<int>());
                Rez[LevelOfV(Rez, conf.Y)].Remove(conf.Y);
                Rez[currentLevel + 1].Add(conf.Y);
                conflictPairs.Remove(conf);


                AddVInroFreePlaces(currentLevel);
                currentLevel++;
                AddVInroFreePlaces(currentLevel);


                // getAllConflicts();
            }

            for (int i = 0; i < Rez.Count; i++)
            {
                AddVInroFreePlaces(i);
            }
            for (int i = 0; i < Rez.Count; i++)
            {
                if (Rez[i].Count == 0)
                {
                    Rez.Remove(Rez[i]);
                }
            }

        }

        void AddVInroFreePlaces(int currentLevel)
        {
            if (Rez[currentLevel].Count < h[0])
            {

                List<List<int>> currentMatrix = getCurrentMatrix(currentLevel - 1);
                List<int> freeV = LookForNotIn(currentMatrix, 1);
                if (conflictPairs != null)
                {
                    freeV.Sort(new ComparerConflictFirst(conflictPairs));
                }
                foreach (int v in Rez[currentLevel])
                {
                    freeV.Remove(v);
                }

                int j = 0;
                while ((Rez[currentLevel].Count < h[0]) && (j < freeV.Count))
                {
                    Rez[LevelOfV(Rez, freeV[j])].Remove(freeV[j]);
                    Rez[currentLevel].Add(freeV[j]);

                    j++;
                }
            }
        }
    }
}

//вільні - s[0]