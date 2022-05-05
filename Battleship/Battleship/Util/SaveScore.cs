namespace Battleship.Util
{
    public class SaveScore
    {
        public SaveScore(int score, string name)
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
    }
}
