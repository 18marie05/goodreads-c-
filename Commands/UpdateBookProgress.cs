using Goodreads.Classes;

// Permet de mettre à jour la progression de lecture d'un livre (en nombre de pages) si un livre est en cours de lecture

namespace Goodreads.Commands
{
    public class UpdateBookProgress : ExecuteCommand
    {
        private readonly Library _library;

        public UpdateBookProgress(Library library)
        {
            _library = library;
        }

        public override void Execute()
        {
            Console.Write("Entrez le titre du livre dont vous souhaitez mettre à jour le progrès : ");
            string? title = Console.ReadLine();

            // Chercher le livre en fonction du titre
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Le titre ne peut pas être vide.");
                return;
            }

            var book = _library.GetBookByTitle(title);

            if (book == null)
            {
                Console.WriteLine("Livre non trouvé.");
                return;
            }

            // Vérifier si le statut est "CurrentlyReading"
            if (book.Status != ReadingStatus.CurrentlyReading)
            {
                Console.WriteLine("Ce livre n'est pas en cours de lecture, donc son progrès ne peut pas être mis à jour.");
                return;
            }

            Console.Write("Entrez le nombre de pages lues (actuellement " + book.CurrentPage + " pages lues) : ");
            int newPagesRead;

            // Vérification de l'entrée pour les pages lues
            while (!int.TryParse(Console.ReadLine(), out newPagesRead) || newPagesRead < 0 || newPagesRead > book.TotalPages)
            {
                Console.WriteLine($"Veuillez entrer un nombre de pages valide (entre 0 et {book.TotalPages}).");
            }

            // Mettre à jour les pages lues
            book.CurrentPage = newPagesRead;

            Console.WriteLine($"Le progrès du livre '{book.Title}' a été mis à jour à {book.CurrentPage}/{book.TotalPages} pages lues.");
        }
    }
}
