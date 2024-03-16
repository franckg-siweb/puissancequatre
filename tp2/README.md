# Reprise d'un projet legacy

> Franck GUTMANN

## 1. Les difficultés liées à la validation

Il y a plusieurs freins à la validation du logiciel dans son état actuel.

- Les méthodes de jeu sont très longues et ont une complexité cyclomatique très élevées.

- L'issue de ces dernières dépendent d'entrées utilisateur devant survenir au cours de l'execution de la fonction.

- La plupart des méthodes ne retournent pas de valeur mais affiche des données dans le terminal.

```text
Ces points rendent la validation automatisée très compliquée, car elle ne peut reposer que sur de la simulation d'entrée et de lecture de la console. Au moindre changement d'affichage que l'on souhaite effectuer, les tests ne fonctionnerons plus.
```

- Il existe beaucoup de code dupliqué, notamment entre les deux jeux implémentés mais aussi au sein d'un même fichier.
  - La grille est réimplémentée dans chaque jeu
  - La vérification de victoire est réimplémentée dans chaque jeu
  - La gestion des entrées utilisateur est réimplémentée dans chaque jeu
  - La gestion des tours est réimplémentée dans chaque jeu
  - La gestion de l'affichage est réimplémentée dans chaque jeu

```text
La duplication de code augmentera drastiquement la quantité de travail nécessaire pour valider le logiciel et maintenir les tests unitaires.
```

## 2. Les méthodes de résolution de ces problèmes

Pour valider l'existant et corriger les bugs éventuels, la première chose à faire de est de découper les méthodes existantes et réarchitecturer le code afin de supprimer le code dupliqué.

Cela permettra de réduire la compléxité cyclomatique et améliorer la lisibilité et la maintenabilité du code. Il sera ainsi bien plus simple de valider le logiciel en écrivant des tests unitaires correctement découpés et portant sur un cas d'utilisation précis.

En même temps, il est possible de rendre la plupart des mécanismes de jeu génériques afin de ne pas avoir à en maintenant deux codes semblables en parrallèle.

## 3. Le développement des fonctionnalités manquantes

### Enregistrement et chargement de partie

### Jeu de l'ordinateur
