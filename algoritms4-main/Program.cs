using System;
using System.Linq;

namespace LabWork4
{
    class Program
    {
        public static void Test()
        {
            //Тесты алгоритма генерации перестановок
            var arr = new int[3] { 1, 2, 3 };
            var p = new Permutation(arr);
            p.Generate(0, arr.Length);
            if (!p.result.Any(x => Enumerable.SequenceEqual(x, new int[] { 1, 2, 3 })))
                Console.WriteLine("Тест генерации перестановок провален");
            if (!p.result.Any(x => Enumerable.SequenceEqual(x, new int[] { 1, 3, 2 })))
                Console.WriteLine("Тест генерации перестановок провален");
            if (!p.result.Any(x => Enumerable.SequenceEqual(x, new int[] { 3, 2, 1 })))
                Console.WriteLine("Тест генерации перестановок провален");
            if (!p.result.Any(x => Enumerable.SequenceEqual(x, new int[] { 3, 1, 2 })))
                Console.WriteLine("Тест генерации перестановок провален");
            if (!p.result.Any(x => Enumerable.SequenceEqual(x, new int[] { 2, 1, 3 })))
                Console.WriteLine("Тест генерации перестановок провален");
            if (!p.result.Any(x => Enumerable.SequenceEqual(x, new int[] { 2, 3, 1 })))
                Console.WriteLine("Тест генерации перестановок провален");
            if (p.result.Count != 6)
                Console.WriteLine("Тест генерации перестановок провален");

            var arr1 = new int[2] { 1, 2 };
            var p1 = new Permutation(arr1);
            p1.Generate(0, arr1.Length);
            if (!p1.result.Any(x => Enumerable.SequenceEqual(x, new int[] { 1, 2 })))
                Console.WriteLine("Тест генерации перестановок провален");
            if (!p1.result.Any(x => Enumerable.SequenceEqual(x, new int[] { 2, 1 })))
                Console.WriteLine("Тест генерации перестановок провален");
            if (p1.result.Count != 2)
                Console.WriteLine("Тест генерации перестановок провален");

            //Тесты задачи коммивояжера
            var matr = new int[5,5];
            matr[1, 0] = 5; matr[2, 0] = 8; matr[3, 0] = 9; matr[4, 0] = 2;
            matr[2, 1] = 3; matr[3, 1] = 3; matr[4, 1] = 4;
            matr[3, 2] = 7; matr[4, 2] = 6; matr[4, 3] = 1;
            for (var j = 0; j < matr.GetLength(1); j++)
            {              
                matr[j,j] = -1;                                
                for (var i = j + 1; i < matr.GetLength(0); i++)          
                    matr[j,i] = matr[i,j];
            }
            var salesmanTask = new SalesmanTask(0);
            salesmanTask.FindBestWay(matr);
            var bw = salesmanTask.bestWay;
            var bwDist = salesmanTask.bestWayDistance;
            if (bwDist != 18)
                Console.WriteLine("Тест задачи коммивояжера провален");
            if (!Enumerable.SequenceEqual(bw, new int[] { 0, 1, 2, 3, 4, 0 }))
                Console.WriteLine("Тест задачи коммивояжера провален");
        }
        
        static void Main(string[] args)
        {
            Test();

        }

        
    }
}
