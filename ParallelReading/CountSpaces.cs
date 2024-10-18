using System.Diagnostics;

namespace ParallelReading
{
    public class CountSpaces
    {
        public int SimpleSpaceCounting(string filePath)
        {
            string content = File.ReadAllText(filePath);
            return content.Count(c => c == ' ');
        }

        public async Task CountSpacesInDirectoryAsync(string directoryPath)
        {
            string[] filePaths = Directory.GetFiles(directoryPath);
            var tasks = filePaths.Select(filePath => Task.Run(() => SimpleSpaceCounting(filePath)));

            Stopwatch stopwatch = Stopwatch.StartNew();
            var results = await Task.WhenAll(tasks);
            stopwatch.Stop();

            for (int i = 0; i < filePaths.Length; i++)
            {
                Console.WriteLine($"Количество пробелов в {filePaths[i]}: {results[i]}");
            }

            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }

        public async Task CountSpacesInFilesAsync(string[] filePaths)
        {
            var tasks = filePaths.Select(filePath => Task.Run(() => SimpleSpaceCounting(filePath)));

            Stopwatch stopwatch = Stopwatch.StartNew();
            var results = await Task.WhenAll(tasks);
            stopwatch.Stop();

            for (int i = 0; i < filePaths.Length; i++)
            {
                Console.WriteLine($"Количество пробелов в {filePaths[i]}: {results[i]}");
            }

            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}
