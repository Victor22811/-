using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        var table = new Dictionary<string, Team>();

        using (var reader = new StreamReader(inStream))
        using (var writer = new StreamWriter(outStream))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(';');
                if (parts.Length != 3)
                    continue;

                string team1 = parts[0];
                string team2 = parts[1];
                string result = parts[2];

                if (!table.ContainsKey(team1)) table[team1] = new Team(team1);
                if (!table.ContainsKey(team2)) table[team2] = new Team(team2);

                switch (result)
                {
                    case "win":
                        table[team1].Win();
                        table[team2].Loss();
                        break;
                    case "loss":
                        table[team1].Loss();
                        table[team2].Win();
                        break;
                    case "draw":
                        table[team1].Draw();
                        table[team2].Draw();
                        break;
                }
            }

            var sorted = table.Values
                .OrderByDescending(t => t.Points)
                .ThenBy(t => t.Name)
                .ToList();

            var lines = new List<string>();
            lines.Add("Team                           | MP |  W |  D |  L |  P");

            foreach (var t in sorted)
            {
                lines.Add($"{t.Name,-30} | {t.MP,2} | {t.W,2} | {t.D,2} | {t.L,2} | {t.Points,2}");
            }

            writer.Write(string.Join("\n", lines)); // без завершающего \n
            writer.Flush();
        }
    }

    private class Team
    {
        public string Name { get; }
        public int MP { get; private set; }
        public int W { get; private set; }
        public int D { get; private set; }
        public int L { get; private set; }
        public int Points => W * 3 + D;

        public Team(string name) => Name = name;

        public void Win() { W++; MP++; }
        public void Draw() { D++; MP++; }
        public void Loss() { L++; MP++; }
    }
}
