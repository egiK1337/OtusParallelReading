using System.Diagnostics;

namespace ParallelReading
{
    internal class СountingSpaces
    {
        // 1: Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
        public virtual async Task<int[]> CountSpacesInFilesAsync(IEnumerable<string> files)
        {
            var stopwatch = Stopwatch.StartNew();
            var spaces = await Task.WhenAll(files.Select(file => CountSpacesInFileAsync(file)));
            stopwatch.Stop();
            Console.WriteLine($"Время обработки файлов: {stopwatch.ElapsedMilliseconds} мс.");
            return spaces;
        }

        // 2: Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
        public async Task<int> CountSpacesInFolderFilesAsync(string folderName)
        {
            Console.WriteLine("");
            Console.WriteLine($"Считаем общее количество пробелов во всех файлах в папке");
            var folderFiles = Directory.GetFiles(folderName);
            var stopwatch = Stopwatch.StartNew();
            int[] spaceCounts = await CountSpacesInFilesAsync(folderFiles);
            var totalSpaceCount = spaceCounts.Sum();
            stopwatch.Stop();
            Console.WriteLine($"Общее количество пробелов во всех файлах в папке: {totalSpaceCount}");
            Console.WriteLine($"Суммарное время результатов: {stopwatch.ElapsedMilliseconds} мс.");
            return totalSpaceCount;
        }

        //Определение кол-во пробелов в одном файле
        static public async Task<int> CountSpacesInFileAsync(string filePath)
        {
            Console.WriteLine($"Начинаем читать файл {filePath},Номер потока: {Thread.CurrentThread.ManagedThreadId}");
            var watch = Stopwatch.StartNew();
            using (var reader = new StreamReader(filePath))
            {
                //добавил задержку для лучшей видимости результата
                await Task.Delay(100);
                string content = await reader.ReadToEndAsync();
                int res = content.Count(c => c == ' ');
                watch.Stop();
                Console.WriteLine($"Файл {filePath} прочитан, Результат: {res} Номер потока: {Thread.CurrentThread.ManagedThreadId}, время затраченное на чтения: {watch.ElapsedMilliseconds} мс.");
                return res;
            }
        }
    }
}
