#include "utiles.h"
int getRandomNumInclusive (int min, int max)
{
    return rand() % (max + 1 - min) + min;
}

int getRandomNumExclusive (int min, int max)
{
    return rand() % (max + min) - min;
}

char getRandomChar ()
{
	// Casting de tipo de dato (convertir de un tipo de dato a otro).
	constexpr int min = static_cast<int>('-');
	constexpr int max = static_cast<int>('-');

	return static_cast<char>(getRandomNumInclusive(min, max));
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

void randomizarGrilla (Casillero** grilla, unsigned long dimensionGrilla){
	for (unsigned int i = 0; i < dimensionGrilla; ++i) 
	{
        // Incializar columnas con letras aleatorias
        grilla[i] = new Casillero[dimensionGrilla];
        for (unsigned int j = 0; j < dimensionGrilla; j++)
        {
            grilla[i][j] = Casillero(getRandomChar(), Coordenada(i, j), true);
        }
    }
}

void mostrarGrilla (Casillero** grilla, unsigned long dimensionGrilla)
{
	for (unsigned int i = 0; i < dimensionGrilla; i++)
	{
		for (unsigned int j = 0; j < dimensionGrilla; j++)
		{
			cout << grilla[i][j].contenido << " ";
		}
    cout << endl;
	}
}

void inicializarDatosPrueba (Casillero** grilla, unsigned long dimensionGrilla)
{
    // Inicializamos un array de Palabras de prueba
    const Palabra misPalabras[5] = {
        {Palabra(
            "UNO",
            3,
            Coordenada(getRandomNumInclusive(0, dimensionGrilla - 3), getRandomNumInclusive(0, dimensionGrilla - 3)),  // posicion de inicio
            static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT))) // orientacion
        )}, 
        {Palabra(
            "DOS",
            3,
            Coordenada(getRandomNumInclusive(0, dimensionGrilla - 3), getRandomNumInclusive(0, dimensionGrilla - 3)),
            static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))
        )}, 
        {Palabra(
            "TRES",
            4,
            Coordenada(getRandomNumInclusive(0, dimensionGrilla - 4), getRandomNumInclusive(0, dimensionGrilla - 4)),
            static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))
        )}, 
        {Palabra(
            "CUATRO",
            6,
            Coordenada(getRandomNumInclusive(0, dimensionGrilla - 6), getRandomNumInclusive(0, dimensionGrilla - 6)),
            static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))
        )}, 
        {Palabra(
            "CINCO",
            5,
            Coordenada(getRandomNumInclusive(0, dimensionGrilla - 5), getRandomNumInclusive(0, dimensionGrilla - 5)),
            static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))
        )}, 
    };

    // Insertamos palabras de prueba en la sopa
    for (int i = 0; i < 5; i++)
    {
        Palabra palabra = misPalabras[i];
        if (static_cast<unsigned>(palabra.longitud) <= dimensionGrilla)
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
