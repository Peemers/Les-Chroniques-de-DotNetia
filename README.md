
# 🎮 Les Chroniques de DotNetia — Documentation détaillée

## 1. Présentation générale

**Les Chroniques de DotNetia** est un projet de RPG console développé en **C# orienté objet**.
Il sert de projet pédagogique avancé pour mettre en pratique :
- l’héritage
- le polymorphisme
- les interfaces
- les classes abstraites
- la séparation claire des responsabilités

Le projet est volontairement structuré comme un **socle technique** plutôt qu’un jeu fini.

---

## 2. Architecture globale

Le projet est organisé autour de trois piliers :
- **Combattants** (joueurs et ennemis)
- **Zones** (environnements et génération)
- **Infrastructure** (interfaces, utilitaires, point d’entrée)

---

## 3. Interfaces

### ICible
Représente toute entité pouvant :
- recevoir des dégâts
- perdre des points de vie
- mourir

Cette interface permet de traiter uniformément joueurs et ennemis.

### ICombattant
Définit les capacités communes :
- attaquer
- subir des dégâts
- participer à un tour de combat

---

## 4. Classe abstraite Combattant

Classe centrale du projet.
Elle gère :
- les points de vie (PV max / actuels)
- l’attaque de base
- les attaques lourdes
- la ressource spécifique
- le cycle de tour

Cette classe expose plusieurs **hooks** permettant aux sous‑classes
d’altérer leur comportement sans casser la logique globale.

---

## 5. Joueurs

### Joueur (abstraite)
Base commune à toutes les classes jouables.
Responsabilités :
- initialisation des statistiques
- gestion de la ressource
- comportement par défaut en combat

### Guerrier
- Ressource : Rage
- Monte en puissance à mesure que ses PV baissent
- Dispose d’un mode Berserk

### Mage
- Ressource : Mana
- Peut entrer dans un état *Illuminé*
- Très dépendant de la gestion de ressource

### Voleur
- Ressource : Énergie
- Fonctionne avec un système de combos
- Spécialisé dans le burst

---

## 6. Ennemis

### Ennemi (abstraite)
Base commune à tous les ennemis.
Permet :
- l’unification du comportement
- l’extension facile de nouveaux ennemis

### Dragonnet
Ennemi simple orienté dégâts.

### Gardien Engourdi
Très défensif tant qu’il n’a pas été touché.

### Traqueur des Fourrés
Plus dangereux lorsqu’il n’est pas menacé.

### Tombi
Possède une attaque unique extrêmement puissante.

---

## 7. Zones

### Zone (abstraite)
Représente un environnement de jeu.
Responsabilités :
- stocker une description
- contenir une liste d’ennemis possibles
- générer dynamiquement des ennemis

Les ennemis sont fournis sous forme de **factories (`Func<Ennemi>`)**
afin d’éviter le couplage fort.

### Forêt
Implémentation concrète d’une zone.
Spécifie :
- ses ennemis possibles
- son ambiance
- sa difficulté

---

## 8. Génération et aléatoire

### Classe De
Centralise :
- le hasard
- les coups critiques
- les variations de dégâts

Cette séparation évite la duplication du `Random`
et facilite l’équilibrage.

---

## 9. Program.cs

Point d’entrée du projet.
Actuellement utilisé comme :
- zone de test
- simulateur de combats
- terrain d’expérimentation

À terme, il pourra être remplacé par :
- une vraie boucle de jeu
- un gestionnaire de scènes

---

## 10. État actuel du projet

Le projet est :
- fonctionnel sur le plan technique
- en cours d’extension

Fonctionnalités prévues :
- boucle de jeu complète
- gestion de progression
- nouvelles zones
- équilibrage

---

## 11. Objectif pédagogique

Ce projet a pour but :
- de comprendre **pourquoi** on structure ainsi
- d’éviter le code procédural déguisé
- de préparer des projets OO plus complexes

---

## 12. Auteur

Mathieu Peeters  
Projet personnel – formation développement logiciel

