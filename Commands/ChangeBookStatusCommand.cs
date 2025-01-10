using Goodreads.Classes;

/*
Permet de changer le statut d'un livre via la commande "change book status"
En fonction de ses activités, le lecteur peut changer le statut d'un livre
en le passant de Want To Read à Currently Reading à Read par exemple
*/

namespace Goodreads.Commands
{
    public class ChangeBookStatusCommand : ExecuteCommand
    {
        private readonly Library _library;

        public ChangeBookStatusCommand(Library library)
        {
            _library = library;
        }

        public override void Execute()
        {
            Console.Write("Entrez le titre du livre pour changer son statut : ");
            string? title = Console.ReadLine();

            if (title == null)
            {
                Console.WriteLine("Titre invalide.");
                return;
            }

            var book = _library.SearchByTitle(title)?.FirstOrDefault();
            if (book != null)
            {
                Console.WriteLine("Choisissez un nouveau statut pour le livre : ");
                Console.WriteLine("0 = WantToRead");
                Console.WriteLine("1 = CurrentlyReading");
                Console.WriteLine("2 = Read");

                if (Enum.TryParse<ReadingStatus>(Console.ReadLine(), out ReadingStatus newStatus))
                {
                    book.ChangeStatus(newStatus);
                    Console.WriteLine("Statut du livre mis à jour !");
                }
                else
                {
                    Console.WriteLine("Statut invalide.");
                }
            }
            else
            {
                Console.WriteLine("Livre introuvable.");
            }
        }
    }
}
