using Goodreads.Classes;

/*
Permet à l'utilisateur d'ajouter des genres au fichier json
*/

namespace Goodreads.Commands
{
    public class AddGenre : ExecuteCommand
    {
        private readonly GenreManager _genreManager;

        public AddGenre(GenreManager genreManager)
        {
            _genreManager = genreManager;
        }

        public override void Execute()
        {
            Console.Write("Entrez un nouveau genre : ");
            string? genre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(genre))
            {
                Console.WriteLine("Le genre est invalide.");
                return;
            }

            _genreManager.AddGenre(genre);
        }
    }
}
