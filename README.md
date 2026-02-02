# Blog API – .NET Entity Framework Core
## Description

Ce projet se compose d'un API REST en .NET avec Entity Framework Core permettant la gestion d’articles de blog via des endpoints HTTP. 
Elle expose un CRUD Article et Comment communiquant avec persistance des données en base MySQL.
Ceci afin de développer une plateforme de blog interne.

## Installation

Vérifier l'installation des packages NuGet de Entity Framework Core

- Pomelo.EntityFrameworkCore.MySql (v9)
- Microsoft.EntityFrameworkCore.Tools

Ainsi que des packages pour logger

- Serilog.AspNetCore
- Serilog.Sinks.File

## Configuration & Base de données

Vérifier les informations du serveur dans appsettings.json

Ouvrir la Console du Gestionnaire de Packages

Exécuter :
Update-Database

Lancer l’application :
dotnet run


URL exemple :

https://localhost:7126 ( http://localhost:5298 )

## API – Article CRUD

Pour lister un article utiliser la formule GET 
	 -> https://localhost:7126/api/v1/articles 

Pour voir les détails d'un article utiliser la formule GET
	 -> https://localhost:7126/api/v1/articles/{ArticleID} 


Via l'utilisation de Postman 
Pour créer un article utiliser la formule POST 
	 -> https://localhost:7126/api/v1/articles 
Exemple de requête JSON:
{ 

  "title": "Mon premier article", 

  "content": "Contenu de mon article..." 

} 

Pour modifier un article utiliser la formule PUT 
	 -> https://localhost:7126/api/v1/articles/{ArticleID} 

Pour supprimer un article utiliser la formule DELETE 
	 -> https://localhost:7126/api/v1/articles/{ArticleID} 

## API – Comment 

Pour lister les commentaires utiliser la formule GET 
	 -> https://localhost:7126/api/v1/articles/{ArticleID}/comments 

Via l'utilisation de Postman 
Pour créer un commentaire utiliser la formule POST 
	 -> https://localhost:7126/api/v1/articles/{ArticleID}/comments 

Pour supprimer un commentaire utiliser la formule DELETE 
	 -> https://localhost:7126/api/v1/articles/{ArticleID}/comments/{CommentID} 

## Recherche

Pour rechercher des articles utiliser une des formule GET
	-> https://localhost:7126/api/v1/articles/search?title=
	-> https://localhost:7126/api/v1/articles/search?content=
	-> https://localhost:7126/api/v1/articles/search?title=&&?content=

## Pagination

Pour retourner 5 articles par page utiliser la formule GET
	-> https://localhost:7126/api/v1/articles?page=

## Logs

Les actions de l’application sont enregistrées dans le fichier :
logs/log.txt
(GetArticles et GetArticle)

