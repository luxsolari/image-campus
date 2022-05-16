#include "utiles.h"
#include <iostream>

int getRandomNumInclusive (const int min, const int max)
{
    return rand() % (max + 1 - min) + min;  // NOLINT(concurrency-mt-unsafe)
}

int getRandomNumExclusive (const int min, const int max)
{
    return rand() % (max + min) - min;  // NOLINT(concurrency-mt-unsafe)
}

//function for converting string to upper
string stringToUpper(string oString)
{
   for(int i = 0; i < static_cast<int>(oString.length()); i++){  // NOLINT(modernize-loop-convert)
       oString[i] = toupper(oString[i]);  // NOLINT(bugprone-narrowing-conversions, cppcoreguidelines-narrowing-conversions, clang-diagnostic-implicit-int-conversion)
    }
    return oString;
}

char getRandomChar ()
{
	// Casting de tipo de dato (convertir de un tipo de dato a otro).
	constexpr int min = static_cast<int>('A');
	constexpr int max = static_cast<int>('Z');

	return static_cast<char>(getRandomNumInclusive(min, max));
}

bool estaOcupado (const Casillero& casillero)
{
	if (casillero.esAutogenerado)
        return false;
	return true;
}

void insertarEnGrilla(Casillero** grilla, const int dimensionGrilla, Palabra& palabra, const bool alAzar)
{
	int cantidadOcupadas;
	int intentos = 1;
	bool insertable = true;
	Coordenada posicionInicio;

	switch (palabra.orientacion)  // NOLINT(clang-diagnostic-switch-enum)
	{
	case Orientacion::HORIZONTAL:
		// Elegir un lugar para insertar la palabra y verificar que sea posible
		do
		{
			if (alAzar)
			{
				// Elegir una posicion al azar
				posicionInicio = Coordenada(getRandomNumExclusive(0, dimensionGrilla - palabra.longitud), 
					getRandomNumExclusive(0, dimensionGrilla));
				palabra.posicionInicio = posicionInicio;
			}
			else
			{
				posicionInicio = palabra.posicionInicio;
			}

			cantidadOcupadas = 0;
			for (int i = 0; i < palabra.longitud; i++)
			{
				if (estaOcupado(grilla[posicionInicio.coordY][posicionInicio.coordX + i]) && 
				grilla[posicionInicio.coordY][posicionInicio.coordX + i].contenido[0] != palabra.palabra[i])
				{
					cantidadOcupadas ++;
				}
			}

			if (cantidadOcupadas > 0)
				intentos ++;
			if (intentos == INTENTOS_MAX)
			{
				insertable = false;
				palabra.intentosDeInsercion = INTENTOS_MAX;
			}
		}
		while (cantidadOcupadas != 0 && intentos <= INTENTOS_MAX);

		// Insertar la palabra si no hay espacios ocupados
		if (insertable)
		{
			for (int i = 0; i < palabra.longitud; i++)
			{
				grilla[posicionInicio.coordY][posicionInicio.coordX + i] = Casillero(palabra.palabra[i], 
					Coordenada(posicionInicio.coordY, posicionInicio.coordX + i), 
					false);
			}
		}
		palabra.intentosDeInsercion = intentos;
		break;
	case Orientacion::VERTICAL:
		do
		{
			if (alAzar)
			{
				// Elegir una posicion al azar
				posicionInicio = Coordenada(getRandomNumExclusive(0, dimensionGrilla), 
					getRandomNumExclusive(0, dimensionGrilla - palabra.longitud));
				palabra.posicionInicio = posicionInicio;
			}
			else
			{
				posicionInicio = palabra.posicionInicio;
			}

			cantidadOcupadas = 0;
			for (int i = 0; i < palabra.longitud; i++)
			{
				if (estaOcupado(grilla[posicionInicio.coordY + i][posicionInicio.coordX]) && 
				grilla[posicionInicio.coordY + i][posicionInicio.coordX].contenido[0] != palabra.palabra[i])
				{
					cantidadOcupadas ++;
				}
			}

			if (cantidadOcupadas > 0)
				intentos ++;
			if (intentos == INTENTOS_MAX)
			{
				insertable = false;
				palabra.intentosDeInsercion = INTENTOS_MAX;
			}
		}
		while (cantidadOcupadas != 0 && intentos <= INTENTOS_MAX);

		// Insertar la palabra si no hay espacios ocupados
		if (insertable)
		{
			for (int i = 0; i < palabra.longitud; i++)
			{
				grilla[posicionInicio.coordY + i][posicionInicio.coordX] = Casillero(palabra.palabra[i], 
					Coordenada(posicionInicio.coordY + i, posicionInicio.coordX), 
					false);
			}
			palabra.intentosDeInsercion = intentos;
		}
		break;
	case Orientacion::DIAGONAL:
		do
		{
			if (alAzar)
			{
				// Elegir una posicion al azar
				posicionInicio = Coordenada(getRandomNumExclusive(0, dimensionGrilla - palabra.longitud), 
					getRandomNumExclusive(0, dimensionGrilla - palabra.longitud));
				palabra.posicionInicio = posicionInicio;
			}
			else
			{
				posicionInicio = palabra.posicionInicio;
			}

			cantidadOcupadas = 0;
			for (int i = 0; i < palabra.longitud; i++)
			{
				if (estaOcupado(grilla[posicionInicio.coordY + i][posicionInicio.coordX + i]) && 
				grilla[posicionInicio.coordY + i][posicionInicio.coordX + i].contenido[0] != palabra.palabra[i])
				{
					cantidadOcupadas ++;
				}
			}

			if (cantidadOcupadas > 0)
				intentos ++;
			if (intentos == INTENTOS_MAX)
			{
				insertable = false;
				palabra.intentosDeInsercion = INTENTOS_MAX;
			}
		}
		while (cantidadOcupadas != 0 && intentos <= INTENTOS_MAX);

		// Insertar la palabra si no hay espacios ocupados
		if (insertable)
		{
			for (int i = 0; i < palabra.longitud; i++)
			{
				grilla[posicionInicio.coordY + i][posicionInicio.coordX + i] = Casillero(palabra.palabra[i], 
					Coordenada(posicionInicio.coordY + i, posicionInicio.coordX + i), 
					false);
			}
			palabra.intentosDeInsercion = intentos;
		}
		break;
	default: 
		break;
	}
}

void randomizarGrilla (Casillero** grilla, const int dimensionGrilla){
	for (int i = 0; i < dimensionGrilla; ++i) 
	{
        // Incializar columnas con letras aleatorias
        grilla[i] = new Casillero[dimensionGrilla];
        for (int j = 0; j < dimensionGrilla; j++)
        {
            grilla[i][j] = Casillero(getRandomChar(), Coordenada(i, j), true);
        }
    }
}

void mostrarGrilla (Casillero** grilla, const int dimensionGrilla)
{
	for (int i = 0; i < dimensionGrilla; i++)
	{
		for (int j = 0; j < dimensionGrilla; j++)
		{
			cout << grilla[i][j].contenido << " " ;
		}
    cout << endl;
	}
}

void inicializarPalabrasABuscar(vector<Palabra>& palabrasAEncontrar, const string palabrasTematicas[], int palabrasTotales)
{
	while (static_cast<int>(palabrasAEncontrar.size()) < palabrasTotales)
	{
		const int indiceAInsertar = getRandomNumExclusive(0, 30);
		bool insertable = true;
		for (int j = 0; j < static_cast<int>(palabrasAEncontrar.size()); j++)  // NOLINT(modernize-loop-convert)
		{
			if (palabrasAEncontrar.at(j).palabra == palabrasTematicas[indiceAInsertar])
			{
				insertable = false;
				break;
			}
		}

		if (insertable)
		{
			Palabra palabra = Palabra(
				palabrasTematicas[indiceAInsertar],
				static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))
			);
			palabrasAEncontrar.push_back(palabra);
		}
	}
}

Estado estaEnLista(vector<Palabra>& palabrasAEncontrar, const string& palabraBuscada)
{
	for (auto& element : palabrasAEncontrar)
	{
		
		if (element.palabra == palabraBuscada && element.encontrada)
			return Estado::REPETIDO;

		if (element.palabra == palabraBuscada && !element.encontrada)
		{
			element.encontrada = true;
			return Estado::ENCONTRADO;
		}
	}
	return Estado::NO_ENCONTRADO;
}
