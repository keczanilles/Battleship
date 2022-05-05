namespace Battleship.Util
{
    public class Score
    {
        public Score(int score, string name)
        {
            Append(score, name);
        }

        public static async Task Append(int score, string name)
        {
            string fileName = "Data\\highscore.txt";
            string destPath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            using (StreamWriter file = new(destPath, append: true))
            {
                await file.WriteLineAsync($"{name}: {score}");
            };
        }

        public static void Read()
        {
            string fileName = "Data\\highscore.txt";
            string destPath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            List<Tuple<string, int>> players = new List<Tuple<string, int>>();

            foreach (string line in File.ReadLines(destPath))
            {
                string name = line.Split(": ")[0];
                int score = int.Parse(line.Split(": ")[1]);
                players.Add(new Tuple<string, int>(name, score));
            }

            players.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            int counter = 1;
            foreach (Tuple<string, int> player in players)
            {
                Console.WriteLine($"{counter}. Name: {player.Item1}, Score: {player.Item2} ");
                counter++;
            }
        }
    }
}
