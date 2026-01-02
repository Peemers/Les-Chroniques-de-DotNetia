# 🧭 NOTES_DEV — Les Chroniques de DotNetia

Ce fichier sert de **journal de dev** : décisions d’architecture, intentions, conventions, et “pourquoi” derrière le code.
Objectif : que **toi (ou quelqu’un d’autre)** puisse reprendre le projet dans 2 mois sans se refaire tout le contexte.

---

## 1) Philosophie du projet

- Projet **pédagogique** : priorité à la **clarté OO** plutôt qu’à “aller vite”.
- Le jeu n’est pas (encore) un produit fini : c’est un **socle**.
- Le code doit rester **extensible** : ajouter une classe / un ennemi / une zone ne doit pas casser l’existant.

---

## 2) Décisions d’architecture

### 2.1 Séparer “domaine” et “infra”
- `Models/` contient le **domaine** (joueurs, ennemis, zones).
- `Interfaces/` contient les **contrats** (ce qui est commun / stable).
- `Utils/` contient les outils transversaux (dés, hasard, helpers).
- `Program.cs` sert de **bac à sable** (tests, simulation, prototypage).

**Raison :** éviter que `Program.cs` devienne un “god file” et garder un domaine réutilisable.

### 2.2 Base abstraite `Combattant`
- Un socle commun pour joueurs + ennemis.
- Centralise : PV, dégâts, attaques, ressource, logique de tour.

**Raison :** éviter duplication et dérives “copier-coller” entre classes.

### 2.3 Interfaces (`ICible`, `ICombattant`)
- L’interface impose le minimum commun et réduit le couplage.

**Raison :** pouvoir brancher plus tard d’autres “cibles” (invocations, objets destructibles, etc.)
sans réécrire toute la logique.

---

## 3) Règles de conception (principes simples)

### 3.1 Une classe = une responsabilité principale
- Joueur : logique spécifique à une classe jouable.
- Ennemi : logique spécifique d’un ennemi.
- Zone : logique de génération + contexte.

### 3.2 Extensions faciles
Ajouter une nouvelle classe doit idéalement être :
- 1 fichier (nouvelle classe),
- éventuellement 1 ligne d’enregistrement (ex : zone / liste d’ennemis possibles),
- zéro modification dans le moteur de combat.

---

## 4) Choix liés au gameplay

### 4.1 Ressources différentes selon la classe
- Guerrier : rage
- Mage : mana
- Voleur : énergie

**Raison :** forcer des styles de jeu différents et tester du polymorphisme.

### 4.2 “Hooks” de tour (cycle)
Le combat est découpé en étapes (début tour / avant attaque / après attaque / fin tour…).

**Raison :** permettre aux classes d’injecter des effets (buff, état, passif) sans dupliquer l’attaque.

---

## 5) Zones & génération d’ennemis

### 5.1 Factories `Func<Ennemi>`
Les ennemis possibles dans une zone sont stockés sous forme de factories (fonctions qui créent un ennemi).

**Raison :**
- éviter de stocker des instances réutilisées (mauvais état partagé),
- éviter un couplage “new EnnemiX()” partout,
- permettre plus tard d’ajouter des poids/probas par factory.

### 5.2 `Program.cs` appelle encore la génération
C’est **temporaire** tant que la boucle de jeu / gestionnaire de zone n’est pas en place.

**Raison :** prototypage rapide, mais l’objectif est de déplacer ça dans une classe dédiée (GameLoop / ZoneManager).

---

## 6) Conventions (à garder cohérentes)

- Nommage : `PascalCase` pour classes/méthodes, `camelCase` pour variables locales.
- Les classes abstraites portent un nom clair (`Combattant`, `Joueur`, `Ennemi`, `Zone`).
- Les sous-classes sont “concrètes” et portent le nom métier (`Guerrier`, `Dragonnet`, `Foret`, etc.).
- Éviter les side-effects cachés dans les getters : préférer des méthodes explicites.

---

## 7) TODO / Roadmap technique

- [ ] Créer une **boucle de jeu** (GameLoop)
- [ ] Introduire une classe **CombatManager** (ou équivalent)
- [ ] Créer un **ZoneManager** (zone actuelle, transitions, génération d’ennemis)
- [ ] Ajouter un **journal de combat** (log)
- [ ] Ajouter des **états** (stun, poison, brûlure, etc.)
- [ ] Ajouter des **objets** (loot, consommables, équipements)
- [ ] Rééquilibrage des stats (PV/attaque/ressource)

---

## 8) Dettes connues (assumées)

- `Program.cs` trop impliqué (normal en phase proto).
- La doc doit suivre l’évolution (README + ARCHITECTURE + NOTES_DEV).
- Certaines mécaniques sont encore “en test” (donc susceptibles de changer).

---

## 9) Règle d’or

Si une fonctionnalité te force à ajouter 15 `if` dans `Program.cs`, c’est que tu dois probablement
créer une **classe** ou un **comportement polymorphe** à la place.

