using System;
using System.Collections.Generic;

namespace Lab5
{
    public class Fisher
    {
        public static int GetLen(string S1, string S2)
        {
            int M, N;
            int[,] D;
            M = S1.Length+1;
            N = S2.Length+1;
            D = new int[M, N];
            for (int i = 0; i < M; i++)
                D[i, 0] = i;
            for (int j = 0; j < N; j++)
                D[0, j] = j;

            for (int i = 1; i <= M-1; i++)
            {
                for(int j = 1; j <= N-1; j++)
                {
                    int difference = (S1[i-1] == S2[j-1]) ? 0 : 1;
                    D[i, j] = Math.Min(Math.Min(D[i - 1,j]+1, 
                            D[i,j - 1]+1),
                            D[i - 1, j - 1] + difference
                        );
                }
            }
            return D[M-1, N-1];
        }

    }
    public class Damerau
    {
        static protected int M, N;
        static protected int[,] D;
        public static int GetLen(string S1, string S2, int dCost, int iCost, int rCost, int tCost)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            M = S1.Length;
            N = S2.Length;
            if (S1 == "")
                if (S2 == "")
                    return 0;
                else
                    return N;
            else if (S2 == "")
                return M;

            D = new int[M + 1, N + 1];
            int Con = Math.Max(dCost, iCost);
            Con = Math.Max(Con, rCost);
            Con = Math.Max(Con, tCost);
            Con *= (M + N);

            D[0, 0] = Con;
            for (int i = 0; i < M; i++)
            {
                D[i + 1, 1] = i * (dCost);
                D[i + 1, 0] = Con;
            }
            for (int i = 0; i < N; i++)
            {
                D[1, i+1] = i * (iCost);
                D[0, i+1] = Con;
            }

            foreach (char let in (S1 + S2))
                dict[let] = 0;

            for(int i = 1; i<M; i++)
            {
                int last = 0;
                for (int j = 1; j < N; j++)
                {
                    int k = dict[S2[j]];
                    int m = last;
                    if (S1[i] == S2[j])
                    {
                        D[i + 1, j + 1] = D[i, j];
                        last = j;
                    }
                    else
                    {
                        int res = Math.Min(D[i, j] + rCost, D[i + 1, j] + iCost);
                        res = Math.Min(res, D[i, j + 1] + dCost);
                        D[i + 1, j + 1] = res;
                    }
                    D[i + 1, j + 1] = Math.Min(D[i + 1, j + 1], D[k, m] + (i - k - 1) * dCost + tCost + (j - m - 1) * iCost);
                }
                dict[S1[i]] = i;
            }
            return D[M, N];

        }
    }
}
