using Goodreads.Classes;

/*
AddCommand permet à l'utilisateur d'ajouter un nouveau livre à la bibliothèque. 
Elle interagit avec la classe Library pour ajouter le livre et avec GenreManager pour valider les genres.

Fonctionnalités : 
- Récupération des informations du livre (titre, auteur, statut, nombre de pages, genres) via la console
- Validation des entrées
- Ajout du livre à la bibliothèque après validation
*/

namespace Goodreads.Commands
{
    public class AddCommand : ExecuteCommand
    {
        private readonly Library _library;
        private readonly GenreManager _genreManager;

        public AddCommand(Library library, GenreManager genreManager)
        {
            _library = library;
            _genreManager = genreManager;
        }

        public override void Execute()
        {
            Console.Write("Entrez le titre du livre : ");
            string? title = Console.ReadLine();

            Console.Write("Entrez l'auteur du livre : ");
            string? author = Console.ReadLine();

            // Vérification que le titre et l'auteur ne sont pas nuls ou vides
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Le titre ou l'auteur est invalide.");
                return;
            }

            if (author.All(char.IsDigit))
            {
                Console.WriteLine("L'auteur ne peut pas être uniquement composé de chiffres.");
                return;
            }

            Console.Write("Entrez le statut de lecture (0=WantToRead, 1=CurrentlyReading, 2=Read) : ");
            
            // Initialiser la variable Status avec une valeur par défaut
            ReadingStatus status = ReadingStatus.WantToRead;
            bool validStatus = false;

            while (!validStatus)
            {
                string? input = Console.ReadLine();
                
                if (Enum.TryParse<ReadingStatus>(input, out status) && Enum.IsDefined(typeof(ReadingStatus), status))
                {
                    validStatus = true;
                }
                else
                {
                    Console.WriteLine("Statut de lecture invalide. Essayez de nouveau (0=WantToRead, 1=CurrentlyReading, 2=Read) : ");
                }
            }

            Console.Write("Entrez le nombre total de pages : ");
            int totalPages;

            // Vérification du nombre de pages
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out totalPages) && totalPages > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Le nombre de pages est invalide. Entrez un nombre supérieur à 0 : ");
                }
            }

            // Genres du livre
            Console.WriteLine("Entrez les genres du livre (séparés par des virgules) : ");
            List<string>? genresInput = Console.ReadLine()?.Split(',').Select(g => g.Trim()).ToList();

            if (genresInput == null || genresInput.Count == 0)
            {
                Console.WriteLine("Aucun genre n'a été spécifié.");
                return;
            }

            // Vérification des genres
            foreach (var genre in genresInput)
            {
                if (!_genreManager.Genres.Contains(genre))
                {
                    Console.WriteLine($"Genre '{genre}' pas connu pour le moment. Vous pouvez l'ajouter avec la commande 'add genre'.");
                    return;
                }
            }

            // Si tous les genres sont valides
            var book = new Book(title, author, status, genresInput, totalPages);
            _library.AddBook(book);
            Console.WriteLine("Livre ajouté avec succès !");
        }
    }
}
