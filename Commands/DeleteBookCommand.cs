using Goodreads.Classes;

/*
Permet à l'utilisateur de supprimer un livre de sa bibliothèque via la commande "delete book"
en spécifiant titre + auteur
*/

namespace Goodreads.Commands;

public class DeleteBookCommand : ExecuteCommand
{
    private readonly Library library;

    public DeleteBookCommand(Library library)
    {
        this.library = library;
    }

    public override void Execute()
    {
        Console.WriteLine("Entrez le titre du livre à supprimer : ");
        string? title = Console.ReadLine();

        Console.WriteLine("Entrez le nom de l'auteur du livre : ");
        string? author = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Titre ou auteur invalide.");
            return;
        }

        try
        {
            library.RemoveBook(title, author);
            Console.WriteLine($"Le livre '{title}' par '{author}' a été supprimé.");
        }
        catch (BookNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
