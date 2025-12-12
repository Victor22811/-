using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        var result = new List<(int a, int b, int c)>();

        for (int a = 1; a <= sum / 3; a++)
        {
            for (int b = a + 1; b <= sum / 2; b++)
            {
                int c = sum - a - b;
                if (c > b && a * a + b * b == c * c)
                {
                    result.Add((a, b, c));
                }
            }
        }

        return result;
    }
}