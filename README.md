# Reprise d'un projet legacy

> Franck GUTMANN

## 1. Les difficultés liées à la validation

Il y a plusieurs freins à la vlaidation du logiciel dans son état actuel.

- Les méthodes de jeu sont très longues et ont une complexité cyclomatique très élevées. L'issue de ces dernières dépendent d'entrées utilisateur devant survenir au cours de l'execution de la fonction.

- La plupart des méthodes ne retournent pas de valeur mais affiche des données ans le terminal. Cela complique la validation des résultats.

- Il existe beaucoup de code dupliqué, notamment entre les deux jeux implémentés mais aussi au sein d'un même fichier.

> TODO : examples

## 2. Les méthodes de résolution de ces problèmes

Pour valider l'existant et corriger les bugs éventuels, la première chose à faire de est de découper les méthodes existantes afin de réduire la compléxité cyclomatique et améliorer la lisibilité et la maintenabilité du code.

En même temps, il est possible de rendre la plupart des mécanismes de jeu génériques afin de ne pas avoir à en maintenant deux en parrallèle.

## 3. Le développement des fonctionnalités manquantes
