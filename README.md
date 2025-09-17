# 📱 Project AR Mobile - Jeu de Tir en Réalité Augmentée

## 🎯 Description
Jeu de tir en réalité augmentée pour mobile où les joueurs placent une table virtuelle dans leur environnement réel et doivent toucher des cibles dans un temps limité. Le jeu combine détection d'environnement AR, physique réaliste et gameplay arcade.

## ✨ Fonctionnalités Principales

### Gameplay
- **Timer de partie** : 30 secondes pour marquer un maximum de points
- **Système de score** : Points attribués pour chaque cible touchée
- **Cibles dynamiques** : Différents types de cibles avec comportements variés
- **Rejouabilité** : Système de replay instantané

### Mécaniques AR
- **Détection de plans** : Reconnaissance automatique des surfaces
- **Placement d'objets** : Positionnement de la table de jeu dans l'espace réel
- **Tracking persistant** : La table reste en place pendant toute la partie
- **Interactions tactiles** : Tir par toucher de l'écran

## 🛠️ Technologies Utilisées

| Technologie | Version | Description |
|------------|---------|-------------|
| Unity | 2022.3+ | Moteur de jeu principal |
| AR Foundation | 5.1+ | Framework AR unifié Unity |
| XR Interaction Toolkit | 3.1.1 | Gestion des interactions AR |
| Input System | 1.7+ | Nouveau système d'input Unity |
| TextMeshPro | 3.0+ | Rendu de texte haute qualité |

## 📁 Structure du Projet

```
Project_Ar_mobile/
├── Assets/
│   ├── Scripts/
│   │   ├── GameManagerBis.cs      # Logique principale du jeu
│   │   ├── LancerBalle.cs         # Système de tir
│   │   ├── CibleIndividuelle.cs   # Comportement des cibles
│   │   ├── Table.cs               # Gestion table AR
│   │   └── CommencerButton.cs     # Interface de démarrage
│   ├── Prefabs/
│   │   ├── Projectile/            # Prefab de balle
│   │   ├── Targets/               # Différents types de cibles
│   │   └── ARObjects/             # Objets AR (table, etc.)
│   ├── Materials/                 # Matériaux et textures
│   ├── UI/                        # Éléments d'interface
│   └── Samples/                   # Exemples XR Toolkit
├── ProjectSettings/               # Configuration Unity
└── Packages/                      # Dépendances
```

## 🎮 Architecture du Code

### GameManagerBis.cs
**Gestion centrale du jeu** avec pattern Singleton
```csharp
- Gestion du timer (30 secondes)
- Système de score
- États de jeu (en cours/terminé)
- Fonction replay
```

### ProjectileShooter (LancerBalle.cs)
**Système de tir AR**
```csharp
- Spawn de projectiles depuis la caméra
- Vérification état de jeu
- Application de forces physiques
- Détection de la table AR
```

### CibleIndividuelle.cs
**Comportement des cibles**
```csharp
- Deux modes de détection (Collision/Trigger)
- Détection de chute avec gravité
- Système de reset pour nouvelle partie
- Communication avec GameManager
```

### Table.cs
**Gestionnaire de table AR**
```csharp
- Placement dans l'environnement
- Gestion des cibles enfants
- Pattern Singleton
- Validation des touches
```

## 📲 Installation et Configuration

### Prérequis
- Unity 2022.3 LTS ou supérieur
- Android SDK (API Level 24+) ou iOS 11+
- Appareil compatible ARCore (Android) ou ARKit (iOS)

### Installation
1. Cloner le repository
```bash
git clone [repository-url]
cd Project_Ar_mobile
```

2. Ouvrir avec Unity Hub
   - Version Unity 2022.3 LTS recommandée
   - Installer les modules Android/iOS

3. Configuration AR
   - `Edit > Project Settings > XR Plug-in Management`
   - Android : Activer ARCore
   - iOS : Activer ARKit

### Build Settings

#### Android
- **Minimum API Level** : 24 (Android 7.0)
- **Target API Level** : 33
- **Scripting Backend** : IL2CPP
- **Target Architectures** : ARM64

#### iOS
- **Target minimum iOS Version** : 11.0
- **Architecture** : ARM64
- **Camera Usage Description** : Requis pour AR

## 🎯 Guide d'Utilisation

### Démarrage d'une Partie
1. **Lancer l'application**
2. **Scanner l'environnement** : Déplacer le téléphone pour détecter les surfaces
3. **Placer la table** : Toucher une surface détectée
4. **Appuyer sur "Commencer"** pour démarrer le timer
5. **Tirer sur les cibles** : Toucher l'écran pour lancer des balles

### Contrôles
| Action | Geste | Description |
|--------|-------|-------------|
| Scanner | Mouvement téléphone | Détecte les surfaces planes |
| Placer table | Tap sur surface | Positionne la table de jeu |
| Tirer | Tap écran | Lance une balle vers la cible |
| Rejouer | Bouton "Rejouer" | Relance une partie |

## ⚙️ Configuration des Cibles

### Types de Cibles
```csharp
// Dans CibleIndividuelle.cs
- utiliserTrigger: false  // Cible physique standard
- utiliserTrigger: true   // Cible avec zone de détection
- seuilChute: 0.2f       // Sensibilité de chute
```

### Paramètres de Jeu
```csharp
// Dans GameManagerBis.cs
- tempsInitial: 30f      // Durée de la partie
- forceProjectile: 500f  // Vitesse des balles
```

## 🔧 Optimisation Mobile

### Performance
- **FPS cible** : 30-60 FPS
- **Résolution** : Adaptative selon device
- **Shaders** : Mobile-optimized
- **Textures** : Compression ETC2/ASTC

### Consommation Batterie
- Désactivation AR quand non nécessaire
- LOD pour objets distants
- Réduction particules et effets

## 🐛 Résolution de Problèmes

### Problèmes Courants

**Surfaces non détectées**
- Meilleur éclairage requis
- Éviter surfaces réfléchissantes
- Scanner plus lentement

**Table mal placée**
- Rescan de la surface
- Vérifier plan horizontal
- Redémarrer l'application

**Performances faibles**
- Fermer autres applications
- Réduire qualité graphique
- Vérifier compatibilité ARCore/ARKit

## 📊 Statistiques de Jeu

### Métriques Suivies
- Score maximum
- Temps moyen de partie
- Précision de tir
- Cibles touchées par partie

## 🚀 Améliorations Futures

- [ ] Multijoueur local
- [ ] Différents niveaux de difficulté
- [ ] Power-ups et bonus
- [ ] Leaderboard en ligne
- [ ] Nouveaux types de cibles
- [ ] Modes de jeu supplémentaires

## 📚 Ressources

- [AR Foundation Documentation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest)
- [ARCore Developer Guide](https://developers.google.com/ar)
- [ARKit Documentation](https://developer.apple.com/arkit/)
- [Unity Mobile Optimization](https://docs.unity3d.com/Manual/MobileOptimization.html)

## 🤝 Contribution
Pour contribuer au projet :
1. Fork le repository
2. Créer une branche feature (`git checkout -b feature/AmazingFeature`)
3. Commit les changements (`git commit -m 'Add AmazingFeature'`)
4. Push vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrir une Pull Request

## 📄 License
Projet développé dans le cadre du double master BIHAR & Ingénierie Logicielle.

## 📧 Contact
Vincent Chabran - [votre email]

---
*Développé avec Unity 2022.3 LTS et AR Foundation 5.1*