using ParallelReading;

internal class Program
{
    public CountSpaces countSpaces = new CountSpaces();

    private static async Task Main()
    {
        CountSpaces countSpaces = new CountSpaces();
        // Считываем пробелы из трех файлов
        string[] filePaths =
        {
             @"..\..\..\FilesForRead\File1.txt"
           , @"..\..\..\FilesForRead\File2.txt"
           , @"..\..\..\FilesForRead\File3.txt"
        };
        await countSpaces.CountSpacesInFilesAsync(filePaths);

        // Считываем пробелы из всех файлов в папке
        string directoryPath = @"C:\Users\Stanislav Lukashov\Desktop\проги\обучение\OtusParallelReading\ParallelReading\FilesForRead";
        await countSpaces.CountSpacesInDirectoryAsync(directoryPath);
    }

   
}



