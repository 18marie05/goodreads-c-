using Goodreads.Classes;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

/*
Permet de sauvegarder une bibliothèque dans un fichier dans un format json ou csv (en précisant le chemin et l'extension)
Un tel fichier pourra ensuite être chargé avec LoadCommand
On peut d'ailleurs charger un fichier en csv et l'enregistrer en json et inversement
*/

namespace Goodreads.Commands;

public class SaveCommand : ExecuteCommand
{
    private readonly Library library;
    private const string saveDirectory = "Data";

    public SaveCommand(Library library)
    {
        this.library = library;
    }

    public override void Execute()
    {
        Console.WriteLine("Entrez le nom du fichier pour sauvegarder (sans extension) : ");
        string? filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Nom de fichier invalide.");
            return;
        }

        Directory.CreateDirectory(saveDirectory);

        Console.WriteLine("Choisissez le format de sauvegarde : CSV ou JSON (entrez 'csv' ou 'json') : ");
        string? format = Console.ReadLine()?.ToLower();

        switch (format)
        {
            case "csv":
                SaveAsCsv(filename);
                break;

            case "json":
                SaveAsJson(filename);
                break;

            default:
                Console.WriteLine("Format non reconnu. Sauvegarde annulée.");
                break;
        }
    }

    private void SaveAsCsv(string filename)
    {
        string path = $"{saveDirectory}/{filename}.csv";

        using StreamWriter writer = new StreamWriter(path);
        writer.WriteLine("Title;Author;Status;Genres;TotalPages;Progress;Rating");
        foreach (var book in library.GetBooks())
        {
            int progress = book.Status switch
            {
                ReadingStatus.Read => book.TotalPages,
                ReadingStatus.WantToRead => 0,
                ReadingStatus.CurrentlyReading => book.CurrentPage,
                _ => throw new InvalidOperationException("Statut de lecture non reconnu")
            };

            writer.WriteLine($"{book.Title};{book.Author};{book.Status};{string.Join(",", book.Genres)};{book.TotalPages};{progress};{book.Rating}");
        }

        Console.WriteLine($"Bibliothèque sauvegardée dans {path}");
    }



    private void SaveAsJson(string filename)
    {
        string path = $"{saveDirectory}/{filename}.json";

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
        };

        string jsonContent = JsonSerializer.Serialize(library.GetBooks(), options);
        File.WriteAllText(path, jsonContent);

        Console.WriteLine($"Bibliothèque sauvegardée dans {path}");
    }
}
