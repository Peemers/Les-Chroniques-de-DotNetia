# Les Chroniques de DotNetia  
## Documentation technique – Système de combat (C# OO)

---

## 1. Vue d’ensemble

Ce projet implémente un **système de combat orienté objet** en C#, basé sur :
- Une hiérarchie de combattants (`Combattant`)
- Une séparation **Joueurs / Ennemis**
- Des mécaniques de combat extensibles (ressources, états, attaques lourdes)
- Une logique de tours avec hooks (`DebutTour`, `FinTour`)
- Une abstraction via interfaces

---

## 2. Interfaces

### ICible
Représente toute entité pouvant recevoir des dégâts.

- `RecevoirDegats(int degats)`

---

### ICombattant
Contrat de base pour tout combattant.

Propriétés :
- `Pseudo`
- `MaxPv`
- `PvActuels`
- `IsAlive`

Méthode :
- `Attaquer(ICible cible)`

---

## 3. Classe abstraite Combattant

Classe centrale du système.

Responsabilités :
- Gestion des PV
- Attaques normales et lourdes
- Coups critiques
- Multiplicateurs de dégâts
- Cycle de tour

Hooks disponibles :
- `DebutTour`
- `AvantAttaque`
- `ApresAttaque`
- `ApresAttaqueLourde`
- `ApresReceptionDegats`
- `FinTour`
- `PeutAttaquerLourd`

---

## 4. Joueurs

### Joueur (abstrait)
Base commune pour toutes les classes jouables.

---

### Guerrier
- Ressource : Rage
- Mode Berserk si PV ≤ 30 %
- Bonus dégâts et réduction reçue en berserk

---

### Mage
- Ressource : Mana
- État Illuminé si mana ≥ 70 %
- Bonus de dégâts

---

### Voleur
- Ressource : Énergie
- Système de points de combo
- Bonus de dégâts x2 à 5 combos

---

## 5. Ennemis

### Ennemi (abstrait)
Base commune pour les ennemis.

---

### Dragonnet
- Dégâts augmentés
- PV faibles

---

### GardienEngourdi
- Protection initiale (-75 % dégâts reçus)
- Protection perdue après le premier coup

---

### TraqueurDesFourrés
- Bonus de dégâts après plusieurs tours sans être touché
- Attaque amplifiée

---

### Tombi
- Mécanique de distance
- Attaque unique extrêmement puissante au contact

---

## 6. Utilitaire

### De
Simulation de dés :
- Dégâts
- Critiques

---

## 7. Architecture

- Code extensible
- Séparation claire des responsabilités
- Ajout facile de nouvelles classes

---

Auteur : Mathieu  
Projet : Les Chroniques de DotNetia  
Langage : C#
