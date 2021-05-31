using System.Collections.Generic;

namespace LabWork4
{
    class SalesmanTask
    {
        public List<int> bestWay;
        public int bestWayDistance;
        List<int[]> ways;
        int start;

        public SalesmanTask(int s)
        {
            start = s;
        }

        private void FindAllWays(int[,] matr)
        {
            var Way = new List<int>();
            Way.Add(start);
            var allNodes = GenerateArrayofNodes(matr.GetLength(0));
            allNodes.Remove(start);
            
            var permut = new Permutation(allNodes.ToArray());
            permut.Generate(0, allNodes.Count);
            ways = permut.result;
        }

        private List<int> GenerateArrayofNodes(int len)
        {
            var result = new List<int>();
            for (var i = 0; i < len; i++)
                result.Add(i);
            return result;
        }

        public void FindBestWay(int[,] matr)
        {
            FindAllWays(matr);
            var tempBestWay = new List<int>();
            var minDist = int.MaxValue;
            foreach(var way in ways)
            {
                var wayDist = FindDistance(way, matr);
                if (wayDist < minDist && minDist > 0)
                {

                    tempBestWay.Add(start);
                    tempBestWay.AddRange(way);
                    tempBestWay.Add(start);
                    minDist = wayDist;
                }
            }
            bestWay = tempBestWay;
            bestWayDistance = minDist;
        }

        private int FindDistance(int[] way, int[,] matr)
        {
            var distance = 0;
            for(var i = 0; i <= way.Length; i++)
            {
                if (i == 0)
                {
                    if (matr[start, way[i]] == -1)
                        return -1;
                    distance += matr[start, way[i]];
                }
                else if (i == way.Length)
                {
                    if (matr[way[i-1], start] == -1)
                        return -1;
                    distance += matr[way[i-1], start];
                }
                else
                {
                    if (matr[way[i-1], way[i]] == -1)
                        return -1;
                    distance += matr[way[i] - 1, way[i]];
                }
            }
            return distance;
        }
    }
}
