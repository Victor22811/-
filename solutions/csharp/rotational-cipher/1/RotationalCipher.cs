using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string input, int key)
    {
        key = ((key % 26) + 26) % 26;
        var sb = new StringBuilder(input.Length);

        foreach (char ch in input)
        {
            if (ch >= 'a' && ch <= 'z')
            {
                sb.Append((char)('a' + (ch - 'a' + key) % 26));
            }
            else if (ch >= 'A' && ch <= 'Z')
            {
                sb.Append((char)('A' + (ch - 'A' + key) % 26));
            }
            else
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }
}

