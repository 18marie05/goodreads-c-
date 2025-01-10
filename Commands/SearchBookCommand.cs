using System;
using Goodreads.Classes;

// Permet à l'utilisateur de rechercher un livre et d'afficher les informations disponibles dessus

namespace Goodreads.Commands
{
    public class SearchBookCommand : ExecuteCommand
    {
        private readonly Library _library;

        public SearchBookCommand(Library library)
        {
            _library = library;
        }

        // Méthode pour exécuter la commande de recherche par titre
        public override void Execute()
        {
            // Demander à l'utilisateur d'entrer le titre du livre à rechercher
            Console.WriteLine("Veuillez entrer le titre du livre à rechercher : ");
            string? title = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Le titre ne peut pas être vide.");
                return;
            }

            // Recherche du livre dans la bibliothèque
            var books = _library.SearchByTitle(title);

            if (books.Any())
            {
                // Afficher les informations du livre(s) trouvé(s)
                foreach (var book in books)
                {
                    Console.WriteLine($"Titre: {book.Title}");
                    Console.WriteLine($"Auteur: {book.Author}");
                    Console.WriteLine($"Statut: {book.Status}");
                    Console.WriteLine($"Genres: {book.DisplayGenres}");
                    Console.WriteLine($"Pages Totales: {book.TotalPages}");
                    Console.WriteLine($"Pages lues: {book.CurrentPage}/{book.TotalPages}");
                    Console.WriteLine();
                }
            }
            else
            {
                // Si aucun livre n'est trouvé
                Console.WriteLine($"Aucun livre trouvé avec le titre '{title}' dans la bibliothèque.");
            }
        }

    }
}
