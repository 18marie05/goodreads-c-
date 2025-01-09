# Projet C# - M2TAL - Marie Delporte-Landat
## Reproduction d'une bibliothèque électronique personnalisable


### But du projet
Reproduire les fonctionnalités de Goodreads. Goodreads est une plateforme sociale sous la forme d'un site et d'une application permettant à ses utilisateurs de chercher sa base de données de livres, les ajouter à leur bibliothèque virtuelle, les noter, écrire des reviews, connecter à d'autres lecteurs etc.  

Mon projet ne reprend pas toutes ces fonctionnalités, mais elle permettra à l'utilisateur de créer sa bibliothèque virtuelle. Il faut noter que cette bibliothèque ne possède pas de base de données littéraires connectée en interne, mais permer à l'utilisateur de conserver ses lectures ainsi que quelques informations liées à celles-ci. Si l'utilisateur décide de rentrer des livres qui n'existent pas, l'application ne renverra aucune erreur.

### A savoir
Concernant les données utilisées pour le projet, elles ont été créées manuellement au fur et à mesure de sa construction.  
Elles sont contenues dans le dossier ```Data/``` où se trouvent un fichier ```genres.json``` qui correspond à différents genres littéraires (cette liste peut être mise à jour par l'utilisateur ; voir les fonctionnalités disponibles dans la partie suivante) ; un fichier ```bookstosave.json``` qui correspond à une bibliothèque exemple que j'ai créée via les commandes disponibles et sauvegardée au format json ; un fichier ```mybooks.csv``` qui est la même chose mais au format csv.  

### Fonctionnalités et commandes
Avec cette application, il est possible de :  
- construire sa bibliothèque en ajoutant et supprimant des livres,
- visualiser tous les livres enregistrés avec leurs informations,
- rechercher un livre,
- ajouter un statut à chaque livre : Want to read, Currently Reading, Read,
- mettre à jour le statut d'un livre (par exemple le passer de Currently reading à Read),
- mettre à jour la progression d'un livre (en nombre de pages) pour un livre en cours de lecture,
- noter un livre (de 1 à 5) une fois un livre lu,
- visualiser les genres disponibles dans la liste de genres littéraires contenus dans ```Data/genres.json```,
- ajouter un genre à la liste de genres contenus dans le fichier ```Data/genres.json```,
- afficher les livres correspondant à un statut,
- charger et seauvegarder sa bibliothèque aux formats csv et json  

Voici toutes les fonctionnalités disponibles :  
- dotnet run --aide : cette commande sert à afficher l'aide et toutes les commandes disponibles. Elle permet surtout à l'utilisateur de lancer le programme en affichant directement toutes les commandes disponibles s'il ne sait pas comment s'y prendre lors de la première utilisation.  

Pour toutes les autres commandes, il faut d'abord lancer l'application avec ```dotnet run``` puis  ```<enter>```.  
Une fois cette commande lancée, _"Veuillez entrer une commande (tapez 'exit' pour quitter) :_ s'affiche.  
Les commandes disponibles sont :  
- ```help``` : permet d'afficher l'aide avec toutes les commandes disponibles  
- ```exit``` : permet de quitter le programme (attention, si rien n'est enregistré, les informations seront naturellement perdues)  
- ```add book``` : permet d'ajouter un livre à la bibliothèque (d'autres informations seront à ajouter aux étapes suivantes en fonction des messages écrits à l'écran telles que le titre, l'auteur, le statut, le genre, le nombre de pages)
- ```delete book``` : permet de supprimer un livre présent dans la bibliothèque
- ```display books``` : permet d'afficher la liste des livres présents dans la bibliothèque
- ```search book``` : permet de chercher un livre et donne toutes ses informations s'il existe
- ```update progress``` : permet de mettre à jour la progression de lecture pour un livre en cours de lecture
- ```change book status``` : permet de passer d'un livre Want to read à Currently Reading par exemple
- ```rate book``` : permet de noter un livre déjà lu (=avec un statut de Read)
- ```display genre``` : permet de visualiser la liste des genres disponibles dans le fichier Data/genres.json
- ```add genre``` : permet d'ajouter un genre à la liste des genres existants dans le fichier Data/genres.json
- ```want to read``` : permet d'afficher les livres qui ont un statut Want To Read
- ```currently reading``` : permet d'afficher les livres qui ont un statut Currently Reading
- ```read``` : permet d'afficher les livres qui ont un statut Read
- ```save``` : permet de sauvegarder la bibliothèque au format csv ou json (l'extension n'est pas à préciser en argument, elle sera à préciser par la suite, il suffit de se laisser guider par les messages qui s'affichent)
- ```load``` : permet de charger une bibliothèque précédemment sauvegardée au format csv ou json


### Quelques exemples d'utilisation

- Un exemple avec la commande _add book_ :
```Veuillez entrer une commande (tapez 'exit' pour quitter) : 
add book
Entrez le titre du livre : Babel
Entrez l'auteur du livre : RF Kuang
Entrez le statut de lecture (0=WantToRead, 1=CurrentlyReading, 2=Read) : 0
Entrez le nombre total de pages : 560
Entrez les genres du livre (séparés par des virgules) : 
Fiction, History, Historical Fiction
Livre ajouté avec succès !
```

- Un exemple avec la commande _save_ : 
```
Veuillez entrer une commande (tapez 'exit' pour quitter) : 
save
Entrez le nom du fichier pour sauvegarder (sans extension) : 
test
Choisissez le format de sauvegarde : CSV ou JSON (entrez 'csv' ou 'json') : 
json
Bibliothèque sauvegardée dans Data/test.json
```
