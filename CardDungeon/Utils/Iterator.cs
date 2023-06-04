using static System.Linq.Enumerable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.Utils
{
    internal static class Iterator
    {

        public delegate T Init<T>();

        public static IEnumerable<int> For(int times)
        {
            return Range(0, times);
        }
        public static void Do(int times, Action action)
        {
            for (int i = 0; i < times; i++)
            {
                action();
            }
        }
        public static void Do(int times, Action<int> action)
        {
            for (int i = 0; i < times; i++)
            {
                action(i);
            }
        }
        public static void Do<T>(int times, T[] array, Action<T> action)
        {
            for (int i = 0; i < times; i++)
            {
                action(array[i]);
            }
        }
        public static T[] GetColumn<T>(T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public static T[] GetRow<T>(T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
        public static void Iterate<T>(T[] array, Action action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                action();
            }
        }
        public static void Iterate<T>(T[] array, Action<T> action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                action(array[i]);
            }
        }

        public static void Iterate<T>(T[] array, Action<T, int> action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                action(array[i], i);
            }
        }

        public static void Iterate<T>(T[,] array, Action<T, int, int, int> action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int x = i / array.GetLength(0);
                int y = i % array.GetLength(1);
                action(array[x, y], i, x, y);
            }
        }

        public static void Iterate<T>(T[,] array, Action<T, int> action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int x = i / array.GetLength(0);
                int y = i % array.GetLength(1);
                action(array[x, y], i);
            }
        }
        public static void Fill<T>(T[,] array, Init<T> init)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int x = i / array.GetLength(0);
                int y = i % array.GetLength(1);
                array[x,y] = init();
            }
        }
        public static void Fill<T>(T[] array, Init<T> init)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = init();
            }
        }

    }
}
