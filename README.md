# Labo final C# - Gestion d'un championnat de basket
Le but est de pourvoir créer et gérer un championnat de basket avec la gestion des clubs participants, dans ces clubs, il y a des déléguées, arbitres et des équipes, dans ces équipes, il y a des joueurs, coach. Les équipes s'affrontent deux fois par championnat pour gagner des points dans le classement. L'application permet aussi de créer et de gérer les clubs et les équipes.

## Fonctionnalité

- Création et gestion de championnat lorsqu'un championnat est créé, tout les matchs sont programmé : tout les match seront contres deux équipes différentes, 2 arbitres de clubs différents, 3 délégées locaux et 2 délégées extérieure
- Le classement est fait en fonction des victoire (3 points par victoire - 1 points par défaite - 2 points par égalité) des différentes équipes
- Enregistrer des personnes
- Création et gestion de club
- Création et gestion d'équipe

## Projet

### :file_folder: ./ClasseBasket

Ce sont toute les classes métier qui permettent de faire fonctionner l'application


### :file_folder: ./GestionChampionnat

Contient les interfaces graphiques de l'application


## Classes

Voici les différentes classes métiers

### Personnes
C'est une classes asbraites qui désigne un être humain lié a l'application
- Nom
- Prénom

### Joueur
Joueur est une classe hérité de Personne qui est un joueur de basket qui participe activement à la pratique du basketball et qui fait partie d'une équipe
- numéro de joueurs

### déléguées
Delegue est une classe hérité de Personne qui est un délégué, qui sont responsable de la coordination des activités logistiques et administratives lors des rencontres de basketball. Il doit s'assurer que les règles sont respectées et que les équipes ont tout ce dont elles ont besoin pour jouer dans les meilleures conditions.
- numéro de délégués 

### Coach
Coach est une classe hérité de Personne qui est un coach au basket qui guide et entraîne les joueurs de basketball, en leur enseignant les techniques, les tactiques et les stratégies pour jouer au mieux de leurs capacités. Il est responsable de la formation des joueurs et de la gestion de l'équipe lors des matchs.
- Numéro de coach

### Arbitre
Arbitre est une classe hérité de Personne qui est un arbitre de basket responsable de faire respecter les règles du jeu lors des matchs de basketball.
- Numéro d'arbitre 

### Clubs
Un club de basket est une organisation sportive qui offre la possibilité aux joueurs de pratiquer le basketball en compétition ou en loisir. Il contient une liste d'équipe qui représente le club, une liste de délégué et d'arbitre affilié au clubs qui assurent le bon déroulé des matchs de basket.
- Nom
- Logo
- Addresses
- Equipe (Liste)
- Arbitre (Liste)

### Equipe
Une équipe de basket est un groupe de joueurs de basketball qui participe à des matchs. Il contient un coach et une liste de joueurs.
- Nom 
- Coach
- Joueur (Liste)
- Delegue (Liste)
- Niveau (P4, poussin, D1, ...)
- Catégorie (provincial, élite, régional)

### Championnat
Un championnat de basket est une compétition sportive qui rassemble plusieurs équipes de basketball. Les équipes s'affrontent dans un calendrier de matchs prédéfini pour déterminer le champion de la compétition. Elle contient la liste des Equipe qui participe et la liste des matchs qui vont ou se sont déroulés.
- Equipe (Liste)
- Match (Liste)

### AWBB
Singleton de l'application
- Liste de Championnats
- Liste de Clubs

### Match
- Date de rencontre
- Score locaux
- Score extérieur
- Equipe locale
- Equipe extérieur
- 2 arbitres
- 5 déléguées
### Equipe Classement
- Équipe
- Nombre de victoire
- Nombre de défaite
- Nombre d'égalite
- Points
