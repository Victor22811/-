using System;

public static class SpiralMatrix
{
    public static int[,] GetMatrix(int n)
    {
        int[,] matrix = new int[n, n];

        int top = 0;
        int bottom = n - 1;
        int left = 0;
        int right = n - 1;
        int value = 1;

        while (top <= bottom && left <= right)
        {
            // Слева направо
            for (int i = left; i <= right; i++)
                matrix[top, i] = value++;
            top++;

            // Сверху вниз
            for (int i = top; i <= bottom; i++)
                matrix[i, right] = value++;
            right--;

            // Справа налево
            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                    matrix[bottom, i] = value++;
                bottom--;
            }

            // Снизу вверх
            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                    matrix[i, left] = value++;
                left++;
            }
        }

        return matrix;
    }
}

