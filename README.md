# EZ Ant Simulator 2K17
<p align="center">
  <img src="https://github.com/xTeddyR/Fourmiliere/blob/master/FourmilliereAL/Media/warrior-ant.png" />
</p>

[![GitHub release](https://img.shields.io/github/tag/xTeddyR/Fourmiliere.svg)]()
[![GitHub issues](https://img.shields.io/github/issues/xTeddyR/Fourmiliere.svg)](https://github.com/xTeddyR/Fourmiliere/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/xTeddyR/Fourmiliere.svg)](https://github.com/xTeddyR/Fourmiliere/pulls)
[![GitHub commits](https://img.shields.io/github/commits-since/xTeddyR/Fourmiliere/v1.0.svg)]()

Un simulateur de fourmilière en C# .Net, une IMH en WPF. 
Récupérez le code source, générez-le et éxécutez-le !
```
git clone https://github.com/xTeddyR/Fourmiliere.git
```

### Spécifications ###

	-Pattern Fabrique Abstraite :
		-FabriqueCase :
			-Terrain -> Aucun objet n'apparait dans cette Case
			-Eau -> Inaccessible par les fourmis
			-Herbe
		-FabriqueObjet :
			-Pomme -> Rend de la vie
			-Baton -> Devient fourmi combattante
			-Panier -> Devient fourmi cueilleuse
			-Phéromone
		-FabriqueEnvironement :
			-Jour -> Crée des pommes random sur la map
			-Nuit -> Fourmi random devient une Fourmi-Garou,
				-Si elle rencontre une fourmi elle devient une Fourmi-Garou jusqu'au Jour
		-FabriqueFourmi :
			-BébéFourmi -> Après deux tours devient Fourmi
			-Fourmi
			-FourmiCueilleuse -> Récupère les phéromones
			-FourmiCombattante -> Grâce au baton
			-ReineFourmi -> Singleton
			-FourmiRouge
			
### Crédits ###
- [xTeddyR](https://github.com/xTeddyR)
- [jeremyboehm](https://github.com/jeremyboehm)
- [Sorion](https://github.com/Sorion)
