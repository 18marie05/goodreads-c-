using Goodreads.Classes;
using Goodreads.Commands;

// Code qui gère les appels des commandes de l'utilisateur
// Permet à l'utilisateur de lancer le programme avec dotnet run --aide pour visualiser les commandes disponibles

namespace Goodreads
{
    class Program
    {
        public void Run(string[] args)
        {
            var genreManager = new GenreManager();
            var library = new Library();

            bool running = true;

            while (running)
            {
                // Demande de commande à l'utilisateur
                Console.WriteLine("\nVeuillez entrer une commande (tapez 'exit' pour quitter) : ");
                string? command = Console.ReadLine()?.ToLower();

                // Vérification pour éviter un appel sur null
                if (command == null)
                {
                    Console.WriteLine("Commande invalide. Essayez de nouveau.");
                    continue;
                }

                // Traitement des commandes
                switch (command)
                {
                    case "exit":
                        running = false;
                        break;

                    case "add book":
                        var addCommand = new AddCommand(library, genreManager);
                        addCommand.Execute();
                        break;

                    case "delete book":
                        var deleteBookCommand = new DeleteBookCommand(library);
                        deleteBookCommand.Execute();
                        break;

                    case "display books":
                        library.DisplayBooks();
                        break;

                    case "search book":
                        var searchCommand = new SearchBookCommand(library);
                        searchCommand.Execute();
                        break;

                    case "update progress":
                        var updateBookProgress = new UpdateBookProgress(library);
                        updateBookProgress.Execute();
                        break;

                    case "change book status":
                        var changeStatusCommand = new ChangeBookStatusCommand(library);
                        changeStatusCommand.Execute();
                        break;

                    case "rate book":
                        var rateBookCommand = new RateBookCommand(library);
                        rateBookCommand.Execute();
                        break;

                    case "add genre":
                        var addGenreCommand = new AddGenre(genreManager);
                        addGenreCommand.Execute();
                        break;

                    case "display genres":
                        genreManager.DisplayGenres();
                        break;

                    case "want to read":
                        var displayBooksByStatusCommandWTR = new DisplayBooksByStatus(library, ReadingStatus.WantToRead);
                        displayBooksByStatusCommandWTR.Execute();
                        break;

                    case "read":
                        var displayBooksByStatusCommandR = new DisplayBooksByStatus(library, ReadingStatus.Read);
                        displayBooksByStatusCommandR.Execute();
                        break;

                    case "currently reading":
                        var displayBooksByStatusCommandCR = new DisplayBooksByStatus(library, ReadingStatus.CurrentlyReading);
                        displayBooksByStatusCommandCR.Execute();
                        break;

                    case "save":
                        var saveCommand = new SaveCommand(library);
                        saveCommand.Execute();
                        break;

                    case "load":
                        var loadCommand = new LoadCommand(library);
                        loadCommand.Execute();
                        break;

                    case "help":
                        var helpCommand = new HelpCommand();
                        helpCommand.Execute();
                        break;

                    default:
                        Console.WriteLine("Commande inconnue. Essayez de nouveau.");
                        break;
                }
            }
        }

        // Point d'entrée de l'application
        static void Main(string[] args)
        {
            try
            {
                // Vérifie si l'utilisateur a passé l'argument '--aide'
                if (args.Contains("--aide"))
                {
                    Console.WriteLine("Affichage de l'aide...");
                    // Affiche ici un message d'aide ou appelle la commande HelpCommand
                    var helpCommand = new HelpCommand();
                    helpCommand.Execute();
                    return;
                }

                var program = new Program();
                program.Run(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur est survenue : {ex.Message}");
            }
        }
    }
}
