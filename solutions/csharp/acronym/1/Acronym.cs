using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        if (string.IsNullOrWhiteSpace(phrase))
            return "";

        phrase = phrase.Replace("-", " ");
        
        phrase = Regex.Replace(phrase, @"[^a-zA-Z\s]", "");

        string[] words = phrase.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder acronym = new StringBuilder();

        foreach (string word in words)
        {
            acronym.Append(char.ToUpper(word[0]));
        }

        return acronym.ToString();
    }
}