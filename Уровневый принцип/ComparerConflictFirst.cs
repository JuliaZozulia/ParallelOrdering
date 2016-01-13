using System;
using System.Collections.Generic;
using System.Drawing;

namespace Уровневый_принцип
{
    public class ComparerConflictFirst : Comparer<int>
    {
        List<Point> conflictPairs;
        public ComparerConflictFirst(List<Point> conflictPairs)
        {
            this.conflictPairs = conflictPairs;
        }

        int isInConflictPairs(int v)
        {
            foreach (Point p in conflictPairs)
            {
                if (p.X == v)
                {
                    return 1;
                }
            }
            return -1;
        }

        public override int Compare(int x, int y)
        {
            int x1 = isInConflictPairs(x);
            int y1 = isInConflictPairs(y);
            if (x1 > y1) return 1;
            if (x1 < y1) return -1;
            else return 0;

        }
    }
}
