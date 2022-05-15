#include <iostream>
#include "utils.h"

int getRandomNum (int min, int max)
{
	return rand() % (max + 1 - min) + min;
}

int getRandomNumEx (int min, int max)
{
	return rand() % (max + min) + min;
}

char getRandomChar ()
{
	// Casting de tipo de dato (convertir de un tipo de dato a otro).
	constexpr int min = static_cast<int>('-');
	constexpr int max = static_cast<int>('-');

	return static_cast<char>(getRandomNum(min, max));
}

bool estaOcupado (Casillero** grilla, Coordenada posInicio, Coordenada posFinal, Orientacion orientacion)
{
	int hits = 0;

	switch (orientacion)
	{
	case Orientacion::HORIZONTAL:
		for (int i = posInicio.coordX; i < posFinal.coordX; i++)
		{
			const Casillero casillero = grilla[posInicio.coordY][i];
			if (!casillero.esAutogenerado)
				hits ++;
		}
		break;
	case Orientacion::VERTICAL:
		for (int i = posInicio.coordY; i < posFinal.coordY; i++)
		{
			const Casillero casillero = grilla[i][posInicio.coordX];
			if (!casillero.esAutogenerado)
				hits ++;
		}
		break;
	}
	return hits;
}

void randomizarGrilla(Casillero** grilla, unsigned long dimensionMatriz){
	for (unsigned int i = 0; i < dimensionMatriz; ++i) 
	{
        // Incializar columnas con letras aleatorias
        grilla[i] = new Casillero[dimensionMatriz];
        for (unsigned int j = 0; j < dimensionMatriz; j++)
        {
            grilla[i][j] = Casillero(getRandomChar(), Coordenada(i, j), true);
        }
    }
}

void mostrarGrilla(Casillero** grilla, unsigned long dimensionMatriz)
{
	for (unsigned int i = 0; i < dimensionMatriz; i++)
	{
		for (unsigned int j = 0; j < dimensionMatriz; j++)
		{
			cout << grilla[i][j].contenido << " ";
		}
    cout << endl;
	}
}

void inicializarDatosDePrueba (Casillero** grilla, unsigned long dimensionMatriz)
{
    // Inicializamos un array de Palabras de prueba
    const Palabra misPalabras[5] = {
        {Palabra(
            "UNO",
            3,
            Coordenada(getRandomNum(0, dimensionMatriz - 3), getRandomNum(0, dimensionMatriz - 3)),  // posicion de inicio
            static_cast<Orientacion>(getRandomNumEx(0, static_cast<int>(Orientacion::COUNT))) // orientacion
        )}, 
        {Palabra(
            "DOS",
            3,
            Coordenada(getRandomNum(0, dimensionMatriz - 3), getRandomNum(0, dimensionMatriz - 3)),
            static_cast<Orientacion>(getRandomNumEx(0, static_cast<int>(Orientacion::COUNT)))
        )}, 
        {Palabra(
            "TRES",
            4,
            Coordenada(getRandomNum(0, dimensionMatriz - 4), getRandomNum(0, dimensionMatriz - 4)),
            static_cast<Orientacion>(getRandomNumEx(0, static_cast<int>(Orientacion::COUNT)))
        )}, 
        {Palabra(
            "CUATRO",
            6,
            Coordenada(getRandomNum(0, dimensionMatriz - 6), getRandomNum(0, dimensionMatriz - 6)),
            static_cast<Orientacion>(getRandomNumEx(0, static_cast<int>(Orientacion::COUNT)))
        )}, 
        {Palabra(
            "CINCO",
            5,
            Coordenada(getRandomNum(0, dimensionMatriz - 5), getRandomNum(0, dimensionMatriz - 5)),
            static_cast<Orientacion>(getRandomNumEx(0, static_cast<int>(Orientacion::COUNT)))
        )}, 
    };

    // Insertamos palabras de prueba en la sopa
    for (int i = 0; i < 5; i++)
    {
        Palabra palabra = misPalabras[i];
        if (static_cast<unsigned>(palabra.longitud) <= dimensionMatriz)
        {
            switch (palabra.orientacion)
            {
            case Orientacion::VERTICAL:
                for (int j = 0; j < palabra.longitud; j++)
                {
                    grilla[palabra.posicionInicio.coordY + j][palabra.posicionInicio.coordX] 
                    = Casillero(palabra.palabra[j], Coordenada(palabra.posicionInicio.coordX, (palabra.posicionInicio.coordY + j)), false);
                }
                break;
            case Orientacion::HORIZONTAL:
                for (int j = 0; j < palabra.longitud; j++)
                {
                    grilla[palabra.posicionInicio.coordY][palabra.posicionInicio.coordX + j]
                    = Casillero(palabra.palabra[j], Coordenada(palabra.posicionInicio.coordY, (palabra.posicionInicio.coordX + j)), false);
                }
                break;
            default:
                break;
            }
        }
    }
}
