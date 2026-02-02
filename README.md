# Blog API – .NET Entity Framework Core
## Description

Ce projet se compose d'un API REST en .NET avec Entity Framework Core permettant la gestion d’articles de blog via des endpoints HTTP. 
Elle expose un CRUD Article et Comment communiquant avec persistance des données en base MySQL.
Ceci afin de développer une plateforme de blog interne.

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

GET /api/v1/articles → Liste des articles

GET /api/v1/articles/{id} → Détails d’un article

POST /api/v1/articles → Créer un article

PUT /api/v1/articles/{id} → Modifier un article

DELETE /api/v1/articles/{id} → Supprimer un article

## API – Comment 

GET /api/v1/articles/{articleId}/comments → Liste des comments

POST /api/v1/articles/{articleId}/comments → Créer un article

DELETE /api/v1/articles/{articleId}/comments/{commentId} → Supprimer un article

## Recherche

GET /api/v1/articles/search?title=
GET /api/v1/articles/search?content=
GET /api/v1/articles/search?title=&&content=

## Pagination

GET /api/v1/articles?page=

## Logs

Les actions de l’application sont enregistrées dans le fichier :
logs/log.txt
(GetArticles et GetArticle)

## Test

Tester les endpoints avec Postman en utilisant l’URL de l’API.