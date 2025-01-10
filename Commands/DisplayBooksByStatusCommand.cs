using Goodreads.Classes;

/*
Permet à l'utilisateur de visualiser tous les livres appartenant à un statut de lecture
*/

namespace Goodreads.Commands
{
    public class DisplayBooksByStatus : ExecuteCommand
    {
        private readonly Library _library;
        private readonly ReadingStatus _status;

        public DisplayBooksByStatus(Library library, ReadingStatus status)
        {
            _library = library;
            _status = status;
        }

        public override void Execute()
        {
            var booksByStatus = _library.GetBooksByStatus(_status);
            if (booksByStatus.Any())
            {
                Console.WriteLine($"Livres avec le statut {_status}:");
                foreach (var book in booksByStatus)
                {
                    // Cas particulier pour le statut est "Read" : on affiche le nombre de pages lues et la note
                    if (book.Status == ReadingStatus.Read)
                    {
                        Console.WriteLine($"{book.Title} par {book.Author} ({book.Status}) - {book.TotalPages}/{book.TotalPages} pages lues - {book.Rating}");
                    }
                    else
                    {
                        Console.WriteLine($"{book.Title} par {book.Author} ({book.Status})");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Aucun livre trouvé avec le statut {_status}.");
            }
        }
    }
}
