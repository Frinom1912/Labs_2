using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Lab5
{
    public abstract class Length
    {
        static protected int M, N;
        static protected int[,] D;

        /// <summary>
        /// Находит расстояние Левенштайна
        /// </summary>
        /// <param name="S1">Первая строка для сравнения</param>
        /// <param name="S2">Вторая строка для сравнения</param>
        /// <returns>
        ///          0, если строки равны, иначе - 1.
        /// </returns>
        /// 
        
        public abstract int GetLen(string S1, string S2);
    }
    public class Fisher : Length
    {
        public override int GetLen(string S1, string S2)
        {
            M = S1.Length+1;
            N = S2.Length+1;
            D = new int[M, N];
            for (int i = 0; i < M; i++)
                D[i, 0] = i;
            for (int j = 0; j < N; j++)
                D[0, j] = j;
            for (int i = 1; i < M; i++)
            {
                for(int j = 1; j<N; j++)
                {
                    int difference = (S1[i-1] == S2[j-1]) ? 0 : 1;
                    int res = Math.Min(D[i - 1,j]+1, D[i,j - 1]+1);
                    res = Math.Min(res, D[i - 1,j - 1]+difference);
                    D[i, j] = res;
                }
            }
            return D[M, N];
        }

    }
    public class Levenstein : Length
    {
        public override int GetLen(string S1, string S2)
        {
            return 0;
        }
    }
}
