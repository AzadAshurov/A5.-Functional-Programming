
using System;

class Solution
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = i + 1;
        }

        int size = arr.Length;
        int step = 0;
        while (size > 1)
        {
            int k = 0;
            for (int i = 0; i < size; i++)
            {
                int position = i + 1;
                bool delete = false;
                if (step == 0)
                {
                    delete = position % 2 == 0;
                }
                else if (step == 1)
                {
                    delete = position % 2 == 1;
                }
                else
                {
                    delete = position % 3 == 0;
                }

                if (!delete)
                {
                    arr[k] = arr[i];
                    k++;
                }

            }
            step = (step + 1) % 3;
            size = k;


        }
        Console.WriteLine(arr[0]);
    }
}
