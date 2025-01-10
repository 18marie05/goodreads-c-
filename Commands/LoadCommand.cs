using Goodreads.Classes;
using System.Text.Json;

/*
Permet de charger un fichier json ou csv (en précisant le chemin et l'extension) qui correspond à une bibliothèque de l'utilisateur
Un tel fichier peut être chargé car il a été enregistré et produit grâce aux fonctionnalités de SaveCommand 
donc le format des fichiers est automatiquement respecté.
*/

namespace Goodreads.Commands;

public class LoadCommand : ExecuteCommand
{
    private readonly Library library;
    private const string loadDirectory = "Data";

    public LoadCommand(Library library)
    {
        this.library = library;
    }

    public override void Execute()
    {
        Console.WriteLine("Entrez le nom du fichier à charger (sans extension) : ");
        string? filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Nom de fichier invalide.");
            return;
        }

        Console.WriteLine("Choisissez le format de fichier : CSV ou JSON (entrez 'csv' ou 'json') : ");
        string? format = Console.ReadLine()?.ToLower();

        switch (format)
        {
            case "csv":
                LoadFromCsv(filename);
                break;

            case "json":
                LoadFromJson(filename);
                break;

            default:
                Console.WriteLine("Format non reconnu. Chargement annulé.");
                break;
        }
    }

    private void LoadFromCsv(string filename)
    {
        string path = $"{loadDirectory}/{filename}.csv";

        if (!File.Exists(path))
        {
            Console.WriteLine($"Fichier {path} introuvable.");
            return;
        }

        using StreamReader reader = new StreamReader(path);
        int count = 0;

        string? header = reader.ReadLine();
        if (header == null || !header.Contains("Title") || !header.Contains("Author") || !header.Contains("Status") || !header.Contains("Genres") || !header.Contains("TotalPages") || !header.Contains("Progress") || !header.Contains("Rating"))
        {
            Console.WriteLine("Format de fichier CSV invalide.");
            return;
        }

        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(";");
            if (parts.Length < 7)
            {
                Console.WriteLine($"Erreur de format dans la ligne : {line}");
                continue;
            }

            try
            {
                int? rating = string.IsNullOrEmpty(parts[6]) ? (int?)null : int.Parse(parts[6]);

                var book = new Book(
                    title: parts[0],
                    author: parts[1],
                    status: Enum.Parse<ReadingStatus>(parts[2]),
                    genres: SplitGenres(parts[3]),
                    totalPages: int.Parse(parts[4]),
                    currentPage: int.Parse(parts[5]),
                    rating: rating
                );

                library.AddBook(book);
                count++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur en chargeant le livre : {ex.Message}");
            }
        }

    }
    private List<string> SplitGenres(string genres)
    {
        return genres.Trim('"').Split(", ").ToList();
    }


    private void LoadFromJson(string filename)
    {
        string path = $"{loadDirectory}/{filename}.json";

        if (!File.Exists(path))
        {
            Console.WriteLine($"Fichier {path} introuvable.");
            return;
        }

        try
        {
            string content = File.ReadAllText(path);
            var books = JsonSerializer.Deserialize<List<Book>>(content);

            if (books != null)
            {
                foreach (var book in books)
                {
                    library.AddBook(book);
                }

                Console.WriteLine($"{books.Count} livres chargés depuis {path}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur en chargeant le fichier JSON : {ex.Message}");
        }
    }
}

