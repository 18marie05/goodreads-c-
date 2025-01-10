using Goodreads.Classes;

/*
Permet à l'utilisateur de noter un livre (de 1 à 5) s'il a déjà été lu (statut Read)
*/

namespace Goodreads.Commands;

public class RateBookCommand : ExecuteCommand
{
    private readonly Library library;

    public RateBookCommand(Library library)
    {
        this.library = library;
    }

    public override void Execute()
    {
        Console.WriteLine("Entrez le titre du livre que vous souhaitez noter : ");
        string? title = Console.ReadLine();

        Console.WriteLine("Entrez le nom de l'auteur du livre : ");
        string? author = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Titre ou auteur invalide.");
            return;
        }

        var book = library.GetBookByTitleAndAuthor(title, author);

        if (book == null)
        {
            Console.WriteLine($"Le livre '{title}' par '{author}' n'a pas été trouvé.");
            return;
        }

        // Vérification si le livre est "Read" avant de demander la note
        if (book.Status != ReadingStatus.Read)
        {
            Console.WriteLine($"Vous ne pouvez noter un livre uniquement si il a été lu (statut 'Read') Le statut actuel est : {book.Status}.");
            return;
        }

        // Si le livre est "Read", on demande la note
        Console.WriteLine($"Entrez une note pour le livre '{title}' (entre 1 et 5) : ");
        if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
        {
            book.SetRating(rating);
            Console.WriteLine($"Vous avez noté le livre '{title}' avec une note de {rating}.");
        }
        else
        {
            Console.WriteLine("Note invalide. Entrez un nombre entre 1 et 5.");
        }
    }

}

