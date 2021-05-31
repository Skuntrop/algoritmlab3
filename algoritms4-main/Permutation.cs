using System;
using System.Collections.Generic;

namespace LabWork4
{
    class Permutation
    {
        public Permutation(int[] _arr)
        {
            array = _arr;
        }
        public int[] array;
        public List<int[]> result = new List<int[]>();

        public void Generate(int l, int r)
        { 
            if (l != r)
            {
                for (var i = l; i < r; i++)
                {
                    Swap(array, l, i);
                    Generate(l + 1, r);
                    Swap(array, l, i);
                }
            }
            else
            {
                var newArray = new int[array.Length];
                Array.Copy(array, newArray, array.Length);
                result.Add(newArray);
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int t;
            t = arr[j];
            arr[j] = arr[i];
            arr[i] = t;
        }
    }
}
