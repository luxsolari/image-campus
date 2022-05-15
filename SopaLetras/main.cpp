#include <iostream>
#include <string>
#include <limits>
#include "utiles.h"

int main()
{
	srand(static_cast<unsigned>(time(nullptr)));
	bool mainLoop = true;
	char input = '\0';

	while (mainLoop)
	{
		// Pedir input del tamaño del array
		bool inputCorrecto = false;
		int inputDimension;
		int dimensionMatriz = 0;
		do
		{
			cout << "Elige la dimension para la grilla de las siguientes opciones:" << endl;
			cout << "[1] - Chico  -  8 x 8 " << endl;
			cout << "[2] - Medio  - 16 x 16" << endl;
			cout << "[3] - Grande - 24 x 24" << endl;
			cout << "-> ";
			cin >> inputDimension;

			if (cin.good() && (inputDimension > 0 && inputDimension < 4))
			{
				inputCorrecto = true;
				switch (inputDimension)
				{
				case 1:
					dimensionMatriz = static_cast<int>(DimensionGrilla::CHICO);
					break;
				case 2:
					dimensionMatriz = static_cast<int>(DimensionGrilla::MEDIANO);
					break;
				case 3:
					dimensionMatriz = static_cast<int>(DimensionGrilla::GRANDE);
					break;
				default: 
					break;
				}
			}
			else
			{
				// Operaciones sobre el stream de entrada para ignorar los inputs invalidos
				// https://stackoverflow.com/questions/5655142/how-to-check-if-input-is-numeric-in-c
				cin.clear();
				cin.ignore((std::numeric_limits<std::streamsize>::max()), '\n');
				cout << "Solo se permite ingresar numeros" << endl;
			}

		} while (!inputCorrecto);

		// Inicializar array
		Casillero** grilla = new Casillero * [dimensionMatriz] {};
		randomizarGrilla(grilla, dimensionMatriz);
		inicializarDatosPrueba(grilla, dimensionMatriz);

		// Mostrar matriz por pantalla
		mostrarGrilla(grilla, dimensionMatriz);

		// Limpiar recursos
		for (int i = 0; i < dimensionMatriz; i++)
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
				system("cls");
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

