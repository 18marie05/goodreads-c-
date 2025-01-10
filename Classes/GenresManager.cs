using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// Ce fichier permet de gérer les genres depuis un fichier json externe
// Cela évite de faire une enum car les genres littéraires ne sont pas exhaustifs et l'utilisateur peut modifier cette liste

namespace Goodreads.Classes
{
    public class GenreManager
    {
        private const string GenreFilePath = "Data/genres.json";
        private List<string> genres = new List<string>();


        public IReadOnlyList<string> Genres => genres.AsReadOnly();

        public GenreManager()
        {
            LoadGenres();
        }

        // Charger les genres depuis le fichier json
        private void LoadGenres()
        {
            try
            {
                if (File.Exists(GenreFilePath))
                {
                    string json = File.ReadAllText(GenreFilePath);
                    genres = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                }
                else
                {
                    genres = new List<string>();
                    SaveGenres();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des genres littéraires : {ex.Message}");
                genres = new List<string>();
            }
        }

        // Sauvegarder les genres dans le fichier json
        private void SaveGenres()
        {
            try
            {
                string json = JsonSerializer.Serialize(genres, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(GenreFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la sauvegarde des genres littéraires : {ex.Message}");
            }
        }

            // Ajouter un nouveau genre (si la commande "add genre est lancée")
            public void AddGenre(string newGenre)
            {
                if (string.IsNullOrWhiteSpace(newGenre))
                {
                    Console.WriteLine("Le genre ne peut pas être vide ou constitué uniquement d'espaces.");
                }
                else if (genres.Contains(newGenre))
                {
                    Console.WriteLine("Le genre existe déjà.");
                }
                else
                {
                    genres.Add(newGenre);
                    SaveGenres();
                    Console.WriteLine($"Le genre '{newGenre}' a été ajouté.");
                }
            }

        // Afficher tous les genres (si la commande "display genres" est lancée)
        public void DisplayGenres()
        {
            if (genres.Count > 0)
            {
                Console.WriteLine("Genres disponibles :");
                foreach (var genre in genres)
                {
                    Console.WriteLine($"- {genre}");
                }
            }
            else
            {
                Console.WriteLine("Aucun genre disponible.");
            }
        }
    }
}
