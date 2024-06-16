using LibraryHelper;
using LibraryHelper.Models;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath;

        if (args.Length > 0)
        {
            filePath = args[0];
        }
        else
        {
            Console.WriteLine("Please enter the file path:");
            filePath = Console.ReadLine();
        }

        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("No file path provided. Exiting.");
            return;
        }

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found. Exiting.");
            return;
        }

        try
        {
            List<FileInput> data = CvsParser.ReadDataFromFile(filePath);
            var result = HighestPairFinder.GetHighestPair(data);
            Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while processing the file: {ex.Message}");
        }
    }
}

