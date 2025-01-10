namespace Goodreads.Classes
/*
La classe Book modélise les informations d'un livre. 
Elle stocke des détails tels que le titre, l'auteur, le statut de lecture, les genres associés, 
le nombre total de pages, l'avancement de la lecture, et une note éventuelle.
*/
{
    public class Book
    // Construire les livres avec ses propriétés
    {
        public string Title { get; } // Titre
        public string Author { get; } // Auteur
        public ReadingStatus Status { get; set; } // Statut de lecture (en cours, lu ou à lire)
        public List<string> Genres { get; set; } = new List<string>(); // Genres littéraires disponibles
        public int TotalPages { get; set; } // Total des pages du livre
        public int CurrentPage { get; set; } // Page actuelle dans le livre
        public int? Rating { get; private set; } // Note donnée au livre

        // Propriété calculée pour afficher les informations d'un livre
        public string Summary => $"{Title} par {Author} - {Status} ({CurrentPage}/{TotalPages} pages lues) - {Rating}";

        public string DisplayGenres => string.Join(", ", Genres);

        public string? DisplayRating => Status == ReadingStatus.Read && Rating.HasValue ? Rating.Value.ToString() : null;

        public Book(string title, string author, ReadingStatus status, List<string> genres, int totalPages, int currentPage=0, int? rating=null)
        {
            Title = title;
            Author = author;
            Status = status;
            Genres = genres;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            Rating = rating;
        }

        // Méthode pour changer le statut du livre
        public void ChangeStatus(ReadingStatus newStatus)
        {
            Status = newStatus;
        }

        // Mise à jour de l'avancement dans le livre
        public void UpdateProgress(int pagesRead)
        {
            if (pagesRead < 0)
            {
                Console.WriteLine("Le nombre de pages lues ne peut pas être négatif.");
                return;
            }
            if (pagesRead > TotalPages)
            {
                Console.WriteLine("Le nombre de pages lues ne peut pas dépasser le total des pages.");
                return;
            }
            CurrentPage = pagesRead;
        }

        // Mettre une note au livre
        public void SetRating(int? rating)
        {
            if (rating.HasValue && (rating < 0 || rating > 5))
            {
                throw new ArgumentException("La note doit être entre 0 et 5.");
            }
            Rating = rating;
        }
    }
}
