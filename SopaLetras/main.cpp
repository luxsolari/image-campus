#include <iostream>
#include <string>
#include <limits>
#include <vector>
#include "utiles.h"
#include "tematicas.h"

int main()
{
	srand(static_cast<unsigned>(time(nullptr)));  // NOLINT(cert-msc51-cpp)
	bool mainLoop = true;
	char input = '\0';

	while (mainLoop)
	{
		bool inputCorrecto = false;
		int inputDimension;

		int inputPVP;
		bool modoPVP = false;

		int dimensionGrilla = 0;
		int palabrasEncontradas = 0;
		int palabrasTotales = 0;

		vector<Palabra> palabrasAEncontrar;

		// Seleccion de tamaño de grilla
		do
		{
			cout << "Elige la dimension para la grilla de las siguientes opciones:" << endl;
			cout << "[1] Chico  - 16 x 16 " << endl;
			cout << "[2] Medio  - 24 x 24" << endl;
			cout << "[3] Grande - 32 x 32" << endl;
			cout << "-> ";
			cin >> inputDimension;

			if (cin.good() && (inputDimension > 0 && inputDimension < 4))
			{
				inputCorrecto = true;
				switch (inputDimension)
				{
				case 1:
					dimensionGrilla = static_cast<int>(DimensionGrilla::CHICO);
					palabrasTotales = 10;
					break;
				case 2:
					dimensionGrilla = static_cast<int>(DimensionGrilla::MEDIANO);
					palabrasTotales = 20;
					break;
				case 3:
					dimensionGrilla = static_cast<int>(DimensionGrilla::GRANDE);
					palabrasTotales = 25;
					break;
				default: 
					break;
				}
			}
			else
			{
				cin.clear();
				cin.ignore((std::numeric_limits<std::streamsize>::max()), '\n');
				system("cls");
			}
		} while (!inputCorrecto);
		// ReSharper disable once CppUseAuto
		Casillero** grilla = new Casillero* [dimensionGrilla] {};
		randomizarGrilla(grilla, dimensionGrilla);

		// Seleccion de solitario o pvp
		do
		{
			inputCorrecto = false;
			cout << "Elige to modo de juego:" << endl;
			cout << "[1] Solitario" << endl;
			cout << "[2] PvP"		<< endl;
			cout << "-> ";
			cin >> inputPVP;

			if (cin.good() && (inputPVP > 0 && inputPVP < 3))
			{
				inputCorrecto = true;
				if (inputPVP == 2)
					modoPVP = true;
			}
			else
			{
				cin.clear();
				cin.ignore((std::numeric_limits<std::streamsize>::max()), '\n');
				system("cls");
			}
		} while (!inputCorrecto);

		if (modoPVP)
		{
			// Insertar palabras a mano
			cout << "El modo PvP aun esta en construccion!" << endl;
		}
		else
		{
			int inputTematica;
			do
			{
				inputCorrecto = false;
				cout << "Elige una de las siguientes tematicas de palabras:" << endl;
				cout << "[1] Colores" << endl;
				cout << "[2] Paises y ciudades" << endl;
				cout << "[3] Computacion" << endl;
				cout << "[4] Videojuegos" << endl;
				cout << "-> ";
				cin >> inputTematica;

				if (cin.good() && (inputDimension > 0 && inputDimension < 5))
				{
					inputCorrecto = true;
					switch (inputTematica)
					{
					case 1:
						while (palabrasAEncontrar.size() < palabrasTotales)
						{
							const int indiceAInsertar = getRandomNumExclusive(0, 30);
							bool insertable = true;
							for (int j = 0; j < palabrasAEncontrar.size(); j++)
							{
								if (palabrasAEncontrar.at(j).palabra == colores[indiceAInsertar])
								{
									insertable = false;
									break;
								}
							}

							if (insertable)
							{
								Palabra palabra = Palabra(
									colores[indiceAInsertar], 
									static_cast<Orientacion>(getRandomNumExclusive(0, static_cast<int>(Orientacion::COUNT)))
								);
								insertarPalabra(grilla, dimensionGrilla, palabra);
								palabrasAEncontrar.push_back(palabra);
							}
						}
						break;
					case 2:
						break;
					case 3:
						break;
					case 4:
						break;
					}
				}
				else
				{
					cin.clear();
					cin.ignore((std::numeric_limits<std::streamsize>::max()), '\n');
					system("cls");
				}
			} while (!inputCorrecto);
			mostrarGrilla(grilla, dimensionGrilla);
		}

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

