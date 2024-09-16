using ParallelReading;

internal class Program
{
    private static string _folderPath = @"..\..\..\FilesForRead";
    private static string[] _files =
    {
          @"..\..\..\FilesForRead\File1.txt"
        , @"..\..\..\FilesForRead\File2.txt"
        , @"..\..\..\FilesForRead\File3.txt"
    };

    private static async Task Main(string[] args)
    {
        try
        {
            var countingSpaces = new СountingSpaces();

            // 1: Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
            await countingSpaces.CountSpacesInFilesAsync(_files);

            // 2: Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
            await countingSpaces.CountSpacesInFolderFilesAsync(_folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.Read();
    }
}
