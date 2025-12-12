using System;
using System.Linq;

public static class Bob
{
    public static string Response(string remark)
    {
        // Защита от null (совместимо со старыми компиляторами)
        if (remark == null)
            remark = "";

        // Убираем пробелы по краям (включая неразрывные и др.)
        var trimmed = remark.Trim();

        // Молчание
        if (string.IsNullOrEmpty(trimmed))
            return "Fine. Be that way!";

        // Вопрос — если последний символ после Trim() это '?'
        bool isQuestion = trimmed.EndsWith("?");

        // Проверяем, есть ли буквенные символы (любой алфавит)
        bool hasLetters = remark.Any(char.IsLetter);

        // Крик — есть буквы и все буквы заглавные
        bool isShouting = hasLetters && remark.Where(char.IsLetter).All(c => char.IsUpper(c));

        // Крик-вопрос должен проверяться в первую очередь
        if (isShouting && isQuestion)
            return "Calm down, I know what I'm doing!";

        if (isShouting)
            return "Whoa, chill out!";

        if (isQuestion)
            return "Sure.";

        return "Whatever.";
    }
}

