# Fourmiliere

Spécifications :
	Pattern Fabrique Abstraite :
		FabriqueCase :
			Terrain -> Aucun objet n'apparait dans cette Case
			Eau -> Inaccessible par les fourmis
			Herbe
		FabriqueObjet :
			Pomme -> Rend de la vie
			Baton -> Devient fourmi combattante
			Panier -> Devient fourmi cueilleuse
			Phéromone
		FabriqueEnvironement :
			Jour -> Crée des pommes random sur la map
			Nuit -> Fourmi random devient une Fourmi-Garou,
				Si elle rencontre une fourmi elle devient une Fourmi-Garou jusqu'au Jour
		FabriqueFourmi :
			BébéFourmi -> Après deux tours devient Fourmi
			Fourmi
			FourmiCueilleuse -> Récupère les phéromones
			FourmiCombattante -> Grâce au baton
			ReineFourmi -> Singleton
			FourmiRouge