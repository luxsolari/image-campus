#include "utiles.h"

int main()
{
	srand(static_cast<unsigned>(time(nullptr)));
	bool mainLoop = true;
	char input = '\0';

	while (mainLoop)
	{
		bool inputCorrecto = false;
		int inputDimension;
		int inputTematica;
		int dimensionGrilla = 0;
		int palabrasTotales = 0;
		vector<Palabra> palabrasAEncontrar;

		// Seleccion de tamaño de grilla
		do
		{
			system("cls"); 
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
					palabrasTotales = 8;
					break;
				case 2:
					dimensionGrilla = static_cast<int>(DimensionGrilla::MEDIANO);
					palabrasTotales = 16;
					break;
				case 3:
					dimensionGrilla = static_cast<int>(DimensionGrilla::GRANDE);
					palabrasTotales = 24;
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

		Casillero** grilla = new Casillero * [dimensionGrilla] {}; 
		randomizarGrilla(grilla, dimensionGrilla);

		// Seleccion de tematica de palabras
		system("cls"); 
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
					inicializarPalabrasABuscar(palabrasAEncontrar, colores, palabrasTotales, dimensionGrilla);
					break;
				case 2:
					inicializarPalabrasABuscar(palabrasAEncontrar, paisesCiudades, palabrasTotales, dimensionGrilla);
					break;
				case 3:
					inicializarPalabrasABuscar(palabrasAEncontrar, computacion, palabrasTotales, dimensionGrilla);
					break;
				case 4:
					inicializarPalabrasABuscar(palabrasAEncontrar, videojuegos, palabrasTotales, dimensionGrilla);
					break;
				}
				for (int i = 0; i < static_cast<int>(palabrasAEncontrar.size()); ++i)
				{
					insertarEnGrilla(grilla, dimensionGrilla, palabrasAEncontrar.at(i), true);
				}
			}
			else
			{
				cin.clear();
				cin.ignore((std::numeric_limits<std::streamsize>::max()), '\n');
				system("cls");
			}
		} while (!inputCorrecto);

		cin.clear();
		cin.ignore((std::numeric_limits<std::streamsize>::max()), '\n');
		// Game Loop
		bool jugando = true;
		int palabrasEncontradas = 0;
		int vidasRestantes = 2;
		while (jugando)
		{
			system("cls"); 
			cout << "Palabras encontradas: " << palabrasEncontradas << "/" << palabrasTotales << endl;
			cout << "Vidas restantes: " << vidasRestantes << endl;
			mostrarGrilla(grilla, dimensionGrilla);
			if (palabrasEncontradas < palabrasTotales)
			{
				string palabraABuscar;
				do
				{
					inputCorrecto = true;
					cout << "Ingresa una palabra entre 1 y " << dimensionGrilla << " letras: ";
					getline(cin, palabraABuscar);

					// funciones para pasar a mayuscula y remover espacios
					// https://stackoverflow.com/questions/83439/remove-spaces-from-stdstring-in-c
					// https://stackoverflow.com/a/55642979
					palabraABuscar = stringToUpper(palabraABuscar);
					palabraABuscar.erase(remove(palabraABuscar.begin(), palabraABuscar.end(), ' '), palabraABuscar.end());

					if (palabraABuscar.length() < 1 || static_cast<int>(palabraABuscar.length()) >= dimensionGrilla)
					{
						cout << "La palabra no tiene la longitud correcta! Perdiste 1 vida." << endl;
						this_thread::sleep_for(1.5s);

						vidasRestantes -= 1;

						if (vidasRestantes < 0)
						{
							jugando = false;
							cout << "Te quedaste sin vidas! GAME OVER!" << endl;
							this_thread::sleep_for(2s);
						}
					}
				}
				while (!inputCorrecto && jugando);

				if (vidasRestantes >= 0)
				{
					switch (estaEnLista(palabrasAEncontrar, palabraABuscar))
					{
					case Estado::ENCONTRADO:
						if (vidasRestantes < 1)
						{
							cout << "Encontraste una palabra! Excelente! Recuperaste 1 vida." << endl;
							vidasRestantes += 1;
						}
						else
							cout << "Encontraste una palabra! Excelente!" << endl;
						
						marcarPalabra(grilla, buscarPalabra(palabrasAEncontrar, palabraABuscar));
						palabrasEncontradas += 1;
						break;
					case Estado::REPETIDO:
						cout << "Esa palabra ya la encontraste. Perdiste 1 vida." << endl;
						vidasRestantes -= 1;
						break;
					case Estado::NO_ENCONTRADO:
						cout << "Esa palabra no esta en la grilla! Perdiste 1 vida." << endl;
						vidasRestantes -= 1;
						break;
					}

					this_thread::sleep_for(1.5s);

					if (vidasRestantes < 0)
					{
						jugando = false;
						cout << "Te quedaste sin vidas! GAME OVER!" << endl;
						this_thread::sleep_for(2s);
					}
				}
			}
			else
			{
				cout << "Encontraste todas las palabras! GANASTE!!" << endl;
				jugando = false;
				this_thread::sleep_for(2s);
			}
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
			cout << "Jugar de nuevo? (s/n): ";
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

