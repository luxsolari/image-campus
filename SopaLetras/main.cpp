#include <iostream>
#include <string>
#include <limits>
#include "utiles.h"

int main()
{
	srand(static_cast<unsigned>(time(nullptr)));  // NOLINT(cert-msc51-cpp)
	bool mainLoop = true;
	char input = '\0';

	while (mainLoop)
	{
		bool inputCorrecto = false;
		int inputDimension;
		int dimensionGrilla = 0;
		do
		{
			cout << "Elige la dimension para la grilla de las siguientes opciones:" << endl;
			cout << "[1] Chico  -  8 x 8 " << endl;
			cout << "[2] Medio  - 16 x 16" << endl;
			cout << "[3] Grande - 24 x 24" << endl;
			cout << "-> ";
			cin >> inputDimension;

			if (cin.good() && (inputDimension > 0 && inputDimension < 4))
			{
				inputCorrecto = true;
				switch (inputDimension)
				{
				case 1:
					dimensionGrilla = static_cast<int>(DimensionGrilla::CHICO);
					break;
				case 2:
					dimensionGrilla = static_cast<int>(DimensionGrilla::MEDIANO);
					break;
				case 3:
					dimensionGrilla = static_cast<int>(DimensionGrilla::GRANDE);
					break;
				default: 
					break;
				}
			}
			else
			{
				cin.clear();
				cin.ignore((std::numeric_limits<std::streamsize>::max()), '\n');
				cout << "Solo se permite ingresar numeros" << endl;
			}

		} while (!inputCorrecto);
		
		// ReSharper disable once CppUseAuto
		Casillero** grilla = new Casillero * [dimensionGrilla] {};
		randomizarGrilla(grilla, dimensionGrilla);

		Palabra misPalabras[10] = {
			Palabra("AZUL", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
			Palabra("NARANJA", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
			Palabra("AMARILLO", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
			Palabra("ROJO", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
			Palabra("VERDE", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
			Palabra("BLANCO", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
			Palabra("NEGRO", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
			Palabra("VIOLETA", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
			Palabra("ROSA", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
			Palabra("TURQUESA", static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))),
		};
		for (int i = 0; i < 10; i++)
		{
			if (misPalabras[i].longitud < dimensionGrilla)
				insertarPalabra(grilla, dimensionGrilla, misPalabras[i]);
		}
		
		mostrarGrilla(grilla, dimensionGrilla);

		// Limpiar recursos
		for (int i = 0; i < dimensionGrilla; i++)
		{
			delete[] grilla[i];
		}
		delete[] grilla;

		do
		{
			cout << endl;
			cout << "Ingresar nuevamente? (s/n): ";
			cin >> input;
			switch (input)
			{
			case 'S':
			case 's':
				system("cls");  // NOLINT(concurrency-mt-unsafe)
				break;
			case 'N':
			case 'n':
				cout << "Terminado!" << endl;
				mainLoop = false;
				break;
			default:
				cout << "Ingresar solamente 's' o 'n'" << endl;
				break;
			}
		} while (input != 'S' && input != 's' && input != 'N' && input != 'n');
	}

	return 0;
}

