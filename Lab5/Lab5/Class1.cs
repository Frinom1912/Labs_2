using System;
using System.Runtime.ExceptionServices;

namespace Lab5
{
    public class Fisher
    {
        static protected int M, N;
        static protected int[,] D;

        /// <summary>
        /// Сравнение строк S1 и S2 методом Вагнера-Фишера.
        /// 
        /// Возвращает:
        /// 0, если строки равны
        /// 1, если строки неравны
        /// </summary>
        static public int getLen(string S1, string S2)
        {
            M = S1.Length;
            N = S2.Length;
            for (int i = 0; i < M; i++)
                D[i, 0] = i;
            for (int j = 0; j < N; j++)
                D[0, j] = j;
            for (int j = 1; j < N; j++)
            {
                for(int i = 1; i<M; i++)
                {
                    char str1_c = S1[i];
                    char str2_c = S2[j];
                    if (str1_c == str2_c)
                        D[i,j] = D[i - 1,j - 1];
                    else
                    {
                        int res = Math.Min(D[i - 1,j], D[i,j - 1]);
                        res = Math.Min(res, D[i - 1,j - 1]);
                        D[i,j] = res + 1;
                    }
                }
            }
            return D[M-1, N-1];
        }

    }
    public class Levenstein
    {

    }
}
