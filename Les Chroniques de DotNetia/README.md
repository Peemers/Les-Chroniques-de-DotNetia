# Les Chroniques de DotNetia ⚔️

Système de combat **orienté objet en C#**, conçu comme un socle extensible pour un jeu de rôle (console ou autre).  
Le projet met l’accent sur une **architecture propre**, des **mécaniques de gameplay distinctes** et une **logique de combat modulaire**.

---

## 🎯 Objectifs du projet

- Mettre en pratique l’orienté objet en C#
- Concevoir une hié
- rarchie claire de classes
- Implémenter des mécaniques de jeu variées (ressources, états, bonus)
- Fournir une base solide et extensible pour un RPG

---

## 🧱 Architecture générale

```text
Interfaces
 ├─ ICible
 └─ ICombattant

Core
 └─ Combattant (abstrait)
     ├─ Joueur (abstrait)
     │   ├─ Guerrier
     │   ├─ Mage
     │   └─ Voleur
     └─ Ennemi (abstrait)
         ├─ Dragonnet
         ├─ GardienEngourdi
         ├─ TraqueurDesFourrés
         └─ Tombi

Utils
 └─ De (dés aléatoires)
```

---

## 🧩 Concepts clés

### Interfaces
- **ICible** : tout ce qui peut recevoir des dégâts
- **ICombattant** : contrat de base pour les entités combattantes

### Combattant
Classe centrale :
- gestion des PV
- attaques normales et lourdes
- critiques
- multiplicateurs de dégâts
- hooks de cycle de tour

### Cycle de tour
Chaque combattant peut réagir à différents moments :
- `DebutTour`
- `AvantAttaque`
- `ApresAttaque`
- `ApresAttaqueLourde`
- `ApresReceptionDegats`
- `FinTour`

---

## 🧙 Classes jouables

### Guerrier
- Ressource : **Rage**
- Mode **Berserk** à bas PV
- Plus il est en danger, plus il devient puissant

### Mage
- Ressource : **Mana**
- État **Illuminé** à mana élevée
- Spécialisé dans les dégâts

### Voleur
- Ressource : **Énergie**
- Système de **points de combo**
- Gros burst de dégâts cyclique

---

## 👹 Ennemis

### Dragonnet
- Ennemi simple et offensif

### Gardien Engourdi
- Protection massive tant qu’il n’a pas été touché

### Traqueur des Fourrés
- Attaques de plus en plus puissantes s’il reste hors de danger

### Tombi
- Approche progressive
- Une seule attaque, mais dévastatrice

---

## 🎲 Aléatoire

La classe `De` permet de :
- simuler les dégâts
- gérer les coups critiques
- centraliser l’aléatoire du combat

---

## 🚀 Extensibilité

Le système est pensé pour évoluer :
- ajout de nouvelles classes
- IA ennemie
- buffs / debuffs
- gestion d’équipes
- journal de combat
- boucle de jeu (GameLoop)

---

## 🛠️ Technologies

- **Langage** : C#
- **Paradigme** : Orienté Objet
- **IDE** : JetBrains Rider / Visual Studio

---

## 👤 Auteur

**Mathieu**  
Projet pédagogique – formation développement logiciel  

---

> Projet conçu comme un socle technique.  
> L’objectif n’est pas un jeu finalisé mais une architecture propre, lisible et évolutive.
