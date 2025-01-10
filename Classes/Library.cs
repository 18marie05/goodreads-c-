namespace Goodreads.Classes

/* 
Gère la collection de livres
Ses fonctionnalités principales : ajouter, rechercher, supprimer, filtrer des livres
*/

{
    public class Library
    {
        private List<Book> books = new List<Book>();

        // Ajouter un livre à la bibliothèque
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        // Afficher tous les livres
        public void DisplayBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Aucun livre présent dans la bibliothèque.");
                return;
            }

            foreach (var book in books)
            {
                if (book.Status == ReadingStatus.Read)
                {
                    Console.WriteLine($"{book.Title} par {book.Author} ({book.Status}) - {book.TotalPages}/{book.TotalPages} pages lues - {book.Rating}");
                }
                else
                {
                    Console.WriteLine($"{book.Title} par {book.Author} ({book.Status}) - {book.CurrentPage}/{book.TotalPages} pages lues - {book.Rating}");
                }
            }
        }

        public List<Book> GetBooks()
        {
            return books;
        }


        // Rechercher un livre par son titre
        public List<Book> SearchByTitle(string title)
        {
            return books.Where(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }


        // Supprimer un livre par son titre et auteur
        public void RemoveBook(string title, string author)
        {
            var bookToRemove = books.FirstOrDefault(b => 
                b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
                b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
            else
            {
                throw new BookNotFoundException($"Le livre '{title}' par '{author}' n'a pas été trouvé.");
            }
        }


        // Filtrer les livres par leur statut de lecture
        public List<Book> GetBooksByStatus(ReadingStatus status)
        {
            return books.Where(b => b.Status == status).ToList();
        }

        // Utile pour UpdateBookProgress.cs
        public Book? GetBookByTitle(string title)
        {
            return books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        // Rechercher un livre par titre et auteur
        public Book? GetBookByTitleAndAuthor(string title, string author)
        {
            return books.FirstOrDefault(b => 
                b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
                b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }



    }

    // Exception pour les livres non trouvés
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message) : base(message) { }
    }
}
