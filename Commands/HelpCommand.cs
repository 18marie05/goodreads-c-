using System;

// Commandes d'aide

namespace Goodreads.Commands
{
    public class HelpCommand : ExecuteCommand
    {
        public override void Execute()
        {
            Console.WriteLine("Commandes disponibles pour construire votre bibliothèque 📚 :");
            Console.WriteLine("Pour chaque commande : choisir la commande, l'écrire dans le terminal sans argument puis faire <entrer>.");
            Console.WriteLine("Laissez vous guider par les différentes étapes pour indiquer les informations nécessaires");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("add book <enter> ----- <title> <author> <status> <genre> <totalPages> seront à ajouter aux étapes suivantes - Ajouter un livre à la bibliothèque. 📚📚📚");
            Console.WriteLine("   Exemple : add book puis les informations sont à écrire une par une (laissez vous guider) \"1984\" \"George Orwell\" \"WantToRead\" \"Dystopian, Fiction\" 328");
            Console.WriteLine("delete book ------ <title> <author> seront à ajouter aux étapes suivantes - Supprimer un livre (avec le titre du livre et l'auteur). ❌ ");
            Console.WriteLine("display books - Affiche tous les livres dans la bibliothèque.");
            Console.WriteLine("search book ----- <title> sera à ajouter à l'étape suivante - Cherche un livre en particulier et donne ses informations s'il existe.  🔎📚 ");
            Console.WriteLine("update progress ----- <title> <pagesRead> seront à ajouter à l'étape suivante - Met à jour la progression de lecture pour un livre en particulier.");
            Console.WriteLine("change book status ----- <title> sera à ajouter à l'étape suivante - Permet de changer le statut d'un livre en un autre");
            Console.WriteLine("rate book ----- <title> <author> seront à ajouter à l'étape suivante - Permet de noter un livre (uniquement les livres notés en statut Read). ⭐⭐⭐⭐⭐");
            Console.WriteLine("add genre ----- <newGenre> sera à ajouter à l'étape suivante - Ajoute un genre à la liste des genres disponibles.");
            Console.WriteLine("display genres - Affiche tous les genres disponibles.");
            Console.WriteLine("want to read - Affiche tous les livres classés comme WantToRead (=les livres que vous souhaitez lire).");
            Console.WriteLine("read - Affiche tous les livres déjà lus.");
            Console.WriteLine("currently reading - Affiche tous les livres que vous êtes en train de lire.");
            Console.WriteLine("save - Sauvegarder des données aux formats csv ou json.");
            Console.WriteLine("load - Charger des données aux formats csv ou json.");
            Console.WriteLine("help - Affiche cette aide.");
            Console.WriteLine("exit - Quitte le programme.");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
