namespace SorteioRetornar.Utils
{
    public static class FileUtils
    {
        public static string filePath = @"C:\temp\sorteio.txt";
        public static string path = @"C:\temp";

        public static List<int> ReadFile()
        {
            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var file = File.Create(filePath);
                file.Close();
            }

            string[] allLines = File.ReadAllLines(filePath);
            var allNumbers = new List<int>();

            foreach (var line in allLines)
            {
                allNumbers.Add(Convert.ToInt32(line));
            }
            return allNumbers;
        }

        public static void AddNumberToFile(int number)
        {
            using (StreamWriter file = new StreamWriter(filePath, append: true))
            {
                file.WriteLine(number);
            }
        }

        public static bool NumberExists(int number)
        {
            var allnumbers = ReadFile();
            return allnumbers.Contains(number);
        }
    }
}
